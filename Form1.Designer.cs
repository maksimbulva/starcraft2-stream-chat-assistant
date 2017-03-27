namespace Sc2FarshStreamHelper
{
    partial class FormOutput
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
            this.sc2HostFetchTimer = new System.Windows.Forms.Timer(this.components);
            this.webBrowserOutput = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // sc2HostFetchTimer
            // 
            this.sc2HostFetchTimer.Enabled = true;
            this.sc2HostFetchTimer.Interval = 2000;
            this.sc2HostFetchTimer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // webBrowserOutput
            // 
            this.webBrowserOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserOutput.Location = new System.Drawing.Point(0, 0);
            this.webBrowserOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserOutput.Name = "webBrowserOutput";
            this.webBrowserOutput.ScrollBarsEnabled = false;
            this.webBrowserOutput.Size = new System.Drawing.Size(909, 171);
            this.webBrowserOutput.TabIndex = 0;
            // 
            // FormOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(909, 171);
            this.Controls.Add(this.webBrowserOutput);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FormOutput";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer sc2HostFetchTimer;
        private System.Windows.Forms.WebBrowser webBrowserOutput;
    }
}

