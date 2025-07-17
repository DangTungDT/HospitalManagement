namespace GUI
{
    partial class DoctorPatientAdmin
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
            this.pnlThongTinChiTiet = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.cboBenhNhan = new System.Windows.Forms.ComboBox();
            this.lblBenhNhan = new System.Windows.Forms.Label();
            this.cboBacSi = new System.Windows.Forms.ComboBox();
            this.lblBacSi = new System.Windows.Forms.Label();
            this.dgvDanhSachPhanCong = new System.Windows.Forms.DataGridView();
            this.pnlThongTinChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlThongTinChiTiet
            // 
            this.pnlThongTinChiTiet.Controls.Add(this.btnThoat);
            this.pnlThongTinChiTiet.Controls.Add(this.btnLamMoi);
            this.pnlThongTinChiTiet.Controls.Add(this.btnXoa);
            this.pnlThongTinChiTiet.Controls.Add(this.btnSua);
            this.pnlThongTinChiTiet.Controls.Add(this.btnThem);
            this.pnlThongTinChiTiet.Controls.Add(this.txtGhiChu);
            this.pnlThongTinChiTiet.Controls.Add(this.lblGhiChu);
            this.pnlThongTinChiTiet.Controls.Add(this.cboVaiTro);
            this.pnlThongTinChiTiet.Controls.Add(this.lblVaiTro);
            this.pnlThongTinChiTiet.Controls.Add(this.dtpNgayKetThuc);
            this.pnlThongTinChiTiet.Controls.Add(this.lblNgayKetThuc);
            this.pnlThongTinChiTiet.Controls.Add(this.dtpNgayBatDau);
            this.pnlThongTinChiTiet.Controls.Add(this.lblNgayBatDau);
            this.pnlThongTinChiTiet.Controls.Add(this.cboBenhNhan);
            this.pnlThongTinChiTiet.Controls.Add(this.lblBenhNhan);
            this.pnlThongTinChiTiet.Controls.Add(this.cboBacSi);
            this.pnlThongTinChiTiet.Controls.Add(this.lblBacSi);
            this.pnlThongTinChiTiet.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlThongTinChiTiet.Location = new System.Drawing.Point(0, 0);
            this.pnlThongTinChiTiet.Margin = new System.Windows.Forms.Padding(2);
            this.pnlThongTinChiTiet.Name = "pnlThongTinChiTiet";
            this.pnlThongTinChiTiet.Size = new System.Drawing.Size(328, 592);
            this.pnlThongTinChiTiet.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(258, 552);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(56, 26);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(197, 552);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(56, 26);
            this.btnLamMoi.TabIndex = 15;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(136, 552);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(56, 26);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(76, 552);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(56, 26);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(15, 552);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(56, 26);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(90, 214);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(225, 74);
            this.txtGhiChu.TabIndex = 11;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(13, 216);
            this.lblGhiChu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 13);
            this.lblGhiChu.TabIndex = 10;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(90, 184);
            this.cboVaiTro.Margin = new System.Windows.Forms.Padding(2);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(225, 21);
            this.cboVaiTro.TabIndex = 9;
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(13, 186);
            this.lblVaiTro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(40, 13);
            this.lblVaiTro.TabIndex = 8;
            this.lblVaiTro.Text = "Vai trò:";
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(90, 157);
            this.dtpNgayKetThuc.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(225, 20);
            this.dtpNgayKetThuc.TabIndex = 7;
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Location = new System.Drawing.Point(13, 161);
            this.lblNgayKetThuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(77, 13);
            this.lblNgayKetThuc.TabIndex = 6;
            this.lblNgayKetThuc.Text = "Ngày kết thúc:";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(90, 130);
            this.dtpNgayBatDau.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(225, 20);
            this.dtpNgayBatDau.TabIndex = 5;
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Location = new System.Drawing.Point(13, 134);
            this.lblNgayBatDau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(75, 13);
            this.lblNgayBatDau.TabIndex = 4;
            this.lblNgayBatDau.Text = "Ngày bắt đầu:";
            // 
            // cboBenhNhan
            // 
            this.cboBenhNhan.FormattingEnabled = true;
            this.cboBenhNhan.Location = new System.Drawing.Point(90, 63);
            this.cboBenhNhan.Margin = new System.Windows.Forms.Padding(2);
            this.cboBenhNhan.Name = "cboBenhNhan";
            this.cboBenhNhan.Size = new System.Drawing.Size(225, 21);
            this.cboBenhNhan.TabIndex = 3;
            // 
            // lblBenhNhan
            // 
            this.lblBenhNhan.AutoSize = true;
            this.lblBenhNhan.Location = new System.Drawing.Point(13, 66);
            this.lblBenhNhan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBenhNhan.Name = "lblBenhNhan";
            this.lblBenhNhan.Size = new System.Drawing.Size(62, 13);
            this.lblBenhNhan.TabIndex = 2;
            this.lblBenhNhan.Text = "Bệnh nhân:";
            // 
            // cboBacSi
            // 
            this.cboBacSi.FormattingEnabled = true;
            this.cboBacSi.Location = new System.Drawing.Point(90, 37);
            this.cboBacSi.Margin = new System.Windows.Forms.Padding(2);
            this.cboBacSi.Name = "cboBacSi";
            this.cboBacSi.Size = new System.Drawing.Size(225, 21);
            this.cboBacSi.TabIndex = 1;
            // 
            // lblBacSi
            // 
            this.lblBacSi.AutoSize = true;
            this.lblBacSi.Location = new System.Drawing.Point(13, 39);
            this.lblBacSi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBacSi.Name = "lblBacSi";
            this.lblBacSi.Size = new System.Drawing.Size(42, 13);
            this.lblBacSi.TabIndex = 0;
            this.lblBacSi.Text = "Bác sĩ:";
            // 
            // dgvDanhSachPhanCong
            // 
            this.dgvDanhSachPhanCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachPhanCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachPhanCong.Location = new System.Drawing.Point(328, 0);
            this.dgvDanhSachPhanCong.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDanhSachPhanCong.Name = "dgvDanhSachPhanCong";
            this.dgvDanhSachPhanCong.RowHeadersWidth = 51;
            this.dgvDanhSachPhanCong.RowTemplate.Height = 24;
            this.dgvDanhSachPhanCong.Size = new System.Drawing.Size(676, 592);
            this.dgvDanhSachPhanCong.TabIndex = 1;
            this.dgvDanhSachPhanCong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachPhanCong_CellClick);
            // 
            // DoctorPatientAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 592);
            this.Controls.Add(this.dgvDanhSachPhanCong);
            this.Controls.Add(this.pnlThongTinChiTiet);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DoctorPatientAdmin";
            this.Text = " Bác sĩ - Bệnh nhân";
            this.Load += new System.EventHandler(this.DoctorPatientAdmin_Load);
            this.pnlThongTinChiTiet.ResumeLayout(false);
            this.pnlThongTinChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhanCong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlThongTinChiTiet;
        private System.Windows.Forms.DataGridView dgvDanhSachPhanCong;
        private System.Windows.Forms.Label lblBacSi;
        private System.Windows.Forms.ComboBox cboBacSi;
        private System.Windows.Forms.Label lblBenhNhan;
        private System.Windows.Forms.ComboBox cboBenhNhan;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
    }
}