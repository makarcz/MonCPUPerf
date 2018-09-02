namespace MonCPUAlert
{
    partial class MsgWarningTimed
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
        	this.labelMsg = new System.Windows.Forms.Label();
        	this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        	this.SuspendLayout();
        	// 
        	// labelMsg
        	// 
        	this.labelMsg.AutoSize = true;
        	this.labelMsg.Location = new System.Drawing.Point(10, 9);
        	this.labelMsg.Name = "labelMsg";
        	this.labelMsg.Size = new System.Drawing.Size(38, 13);
        	this.labelMsg.TabIndex = 0;
        	this.labelMsg.Text = "Wait...";
        	// 
        	// backgroundWorker1
        	// 
        	this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
        	this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        	// 
        	// MsgWarningTimed
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.AutoSize = true;
        	this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.ClientSize = new System.Drawing.Size(395, 93);
        	this.ControlBox = false;
        	this.Controls.Add(this.labelMsg);
        	this.MaximizeBox = false;
        	this.MaximumSize = new System.Drawing.Size(411, 480);
        	this.MinimizeBox = false;
        	this.MinimumSize = new System.Drawing.Size(411, 132);
        	this.Name = "MsgWarningTimed";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.Text = "WARNING";
        	this.TopMost = true;
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMsg;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}