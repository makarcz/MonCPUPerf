using System;
using System.Windows.Forms;
using System.Threading;

namespace MonCPUAlert
{
    public partial class FormMonCPUAlert : Form
    {
    	//ArrayList m_ProcCpuPerfCounter = new ArrayList();
        readonly CPUPerformanceTools m_MonitoringTools = new CPUPerformanceTools();
        IAlertsSink m_AlertsSink = new AlertsSink();
        int m_nLogSizeHeightOffset;
        int m_nLogSizeWidthOffset;
        const string NL = "\r\n";

        public FormMonCPUAlert()
        {
            InitializeComponent();
            float fCPUThreshold = Convert.ToSingle(toolStripTextBoxCPUThreshold.Text);
            int nTimerInterval = Convert.ToInt32(toolStripTextBoxInterval.Text) * 1000;
            bool bDisplayPopUpMessages = displayPopupsToolStripMenuItem.Checked;
            m_MonitoringTools = new CPUPerformanceTools(textBoxLog, fCPUThreshold, bDisplayPopUpMessages);
            m_MonitoringTools.RegisterSink(m_AlertsSink);
            timerMonitorCPU.Interval = nTimerInterval;
            timerMonitorCPU.Start();
            timerWatchdog.Start();
            m_nLogSizeHeightOffset = this.Height - textBoxLog.Height;
            m_nLogSizeWidthOffset = this.Width - textBoxLog.Width;
        }

        string[] Tail(string[] a, int count)
        {
            int size = (a.Length > count) ? count : a.Length;
            var ret = new string[size];
            int n = a.Length - count - 1;

            if (0 > n)
                n = 0;

            for (int i=0;i < size; n++,i++)
            {
                ret[i] = a[n];
            }

            return (ret);
        }

        void CleanLogWindowText()
        {
            var asSep = new string [1];

            asSep[0] = "\n";
            timerMonitorCPU.Stop();
            string[] asLines = textBoxLog.Text.Split(asSep, StringSplitOptions.RemoveEmptyEntries);
            string[] asTail = Tail(asLines, 75);
            textBoxLog.Clear();

            foreach (string s in asTail)
            {
                textBoxLog.AppendText(s + AlertsSink.NL);
            }
            textBoxLog.AppendText("------------------ LOG COMPRESSED ------------------" + AlertsSink.NL);
            timerMonitorCPU.Start();
        }

        void timerMonitorCPU_Tick(object sender, EventArgs e)
        {
        	if (m_MonitoringTools.MonitorBusy) {
        		
        		return;
        	}
        	// run the monitor in a thread to make GUI more responsive
        	new Thread(() =>
        	{
        		Thread.CurrentThread.IsBackground = true;
            	m_MonitoringTools.MonitorEvents();
            	toolStripProgressBar1.PerformStep();
            	if (toolStripProgressBar1.Value >= toolStripProgressBar1.Maximum)
                	toolStripProgressBar1.Value = 0;
	            if (textBoxLog.Text.Length >= textBoxLog.MaxLength - 100) {
	                CleanLogWindowText();
            	}
			}).Start();
        }
        
        void timerWatchdog_Tick(object sender, EventArgs e)
        {
        	// When the number of performance counter reaches 1000, reload performance counters based
        	// on current process list to get rid of performance counters of non-existing processes.
        	if (m_MonitoringTools.GetPerfCountersCount() >= 1000) {
        		timerMonitorCPU.Stop();
        		m_MonitoringTools.ClearPerfCounters();
        		m_MonitoringTools.LoadPerfCounters();
        		timerMonitorCPU.Start();
        	}
        } 
 
        void toolStrip1_Click(object sender, EventArgs e)
        {
            // EMPTY
        }

        void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            timerMonitorCPU.Stop();
            timerMonitorCPU.Dispose();
            m_MonitoringTools.UnregisterSink(m_AlertsSink);
            this.Close();
        }

        void FormMonCPUAlert_Resize(object sender, EventArgs e)
        {
            textBoxLog.Height = this.Height - m_nLogSizeHeightOffset;
            textBoxLog.Width = this.Width - m_nLogSizeWidthOffset;
        }

        bool IsNumber(string s)
        {
            char[] acStr = s.ToCharArray();
            bool ret = true;

            foreach (char ch in acStr)
            {
				if (!Char.IsDigit(ch)) {
					ret = false;
				}
            }

            return (ret);
        }

        void toolStripTextBoxInterval_TextChanged(object sender, EventArgs e)
        {
            if (0 < toolStripTextBoxInterval.Text.Length
                && IsNumber (toolStripTextBoxInterval.Text))
            {
                int nTimerInterval = Convert.ToInt32(toolStripTextBoxInterval.Text) * 1000;
                if (0 < nTimerInterval)
                {
                    timerMonitorCPU.Stop();
                    timerMonitorCPU.Interval = nTimerInterval;
                    timerMonitorCPU.Start();
                }
            }
        }

        void toolStripTextBoxCPUThreshold_TextChanged(object sender, EventArgs e)
        {
            if (0 < toolStripTextBoxCPUThreshold.Text.Length
                && IsNumber(toolStripTextBoxCPUThreshold.Text))
            {
                float fCPUThreshold = Convert.ToSingle(toolStripTextBoxCPUThreshold.Text);
                if (0f < fCPUThreshold)
                    m_MonitoringTools.CPUThreshold = fCPUThreshold;
            }
        }

        void displayPopupsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            timerMonitorCPU.Stop();
            m_MonitoringTools.DisplayPopups = displayPopupsToolStripMenuItem.Checked;
            timerMonitorCPU.Start();
        }

        void toolStripButtonPause_Click(object sender, EventArgs e)
        {
            if (0 == string.Compare(toolStripButtonPause.Text, "|| Pause", StringComparison.Ordinal))
            {
                timerMonitorCPU.Stop();
                toolStripButtonPause.Text = "Start";
                //this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPause.Image")));
                toolStripButtonPause.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                toolStripLabel1.Text = "Monitoring paused...";
            }
            else
            {
                timerMonitorCPU.Start();
                toolStripButtonPause.DisplayStyle = ToolStripItemDisplayStyle.Text;
                toolStripButtonPause.Text = "|| Pause";
                toolStripLabel1.Text = "Monitoring for CPU performance events...";
            }
        }

        void toolStripTextBoxInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EMPTY
        }

        void toolStripTextBoxCPUThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EMPTY
        }

        void toolStripTextBoxInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (false == System.Char.IsDigit((char)e.KeyValue)
                && 0 != e.KeyValue.CompareTo((int)Keys.Back)
                && 0 != e.KeyValue.CompareTo((int)Keys.Left)
                && 0 != e.KeyValue.CompareTo((int)Keys.Right)
                && 0 != e.KeyValue.CompareTo((int)Keys.Delete)) {
        		
                e.SuppressKeyPress = true;
            }
        }

        void toolStripTextBoxCPUThreshold_KeyDown(object sender, KeyEventArgs e)
        {
            if (false == System.Char.IsDigit((char)e.KeyValue)
        	    && 0 != e.KeyValue.CompareTo((int)Keys.Back)
        	    && 0 != e.KeyValue.CompareTo((int)Keys.Left)
        	    && 0 != e.KeyValue.CompareTo((int)Keys.Right)
				&& 0 != e.KeyValue.CompareTo((int)Keys.Delete)) {
        		
                e.SuppressKeyPress = true;
            }
        }

        void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            string sVer = Application.ProductVersion;
            string sCompany = Application.CompanyName;
            string sProd = Application.ProductName;
            string sMsg = sProd + " " + sVer+ " (C) 2009, 2018 by " + sCompany + "." + NL
            				+ "All rights reserved." + NL + NL
                          	+ "Warning messages for processes, CPU and memory." + NL
                          	+ "Logging of CPU, memory and processes" + NL
							+ "performance information and warnings." + NL
                          	+ "Run as Administrator." + NL
                          	+ "Contact: makarcz@yahoo.com";

            MessageBox.Show (sMsg, "About...", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        
		void HighCPUUseToolStripMenuItemCheckedChanged(object sender, EventArgs e)
		{
			m_MonitoringTools.DisplayHighCPUPopup = highCPUUseToolStripMenuItem.Checked;
		}
		
		void HighMemoryUseToolStripMenuItemCheckedChanged(object sender, EventArgs e)
		{
			m_MonitoringTools.DisplayHighMemoryPopup = highMemoryUseToolStripMenuItem.Checked;
		}
		
		void ProcessNotRespondingToolStripMenuItemCheckedChanged(object sender, EventArgs e)
		{
			m_MonitoringTools.DisplayProcessNotRespondingPopup = processNotRespondingToolStripMenuItem.Checked;
		}
		
		// Memory% threshold changed.
		void ToolStripTextBox1TextChanged(object sender, EventArgs e)
		{
            if (0 < toolStripTextBoxMemThreshold.Text.Length
                && IsNumber(toolStripTextBoxMemThreshold.Text))
            {
                uint unMemThreshold = Convert.ToUInt16(toolStripTextBoxMemThreshold.Text);
                if (0 < unMemThreshold && 100 > unMemThreshold)
                    m_MonitoringTools.MemTotalPcThreshold = unMemThreshold;
                else {
                	toolStripTextBoxMemThreshold.Text = CPUPerformanceTools.GetDefltTotalMemPcThreshold().ToString();
                }
            }	
		}
		
		void ToolStripTextBoxMemThresholdKeyDown(object sender, KeyEventArgs e)
		{
			if (!Char.IsDigit((char)e.KeyValue)
                && 0 != e.KeyValue.CompareTo((int)Keys.Back)
                && 0 != e.KeyValue.CompareTo((int)Keys.Left)
                && 0 != e.KeyValue.CompareTo((int)Keys.Right)
                && 0 != e.KeyValue.CompareTo((int)Keys.Delete)) {
				
                e.SuppressKeyPress = true;
            }

		}
		
    }
}