using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MonCPUAlert
{
    class AlertsSink : IAlertsSink
    {
        public const string NL = "\r\n";
        bool m_DisplayAlerts = true;
        MsgWarningTimed m_MsgPop = new MsgWarningTimed();
        const int FadingTimeMs = 3500;

        public AlertsSink()
        {
        }

        public AlertsSink(bool alerts)
        {
            m_DisplayAlerts = alerts;
        }

        private void InitDisplayAlertsFlags()
        {
        }

        public void ProcessNotResponding(string msg, Process p)
        {
            string sMsg = string.Empty;

            sMsg = GetDTNow () + msg + NL + "Process is not responding:" + NL;
            sMsg = sMsg + "Name: " + p.ProcessName + NL;
            sMsg = sMsg + "Id: " + p.Id + NL;

            if (m_DisplayAlerts) {
                m_MsgPop.TimedPop(FadingTimeMs, sMsg);
            }
             
        }

        public void HighCPUUsage(string msg, int cpup, Process p)
        {
            string sMsg = string.Empty;

            sMsg = GetDTNow() + msg + NL + "CPU use above threshold:" + NL;
            sMsg = sMsg + "Name: " + p.ProcessName + NL;
            sMsg = sMsg + "Id: " + p.Id + NL;
            sMsg = sMsg + "CPU usage: " + cpup + "%" + NL;

            if (m_DisplayAlerts) {
                m_MsgPop.TimedPop(FadingTimeMs, sMsg);
            }

        }

        public void HighMemoryUsage(string msg, int memusage, Process p)
        {
            string sMsg = string.Empty;

            sMsg = GetDTNow() + msg + NL + "Process memory use above threshold:" + NL;
            sMsg = sMsg + "Name: " + p.ProcessName + NL;
            sMsg = sMsg + "Id: " + p.Id + NL;
            sMsg = sMsg + "Memory usage: " + memusage + "K" + NL;

            if (m_DisplayAlerts) {
                m_MsgPop.TimedPop(FadingTimeMs, sMsg);
            }

        }
        
        public void HighTotalMemoryUsage(string msg, int memusage, int totalmem)
        {
            string sMsg = string.Empty;

            sMsg = GetDTNow() + msg + NL + "Total memory use above threshold." + NL;
            sMsg = sMsg + "Memory used: " + memusage + "K, out of total " + totalmem + "K." + NL;

            if (m_DisplayAlerts) {
                m_MsgPop.TimedPop(FadingTimeMs, sMsg);
            }

        }        

        public void LogEntry(string msg, TextBox logwindow)
        {
            string sDate = GetDTNow();

            if (null != logwindow) {
                logwindow.AppendText(sDate + msg + NL);
            }
        }

        private string GetDTNow()
        {
            DateTime now = DateTime.Now;
            string sDate = now.Year.ToString()
                            + "/" + now.Month.ToString().PadLeft (2, '0')
                            + "/" + now.Day.ToString().PadLeft (2, '0')
                            + " " + now.Hour.ToString().PadLeft (2, '0')
                            + ":" + now.Minute.ToString().PadLeft (2, '0')
                            + ":" + now.Second.ToString().PadLeft (2, '0')
                            + " > ";

            return (sDate);
        }
    }
}
