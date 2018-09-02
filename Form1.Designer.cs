namespace MonCPUAlert
{
    partial class FormMonCPUAlert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonCPUAlert));
        	this.timerMonitorCPU = new System.Windows.Forms.Timer(this.components);
        	this.textBoxLog = new System.Windows.Forms.TextBox();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
        	this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
        	this.toolStripTextBoxInterval = new System.Windows.Forms.ToolStripTextBox();
        	this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
        	this.toolStripTextBoxCPUThreshold = new System.Windows.Forms.ToolStripTextBox();
        	this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripDropDownButtonPopUps = new System.Windows.Forms.ToolStripDropDownButton();
        	this.displayPopupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.highCPUUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.highMemoryUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.processNotRespondingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
        	this.toolStripTextBoxMemThreshold = new System.Windows.Forms.ToolStripTextBox();
        	this.timerWatchdog = new System.Windows.Forms.Timer(this.components);
        	this.toolStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// timerMonitorCPU
        	// 
        	this.timerMonitorCPU.Enabled = true;
        	this.timerMonitorCPU.Interval = 10000;
        	this.timerMonitorCPU.Tick += new System.EventHandler(this.timerMonitorCPU_Tick);
        	// 
        	// textBoxLog
        	// 
        	this.textBoxLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.textBoxLog.Location = new System.Drawing.Point(12, 28);
        	this.textBoxLog.MaxLength = 1000000;
        	this.textBoxLog.Multiline = true;
        	this.textBoxLog.Name = "textBoxLog";
        	this.textBoxLog.ReadOnly = true;
        	this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.textBoxLog.Size = new System.Drawing.Size(953, 325);
        	this.textBoxLog.TabIndex = 3;
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripButtonPause,
			this.toolStripSeparator1,
			this.toolStripButtonStop,
			this.toolStripSeparator2,
			this.toolStripProgressBar1,
			this.toolStripSeparator3,
			this.toolStripLabel2,
			this.toolStripTextBoxInterval,
			this.toolStripSeparator4,
			this.toolStripLabel3,
			this.toolStripTextBoxCPUThreshold,
			this.toolStripSeparator5,
			this.toolStripDropDownButtonPopUps,
			this.toolStripSeparator6,
			this.toolStripButtonAbout,
			this.toolStripSeparator7,
			this.toolStripLabel1,
			this.toolStripLabel4,
			this.toolStripTextBoxMemThreshold});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(977, 25);
        	this.toolStrip1.TabIndex = 4;
        	this.toolStrip1.Text = "toolStrip1";
        	this.toolStrip1.Click += new System.EventHandler(this.toolStrip1_Click);
        	// 
        	// toolStripButtonPause
        	// 
        	this.toolStripButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.toolStripButtonPause.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.toolStripButtonPause.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPause.Image")));
        	this.toolStripButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonPause.Name = "toolStripButtonPause";
        	this.toolStripButtonPause.Size = new System.Drawing.Size(67, 22);
        	this.toolStripButtonPause.Text = "|| Pause";
        	this.toolStripButtonPause.Click += new System.EventHandler(this.toolStripButtonPause_Click);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripButtonStop
        	// 
        	this.toolStripButtonStop.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
        	this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonStop.Name = "toolStripButtonStop";
        	this.toolStripButtonStop.Size = new System.Drawing.Size(55, 22);
        	this.toolStripButtonStop.Text = "Stop";
        	this.toolStripButtonStop.ToolTipText = "Stop";
        	this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripProgressBar1
        	// 
        	this.toolStripProgressBar1.Name = "toolStripProgressBar1";
        	this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
        	this.toolStripProgressBar1.Step = 1;
        	// 
        	// toolStripSeparator3
        	// 
        	this.toolStripSeparator3.Name = "toolStripSeparator3";
        	this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripLabel2
        	// 
        	this.toolStripLabel2.Name = "toolStripLabel2";
        	this.toolStripLabel2.Size = new System.Drawing.Size(77, 22);
        	this.toolStripLabel2.Text = "Interval [sec]:";
        	// 
        	// toolStripTextBoxInterval
        	// 
        	this.toolStripTextBoxInterval.MaxLength = 3;
        	this.toolStripTextBoxInterval.Name = "toolStripTextBoxInterval";
        	this.toolStripTextBoxInterval.Size = new System.Drawing.Size(30, 25);
        	this.toolStripTextBoxInterval.Text = "30";
        	this.toolStripTextBoxInterval.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.toolStripTextBoxInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxInterval_KeyDown);
        	this.toolStripTextBoxInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxInterval_KeyPress);
        	this.toolStripTextBoxInterval.TextChanged += new System.EventHandler(this.toolStripTextBoxInterval_TextChanged);
        	// 
        	// toolStripSeparator4
        	// 
        	this.toolStripSeparator4.Name = "toolStripSeparator4";
        	this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripLabel3
        	// 
        	this.toolStripLabel3.Name = "toolStripLabel3";
        	this.toolStripLabel3.Size = new System.Drawing.Size(96, 22);
        	this.toolStripLabel3.Text = "CPU% threshold:";
        	// 
        	// toolStripTextBoxCPUThreshold
        	// 
        	this.toolStripTextBoxCPUThreshold.MaxLength = 2;
        	this.toolStripTextBoxCPUThreshold.Name = "toolStripTextBoxCPUThreshold";
        	this.toolStripTextBoxCPUThreshold.Size = new System.Drawing.Size(30, 25);
        	this.toolStripTextBoxCPUThreshold.Text = "20";
        	this.toolStripTextBoxCPUThreshold.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.toolStripTextBoxCPUThreshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxCPUThreshold_KeyDown);
        	this.toolStripTextBoxCPUThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxCPUThreshold_KeyPress);
        	this.toolStripTextBoxCPUThreshold.TextChanged += new System.EventHandler(this.toolStripTextBoxCPUThreshold_TextChanged);
        	// 
        	// toolStripSeparator5
        	// 
        	this.toolStripSeparator5.Name = "toolStripSeparator5";
        	this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripDropDownButtonPopUps
        	// 
        	this.toolStripDropDownButtonPopUps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.toolStripDropDownButtonPopUps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.displayPopupsToolStripMenuItem,
			this.highCPUUseToolStripMenuItem,
			this.highMemoryUseToolStripMenuItem,
			this.processNotRespondingToolStripMenuItem});
        	this.toolStripDropDownButtonPopUps.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripDropDownButtonPopUps.Name = "toolStripDropDownButtonPopUps";
        	this.toolStripDropDownButtonPopUps.Size = new System.Drawing.Size(117, 22);
        	this.toolStripDropDownButtonPopUps.Text = "Pop-up messages:";
        	// 
        	// displayPopupsToolStripMenuItem
        	// 
        	this.displayPopupsToolStripMenuItem.CheckOnClick = true;
        	this.displayPopupsToolStripMenuItem.Name = "displayPopupsToolStripMenuItem";
        	this.displayPopupsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
        	this.displayPopupsToolStripMenuItem.Text = "Display pop-ups";
        	this.displayPopupsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.displayPopupsToolStripMenuItem_CheckedChanged);
        	// 
        	// highCPUUseToolStripMenuItem
        	// 
        	this.highCPUUseToolStripMenuItem.Checked = true;
        	this.highCPUUseToolStripMenuItem.CheckOnClick = true;
        	this.highCPUUseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.highCPUUseToolStripMenuItem.Name = "highCPUUseToolStripMenuItem";
        	this.highCPUUseToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
        	this.highCPUUseToolStripMenuItem.Text = "High CPU use";
        	this.highCPUUseToolStripMenuItem.CheckedChanged += new System.EventHandler(this.HighCPUUseToolStripMenuItemCheckedChanged);
        	// 
        	// highMemoryUseToolStripMenuItem
        	// 
        	this.highMemoryUseToolStripMenuItem.Checked = true;
        	this.highMemoryUseToolStripMenuItem.CheckOnClick = true;
        	this.highMemoryUseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.highMemoryUseToolStripMenuItem.Name = "highMemoryUseToolStripMenuItem";
        	this.highMemoryUseToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
        	this.highMemoryUseToolStripMenuItem.Text = "High memory use";
        	this.highMemoryUseToolStripMenuItem.CheckedChanged += new System.EventHandler(this.HighMemoryUseToolStripMenuItemCheckedChanged);
        	// 
        	// processNotRespondingToolStripMenuItem
        	// 
        	this.processNotRespondingToolStripMenuItem.Checked = true;
        	this.processNotRespondingToolStripMenuItem.CheckOnClick = true;
        	this.processNotRespondingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.processNotRespondingToolStripMenuItem.Name = "processNotRespondingToolStripMenuItem";
        	this.processNotRespondingToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
        	this.processNotRespondingToolStripMenuItem.Text = "Process not responding";
        	this.processNotRespondingToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ProcessNotRespondingToolStripMenuItemCheckedChanged);
        	// 
        	// toolStripSeparator6
        	// 
        	this.toolStripSeparator6.Name = "toolStripSeparator6";
        	this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripButtonAbout
        	// 
        	this.toolStripButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
        	this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonAbout.Name = "toolStripButtonAbout";
        	this.toolStripButtonAbout.Size = new System.Drawing.Size(95, 22);
        	this.toolStripButtonAbout.Text = "About MonCPU";
        	this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
        	// 
        	// toolStripSeparator7
        	// 
        	this.toolStripSeparator7.Name = "toolStripSeparator7";
        	this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripLabel1
        	// 
        	this.toolStripLabel1.Name = "toolStripLabel1";
        	this.toolStripLabel1.Size = new System.Drawing.Size(228, 22);
        	this.toolStripLabel1.Text = "Monitoring for CPU performance events...";
        	// 
        	// toolStripLabel4
        	// 
        	this.toolStripLabel4.Enabled = false;
        	this.toolStripLabel4.Name = "toolStripLabel4";
        	this.toolStripLabel4.Size = new System.Drawing.Size(101, 15);
        	this.toolStripLabel4.Text = "Mem% threshold:";
        	this.toolStripLabel4.ToolTipText = "1-99% memory use warning threshold";
        	// 
        	// toolStripTextBoxMemThreshold
        	// 
        	this.toolStripTextBoxMemThreshold.MaxLength = 2;
        	this.toolStripTextBoxMemThreshold.Name = "toolStripTextBoxMemThreshold";
        	this.toolStripTextBoxMemThreshold.Size = new System.Drawing.Size(100, 23);
        	this.toolStripTextBoxMemThreshold.Text = "75";
        	this.toolStripTextBoxMemThreshold.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.toolStripTextBoxMemThreshold.ToolTipText = "1-99% memory use warning threshold";
        	this.toolStripTextBoxMemThreshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStripTextBoxMemThresholdKeyDown);
        	this.toolStripTextBoxMemThreshold.TextChanged += new System.EventHandler(this.ToolStripTextBox1TextChanged);
        	// 
        	// timerWatchdog
        	// 
        	this.timerWatchdog.Enabled = true;
        	this.timerWatchdog.Interval = 1800000;
        	this.timerWatchdog.Tick += new System.EventHandler(this.timerWatchdog_Tick);
        	// 
        	// FormMonCPUAlert
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(977, 365);
        	this.Controls.Add(this.toolStrip1);
        	this.Controls.Add(this.textBoxLog);
        	this.Name = "FormMonCPUAlert";
        	this.Text = "Monitor CPU with alerts";
        	this.Resize += new System.EventHandler(this.FormMonCPUAlert_Resize);
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerMonitorCPU;
        //private System.Windows.Forms.Timer timerWatchdog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPause;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxInterval;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCPUThreshold;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonPopUps;
        private System.Windows.Forms.ToolStripMenuItem displayPopupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Timer timerWatchdog;
        private System.Windows.Forms.ToolStripMenuItem highCPUUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highMemoryUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processNotRespondingToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMemThreshold;
    }
}

