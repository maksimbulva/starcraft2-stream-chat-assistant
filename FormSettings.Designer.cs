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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblConnectionToSc2 = new System.Windows.Forms.Label();
            this.Sc2ClientPortSelector = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtLegalNote = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.playersList2 = new Sc2StreamChatAssistant.PlayersList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.playersList1 = new Sc2StreamChatAssistant.PlayersList();
            this.txtDuplicateNamesInfo = new System.Windows.Forms.TextBox();
            this.txtNewVersionAvailable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.numericWinsCount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericLosesCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sc2ClientPortSelector)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWinsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLosesCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblConnectionToSc2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Sc2ClientPortSelector, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnHelp, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(758, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "StarCraft 2 client connection";
            // 
            // LblConnectionToSc2
            // 
            this.LblConnectionToSc2.AutoSize = true;
            this.LblConnectionToSc2.Location = new System.Drawing.Point(177, 0);
            this.LblConnectionToSc2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblConnectionToSc2.Name = "LblConnectionToSc2";
            this.LblConnectionToSc2.Size = new System.Drawing.Size(0, 17);
            this.LblConnectionToSc2.TabIndex = 1;
            // 
            // Sc2ClientPortSelector
            // 
            this.Sc2ClientPortSelector.Location = new System.Drawing.Point(177, 36);
            this.Sc2ClientPortSelector.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Sc2ClientPortSelector.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Sc2ClientPortSelector.Name = "Sc2ClientPortSelector";
            this.Sc2ClientPortSelector.Size = new System.Drawing.Size(130, 25);
            this.Sc2ClientPortSelector.TabIndex = 3;
            this.Sc2ClientPortSelector.ValueChanged += new System.EventHandler(this.OnSc2ClientPortSelectorValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "StarCraft 2 client port";
            // 
            // btnHelp
            // 
            this.btnHelp.AutoSize = true;
            this.btnHelp.Location = new System.Drawing.Point(311, 36);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(58, 27);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.OnBtnHelpClick);
            // 
            // txtLegalNote
            // 
            this.txtLegalNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLegalNote.Location = new System.Drawing.Point(0, 680);
            this.txtLegalNote.Multiline = true;
            this.txtLegalNote.Name = "txtLegalNote";
            this.txtLegalNote.ReadOnly = true;
            this.txtLegalNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLegalNote.Size = new System.Drawing.Size(758, 87);
            this.txtLegalNote.TabIndex = 1;
            this.txtLegalNote.Text = "LEGAL";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.playersList2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.playersList1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtDuplicateNamesInfo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNewVersionAvailable, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 66);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(758, 614);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // playersList2
            // 
            this.playersList2.AutoSize = true;
            this.playersList2.Dock = System.Windows.Forms.DockStyle.Top;
            this.playersList2.Location = new System.Drawing.Point(3, 319);
            this.playersList2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playersList2.Name = "playersList2";
            this.playersList2.Size = new System.Drawing.Size(752, 189);
            this.playersList2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 298);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 14);
            this.panel1.TabIndex = 14;
            // 
            // playersList1
            // 
            this.playersList1.AutoSize = true;
            this.playersList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersList1.Location = new System.Drawing.Point(3, 102);
            this.playersList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playersList1.Name = "playersList1";
            this.playersList1.Size = new System.Drawing.Size(752, 189);
            this.playersList1.TabIndex = 1;
            // 
            // txtDuplicateNamesInfo
            // 
            this.txtDuplicateNamesInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDuplicateNamesInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDuplicateNamesInfo.Location = new System.Drawing.Point(2, 3);
            this.txtDuplicateNamesInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDuplicateNamesInfo.Multiline = true;
            this.txtDuplicateNamesInfo.Name = "txtDuplicateNamesInfo";
            this.txtDuplicateNamesInfo.ReadOnly = true;
            this.txtDuplicateNamesInfo.Size = new System.Drawing.Size(754, 92);
            this.txtDuplicateNamesInfo.TabIndex = 11;
            this.txtDuplicateNamesInfo.Text = resources.GetString("txtDuplicateNamesInfo.Text");
            // 
            // txtNewVersionAvailable
            // 
            this.txtNewVersionAvailable.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNewVersionAvailable.Location = new System.Drawing.Point(3, 515);
            this.txtNewVersionAvailable.Name = "txtNewVersionAvailable";
            this.txtNewVersionAvailable.ReadOnly = true;
            this.txtNewVersionAvailable.Size = new System.Drawing.Size(752, 25);
            this.txtNewVersionAvailable.TabIndex = 15;
            this.txtNewVersionAvailable.Text = "New version available at https://github.com/maksimbulva/starcraft2-stream-chat-as" +
    "sistant/releases";
            this.txtNewVersionAvailable.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(404, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "If something went wrong, you can manually adjust some values here";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.numericWinsCount);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.numericLosesCount);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.comboBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 566);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(752, 45);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Wins";
            // 
            // numericWinsCount
            // 
            this.numericWinsCount.Location = new System.Drawing.Point(45, 3);
            this.numericWinsCount.Name = "numericWinsCount";
            this.numericWinsCount.Size = new System.Drawing.Size(49, 25);
            this.numericWinsCount.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Loses";
            // 
            // numericLosesCount
            // 
            this.numericLosesCount.Location = new System.Drawing.Point(147, 3);
            this.numericLosesCount.Name = "numericLosesCount";
            this.numericLosesCount.Size = new System.Drawing.Size(49, 25);
            this.numericLosesCount.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Your teammate";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(304, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 25);
            this.comboBox1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 767);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.txtLegalNote);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(704, 39);
            this.Name = "FormSettings";
            this.Text = "Sc2 Stream Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sc2ClientPortSelector)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWinsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLosesCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblConnectionToSc2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Sc2ClientPortSelector;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtLegalNote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtDuplicateNamesInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private PlayersList playersList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private PlayersList playersList2;
        private System.Windows.Forms.TextBox txtNewVersionAvailable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericWinsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericLosesCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}