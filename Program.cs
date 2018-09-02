using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MonCPUAlert
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// This little program's purpose is to monitor
        /// processes and report events to user in real time
        /// such as: high CPU usage per process, non-responding processes,
        /// high memory usage, etc.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMonCPUAlert());
        }
    }
}