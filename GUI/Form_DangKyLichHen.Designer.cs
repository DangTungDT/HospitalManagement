namespace GUI
{
    partial class Form_DangKyLichHen
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
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_datestar = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_tenbacsi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.dgv_dangkylichhen = new System.Windows.Forms.DataGridView();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.cbo_tenbenhnhan = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dangkylichhen)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(379, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(479, 54);
            this.label16.TabIndex = 27;
            this.label16.Text = "ĐĂNG KÝ LỊCH HẸN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "ID:";
            // 
            // txt_id
            // 
            this.txt_id.Enabled = false;
            this.txt_id.Location = new System.Drawing.Point(306, 124);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(248, 20);
            this.txt_id.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Ngày hẹn:";
            // 
            // dtp_datestar
            // 
            this.dtp_datestar.Location = new System.Drawing.Point(306, 163);
            this.dtp_datestar.Name = "dtp_datestar";
            this.dtp_datestar.Size = new System.Drawing.Size(248, 20);
            this.dtp_datestar.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Ghi chú:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Trạng thái:";
            // 
            // txt_note
            // 
            this.txt_note.Location = new System.Drawing.Point(306, 195);
            this.txt_note.Name = "txt_note";
            this.txt_note.Size = new System.Drawing.Size(248, 20);
            this.txt_note.TabIndex = 29;
            // 
            // txt_status
            // 
            this.txt_status.Location = new System.Drawing.Point(306, 229);
            this.txt_status.Name = "txt_status";
            this.txt_status.Size = new System.Drawing.Size(248, 20);
            this.txt_status.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Tên bác sĩ:";
            // 
            // cbo_tenbacsi
            // 
            this.cbo_tenbacsi.FormattingEnabled = true;
            this.cbo_tenbacsi.Location = new System.Drawing.Point(306, 268);
            this.cbo_tenbacsi.Name = "cbo_tenbacsi";
            this.cbo_tenbacsi.Size = new System.Drawing.Size(248, 21);
            this.cbo_tenbacsi.TabIndex = 31;
            this.cbo_tenbacsi.SelectedIndexChanged += new System.EventHandler(this.cbo_tenbacsi_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Tên bệnh nhân:";
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(217, 395);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 32;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(417, 395);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa.TabIndex = 32;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(584, 395);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 23);
            this.btn_sua.TabIndex = 32;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Location = new System.Drawing.Point(741, 395);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(75, 23);
            this.btn_lammoi.TabIndex = 32;
            this.btn_lammoi.Text = "Làm mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            // 
            // dgv_dangkylichhen
            // 
            this.dgv_dangkylichhen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_dangkylichhen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dangkylichhen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_dangkylichhen.Location = new System.Drawing.Point(0, 451);
            this.dgv_dangkylichhen.Name = "dgv_dangkylichhen";
            this.dgv_dangkylichhen.Size = new System.Drawing.Size(1208, 380);
            this.dgv_dangkylichhen.TabIndex = 33;
            this.dgv_dangkylichhen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dangkylichhen_CellClick);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(906, 395);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_thoat.TabIndex = 32;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            // 
            // cbo_tenbenhnhan
            // 
            this.cbo_tenbenhnhan.FormattingEnabled = true;
            this.cbo_tenbenhnhan.Location = new System.Drawing.Point(306, 301);
            this.cbo_tenbenhnhan.Name = "cbo_tenbenhnhan";
            this.cbo_tenbenhnhan.Size = new System.Drawing.Size(248, 21);
            this.cbo_tenbenhnhan.TabIndex = 31;
            this.cbo_tenbenhnhan.SelectedIndexChanged += new System.EventHandler(this.cbo_tenbacsi_SelectedIndexChanged);
            // 
            // Form_DangKyLichHen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 831);
            this.Controls.Add(this.dgv_dangkylichhen);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.cbo_tenbenhnhan);
            this.Controls.Add(this.cbo_tenbacsi);
            this.Controls.Add(this.dtp_datestar);
            this.Controls.Add(this.txt_status);
            this.Controls.Add(this.txt_note);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Name = "Form_DangKyLichHen";
            this.Text = "Form_DangKyLichHen";
            this.Load += new System.EventHandler(this.Form_DangKyLichHen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dangkylichhen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_datestar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_note;
        private System.Windows.Forms.TextBox txt_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_tenbacsi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.DataGridView dgv_dangkylichhen;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.ComboBox cbo_tenbenhnhan;
    }
}