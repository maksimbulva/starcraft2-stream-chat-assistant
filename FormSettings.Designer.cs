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
            this.button1 = new System.Windows.Forms.Button();
            this.txtLegalNote = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.playersList2 = new Sc2StreamChatAssistant.PlayersList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.playersList1 = new Sc2StreamChatAssistant.PlayersList();
            this.txtDuplicateNamesInfo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sc2ClientPortSelector)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(688, 66);
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
            this.Sc2ClientPortSelector.Size = new System.Drawing.Size(92, 25);
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
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(273, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtLegalNote
            // 
            this.txtLegalNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLegalNote.Location = new System.Drawing.Point(0, 633);
            this.txtLegalNote.Multiline = true;
            this.txtLegalNote.Name = "txtLegalNote";
            this.txtLegalNote.ReadOnly = true;
            this.txtLegalNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLegalNote.Size = new System.Drawing.Size(753, 75);
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
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(753, 633);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // playersList2
            // 
            this.playersList2.AutoSize = true;
            this.playersList2.Dock = System.Windows.Forms.DockStyle.Top;
            this.playersList2.Location = new System.Drawing.Point(3, 287);
            this.playersList2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playersList2.Name = "playersList2";
            this.playersList2.Size = new System.Drawing.Size(747, 189);
            this.playersList2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 266);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 14);
            this.panel1.TabIndex = 14;
            // 
            // playersList1
            // 
            this.playersList1.AutoSize = true;
            this.playersList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersList1.Location = new System.Drawing.Point(3, 70);
            this.playersList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playersList1.Name = "playersList1";
            this.playersList1.Size = new System.Drawing.Size(747, 189);
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
            this.txtDuplicateNamesInfo.Size = new System.Drawing.Size(749, 60);
            this.txtDuplicateNamesInfo.TabIndex = 11;
            this.txtDuplicateNamesInfo.Text = resources.GetString("txtDuplicateNamesInfo.Text");
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
            this.ClientSize = new System.Drawing.Size(753, 708);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblConnectionToSc2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Sc2ClientPortSelector;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLegalNote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtDuplicateNamesInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private PlayersList playersList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private PlayersList playersList2;
    }
}