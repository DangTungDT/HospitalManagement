namespace GUI
{
    partial class frm_CongNo
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
            this.dgv_thongtincongthuno = new System.Windows.Forms.DataGridView();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txt_tienconno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_mabenhnhan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_mahoadon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_macongnothu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_hanthanhtoan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_trangthai = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtincongthuno)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_thongtincongthuno
            // 
            this.dgv_thongtincongthuno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thongtincongthuno.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_thongtincongthuno.Location = new System.Drawing.Point(0, 362);
            this.dgv_thongtincongthuno.Name = "dgv_thongtincongthuno";
            this.dgv_thongtincongthuno.Size = new System.Drawing.Size(990, 170);
            this.dgv_thongtincongthuno.TabIndex = 19;
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
            // txt_tienconno
            // 
            this.txt_tienconno.Location = new System.Drawing.Point(653, 119);
            this.txt_tienconno.Name = "txt_tienconno";
            this.txt_tienconno.Size = new System.Drawing.Size(164, 20);
            this.txt_tienconno.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Số tiền còn nợ:";
            // 
            // txt_mabenhnhan
            // 
            this.txt_mabenhnhan.Location = new System.Drawing.Point(177, 247);
            this.txt_mabenhnhan.Name = "txt_mabenhnhan";
            this.txt_mabenhnhan.Size = new System.Drawing.Size(164, 20);
            this.txt_mabenhnhan.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã bệnh nhân:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txt_mahoadon
            // 
            this.txt_mahoadon.Location = new System.Drawing.Point(177, 182);
            this.txt_mahoadon.Name = "txt_mahoadon";
            this.txt_mahoadon.Size = new System.Drawing.Size(164, 20);
            this.txt_mahoadon.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mã hóa đơn:";
            // 
            // txt_macongnothu
            // 
            this.txt_macongnothu.Location = new System.Drawing.Point(177, 122);
            this.txt_macongnothu.Name = "txt_macongnothu";
            this.txt_macongnothu.Size = new System.Drawing.Size(164, 20);
            this.txt_macongnothu.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã công nợ thu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(649, 54);
            this.label1.TabIndex = 5;
            this.label1.Text = "THÔNG TIN CÔNG THU NỢ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(553, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Hạn thanh toán:";
            // 
            // txt_hanthanhtoan
            // 
            this.txt_hanthanhtoan.Location = new System.Drawing.Point(653, 175);
            this.txt_hanthanhtoan.Name = "txt_hanthanhtoan";
            this.txt_hanthanhtoan.Size = new System.Drawing.Size(164, 20);
            this.txt_hanthanhtoan.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Trạng thái:";
            // 
            // txt_trangthai
            // 
            this.txt_trangthai.Location = new System.Drawing.Point(653, 240);
            this.txt_trangthai.Name = "txt_trangthai";
            this.txt_trangthai.Size = new System.Drawing.Size(164, 20);
            this.txt_trangthai.TabIndex = 10;
            // 
            // frm_CongNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 532);
            this.Controls.Add(this.dgv_thongtincongthuno);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_trangthai);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_hanthanhtoan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_tienconno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_mabenhnhan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_mahoadon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_macongnothu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_CongNo";
            this.Text = "frm_CongNo";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtincongthuno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_thongtincongthuno;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txt_tienconno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_mabenhnhan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_mahoadon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_macongnothu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_hanthanhtoan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_trangthai;
    }
}