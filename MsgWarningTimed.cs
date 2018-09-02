using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace MonCPUAlert
{
    public partial class MsgWarningTimed : Form
    {
        int m_nTimerInt = 3000;
        bool m_bWorkerBusy = false;
        int m_X;
        int m_Y;
        const string NL = "\r\n";

        public bool IsBusy
        {
            get { return m_bWorkerBusy; }
            set { m_bWorkerBusy = value; }
        }

        public MsgWarningTimed()
        {
            InitializeComponent();
            
            m_X = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            m_Y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            MaximumSize = new System.Drawing.Size(411, m_Y);
            Opacity = 0.0f;
            Show();
            this.SetBounds(m_X, m_Y, this.Width, this.Height);
            this.Update();
            this.Hide();
        }

        public void TimedPop(int ms, string msg)
        {
            m_nTimerInt = ms;
            if (backgroundWorker1.IsBusy == false && IsBusy == false) {
            	
            	IsBusy = true;
            	labelMsg.Text = msg;
            	m_X = Screen.PrimaryScreen.WorkingArea.Width - Width;
            	m_Y = Screen.PrimaryScreen.WorkingArea.Height - Height;
            	SetBounds(m_X, m_Y, Width, Height);            	
        	 	Show();
            	//Refresh();
                backgroundWorker1.RunWorkerAsync((object)this);
            } else {
            	// stack the messages on top
            	labelMsg.Text = msg + NL + labelMsg.Text;
            	m_X = Screen.PrimaryScreen.WorkingArea.Width - Width;
            	m_Y = Screen.PrimaryScreen.WorkingArea.Height - Height;
            	SetBounds(m_X, m_Y, Width, Height);            	
            	//Refresh();
            }
            Refresh();
        }

        /*
         * Gradually disappear the warning window.
         */
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var msgBox = (MsgWarningTimed)e.Argument;
          
            double op = 1.0f;
            msgBox.Opacity = op;
            int div = m_nTimerInt / 100;
            for (int i = 0, j = div; i < m_nTimerInt && op >= 0.01; i++, j--)
            {
                if (j == 0)
                {
                    op -= 0.01;
                    msgBox.Opacity = op;
                    j = div;
                }
                Thread.Sleep(1);
            }        
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsBusy = false;
            Opacity = 0.0f;
            Hide();
        }
    }
}
