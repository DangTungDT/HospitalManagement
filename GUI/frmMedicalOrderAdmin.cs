using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
   
  

    public partial class frmMedicalOrderAdmin : Form
    {
        MedicalOrderBLL bll = new MedicalOrderBLL();

        public frmMedicalOrderAdmin()
        {
            InitializeComponent();
            // Đăng ký các sự kiện
            this.Load += frmMedicalOrderAdmin_Load;
            dgvDanhSachYLenh.CellClick += dgvDanhSachYLenh_CellClick;
            cboLoaiYLenh.SelectedIndexChanged += cboLoaiYLenh_SelectedIndexChanged;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnThoat.Click += btnThoat_Click;
            txtMaYLenh.ReadOnly = true;
            txtNgayTao.ReadOnly = true;
        }

        private void frmMedicalOrderAdmin_Load(object sender, EventArgs e)
        {
            SetupDateTimePickerNull();
            LoadComboBoxes();
            LoadDataGridView();
            ClearFields();
            // Disable combobox thuốc và loại xét nghiệm khi load form
            cboVatTu.Enabled = false;
            cboLoaiXetNghiem.Enabled = false;
        }

        #region "Load & Setup"
        private void LoadDataGridView()
        {
            dgvDanhSachYLenh.DataSource = bll.GetAll();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            // Hiển thị cột mã y lệnh (id)
            dgvDanhSachYLenh.Columns["id"].Visible = true;
            dgvDanhSachYLenh.Columns["id"].HeaderText = "Mã Y Lệnh";
            dgvDanhSachYLenh.Columns["PatientID"].Visible = false;
            dgvDanhSachYLenh.Columns["DoctorID"].Visible = false;
            dgvDanhSachYLenh.Columns["ItemID"].Visible = false;
            dgvDanhSachYLenh.Columns["TestTypeID"].Visible = false;
            
            // Đặt lại tên cột
            dgvDanhSachYLenh.Columns["PatientName"].HeaderText = "Bệnh Nhân";
            dgvDanhSachYLenh.Columns["DoctorName"].HeaderText = "Bác Sĩ";
            dgvDanhSachYLenh.Columns["OrderType"].HeaderText = "Loại Y Lệnh";
            dgvDanhSachYLenh.Columns["ItemName"].HeaderText = "Tên Thuốc/Vật Tư";
            dgvDanhSachYLenh.Columns["TestName"].HeaderText = "Tên Xét Nghiệm";
            dgvDanhSachYLenh.Columns["Dosage"].HeaderText = "Liều Lượng";
            dgvDanhSachYLenh.Columns["Quantity"].HeaderText = "Số Lượng";
            dgvDanhSachYLenh.Columns["Unit"].HeaderText = "Đơn Vị";
            dgvDanhSachYLenh.Columns["Frequency"].HeaderText = "Tần Suất";
            dgvDanhSachYLenh.Columns["Status"].HeaderText = "Trạng Thái";
            dgvDanhSachYLenh.Columns["StartDate"].HeaderText = "Ngày Bắt Đầu";
            dgvDanhSachYLenh.Columns["EndDate"].HeaderText = "Ngày Kết Thúc";
            dgvDanhSachYLenh.Columns["CreatedAt"].HeaderText = "Thời Gian Tạo";
            dgvDanhSachYLenh.Columns["SignedAt"].HeaderText = "Ngày Ký Duyệt";
            dgvDanhSachYLenh.Columns["Note"].HeaderText = "Ghi Chú";
            
            // ... có thể thêm các cột khác nếu cần
        }

        private void LoadComboBoxes()
        {
            // ComboBox Bệnh nhân
            cboBenhNhan.DataSource = bll.GetPatients();
            cboBenhNhan.DisplayMember = "Name";
            cboBenhNhan.ValueMember = "Id";

            // ComboBox Bác sĩ
            cboBacSi.DataSource = bll.GetDoctors();
            cboBacSi.DisplayMember = "Name";
            cboBacSi.ValueMember = "Id";

            // ComboBox Vật tư/Thuốc
            cboVatTu.DataSource = bll.GetItems();
            cboVatTu.DisplayMember = "Name";
            cboVatTu.ValueMember = "Id";
            
            // ComboBox Xét nghiệm
            cboLoaiXetNghiem.DataSource = bll.GetLabTests();
            cboLoaiXetNghiem.DisplayMember = "Name";
            cboLoaiXetNghiem.ValueMember = "Id";

            // ComboBox Loại Y Lệnh (dữ liệu tĩnh)
            cboLoaiYLenh.Items.Clear();
            cboLoaiYLenh.Items.AddRange(new string[] { "Thuốc", "Xét nghiệm", "Chỉ định khác" });
            
            // ComboBox Trạng thái (dữ liệu tĩnh)
            cboTrangThai.Items.AddRange(new string[] { "Active", "Completed", "Discontinued" });
        }
        
        /// <summary>
        /// Cấu hình các DateTimePicker để có thể nhận giá trị Null.
        /// </summary>
        private void SetupDateTimePickerNull()
        {
            dtpNgayBatDau.ShowCheckBox = dtpNgayKetThuc.ShowCheckBox = dtpNgayKyDuyet.ShowCheckBox = true;
            dtpNgayBatDau.Checked = dtpNgayKetThuc.Checked = dtpNgayKyDuyet.Checked = false;
        }

        #endregion

        #region "Event Handlers"
        private void dgvDanhSachYLenh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvDanhSachYLenh.Rows[e.RowIndex];

            // Điền dữ liệu vào các control
            cboBenhNhan.SelectedValue = row.Cells["PatientID"].Value;
            cboBacSi.SelectedValue = row.Cells["DoctorID"].Value;
            string orderType = row.Cells["OrderType"].Value?.ToString();
            int idx = -1;
            for (int i = 0; i < cboLoaiYLenh.Items.Count; i++)
            {
                if (cboLoaiYLenh.Items[i].ToString() == orderType)
                {
                    idx = i;
                    break;
                }
            }
            cboLoaiYLenh.SelectedIndex = idx;
            
            // Xử lý các giá trị có thể null
            SelectComboBoxValue(cboVatTu, row.Cells["ItemID"].Value);
            SelectComboBoxValue(cboLoaiXetNghiem, row.Cells["TestTypeID"].Value);

            txtLieuLuong.Text = GetStringValue(row.Cells["Dosage"].Value);
            nudSoLuong.Value = GetDecimalValue(row.Cells["Quantity"].Value);
            txtDonVi.Text = GetStringValue(row.Cells["Unit"].Value);
            txtTanSuat.Text = GetStringValue(row.Cells["Frequency"].Value);
            cboTrangThai.Text = GetStringValue(row.Cells["Status"].Value);
            txtGhiChu.Text = GetStringValue(row.Cells["Note"].Value);

            SetDateTimePickerValue(dtpNgayBatDau, row.Cells["StartDate"].Value);
            SetDateTimePickerValue(dtpNgayKetThuc, row.Cells["EndDate"].Value);
            SetDateTimePickerValue(dtpNgayKyDuyet, row.Cells["SignedAt"].Value);
            // Hiển thị mã y lệnh và thời gian tạo
            txtMaYLenh.Text = row.Cells["id"].Value?.ToString() ?? "";
            txtNgayTao.Text = row.Cells["CreatedAt"].Value != null ? ((DateTime)row.Cells["CreatedAt"].Value).ToString("yyyy-MM-dd HH:mm:ss") : "";
        }

        private void cboLoaiYLenh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiYLenh.SelectedItem == null) return;
            string selectedType = cboLoaiYLenh.SelectedItem.ToString();
            // Bật/tắt các control tương ứng với loại y lệnh
            cboVatTu.Enabled = (selectedType == "Thuốc");
            cboLoaiXetNghiem.Enabled = (selectedType == "Xét nghiệm");
            // Khi thay đổi loại, reset các lựa chọn không liên quan
            if (!cboVatTu.Enabled) cboVatTu.SelectedIndex = -1;
            if (!cboLoaiXetNghiem.Enabled) cboLoaiXetNghiem.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (bll.Add(GetDTOFromForm()))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachYLenh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một y lệnh để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            MedicalOrderDTO dto = GetDTOFromForm();
            dto.id = (int)dgvDanhSachYLenh.CurrentRow.Cells["id"].Value; // Lấy ID của hàng đang chọn

            if (bll.Update(dto))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachYLenh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một y lệnh để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int id = (int)dgvDanhSachYLenh.CurrentRow.Cells["id"].Value;
            if(MessageBox.Show($"Bạn có chắc muốn xóa y lệnh #{id} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(bll.Delete(id))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadDataGridView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Helper Methods"
        /// <summary>
        /// Reset các control về trạng thái ban đầu.
        /// </summary>
        private void ClearFields()
        {
            cboBenhNhan.SelectedIndex = cboBacSi.SelectedIndex = cboLoaiYLenh.SelectedIndex = cboVatTu.SelectedIndex = cboLoaiXetNghiem.SelectedIndex = cboTrangThai.SelectedIndex = -1;
            txtLieuLuong.Clear();
            nudSoLuong.Value = 0;
            txtDonVi.Clear();
            txtTanSuat.Clear();
            txtGhiChu.Clear();
            dtpNgayBatDau.Checked = dtpNgayKetThuc.Checked = dtpNgayKyDuyet.Checked = false;
            // Disable combobox thuốc và loại xét nghiệm khi làm mới
            cboVatTu.Enabled = false;
            cboLoaiXetNghiem.Enabled = false;
            // Xóa mã y lệnh và ngày tạo khi làm mới
            txtMaYLenh.Text = "";
            txtNgayTao.Text = "";
        }
        
        /// <summary>
        /// Lấy dữ liệu từ các control trên form để tạo đối tượng DTO.
        /// </summary>
        private MedicalOrderDTO GetDTOFromForm()
        {
            return new MedicalOrderDTO
            {
                PatientID = cboBenhNhan.SelectedValue?.ToString(),
                DoctorID = cboBacSi.SelectedValue?.ToString(),
                // Lưu lại text tiếng Việt
                OrderType = cboLoaiYLenh.Text,
                ItemID = cboVatTu.Enabled ? cboVatTu.SelectedValue?.ToString() : null,
                TestTypeID = cboLoaiXetNghiem.Enabled ? (int?)cboLoaiXetNghiem.SelectedValue : null,
                Dosage = txtLieuLuong.Text,
                Quantity = nudSoLuong.Value > 0 ? (decimal?)nudSoLuong.Value : null,
                Unit = txtDonVi.Text,
                Frequency = txtTanSuat.Text,
                Status = cboTrangThai.Text,
                Note = txtGhiChu.Text,
                StartDate = dtpNgayBatDau.Checked ? (DateTime?)dtpNgayBatDau.Value : null,
                EndDate = dtpNgayKetThuc.Checked ? (DateTime?)dtpNgayKetThuc.Value : null,
                SignedAt = dtpNgayKyDuyet.Checked ? (DateTime?)dtpNgayKyDuyet.Value : null
            };
        }

        // Các hàm hỗ trợ lấy giá trị an toàn từ DataGridView
        private string GetStringValue(object value) => value?.ToString() ?? "";
        private decimal GetDecimalValue(object value) => value != null && decimal.TryParse(value.ToString(), out decimal result) ? result : 0;
        private void SetDateTimePickerValue(DateTimePicker dtp, object value)
        {
            if (value != null && DateTime.TryParse(value.ToString(), out DateTime date))
            {
                dtp.Value = date;
                dtp.Checked = true;
            }
            else
            {
                dtp.Checked = false;
            }
        }
        private void SelectComboBoxValue(ComboBox cbo, object value)
        {
            if (value != null && value != DBNull.Value)
            {
                try
                {
                    cbo.SelectedValue = value;
                }
                catch (Exception)
                {
                    cbo.SelectedIndex = -1;
                }
            }
            else cbo.SelectedIndex = -1;
        }

        #endregion
    }
}
