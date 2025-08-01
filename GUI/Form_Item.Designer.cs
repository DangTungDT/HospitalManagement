namespace GUI
{
    partial class Form_Item
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
            this.radInActive = new System.Windows.Forms.RadioButton();
            this.radActive = new System.Windows.Forms.RadioButton();
            this.dtp_CreatedAt = new System.Windows.Forms.DateTimePicker();
            this.cboTypeItem = new System.Windows.Forms.ComboBox();
            this.dgv_items = new System.Windows.Forms.DataGridView();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtNameItem = new System.Windows.Forms.TextBox();
            this.txtIdItem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_items)).BeginInit();
            this.SuspendLayout();
            // 
            // radInActive
            // 
            this.radInActive.AutoSize = true;
            this.radInActive.Location = new System.Drawing.Point(762, 228);
            this.radInActive.Name = "radInActive";
            this.radInActive.Size = new System.Drawing.Size(90, 17);
            this.radInActive.TabIndex = 70;
            this.radInActive.TabStop = true;
            this.radInActive.Text = "chưa sử dụng";
            this.radInActive.UseVisualStyleBackColor = true;
            // 
            // radActive
            // 
            this.radActive.AutoSize = true;
            this.radActive.Location = new System.Drawing.Point(657, 228);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(91, 17);
            this.radActive.TabIndex = 69;
            this.radActive.TabStop = true;
            this.radActive.Text = "được sử dụng";
            this.radActive.UseVisualStyleBackColor = true;
            // 
            // dtp_CreatedAt
            // 
            this.dtp_CreatedAt.Location = new System.Drawing.Point(657, 191);
            this.dtp_CreatedAt.Name = "dtp_CreatedAt";
            this.dtp_CreatedAt.Size = new System.Drawing.Size(211, 20);
            this.dtp_CreatedAt.TabIndex = 68;
            // 
            // cboTypeItem
            // 
            this.cboTypeItem.FormattingEnabled = true;
            this.cboTypeItem.Location = new System.Drawing.Point(234, 206);
            this.cboTypeItem.Name = "cboTypeItem";
            this.cboTypeItem.Size = new System.Drawing.Size(211, 21);
            this.cboTypeItem.TabIndex = 67;
            // 
            // dgv_items
            // 
            this.dgv_items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_items.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_items.Location = new System.Drawing.Point(0, 362);
            this.dgv_items.Name = "dgv_items";
            this.dgv_items.Size = new System.Drawing.Size(1190, 387);
            this.dgv_items.TabIndex = 66;
            this.dgv_items.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_items_CellClick);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(823, 287);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_thoat.TabIndex = 61;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Location = new System.Drawing.Point(671, 287);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(75, 23);
            this.btn_lammoi.TabIndex = 62;
            this.btn_lammoi.Text = "Làm mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(506, 287);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 23);
            this.btn_sua.TabIndex = 63;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(370, 287);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa.TabIndex = 64;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(209, 287);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 65;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(657, 141);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(211, 20);
            this.txtPrice.TabIndex = 57;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(234, 233);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(211, 20);
            this.txtUnit.TabIndex = 58;
            // 
            // txtNameItem
            // 
            this.txtNameItem.Location = new System.Drawing.Point(234, 171);
            this.txtNameItem.Name = "txtNameItem";
            this.txtNameItem.Size = new System.Drawing.Size(211, 20);
            this.txtNameItem.TabIndex = 59;
            // 
            // txtIdItem
            // 
            this.txtIdItem.Location = new System.Drawing.Point(234, 136);
            this.txtIdItem.Name = "txtIdItem";
            this.txtIdItem.Size = new System.Drawing.Size(211, 20);
            this.txtIdItem.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(584, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Trạng thái:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(584, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Ngày thêm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(584, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Giá:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "ID vật tư:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Đơn vị:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Loại vật tư:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Tên vật tư:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(350, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(476, 54);
            this.label16.TabIndex = 49;
            this.label16.Text = "THÔNG TIN VẬT TƯ";
            // 
            // Form_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 749);
            this.Controls.Add(this.radInActive);
            this.Controls.Add(this.radActive);
            this.Controls.Add(this.dtp_CreatedAt);
            this.Controls.Add(this.cboTypeItem);
            this.Controls.Add(this.dgv_items);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtNameItem);
            this.Controls.Add(this.txtIdItem);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Name = "Form_Item";
            this.Text = "Form_Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Item_FormClosing);
            this.Load += new System.EventHandler(this.Form_Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radInActive;
        private System.Windows.Forms.RadioButton radActive;
        private System.Windows.Forms.DateTimePicker dtp_CreatedAt;
        private System.Windows.Forms.ComboBox cboTypeItem;
        private System.Windows.Forms.DataGridView dgv_items;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtNameItem;
        private System.Windows.Forms.TextBox txtIdItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
    }
}