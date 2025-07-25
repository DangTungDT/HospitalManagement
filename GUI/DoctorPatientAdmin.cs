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
    public partial class DoctorPatientAdmin : Form
    {
        // Khởi tạo lớp Business Logic Layer (BLL) để tương tác với logic nghiệp vụ
        DoctorPatientAdminBLL bll = new DoctorPatientAdminBLL();

        // Constructor của Form
        public DoctorPatientAdmin()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Xử lý sự kiện khi form được tải lần đầu.
        /// Chịu trách nhiệm thiết lập trạng thái ban đầu cho các control.
        /// </summary>
        private void DoctorPatientAdmin_Load(object sender, EventArgs e)
        {
            // Cấu hình DateTimePicker cho phép chọn giá trị null
            dtpNgayKetThuc.ShowCheckBox = true; // Hiển thị checkbox
            dtpNgayKetThuc.Checked = false; // Mặc định không check, tương ứng với giá trị null

            // Tải dữ liệu cho các ComboBox và DataGridView
            LoadComboBoxes();
            LoadDataGridView();

        }

        /// <summary>
        /// Tải hoặc làm mới dữ liệu trên DataGridView.
        /// </summary>
        private void LoadDataGridView()
        {

            dgvDanhSachPhanCong.DataSource = bll.GetAll();
            SetupDataGridView();
            dgvDanhSachPhanCong.ClearSelection(); // Bỏ chọn tất cả các dòng sau khi load
            dgvDanhSachPhanCong.CellClick += dgvDanhSachPhanCong_CellClick;
        }

        /// <summary>
        /// Tùy chỉnh giao diện và các cột của DataGridView.
        /// </summary>
        private void SetupDataGridView()
        {
            // Ẩn các cột chứa ID để người dùng không nhìn thấy
            dgvDanhSachPhanCong.Columns["doctorID"].Visible = false;
            dgvDanhSachPhanCong.Columns["patientID"].Visible = false;

            // Đặt lại tên header cho các cột để hiển thị thân thiện hơn
            dgvDanhSachPhanCong.Columns["doctorName"].HeaderText = "Tên Bác Sĩ";
            dgvDanhSachPhanCong.Columns["patientName"].HeaderText = "Tên Bệnh Nhân";
            dgvDanhSachPhanCong.Columns["startDate"].HeaderText = "Ngày Bắt Đầu";
            dgvDanhSachPhanCong.Columns["endDate"].HeaderText = "Ngày Kết Thúc";
            dgvDanhSachPhanCong.Columns["role"].HeaderText = "Vai Trò";
            dgvDanhSachPhanCong.Columns["note"].HeaderText = "Ghi Chú";

            // Áp dụng style tùy chỉnh cho DataGridView
            StyleDataGridView(dgvDanhSachPhanCong);
        }

        /// <summary>
        /// Tải dữ liệu cho các ComboBox (Bác sĩ, Bệnh nhân, Vai trò).
        /// </summary>
        private void LoadComboBoxes()
        {
            // Tải và cấu hình ComboBox Bác sĩ
            cboBacSi.DataSource = bll.GetDoctors();
            cboBacSi.DisplayMember = "name"; // Hiển thị tên
            cboBacSi.ValueMember = "id"; // Giá trị thực là mã

            // Tải và cấu hình ComboBox Bệnh nhân
            cboBenhNhan.DataSource = bll.GetPatients();
            cboBenhNhan.DisplayMember = "fullName"; // Hiển thị tên
            cboBenhNhan.ValueMember = "id"; // Giá trị thực là mã

            // Tải dữ liệu tĩnh cho ComboBox Vai trò
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.AddRange(new string[] { "Khám chính", "Hội chẩn", "Điều trị", "Khám ngoại trú", "Khám nội trú" });

           
        }
        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào một ô trong DataGridView.
        /// Lấy dữ liệu từ hàng được chọn và hiển thị lên các control nhập liệu.
        /// </summary>
        private void dgvDanhSachPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo rằng người dùng click vào một hàng hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSachPhanCong.Rows.Count)
            {
                // Lấy ra hàng đang được chọn
                DataGridViewRow row = dgvDanhSachPhanCong.Rows[e.RowIndex];

                // Điền dữ liệu từ hàng vào các control tương ứng
                cboBacSi.SelectedValue = row.Cells["doctorID"].Value;
                cboBenhNhan.SelectedValue = row.Cells["patientID"].Value;
                dtpNgayBatDau.Value = Convert.ToDateTime(row.Cells["startDate"].Value);

                // Xử lý cho ngày kết thúc (có thể là null)
                if (row.Cells["endDate"].Value != null && row.Cells["endDate"].Value != DBNull.Value)
                {
                    dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["endDate"].Value);
                    dtpNgayKetThuc.Checked = true; // Check vào checkbox nếu có ngày
                }
                else
                {
                    dtpNgayKetThuc.Checked = false; // Bỏ check nếu không có ngày
                }
                cboVaiTro.Text = row.Cells["role"].Value.ToString();
                txtGhiChu.Text = row.Cells["note"].Value.ToString();
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút "Thêm".
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (cboBacSi.SelectedValue == null || cboBenhNhan.SelectedValue == null || string.IsNullOrWhiteSpace(cboVaiTro.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc (Bác sĩ, Bệnh nhân, Vai trò).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng DTO từ dữ liệu trên form
            DoctorPatientAdminDTO dp = new DoctorPatientAdminDTO
            {
                doctorID = cboBacSi.SelectedValue.ToString(),
                patientID = cboBenhNhan.SelectedValue.ToString(),
                startDate = dtpNgayBatDau.Value.Date, // Chỉ lấy ngày, bỏ qua giờ
                endDate = dtpNgayKetThuc.Checked ? (DateTime?)dtpNgayKetThuc.Value.Date : null, // Nếu checkbox được check thì lấy ngày, ngược lại là null
                role = cboVaiTro.Text,
                note = txtGhiChu.Text
            };

            // Gọi BLL để thực hiện thêm mới
            if (bll.Add(dp))
            {
                MessageBox.Show("Thêm phân công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView(); // Tải lại lưới dữ liệu

            }
            else
            {
                MessageBox.Show("Thêm thất bại. Phân công này có thể đã tồn tại hoặc ngày kết thúc không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút "Sửa".
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhanCong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cboVaiTro.Text))
            {
                MessageBox.Show("Vui lòng điền vai trò.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DoctorPatientAdminDTO dp = new DoctorPatientAdminDTO
            {
                doctorID = dgvDanhSachPhanCong.CurrentRow.Cells["doctorID"].Value.ToString(),
                patientID = dgvDanhSachPhanCong.CurrentRow.Cells["patientID"].Value.ToString(),
                startDate = Convert.ToDateTime(dgvDanhSachPhanCong.CurrentRow.Cells["startDate"].Value),
                endDate = dtpNgayKetThuc.Checked ? (DateTime?)dtpNgayKetThuc.Value.Date : null,
                role = cboVaiTro.Text,
                note = txtGhiChu.Text
            };
            if (bll.Update(dp))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                dgvDanhSachPhanCong.ClearSelection();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Ngày kết thúc có thể không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút "Xóa".
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhanCong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phân công này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string doctorId = dgvDanhSachPhanCong.CurrentRow.Cells["doctorID"].Value.ToString();
                string patientId = dgvDanhSachPhanCong.CurrentRow.Cells["patientID"].Value.ToString();
                DateTime startDate = Convert.ToDateTime(dgvDanhSachPhanCong.CurrentRow.Cells["startDate"].Value);
                if (bll.Delete(doctorId, patientId, startDate))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    dgvDanhSachPhanCong.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút "Làm Mới".
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields(); // Xóa trắng các ô nhập liệu
            LoadDataGridView(); // Tải lại dữ liệu mới nhất
        }

        /// <summary>
        /// Xử lý sự kiện click nút "Thoát".
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại
        }

        /// <summary>
        /// Xóa trắng và reset các control nhập liệu về trạng thái ban đầu.
        /// </summary>
        private void ClearFields()
        {
            cboBacSi.SelectedIndex = -1; // Bỏ chọn ComboBox
            cboBenhNhan.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Now; // Đặt lại ngày về hiện tại
            dtpNgayKetThuc.Value = DateTime.Now;
            dtpNgayKetThuc.Checked = false; // Bỏ check ngày kết thúc
            cboVaiTro.SelectedIndex = -1;
            cboVaiTro.Text = ""; // Xóa text của ComboBox có thể nhập
            txtGhiChu.Clear(); // Xóa TextBox
            cboBacSi.Focus(); // Di chuyển con trỏ về ComboBox Bác sĩ
        }

        /// <summary>
        /// Áp dụng các style tùy chỉnh cho DataGridView để có giao diện đẹp hơn.
        /// </summary>
        /// <param name="dgv">DataGridView cần áp dụng style.</param>
        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(245, 248, 250);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.MediumSeaGreen;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 60, 90);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 253, 255);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.RowTemplate.Height = 28;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
        }

    }
}
