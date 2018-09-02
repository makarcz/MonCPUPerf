using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace MonCPUAlert
{
    class CPUPerformanceTools
    {
        
        struct ProcPerfCounter
		{
			public string process_name;
			public int    process_id;
			public PerformanceCounter cpu_pc;
			public PerformanceCounter mem_pc;
		};	


        ArrayList m_Alerts = new ArrayList();
        TextBox m_LogWindow;
        float m_fCPUThreshold = 50f;
        bool m_bDisplayPopups = false;
        bool m_bDisplayHighCPUUsagePopup = true;
        bool m_bDisplayHighMemoryUsagePopup = true;
        bool m_bDisplayProcessNotRespondingPopup = true;
        ArrayList m_ProcPerfCounter = new ArrayList();
        const string PCTR_CAT_PROCESS = "Process";
        const string PCTR_PROC_CPU = "% Processor Time";
        const string PCTR_PROC_MEM = "Private Bytes";
        const uint DFTL_TOTAL_MEMPC_THRESHOLD = 75;
        const int	GET_PROCLIST_INTERVAL = 10000;
        ulong m_ulTotalPhysicalMemoryK;
        uint m_unMemTotalPcThreshold = DFTL_TOTAL_MEMPC_THRESHOLD;
        Process[] m_aProcList;
        bool m_bProcessListInUse;
        System.Windows.Forms.Timer m_TimerProcList;
        
        public bool MonitorBusy
        {
        	get { return m_bProcessListInUse; }
        }

        public float CPUThreshold
        {
            get { return m_fCPUThreshold; }
            set { m_fCPUThreshold = value; }
        }

        public bool DisplayPopups
        {
            get { return m_bDisplayPopups; }
            set { m_bDisplayPopups = value; }
        }
        
        public bool DisplayHighCPUPopup 
        {
        	get { return m_bDisplayHighCPUUsagePopup; }
        	set { m_bDisplayHighCPUUsagePopup = value; }
        }
        
        public bool DisplayHighMemoryPopup
        {
        	get { return m_bDisplayHighMemoryUsagePopup; }
        	set { m_bDisplayHighMemoryUsagePopup = value; }
        }
        
        public bool DisplayProcessNotRespondingPopup
        {
        	get { return m_bDisplayProcessNotRespondingPopup; }
        	set { m_bDisplayProcessNotRespondingPopup = value; }
        }
        
        public uint MemTotalPcThreshold
        {
        	get { return m_unMemTotalPcThreshold; }
        	set { m_unMemTotalPcThreshold = value; }
        }

        public CPUPerformanceTools()
        {
        	InitPerfTools();
        }

        public CPUPerformanceTools(TextBox logwindow)
        {
        	m_LogWindow = logwindow;
        	InitPerfTools();
        }

        public CPUPerformanceTools(TextBox logwindow, float cputhreshold, bool popups)
        {
            m_LogWindow = logwindow;
            m_fCPUThreshold = cputhreshold;
            m_bDisplayPopups = popups;
            InitPerfTools();
        }
        
        void InitPerfTools()
        {
        	m_TimerProcList = new System.Windows.Forms.Timer();
        	m_TimerProcList.Interval = GET_PROCLIST_INTERVAL;
			m_TimerProcList.Tick += GetProcessListWorker;
        	m_TimerProcList.Start();
            m_ulTotalPhysicalMemoryK = GetTotalMemoryInBytes() / 1024;
            LoadPerfCounters();        	
        }

        public void RegisterSink(IAlertsSink itfSink)
        {
            m_Alerts.Add(itfSink);
            itfSink.LogEntry("Monitoring started...", m_LogWindow);
        }

        public void UnregisterSink(IAlertsSink itfSink)
        {
            m_Alerts.Remove(itfSink);
        }
        
        public static uint GetDefltTotalMemPcThreshold()
        {
        	return DFTL_TOTAL_MEMPC_THRESHOLD;
        }
        
        public void LoadPerfCounters()
        {
        	if (m_ProcPerfCounter.Count == 0) {
        		
	            Process[] aProcList = Process.GetProcesses();
	         
	            foreach (Process p in aProcList) {
	            	ProcPerfCounter ppctr;
	            	ppctr.process_name = p.ProcessName;
	            	ppctr.process_id = p.Id;
	            	ppctr.cpu_pc = new PerformanceCounter(PCTR_CAT_PROCESS, PCTR_PROC_CPU, p.ProcessName);
	            	ppctr.mem_pc = new PerformanceCounter(PCTR_CAT_PROCESS, PCTR_PROC_MEM, p.ProcessName);
	            	m_ProcPerfCounter.Add((object)ppctr);
	            }        	
        	}
        }
        
        public int GetPerfCountersCount()
        {
        	return m_ProcPerfCounter.Count;
        }
        
        public void ClearPerfCounters()
        {
        	if (m_ProcPerfCounter.Count > 0) {
        		m_ProcPerfCounter.Clear();
        	}
        }

        float CPUUsage(Process p, ArrayList pc)
        {
            float ret = 0.0f;
            bool found = false;
            var perfCtrCpu = new PerformanceCounter(PCTR_CAT_PROCESS, PCTR_PROC_CPU, p.ProcessName);
            var perfCtrMem = new PerformanceCounter(PCTR_CAT_PROCESS, PCTR_PROC_MEM, p.ProcessName);

            try
            {
            	foreach (ProcPerfCounter pctr in pc) {
            		if (0 == string.Compare(pctr.process_name, p.ProcessName, StringComparison.Ordinal)
            		    && pctr.process_id == p.Id) {
            			
            			found = true;
            			ret = pctr.cpu_pc.NextValue();
            			break;
            		}
            	}
            	if (false == found) {
#if DEBUG
					foreach (IAlertsSink sink in m_Alerts) {
						sink.LogEntry("DEBUG: Perf. counter not found, adding process name <" + p.ProcessName + ">, ID: <" + p.Id + ">", m_LogWindow);
					}
#endif
            		ProcPerfCounter ppctr;
            		ppctr.process_name = p.ProcessName;
            		ppctr.process_id = p.Id;
            		ppctr.cpu_pc = perfCtrCpu;
            		ppctr.mem_pc = perfCtrMem;
            		pc.Add(ppctr);
            		ret = perfCtrCpu.NextValue();
            	}
            	ret = ret / Environment.ProcessorCount;
            }
#if DEBUG            
            catch (Exception e)
            {
                ret = -1.0f;
                
                foreach (IAlertsSink sink in m_Alerts) {
                	sink.LogEntry("DEBUG: Exception caused by - " + e.Message, m_LogWindow);
                	sink.LogEntry("\r\n" + e.StackTrace, m_LogWindow);
                }
            
            }
#else        
            catch (Exception)
            {
                ret = -1.0f;
            }
#endif            


            return (ret);
        }
        
        float MemoryUsage(Process p, ArrayList pc)
        {
            float ret = 0.0f;
            bool found = false;
            var perfCtrCpu = new PerformanceCounter(PCTR_CAT_PROCESS, PCTR_PROC_CPU, p.ProcessName);
            var perfCtrMem = new PerformanceCounter(PCTR_CAT_PROCESS, PCTR_PROC_MEM, p.ProcessName);

            try
            {
            	foreach (ProcPerfCounter pctr in pc) {
            		if (0 == string.Compare(pctr.process_name, p.ProcessName, StringComparison.Ordinal)
            		    && pctr.process_id == p.Id) {
            			
            			found = true;
            			ret = pctr.mem_pc.NextValue();
            			break;
            		}
            	}
            	if (false == found) {
#if DEBUG
					foreach (IAlertsSink sink in m_Alerts) {
						sink.LogEntry("DEBUG: Perf. counter not found, adding process name <" + p.ProcessName + ">, ID: <" + p.Id + ">", m_LogWindow);
					}
#endif
            		ProcPerfCounter ppctr;
            		ppctr.process_name = p.ProcessName;
            		ppctr.process_id = p.Id;
            		ppctr.cpu_pc = perfCtrCpu;
            		ppctr.mem_pc = perfCtrMem;
            		pc.Add(ppctr);
            		ret = perfCtrMem.NextValue();
            	}
            }
#if DEBUG            
            catch (Exception e)
            {
                ret = -1.0f;
                
                foreach (IAlertsSink sink in m_Alerts) {
                	sink.LogEntry("DEBUG: Exception caused by - " + e.Message, m_LogWindow);
                	sink.LogEntry("\r\n" + e.StackTrace, m_LogWindow);
                }
            
            }
#else        
            catch (Exception)
            {
                ret = -1.0f;
            }
#endif            


            return (ret);
        }        
        
        static ulong GetTotalMemoryInBytes()
		{
		    return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
		}
        
        void GetProcessListWorker(object sender, EventArgs e)
        {
        	if (!m_bProcessListInUse) {
        		m_bProcessListInUse = true;
        		m_aProcList = Process.GetProcesses();
        		m_bProcessListInUse = false;
        	}
        }

        public void MonitorEvents()
		{
        	Process[] aProcList; // = Process.GetProcesses();
			bool bErrorCPUUsage = false;
			float fTopCpuPc = 0.0f;
			float fTopMemPc = 0.0f;
			Process TopCpuProcess = null;
			Process TopMemProcess = null;
			var pc = m_ProcPerfCounter;
			ulong ulTotalMemK = m_ulTotalPhysicalMemoryK;
			ulong ulTotalMemAllProcK = 0L;
			
			if (m_bProcessListInUse) {
            	
				return;
			}
            
			m_bProcessListInUse = true;
			aProcList = m_aProcList;

			foreach (IAlertsSink sink in m_Alerts) {
				sink.LogEntry("INFO: # of CPU-s        = " + Environment.ProcessorCount, m_LogWindow);
				sink.LogEntry("INFO: Physical memory   = " + ulTotalMemK + " K", m_LogWindow);
				sink.LogEntry("INFO: # of processes    = " + aProcList.Length, m_LogWindow);                              
			}
            
			foreach (Process p in aProcList) {
				if (p.Id == 0)
					continue;
				if (false == p.Responding) {
					foreach (IAlertsSink sink in m_Alerts) {
						sink.LogEntry("WARNING: Process not responding, name: <" + p.ProcessName + ">, Id: <" + p.Id + ">.", m_LogWindow);
						if (m_bDisplayPopups && DisplayProcessNotRespondingPopup) {
							sink.ProcessNotResponding("WARNING:", p);
						}
					}
				}
            	
				float fCpuUsage = CPUUsage(p, pc);
				float fMemUsage = MemoryUsage(p, pc);
                
				ulTotalMemAllProcK += (ulong)(fMemUsage / 1024);
                
				if (fCpuUsage >= fTopCpuPc) {
					fTopCpuPc = fCpuUsage;
					TopCpuProcess = p;
				}
				if (fMemUsage >= fTopMemPc) {
					fTopMemPc = fMemUsage;
					TopMemProcess = p;
				}

				if (m_fCPUThreshold <= fCpuUsage
				                && 0 == string.Compare(p.ProcessName, TopCpuProcess.ProcessName, StringComparison.Ordinal)) {
					foreach (IAlertsSink sink in m_Alerts) {
						sink.LogEntry("WARNING: High CPU usage, name: <" + p.ProcessName + ">, Id: <" + p.Id + ">, CPU: <" + fCpuUsage.ToString() + "%>.", m_LogWindow);
						if (m_bDisplayPopups && DisplayHighCPUPopup) {
							sink.HighCPUUsage("WARNING:", (int)fCpuUsage, p);
						}
					}
				}
				bErrorCPUUsage = (0.0f > fCpuUsage);
                
				ulong ulTopMemUse = (ulong)(fTopMemPc / 1024);
                                
				if (ulTopMemUse > ulTotalMemK / 4
				                && 0 == string.Compare(p.ProcessName, TopMemProcess.ProcessName, StringComparison.Ordinal)) {	// for now it's fixed at 25%
					foreach (IAlertsSink sink in m_Alerts) {
						sink.LogEntry("WARNING: High memory process, name: <" + TopMemProcess.ProcessName + ">, Id: <" + TopMemProcess.Id + ">, memory: <" + ulTopMemUse + "K>.", m_LogWindow);
						if (m_bDisplayPopups && m_bDisplayHighMemoryUsagePopup) {
							sink.HighMemoryUsage("WARNING:", (int)ulTopMemUse, TopMemProcess);
						}
					}
				}
                
#if DEBUG                
                foreach (IAlertsSink sink in m_Alerts) {
                    sink.LogEntry("DEBUG: Process: " + p.ProcessName + ", PID: " + p.Id + ", CPU usage = " + fCpuUsage, m_LogWindow);               
                }
#endif                
			}
            
			if (ulTotalMemAllProcK > (ulTotalMemK / 100) * m_unMemTotalPcThreshold) {
            	
				// memory used by all processes crossed the threshold set in setup
				foreach (IAlertsSink sink in m_Alerts) {
					sink.LogEntry("WARNING: " + m_unMemTotalPcThreshold + "% or more memory used: " + ulTotalMemAllProcK + "K used. Physical memory: " + ulTotalMemK + "K.", m_LogWindow);
					if (m_bDisplayPopups && m_bDisplayHighMemoryUsagePopup) {
						sink.HighTotalMemoryUsage("WARNING:", (int)ulTotalMemAllProcK, (int)ulTotalMemK);
					}
				}
			}

			foreach (IAlertsSink sink in m_Alerts) {
				if (null != TopCpuProcess) {
					sink.LogEntry("INFO: Top CPU process: " + TopCpuProcess.ProcessName + ", PID: " + TopCpuProcess.Id + ", CPU usage = " + fTopCpuPc, m_LogWindow);
				}
				if (null != TopMemProcess) {
					sink.LogEntry("INFO: Top memory process: " + TopMemProcess.ProcessName + ", PID: " + TopMemProcess.Id + ", Commit size = " + (int)(fTopMemPc / 1024) + "K", m_LogWindow);
				}
				sink.LogEntry("INFO: Total memory used by processes: " + ulTotalMemAllProcK + "K.", m_LogWindow);
				sink.LogEntry("INFO: # of performance counters = " + pc.Count, m_LogWindow);
			}
			if (bErrorCPUUsage) {
				foreach (IAlertsSink sink in m_Alerts) {
					sink.LogEntry("ERROR: There were errors reading CPU usage stats.", m_LogWindow);               
				}
			}
			
			m_bProcessListInUse = false;
		}
    }
}
