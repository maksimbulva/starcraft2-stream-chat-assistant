namespace Sc2StreamChatAssistant
{
    partial class FormSettings
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblPlayersInDatabase = new System.Windows.Forms.Label();
            this.lblLaddersDiscovered = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPlayersInDatabase
            // 
            this.lblPlayersInDatabase.AutoSize = true;
            this.lblPlayersInDatabase.Location = new System.Drawing.Point(0, 0);
            this.lblPlayersInDatabase.Name = "lblPlayersInDatabase";
            this.lblPlayersInDatabase.Size = new System.Drawing.Size(0, 13);
            this.lblPlayersInDatabase.TabIndex = 1;
            // 
            // lblLaddersDiscovered
            // 
            this.lblLaddersDiscovered.AutoSize = true;
            this.lblLaddersDiscovered.Location = new System.Drawing.Point(81, 24);
            this.lblLaddersDiscovered.Name = "lblLaddersDiscovered";
            this.lblLaddersDiscovered.Size = new System.Drawing.Size(0, 13);
            this.lblLaddersDiscovered.TabIndex = 2;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblLaddersDiscovered);
            this.Controls.Add(this.lblPlayersInDatabase);
            this.Controls.Add(this.button1);
            this.Name = "FormSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPlayersInDatabase;
        private System.Windows.Forms.Label lblLaddersDiscovered;
    }
}