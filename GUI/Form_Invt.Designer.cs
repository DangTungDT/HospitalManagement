namespace GUI
{
    partial class Form_Invt
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
            this.label5 = new System.Windows.Forms.Label();
            this.txt_iditem = new System.Windows.Forms.TextBox();
            this.txt_nameitem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvitem = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpLastUpdate = new System.Windows.Forms.DateTimePicker();
            this.dgv_khovattu = new System.Windows.Forms.DataGridView();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_khovattu)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Tên vật phẩm:";
            // 
            // txt_iditem
            // 
            this.txt_iditem.Enabled = false;
            this.txt_iditem.Location = new System.Drawing.Point(263, 128);
            this.txt_iditem.Name = "txt_iditem";
            this.txt_iditem.Size = new System.Drawing.Size(211, 20);
            this.txt_iditem.TabIndex = 63;
            // 
            // txt_nameitem
            // 
            this.txt_nameitem.Location = new System.Drawing.Point(263, 154);
            this.txt_nameitem.Name = "txt_nameitem";
            this.txt_nameitem.Size = new System.Drawing.Size(211, 20);
            this.txt_nameitem.TabIndex = 64;
            this.txt_nameitem.TextChanged += new System.EventHandler(this.txt_nameitem_TextChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh sách sản phẩm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 431);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 44);
            this.panel3.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 100);
            this.panel2.TabIndex = 49;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.dgvitem);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(919, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 475);
            this.panel1.TabIndex = 62;
            // 
            // dgvitem
            // 
            this.dgvitem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvitem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvitem.Location = new System.Drawing.Point(0, 100);
            this.dgvitem.Name = "dgvitem";
            this.dgvitem.Size = new System.Drawing.Size(376, 375);
            this.dgvitem.TabIndex = 47;
            this.dgvitem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvitem_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Id item:";
            // 
            // dtpLastUpdate
            // 
            this.dtpLastUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLastUpdate.Location = new System.Drawing.Point(263, 212);
            this.dtpLastUpdate.Name = "dtpLastUpdate";
            this.dtpLastUpdate.Size = new System.Drawing.Size(211, 20);
            this.dtpLastUpdate.TabIndex = 61;
            // 
            // dgv_khovattu
            // 
            this.dgv_khovattu.AllowDrop = true;
            this.dgv_khovattu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_khovattu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_khovattu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_khovattu.Location = new System.Drawing.Point(0, 475);
            this.dgv_khovattu.Name = "dgv_khovattu";
            this.dgv_khovattu.Size = new System.Drawing.Size(1295, 207);
            this.dgv_khovattu.TabIndex = 60;
            this.dgv_khovattu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_khovattu_CellClick);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(723, 294);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_thoat.TabIndex = 55;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Location = new System.Drawing.Point(566, 294);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(75, 23);
            this.btn_lammoi.TabIndex = 56;
            this.btn_lammoi.Text = "Làm mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(403, 294);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 23);
            this.btn_sua.TabIndex = 57;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(272, 294);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa.TabIndex = 58;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(106, 294);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 59;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(263, 186);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(211, 20);
            this.txtQuantity.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Thời gian cập nhật gần nhất:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Số lượng:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(152, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(710, 54);
            this.label16.TabIndex = 51;
            this.label16.Text = "THÔNG TIN TỒN KHO VẬT TƯ";
            // 
            // Form_Invt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 682);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_iditem);
            this.Controls.Add(this.txt_nameitem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpLastUpdate);
            this.Controls.Add(this.dgv_khovattu);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Name = "Form_Invt";
            this.Text = "Form_Invt";
            this.Load += new System.EventHandler(this.Form_Invt_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_khovattu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_iditem;
        private System.Windows.Forms.TextBox txt_nameitem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvitem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpLastUpdate;
        private System.Windows.Forms.DataGridView dgv_khovattu;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
    }
}