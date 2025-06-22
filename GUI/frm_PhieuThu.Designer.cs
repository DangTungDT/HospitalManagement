namespace GUI
{
    partial class frm_PhieuThu
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
            this.dgv_thongtinphieuthu = new System.Windows.Forms.DataGridView();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txt_sotien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_mabenhnhan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_maphieuthu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_nhanvienphathanh = new System.Windows.Forms.TextBox();
            this.dtp_ngayphathanh = new System.Windows.Forms.DateTimePicker();
            this.cbo_tendichvu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtinphieuthu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_thongtinphieuthu
            // 
            this.dgv_thongtinphieuthu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thongtinphieuthu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_thongtinphieuthu.Location = new System.Drawing.Point(0, 365);
            this.dgv_thongtinphieuthu.Name = "dgv_thongtinphieuthu";
            this.dgv_thongtinphieuthu.Size = new System.Drawing.Size(977, 170);
            this.dgv_thongtinphieuthu.TabIndex = 19;
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(330, 302);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa.TabIndex = 14;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(892, 302);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_thoat.TabIndex = 15;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Location = new System.Drawing.Point(676, 302);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(75, 23);
            this.btn_lammoi.TabIndex = 16;
            this.btn_lammoi.Text = "Làm mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(492, 302);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 23);
            this.btn_sua.TabIndex = 17;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(155, 302);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 18;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            // 
            // txt_sotien
            // 
            this.txt_sotien.Location = new System.Drawing.Point(676, 122);
            this.txt_sotien.Name = "txt_sotien";
            this.txt_sotien.Size = new System.Drawing.Size(164, 20);
            this.txt_sotien.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Số tiền:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tên dịch vụ:";
            // 
            // txt_mabenhnhan
            // 
            this.txt_mabenhnhan.Location = new System.Drawing.Point(177, 182);
            this.txt_mabenhnhan.Name = "txt_mabenhnhan";
            this.txt_mabenhnhan.Size = new System.Drawing.Size(164, 20);
            this.txt_mabenhnhan.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mã bệnh nhân:";
            // 
            // txt_maphieuthu
            // 
            this.txt_maphieuthu.Location = new System.Drawing.Point(177, 122);
            this.txt_maphieuthu.Name = "txt_maphieuthu";
            this.txt_maphieuthu.Size = new System.Drawing.Size(164, 20);
            this.txt_maphieuthu.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã phiếu thu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(551, 54);
            this.label1.TabIndex = 5;
            this.label1.Text = "THÔNG TIN PHẾU THU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(531, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ngày phát hành:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(531, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nhân viên phát hành:";
            // 
            // txt_nhanvienphathanh
            // 
            this.txt_nhanvienphathanh.Location = new System.Drawing.Point(676, 240);
            this.txt_nhanvienphathanh.Name = "txt_nhanvienphathanh";
            this.txt_nhanvienphathanh.Size = new System.Drawing.Size(164, 20);
            this.txt_nhanvienphathanh.TabIndex = 10;
            // 
            // dtp_ngayphathanh
            // 
            this.dtp_ngayphathanh.Location = new System.Drawing.Point(676, 174);
            this.dtp_ngayphathanh.Name = "dtp_ngayphathanh";
            this.dtp_ngayphathanh.Size = new System.Drawing.Size(164, 20);
            this.dtp_ngayphathanh.TabIndex = 20;
            // 
            // cbo_tendichvu
            // 
            this.cbo_tendichvu.FormattingEnabled = true;
            this.cbo_tendichvu.Location = new System.Drawing.Point(177, 238);
            this.cbo_tendichvu.Name = "cbo_tendichvu";
            this.cbo_tendichvu.Size = new System.Drawing.Size(164, 21);
            this.cbo_tendichvu.TabIndex = 21;
            // 
            // frm_PhieuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 535);
            this.Controls.Add(this.cbo_tendichvu);
            this.Controls.Add(this.dtp_ngayphathanh);
            this.Controls.Add(this.dgv_thongtinphieuthu);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_nhanvienphathanh);
            this.Controls.Add(this.txt_sotien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_mabenhnhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_maphieuthu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_PhieuThu";
            this.Text = "frm_PhieuThu";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtinphieuthu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_thongtinphieuthu;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txt_sotien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_mabenhnhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_maphieuthu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_nhanvienphathanh;
        private System.Windows.Forms.DateTimePicker dtp_ngayphathanh;
        private System.Windows.Forms.ComboBox cbo_tendichvu;
    }
}