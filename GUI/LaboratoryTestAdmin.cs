using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class LaboratoryTestAdmin : Form
    {
        // Khởi tạo lớp Business Logic Layer để thao tác dữ liệu xét nghiệm
        LaboratoryTestAdminBLL bll = new LaboratoryTestAdminBLL();

        // Constructor của form
        public LaboratoryTestAdmin()
        {
            InitializeComponent();
            // Đăng ký các sự kiện cho các control trên form
            this.Load += LaboratoryTestAdmin_Load;
            //dgvDanhSachXetNghiem.CellClick += dgvDanhSachXetNghiem_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnThoat.Click += btnThoat_Click;
        }

        #region "Load & Setup"
        /// <summary>
        /// Sự kiện khi form được load lần đầu. Thiết lập trạng thái ban đầu cho các control.
        /// </summary>
        private void LaboratoryTestAdmin_Load(object sender, EventArgs e)
        {
            dtpNgayBatDau.ShowCheckBox = true;
            dtpNgayBatDau.Checked = false;

            LoadComboBoxes();
            LoadDataGridView(); 
            ClearFields();
        }

        /// <summary>
        /// Nạp dữ liệu cho các combobox trên form.
        /// </summary>
        private void LoadComboBoxes()
        {
            // Nạp danh sách y lệnh
            cboYLenh.DataSource = bll.GetMedicalOrdersForLabTest();
            cboYLenh.DisplayMember = "Display"; // Sẽ tạo property Display ở dưới
            cboYLenh.ValueMember = "Id";


            // Nạp danh sách trạng thái xét nghiệm
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Chờ lấy mẫu", "Đang xử lý", "Hoàn thành", "Hủy" });
        }

       

        /// <summary>
        /// Nạp dữ liệu cho DataGridView từ BLL.
        /// </summary>
        private void LoadDataGridView()
        {
            var list = bll.GetAll();
            var orders = bll.GetMedicalOrdersForLabTest();
            foreach (var item in list)
            {
                var mo = orders.Find(x => x.Id == item.MedicalOrderID);
                item.MedicalOrderDisplay = mo != null ? mo.Display : item.MedicalOrderID.ToString();
            }
            dgvDanhSachXetNghiem.DataSource = list;
            SetupDataGridView();
        }

        /// <summary>
        /// Cấu hình lại header cho DataGridView (hiển thị tiếng Việt).
        /// </summary>
        private void SetupDataGridView()
        {
            dgvDanhSachXetNghiem.Columns["id"].Visible = true;
            dgvDanhSachXetNghiem.Columns["id"].HeaderText = "Mã Xét Nghiệm";
            if (dgvDanhSachXetNghiem.Columns.Contains("MedicalOrderID"))
                dgvDanhSachXetNghiem.Columns["MedicalOrderID"].Visible = false;
            if (dgvDanhSachXetNghiem.Columns.Contains("MedicalOrderDisplay"))
                dgvDanhSachXetNghiem.Columns["MedicalOrderDisplay"].HeaderText = "Y lệnh";
            if (dgvDanhSachXetNghiem.Columns.Contains("startDate"))
                dgvDanhSachXetNghiem.Columns["startDate"].HeaderText = "Ngày Thực Hiện";
            if (dgvDanhSachXetNghiem.Columns.Contains("resultValue"))
                dgvDanhSachXetNghiem.Columns["resultValue"].HeaderText = "Giá trị KQ";
            if (dgvDanhSachXetNghiem.Columns.Contains("resultUnit"))
                dgvDanhSachXetNghiem.Columns["resultUnit"].HeaderText = "Đơn vị KQ";
            if (dgvDanhSachXetNghiem.Columns.Contains("result"))
                dgvDanhSachXetNghiem.Columns["result"].HeaderText = "Kết Luận";
            if (dgvDanhSachXetNghiem.Columns.Contains("status"))
                dgvDanhSachXetNghiem.Columns["status"].HeaderText = "Trạng Thái";
            if (dgvDanhSachXetNghiem.Columns.Contains("note"))
                dgvDanhSachXetNghiem.Columns["note"].HeaderText = "Ghi Chú";
            // Ẩn các cột không có trong bảng LaboratoryTest nếu có
            string[] extraCols = {"PatientName", "DoctorName", "TestTypeName", "LabTestTypeID"};
            foreach (var col in extraCols)
                if (dgvDanhSachXetNghiem.Columns.Contains(col))
                    dgvDanhSachXetNghiem.Columns[col].Visible = false;
        }
        #endregion

        #region "Event Handlers"
        /// <summary>
        /// Sự kiện khi click vào một dòng trên DataGridView.
        /// Lấy dữ liệu từ dòng được chọn và hiển thị lên các control nhập liệu.
        /// </summary>
        private void dgvDanhSachXetNghiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvDanhSachXetNghiem.Rows[e.RowIndex];
            txtMaXetNghiem.Text = row.Cells["id"].Value?.ToString() ?? "";
            if (row.Cells["MedicalOrderID"].Value != null)
                cboYLenh.SelectedValue = Convert.ToInt32(row.Cells["MedicalOrderID"].Value);
            SetDateTimePickerValue(dtpNgayBatDau, row.Cells["startDate"].Value);
            txtGiaTriKetQua.Text = GetStringValue(row.Cells["resultValue"].Value);
            txtDonViKetQua.Text = GetStringValue(row.Cells["resultUnit"].Value);
            txtKetQua.Text = GetStringValue(row.Cells["result"].Value);
            string status = GetStringValue(row.Cells["status"].Value);
            int statusIdx = -1;
            for (int i = 0; i < cboTrangThai.Items.Count; i++)
            {
                if (cboTrangThai.Items[i].ToString().Trim().ToLower() == status.Trim().ToLower())
                {
                    statusIdx = i;
                    break;
                }
            }
            cboTrangThai.SelectedIndex = statusIdx;
            txtGhiChu.Text = GetStringValue(row.Cells["note"].Value);
        }

        /// <summary>
        /// Sự kiện click nút Thêm mới.
        /// </summary>
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
                MessageBox.Show("Thêm thất bại! Vui lòng kiểm tra lại thông tin bắt buộc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện click nút Sửa.
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachXetNghiem.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LaboratoryTestDTO dto = GetDTOFromForm();
            dto.id = (int)dgvDanhSachXetNghiem.CurrentRow.Cells["id"].Value;

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

        /// <summary>
        /// Sự kiện click nút Xóa.
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachXetNghiem.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = (int)dgvDanhSachXetNghiem.CurrentRow.Cells["id"].Value;
            if (MessageBox.Show($"Bạn có chắc muốn xóa xét nghiệm #{id} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bll.Delete(id))
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

        /// <summary>
        /// Sự kiện click nút Làm Mới.
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadDataGridView();
        }

        /// <summary>
        /// Sự kiện click nút Thoát.
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Helper Methods"
        /// <summary>
        /// Xóa trắng các control về trạng thái ban đầu.
        /// </summary>
        private void ClearFields()
        {
            cboYLenh.SelectedIndex = -1;
            
            dtpNgayBatDau.Checked = false;
            txtGiaTriKetQua.Clear();
            txtDonViKetQua.Clear();
            txtKetQua.Clear();
            cboTrangThai.SelectedIndex = -1;
            cboTrangThai.Text = "";
            txtGhiChu.Clear();
            txtMaXetNghiem.Text = "";
            
        }

        /// <summary>
        /// Lấy dữ liệu từ các control trên form để tạo đối tượng DTO.
        /// </summary>
        private LaboratoryTestDTO GetDTOFromForm()
        {
            return new LaboratoryTestDTO
            {
                MedicalOrderID = cboYLenh.SelectedValue != null ? (int)cboYLenh.SelectedValue : 0,
                startDate = dtpNgayBatDau.Checked ? (DateTime?)dtpNgayBatDau.Value : null,
                resultValue = txtGiaTriKetQua.Text,
                resultUnit = txtDonViKetQua.Text,
                result = txtKetQua.Text,
                status = cboTrangThai.Text,
                note = txtGhiChu.Text
            };
        }

        /// <summary>
        /// Lấy giá trị string an toàn từ object (tránh null).
        /// </summary>
        private string GetStringValue(object value) => value?.ToString() ?? "";

        /// <summary>
        /// Đặt giá trị cho DateTimePicker từ object (có thể null).
        /// </summary>
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

        #endregion


    }
}
