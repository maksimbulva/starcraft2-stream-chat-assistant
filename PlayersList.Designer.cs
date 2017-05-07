namespace Sc2StreamChatAssistant
{
    partial class PlayersList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.txtPlayerUrl = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.listOfPlayers = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMoveToTop = new System.Windows.Forms.Button();
            this.btnMoveToBottom = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(603, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.44444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.55556F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddPlayer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPlayerUrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listOfPlayers, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(603, 195);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(476, 33);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(124, 23);
            this.btnAddPlayer.TabIndex = 1;
            this.btnAddPlayer.Text = "Add";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.OnAddPlayerClick);
            // 
            // txtPlayerUrl
            // 
            this.txtPlayerUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlayerUrl.Location = new System.Drawing.Point(3, 33);
            this.txtPlayerUrl.Name = "txtPlayerUrl";
            this.txtPlayerUrl.Size = new System.Drawing.Size(467, 20);
            this.txtPlayerUrl.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(469, 26);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter link to a character on battle.net. For example:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(2, 13);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(274, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://eu.battle.net/sc2/ru/profile/5957073/1/MxFarsh/";
            // 
            // listOfPlayers
            // 
            this.listOfPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOfPlayers.FormattingEnabled = true;
            this.listOfPlayers.Location = new System.Drawing.Point(2, 61);
            this.listOfPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.listOfPlayers.Name = "listOfPlayers";
            this.listOfPlayers.Size = new System.Drawing.Size(469, 132);
            this.listOfPlayers.TabIndex = 5;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.btnMoveToTop);
            this.flowLayoutPanel3.Controls.Add(this.btnMoveToBottom);
            this.flowLayoutPanel3.Controls.Add(this.btnRemove);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(475, 61);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(126, 132);
            this.flowLayoutPanel3.TabIndex = 6;
            // 
            // btnMoveToTop
            // 
            this.btnMoveToTop.AutoSize = true;
            this.btnMoveToTop.Location = new System.Drawing.Point(2, 2);
            this.btnMoveToTop.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoveToTop.Name = "btnMoveToTop";
            this.btnMoveToTop.Size = new System.Drawing.Size(124, 23);
            this.btnMoveToTop.TabIndex = 0;
            this.btnMoveToTop.Text = "Move to top";
            this.btnMoveToTop.UseVisualStyleBackColor = true;
            this.btnMoveToTop.Click += new System.EventHandler(this.OnMoveToTopClick);
            // 
            // btnMoveToBottom
            // 
            this.btnMoveToBottom.AutoSize = true;
            this.btnMoveToBottom.Location = new System.Drawing.Point(2, 29);
            this.btnMoveToBottom.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoveToBottom.Name = "btnMoveToBottom";
            this.btnMoveToBottom.Size = new System.Drawing.Size(124, 23);
            this.btnMoveToBottom.TabIndex = 1;
            this.btnMoveToBottom.Text = "Move to bottom";
            this.btnMoveToBottom.UseVisualStyleBackColor = true;
            this.btnMoveToBottom.Click += new System.EventHandler(this.OnMoveToBottomClick);
            // 
            // btnRemove
            // 
            this.btnRemove.AutoSize = true;
            this.btnRemove.Location = new System.Drawing.Point(2, 56);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(124, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.OnRemoveClick);
            // 
            // PlayersList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PlayersList";
            this.Size = new System.Drawing.Size(603, 195);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.TextBox txtPlayerUrl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox listOfPlayers;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnMoveToTop;
        private System.Windows.Forms.Button btnMoveToBottom;
        private System.Windows.Forms.Button btnRemove;
    }
}
