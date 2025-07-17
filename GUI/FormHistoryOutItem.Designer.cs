namespace GUI
{
    partial class FormHistoryOutItem
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpDateOutItem = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDispatcherName = new System.Windows.Forms.TextBox();
            this.txtRecipientName = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHistoryItemOut = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryItemOut)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(222, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(755, 70);
            this.panel5.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 49);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lịch sử xuất hàng";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewDetail.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetail.Location = new System.Drawing.Point(553, 18);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(193, 60);
            this.btnViewDetail.TabIndex = 3;
            this.btnViewDetail.Text = "Xem chi tiết";
            this.btnViewDetail.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpDateOutItem);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtDispatcherName);
            this.panel2.Controls.Add(this.txtRecipientName);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.txtItemName);
            this.panel2.Controls.Add(this.txtItemID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 653);
            this.panel2.TabIndex = 4;
            // 
            // dtpDateOutItem
            // 
            this.dtpDateOutItem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOutItem.Location = new System.Drawing.Point(9, 413);
            this.dtpDateOutItem.Name = "dtpDateOutItem";
            this.dtpDateOutItem.Size = new System.Drawing.Size(200, 22);
            this.dtpDateOutItem.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 394);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Ngày xuất";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tên người xuất";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tên người nhận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tên hàng hóa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã hàng hóa";
            // 
            // txtDispatcherName
            // 
            this.txtDispatcherName.Location = new System.Drawing.Point(9, 330);
            this.txtDispatcherName.Multiline = true;
            this.txtDispatcherName.Name = "txtDispatcherName";
            this.txtDispatcherName.Size = new System.Drawing.Size(202, 30);
            this.txtDispatcherName.TabIndex = 8;
            this.txtDispatcherName.Enter += new System.EventHandler(this.txtDispatcherName_Enter);
            this.txtDispatcherName.Leave += new System.EventHandler(this.txtDispatcherName_Leave);
            // 
            // txtRecipientName
            // 
            this.txtRecipientName.Location = new System.Drawing.Point(9, 253);
            this.txtRecipientName.Multiline = true;
            this.txtRecipientName.Name = "txtRecipientName";
            this.txtRecipientName.Size = new System.Drawing.Size(202, 30);
            this.txtRecipientName.TabIndex = 8;
            this.txtRecipientName.Enter += new System.EventHandler(this.txtRecipientName_Enter);
            this.txtRecipientName.Leave += new System.EventHandler(this.txtRecipientName_Leave);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(11, 571);
            this.btnFind.Margin = new System.Windows.Forms.Padding(0);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(200, 70);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = false;
            // 
            // txtItemName
            // 
            this.txtItemName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtItemName.Location = new System.Drawing.Point(9, 182);
            this.txtItemName.Multiline = true;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(202, 30);
            this.txtItemName.TabIndex = 4;
            this.txtItemName.Enter += new System.EventHandler(this.txtItemName_Enter);
            this.txtItemName.Leave += new System.EventHandler(this.txtItemName_Leave);
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(9, 110);
            this.txtItemID.Multiline = true;
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(202, 30);
            this.txtItemID.TabIndex = 5;
            this.txtItemID.Enter += new System.EventHandler(this.txtItemID_Enter);
            this.txtItemID.Leave += new System.EventHandler(this.txtItemID_Leave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Lime;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 70);
            this.label2.TabIndex = 3;
            this.label2.Tag = "";
            this.label2.Text = "Tìm Kiếm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvHistoryItemOut
            // 
            this.dgvHistoryItemOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryItemOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistoryItemOut.Location = new System.Drawing.Point(0, 0);
            this.dgvHistoryItemOut.Margin = new System.Windows.Forms.Padding(20);
            this.dgvHistoryItemOut.Name = "dgvHistoryItemOut";
            this.dgvHistoryItemOut.RowHeadersWidth = 51;
            this.dgvHistoryItemOut.RowTemplate.Height = 24;
            this.dgvHistoryItemOut.Size = new System.Drawing.Size(977, 653);
            this.dgvHistoryItemOut.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnViewDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(222, 553);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 100);
            this.panel1.TabIndex = 7;
            // 
            // FormHistoryOutItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 653);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvHistoryItemOut);
            this.Name = "FormHistoryOutItem";
            this.Text = "Lịch sử xuất hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormHistoryItemOut_Load);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryItemOut)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvHistoryItemOut;
        private System.Windows.Forms.TextBox txtRecipientName;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDispatcherName;
        private System.Windows.Forms.DateTimePicker dtpDateOutItem;
    }
}