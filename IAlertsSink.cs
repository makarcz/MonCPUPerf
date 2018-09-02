using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace MonCPUAlert
{
    interface IAlertsSink
    {
        void ProcessNotResponding(string msg, Process p);
        void HighCPUUsage(string msg, int cpup, Process p);
        void HighMemoryUsage(string msg, int memusage, Process p);
        void HighTotalMemoryUsage(string msg, int memusage, int totalmem);
        void LogEntry(string msg, TextBox logwindow);
    }
}
