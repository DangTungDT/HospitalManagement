namespace GUI
{
    partial class Form_DtorPaitent
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
            this.dtp_enddate = new System.Windows.Forms.DateTimePicker();
            this.dgv_doctorpaitent = new System.Windows.Forms.DataGridView();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txt_idpaitent = new System.Windows.Forms.TextBox();
            this.txt_iddoctor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtp_stardate = new System.Windows.Forms.DateTimePicker();
            this.txt_role = new System.Windows.Forms.TextBox();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.dgv_paitent = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_namepaitent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rad_nam = new System.Windows.Forms.RadioButton();
            this.rad_nu = new System.Windows.Forms.RadioButton();
            this.dtp_dobpantent = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_doctorpaitent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_paitent)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_enddate
            // 
            this.dtp_enddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_enddate.Location = new System.Drawing.Point(227, 281);
            this.dtp_enddate.Name = "dtp_enddate";
            this.dtp_enddate.Size = new System.Drawing.Size(211, 20);
            this.dtp_enddate.TabIndex = 90;
            // 
            // dgv_doctorpaitent
            // 
            this.dgv_doctorpaitent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_doctorpaitent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_doctorpaitent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_doctorpaitent.Location = new System.Drawing.Point(0, 434);
            this.dgv_doctorpaitent.Name = "dgv_doctorpaitent";
            this.dgv_doctorpaitent.Size = new System.Drawing.Size(1247, 367);
            this.dgv_doctorpaitent.TabIndex = 88;
            this.dgv_doctorpaitent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_doctorpaitent_CellClick);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(793, 405);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_thoat.TabIndex = 83;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Location = new System.Drawing.Point(641, 405);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(75, 23);
            this.btn_lammoi.TabIndex = 84;
            this.btn_lammoi.Text = "Làm mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(476, 405);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 23);
            this.btn_sua.TabIndex = 85;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(340, 405);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa.TabIndex = 86;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(179, 405);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 87;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txt_idpaitent
            // 
            this.txt_idpaitent.Location = new System.Drawing.Point(227, 213);
            this.txt_idpaitent.Name = "txt_idpaitent";
            this.txt_idpaitent.Size = new System.Drawing.Size(211, 20);
            this.txt_idpaitent.TabIndex = 81;
            // 
            // txt_iddoctor
            // 
            this.txt_iddoctor.Location = new System.Drawing.Point(227, 95);
            this.txt_iddoctor.Name = "txt_iddoctor";
            this.txt_iddoctor.Size = new System.Drawing.Size(211, 20);
            this.txt_iddoctor.TabIndex = 82;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 73;
            this.label7.Text = "Ghi chú:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "Vai trò:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "Ngày kết thúc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "ID Bác sĩ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 76;
            this.label5.Text = "Ngày bắt đầu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "ID Bệnh nhân:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(200, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(836, 54);
            this.label16.TabIndex = 71;
            this.label16.Text = "THÔNG TIN BÁC SĨ VÀ BỆNH NHÂN";
            // 
            // dtp_stardate
            // 
            this.dtp_stardate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_stardate.Location = new System.Drawing.Point(227, 247);
            this.dtp_stardate.Name = "dtp_stardate";
            this.dtp_stardate.Size = new System.Drawing.Size(211, 20);
            this.dtp_stardate.TabIndex = 90;
            // 
            // txt_role
            // 
            this.txt_role.Location = new System.Drawing.Point(227, 321);
            this.txt_role.Name = "txt_role";
            this.txt_role.Size = new System.Drawing.Size(211, 20);
            this.txt_role.TabIndex = 81;
            // 
            // txt_note
            // 
            this.txt_note.Location = new System.Drawing.Point(227, 355);
            this.txt_note.Name = "txt_note";
            this.txt_note.Size = new System.Drawing.Size(211, 20);
            this.txt_note.TabIndex = 81;
            // 
            // dgv_paitent
            // 
            this.dgv_paitent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_paitent.Location = new System.Drawing.Point(581, 66);
            this.dgv_paitent.Name = "dgv_paitent";
            this.dgv_paitent.Size = new System.Drawing.Size(666, 219);
            this.dgv_paitent.TabIndex = 91;
            this.dgv_paitent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_paitent_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "Tên bệnh nhân:";
            // 
            // txt_namepaitent
            // 
            this.txt_namepaitent.Location = new System.Drawing.Point(227, 126);
            this.txt_namepaitent.Name = "txt_namepaitent";
            this.txt_namepaitent.Size = new System.Drawing.Size(211, 20);
            this.txt_namepaitent.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "Giới tính:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(113, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "Ngày sinh bệnh nhân:";
            // 
            // rad_nam
            // 
            this.rad_nam.AutoSize = true;
            this.rad_nam.Location = new System.Drawing.Point(227, 161);
            this.rad_nam.Name = "rad_nam";
            this.rad_nam.Size = new System.Drawing.Size(48, 17);
            this.rad_nam.TabIndex = 92;
            this.rad_nam.TabStop = true;
            this.rad_nam.Text = "Male";
            this.rad_nam.UseVisualStyleBackColor = true;
            // 
            // rad_nu
            // 
            this.rad_nu.AutoSize = true;
            this.rad_nu.Location = new System.Drawing.Point(332, 161);
            this.rad_nu.Name = "rad_nu";
            this.rad_nu.Size = new System.Drawing.Size(59, 17);
            this.rad_nu.TabIndex = 92;
            this.rad_nu.TabStop = true;
            this.rad_nu.Text = "Female";
            this.rad_nu.UseVisualStyleBackColor = true;
            // 
            // dtp_dobpantent
            // 
            this.dtp_dobpantent.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_dobpantent.Location = new System.Drawing.Point(227, 185);
            this.dtp_dobpantent.Name = "dtp_dobpantent";
            this.dtp_dobpantent.Size = new System.Drawing.Size(200, 20);
            this.dtp_dobpantent.TabIndex = 93;
            // 
            // Form_DtorPaitent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 801);
            this.Controls.Add(this.dtp_dobpantent);
            this.Controls.Add(this.rad_nu);
            this.Controls.Add(this.rad_nam);
            this.Controls.Add(this.dgv_paitent);
            this.Controls.Add(this.dtp_stardate);
            this.Controls.Add(this.dtp_enddate);
            this.Controls.Add(this.dgv_doctorpaitent);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_note);
            this.Controls.Add(this.txt_role);
            this.Controls.Add(this.txt_idpaitent);
            this.Controls.Add(this.txt_namepaitent);
            this.Controls.Add(this.txt_iddoctor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Name = "Form_DtorPaitent";
            this.Text = "Form_DtorPaitent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_DtorPaitent_FormClosing);
            this.Load += new System.EventHandler(this.Form_DtorPaitent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_doctorpaitent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_paitent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtp_enddate;
        private System.Windows.Forms.DataGridView dgv_doctorpaitent;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txt_idpaitent;
        private System.Windows.Forms.TextBox txt_iddoctor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtp_stardate;
        private System.Windows.Forms.TextBox txt_role;
        private System.Windows.Forms.TextBox txt_note;
        private System.Windows.Forms.DataGridView dgv_paitent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_namepaitent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rad_nam;
        private System.Windows.Forms.RadioButton rad_nu;
        private System.Windows.Forms.DateTimePicker dtp_dobpantent;
    }
}