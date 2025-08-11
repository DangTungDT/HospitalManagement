using BLL;
using DAL;
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
    public partial class frmTaskAssignmentGUI : Form
    {
        public frmTaskAssignmentGUI(string nurseId)
        {
            InitializeComponent();
            this.nurseId = nurseId;
        }
        private NurseAssignmentNurseBLL bll = new NurseAssignmentNurseBLL();
        private string nurseId; // Lấy từ form login
        private void LoadData()
        {
            dgvAssignments.DataSource = bll.GetAssignmentsInSameDepartment(nurseId);

            dgvAssignments.Columns["DoctorID"].HeaderText = "Mã bác sĩ/y tá";
            dgvAssignments.Columns["PatientID"].HeaderText = "Mã bệnh nhân";
            dgvAssignments.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
            dgvAssignments.Columns["EndDate"].HeaderText = "Ngày kết thúc";
            dgvAssignments.Columns["Role"].HeaderText = "Vai trò";
            dgvAssignments.Columns["Note"].HeaderText = "Ghi chú";
            dgvAssignments.Columns["DoctorName"].HeaderText = "Tên y tá";
            dgvAssignments.Columns["PatientName"].HeaderText = "Tên bệnh nhân";
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;

            // Màu nền nhẹ dịu (xanh nhạt)
            Color nurseBackground = Color.FromArgb(230, 245, 255);
            this.BackColor = nurseBackground;
            e.Graphics.Clear(nurseBackground);

            Pen thickPen = new Pen(Color.RoyalBlue, 2);
            Brush textBrush = new SolidBrush(Color.RoyalBlue);

            Font font = box.Font;
            string text = box.Text;
            SizeF textSize = e.Graphics.MeasureString(text, font);

            int textPadding = 10;
            int textWidth = (int)textSize.Width + textPadding * 2;

            Rectangle borderRect = new Rectangle(
                0,
                (int)(textSize.Height / 2),
                box.Width - 1,
                box.Height - (int)(textSize.Height / 2) - 1
            );

            e.Graphics.DrawRectangle(thickPen, borderRect);

            e.Graphics.FillRectangle(
                new SolidBrush(nurseBackground),
                new Rectangle(textPadding, 0, textWidth, (int)textSize.Height)
            );

            e.Graphics.DrawString(text, font, textBrush, textPadding, 0);

            // Chỉ đổi màu chữ cho các control không phải TextBox
            foreach (Control ctrl in box.Controls)
            {
                if (!(ctrl is TextBox))
                {
                    ctrl.ForeColor = Color.RoyalBlue;
                }
            }
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;

            // Màu nền nhẹ dịu (xanh nhạt)
            Color nurseBackground = Color.FromArgb(230, 245, 255);
            this.BackColor = nurseBackground;
            e.Graphics.Clear(nurseBackground);

            Pen thickPen = new Pen(Color.RoyalBlue, 2);
            Brush textBrush = new SolidBrush(Color.RoyalBlue);

            Font font = box.Font;
            string text = box.Text;
            SizeF textSize = e.Graphics.MeasureString(text, font);

            int textPadding = 10;
            int textWidth = (int)textSize.Width + textPadding * 2;

            Rectangle borderRect = new Rectangle(
                0,
                (int)(textSize.Height / 2),
                box.Width - 1,
                box.Height - (int)(textSize.Height / 2) - 1
            );

            e.Graphics.DrawRectangle(thickPen, borderRect);

            e.Graphics.FillRectangle(
                new SolidBrush(nurseBackground),
                new Rectangle(textPadding, 0, textWidth, (int)textSize.Height)
            );

            e.Graphics.DrawString(text, font, textBrush, textPadding, 0);

            // Chỉ đổi màu chữ cho các control không phải TextBox
            foreach (Control ctrl in box.Controls)
            {
                if (!(ctrl is TextBox))
                {
                    ctrl.ForeColor = Color.RoyalBlue;
                }
            }
        }
        private void LoadPatientsForDoctor(string doctorId)
        {
            MedicalOrderDoctorBLL bll = new MedicalOrderDoctorBLL();
            var patients = bll.GetPatientsByDoctorDepartment(doctorId);

            // Hiển thị tên bệnh nhân
            cboPatient.DataSource = patients;
            cboPatient.DisplayMember = "FullName"; // ✅ Đúng với DTO
            cboPatient.ValueMember = "Id";         // ✅ Đúng với DTO
            cboPatient.SelectedIndex = -1;

            // Tìm kiếm gợi ý
            cboPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPatient.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoCompleteSource = new AutoCompleteStringCollection();
            autoCompleteSource.AddRange(patients.Select(p => p.FullName).ToArray());
            cboPatient.AutoCompleteCustomSource = autoCompleteSource;

            // Load vào DataGridView
            dgvPatient.AutoGenerateColumns = true;
            dgvPatient.DataSource = patients;

            CustomizePatientGrid();
        }


        private void CustomizePatientGrid()
        {
            if (dgvPatient.Columns.Count == 0) return;

            // Đổi tên cột sang tiếng Việt
            dgvPatient.Columns["Id"].HeaderText = "Mã BN";
            dgvPatient.Columns["FullName"].HeaderText = "Họ tên";
            dgvPatient.Columns["Gender"].HeaderText = "Giới tính";
            dgvPatient.Columns["Dob"].HeaderText = "Ngày sinh";
            dgvPatient.Columns["PhoneNumber"].HeaderText = "SĐT";
            dgvPatient.Columns["Status"].HeaderText = "Trạng thái";

            // Ẩn cột không cần thiết (nếu có thêm trường khác trong DTO)
            foreach (DataGridViewColumn col in dgvPatient.Columns)
            {
                if (!new[] { "Id", "FullName", "Gender", "Dob", "PhoneNumber", "Status" }.Contains(col.Name))
                {
                    col.Visible = false;
                }
            }
        }
        private void frmTaskAssignmentGUI_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgvAssignments);
            LoadData();
            LoadNurseComboBox(nurseId);
            LoadPatientsForDoctor(nurseId);
            StyleDataGridView(dgvPatient);
            //LoadSearchComboboxes();
        }
       

        private void LoadNurseComboBox(string loggedInNurseId)
        {
            // Lấy danh sách y tá cùng khoa
            var nurses = bll.GetNursesInSameDepartment(loggedInNurseId);

            cboDoctor.DataSource = nurses;
            cboDoctor.DisplayMember = "DoctorName"; // Hiển thị tên y tá
            cboDoctor.ValueMember = "DoctorID";     // Lấy ID khi chọn
            cboDoctor.SelectedIndex = -1;

            // ✅ Thiết lập tìm kiếm gần đúng cho cboDoctor
            cboDoctor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDoctor.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoCompleteNurse = new AutoCompleteStringCollection();
            autoCompleteNurse.AddRange(nurses.Select(n => n.DoctorName).ToArray());
            cboDoctor.AutoCompleteCustomSource = autoCompleteNurse;
        }
        private void StyleDataGridView(DataGridView dgv)
        {
            // Nền tổng thể (hơi xám xanh, khác biệt với form xanh nhạt)
            dgv.BackgroundColor = Color.FromArgb(245, 248, 250); // Nhạt nhưng hơi xám -> tạo tách biệt

            // Viền & ô
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // 👉 Đổi màu đường phân cách giữa các ô (hàng dữ liệu)
            dgv.GridColor = Color.MediumSeaGreen; // Xanh lá dễ nhìn

            // Header
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;  // đậm hơn RoyalBlue
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Dữ liệu
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 60, 90); // Xanh navy nhẹ
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255); // xanh pastel khi chọn
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Hàng xen kẽ
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 253, 255); // Trắng-xanh nhạt sát trắng

            // Căn lề
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Kích thước dòng + kiểu fill
            dgv.RowTemplate.Height = 28;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime today = DateTime.Today;

                // Kiểm tra ngày bắt đầu
                if (dtpStartDate.Value.Date < today)
                {
                    MessageBox.Show("Ngày bắt đầu phải lớn hơn hoặc bằng ngày hôm nay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra bắt buộc chọn bác sĩ
                if (cboDoctor.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn y tá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra bắt buộc chọn bệnh nhân
                if (cboPatient.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn bệnh nhân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra bắt buộc chọn vai trò
                if (cboRole.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn vai trò!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (bll.IsDoctorPatientExists(cboDoctor.SelectedValue.ToString(), cboPatient.SelectedValue.ToString() ,today))
                {
                    MessageBox.Show("Bệnh nhân này đã được phân công cho bác sĩ trong ngày hôm nay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NurseAssignmentNurseDTO dto = new NurseAssignmentNurseDTO
                {
                    DoctorID = cboDoctor.SelectedValue.ToString(),
                    PatientID = cboPatient.SelectedValue.ToString(),
                    StartDate = dtpStartDate.Value.Date,
                    EndDate = null, // Mặc định null khi thêm mới
                    Role = cboRole.SelectedItem.ToString(),
                    Note = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim()
                };

                if (bll.AddAssignment(dto))
                {
                    MessageBox.Show("Thêm phân công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAssignments.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn phân công cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow row = dgvAssignments.CurrentRow;

                string doctorId = row.Cells["DoctorID"].Value?.ToString();
                string patientId = row.Cells["PatientID"].Value?.ToString();
                DateTime startDate = Convert.ToDateTime(row.Cells["StartDate"].Value);

                DialogResult confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa phân công của bác sĩ {doctorId} cho bệnh nhân {patientId} không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    if (bll.DeleteAssignment(doctorId, patientId, startDate))
                    {
                        MessageBox.Show("Xóa phân công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa phân công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAssignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAssignments.Rows[e.RowIndex];

                // Lưu thông tin gốc để kiểm tra khi update
                selectedDoctorId = row.Cells["DoctorID"].Value?.ToString();
                selectedPatientId = row.Cells["PatientID"].Value?.ToString();
                selectedStartDate = Convert.ToDateTime(row.Cells["StartDate"].Value);

                // Gán cho combo Y tá
                string doctorName = row.Cells["DoctorName"].Value?.ToString();
                cboDoctor.SelectedValue = selectedDoctorId;
                if (cboDoctor.SelectedValue == null || cboDoctor.SelectedValue.ToString() != selectedDoctorId)
                {
                    cboDoctor.Text = doctorName;
                }

                // Gán cho combo Bệnh nhân
                string patientName = row.Cells["PatientName"].Value?.ToString();
                cboPatient.SelectedValue = selectedPatientId;
                if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != selectedPatientId)
                {
                    cboPatient.Text = patientName;
                }

                // Gán vai trò
                if (row.Cells["Role"].Value != null)
                    cboRole.SelectedItem = row.Cells["Role"].Value.ToString();

                // Ngày bắt đầu
                dtpStartDate.Value = selectedStartDate;

                // Ngày kết thúc
                if (row.Cells["EndDate"].Value != null && DateTime.TryParse(row.Cells["EndDate"].Value.ToString(), out DateTime endDate))
                    dtpEndDate.Value = endDate;
                else
                    dtpEndDate.Checked = false;

                // Ghi chú
                txtNotes.Text = row.Cells["Note"].Value?.ToString() ?? "";

                // Khóa các trường không được sửa
                cboDoctor.Enabled = false;
                cboPatient.Enabled = false;
                dtpStartDate.Enabled = false;
            }
        }
        private DateTime selectedStartDate; // Lưu StartDate gốc để kiểm tra khi update
        private string selectedDoctorId = null;
        private string selectedPatientId = null;

        MedicalOrderDoctorBLL blla = new MedicalOrderDoctorBLL();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedNurseId = cboDoctor.SelectedValue?.ToString();
            string selectedPatientId = cboPatient.SelectedValue?.ToString();

            var list = bll.SearchAssignmentsByNurseAndPatient(selectedNurseId, selectedPatientId);

            if (list.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phân công phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvAssignments.DataSource = list;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Phải chọn từ DataGridView
            if (string.IsNullOrEmpty(selectedDoctorId) || string.IsNullOrEmpty(selectedPatientId))
            {
                MessageBox.Show("Vui lòng chọn phân công từ danh sách trước khi cập nhật!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ngày bắt đầu không được thay đổi
            if (dtpStartDate.Value != selectedStartDate)
            {
                MessageBox.Show("Không được thay đổi ngày bắt đầu!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra ngày kết thúc
            DateTime? endDate = dtpEndDate.Checked ? dtpEndDate.Value : (DateTime?)null;
            if (endDate.HasValue && endDate.Value < selectedStartDate)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dto = new NurseAssignmentNurseDTO
            {
                DoctorID = selectedDoctorId,
                PatientID = selectedPatientId,
                StartDate = selectedStartDate,
                EndDate = endDate,
                Role = cboRole.SelectedItem?.ToString(),
                Note = txtNotes.Text
            };

            bool result = bll.UpdateAssignment(dto);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Refresh lại dữ liệu
                ClearFields();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            // Reset combobox
            cboDoctor.SelectedIndex = -1;
            cboPatient.SelectedIndex = -1;
            cboRole.SelectedIndex = -1;

            // Mở khóa combobox
            cboDoctor.Enabled = true;
            cboPatient.Enabled = true;
            dtpStartDate.Enabled = true;

            // Reset date
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            dtpEndDate.Checked = false; // Bỏ chọn nếu muốn để trống

            // Xóa text
            txtNotes.Clear();

            // Xóa biến lưu selection
            selectedDoctorId = null;
            selectedPatientId = null;
            selectedStartDate = DateTime.MinValue;

            // Nếu muốn focus vào control đầu tiên
            cboDoctor.Focus();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var patient = dgvPatient.Rows[e.RowIndex].DataBoundItem as PatientSupplyHistoryDTO;
                if (patient != null)
                {
                    cboPatient.SelectedValue = patient.Id;

                    if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != patient.Id)
                    {
                        // fallback nếu không tìm được
                        cboPatient.Text = patient.FullName;
                    }
                }
            }
        }

        private void cboPatient_TextChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                string keyword = cboPatient.Text.Trim().ToLower();
                var allPatients = blla.GetPatientsByDoctorDepartment(nurseId);
                var filtered = string.IsNullOrWhiteSpace(keyword)
                    ? allPatients
                    : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();
                dgvPatient.DataSource = filtered;
            }));
        }
    }
}
