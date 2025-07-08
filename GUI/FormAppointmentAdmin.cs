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
    public partial class FormAppointmentAdmin : Form
    {
        public FormAppointmentAdmin()
        {
            InitializeComponent();
        }
        AppointmentBLL bll = new AppointmentBLL();

        private void FormAppointmentAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDepartments();
            LoadPatients();

            cboDepartment.SelectedIndexChanged += cboDepartment_SelectedIndexChanged;
            StyleDataGridView(dgvAppointment);
            StyleDataGridView(dgvPatient);
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
        private void LoadPatients()
        {
            var patients = bll.GetAllPatients();

            cboPatient.DataSource = patients;
            cboPatient.DisplayMember = "FullName"; // ✅
            cboPatient.ValueMember = "Id";         // ✅ đúng với DTO.Id

            cboPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPatient.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var auto = new AutoCompleteStringCollection();
            auto.AddRange(patients.Select(p => p.FullName).ToArray());
            cboPatient.AutoCompleteCustomSource = auto;

            cboPatient.SelectedIndex = -1;
            cboPatient.Text = "";
        }
        private List<StaffSupplyHistoryDTO> currentNurseList = new List<StaffSupplyHistoryDTO>();
        private void LoadDepartments()
        {
            var departments = bll.GetDepartments();
            cboDepartment.DataSource = departments;
            cboDepartment.DisplayMember = "DepartmentName";
            cboDepartment.ValueMember = "Id";
            cboDepartment.SelectedIndex = -1;
        }
        private void LoadData()
        {
            dgvAppointment.DataSource = bll.GetAll();
        }
        private string originalPatientId = "";
        private string originalNurseId = "";
        private int selectedId = -1; // -1: chưa chọn gì

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string doctorName = cboNurse.Text.Trim();
            string note = txtNote.Text.Trim();
            string status = cboStatus.Text.Trim();
            DateTime startDate = dtpDateofExamination.Value;

            if (string.IsNullOrWhiteSpace(doctorName) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedDoctor = currentNurseList
                .FirstOrDefault(n => n.Name.Equals(doctorName, StringComparison.OrdinalIgnoreCase));

            if (selectedDoctor == null)
            {
                MessageBox.Show("VUI lòng chọn bác sĩ hoặc không tìm thấy bác sĩ với tên đã nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string doctorId = selectedDoctor.Id;

            if (!bll.CheckDoctorExists(doctorId))
            {
                MessageBox.Show("Không tìm thấy bác sĩ có mã: " + doctorId, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Lấy patient ID từ ComboBox
            string patientId = cboPatient.SelectedValue?.ToString();

            if (string.IsNullOrWhiteSpace(patientId))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân hợp lệ từ danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!bll.CheckPatientExists(patientId))
            {
                MessageBox.Show("Không tìm thấy bệnh nhân với mã: " + patientId, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startDate.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày khám không được nhỏ hơn ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dto = new AppointmentDTO
            {
                StartDate = startDate,
                Note = note,
                Status = status,
                DoctorID = doctorId,
                PatientID = patientId
            };

            try
            {
                bll.Add(dto);
                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại! Lỗi: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string note = txtNote.Text.Trim();
            string status = cboStatus.Text.Trim();
            DateTime startDate = dtpDateofExamination.Value;

            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Vui lòng cập nhật trạng thái.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // ✅ Không được thay đổi PatientID
            string selectedPatientId = cboPatient.SelectedValue?.ToString();
            if (!string.Equals(selectedPatientId, originalPatientId, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được thay đổi bệnh nhân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Không được thay đổi DoctorID
            string selectedDoctorId = cboNurse.SelectedValue?.ToString();
            // Kiểm tra đổi bác sĩ (DoctorID)
            if (!string.IsNullOrWhiteSpace(cboNurse.Text) &&
                selectedDoctorId != null &&
                !string.Equals(selectedDoctorId, originalNurseId, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được thay đổi bác sĩ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dto = new AppointmentDTO
            {
                Id = selectedId,
                StartDate = startDate,
                Note = note,
                Status = status,
                DoctorID = originalNurseId,
                PatientID = originalPatientId
            };

            try
            {
                bll.Update(dto);
                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại! Lỗi: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn bản ghi để xoá.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bll.Delete(selectedId);
                    MessageBox.Show("Xoá thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xoá thất bại! Lỗi: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string doctorId = cboNurse.SelectedValue?.ToString();
            string patientId = cboPatient.SelectedValue?.ToString();
            string startDate = dtpDateofExamination.Value.ToString("yyyy-MM-dd");
            string statust = cboStatus.Text;

            var result = bll.Search(doctorId, patientId, startDate,statust);
            dgvAppointment.DataSource = result;
        }

        private void dgvAppointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAppointment.Rows[e.RowIndex];
                var dto = row.DataBoundItem as AppointmentDTO;
                if (dto == null) return;

                selectedId = dto.Id;
                txtNote.Text = dto.Note;
                cboStatus.Text = dto.Status;
                dtpDateofExamination.Value = dto.StartDate;

                originalPatientId = string.IsNullOrWhiteSpace(dto.PatientID) ? null : dto.PatientID.Trim();
                originalNurseId = string.IsNullOrWhiteSpace(dto.DoctorID) ? null : dto.DoctorID.Trim();

                // 🔄 Load bệnh nhân
                if (!string.IsNullOrEmpty(originalPatientId))
                {
                    if (cboPatient.DataSource == null || cboPatient.Items.Count == 0)
                        LoadPatients();

                    cboPatient.SelectedValue = originalPatientId;

                    if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != originalPatientId)
                    {
                        var pat = bll.GetAllPatients().FirstOrDefault(p => p.Id == originalPatientId);
                        cboPatient.Text = pat?.FullName ?? "";
                    }
                }
                else
                {
                    cboPatient.SelectedIndex = -1;
                    cboPatient.Text = "";
                }

                string doctorDeptId = bll.GetDepartmentIdByStaffId(originalNurseId);

                if (!string.IsNullOrEmpty(doctorDeptId))
                {
                    isLoadingDoctor = true;
                    cboDepartment.SelectedValue = doctorDeptId;
                    isLoadingDoctor = false;

                    // Gọi load bác sĩ trực tiếp
                    LoadDoctorsByDepartment(doctorDeptId, originalNurseId);
                }
                else
                {
                    cboDepartment.SelectedIndex = -1;
                    cboNurse.DataSource = null;
                    cboNurse.Text = "";
                }

            }
        }
        private void ClearFields()
        {
            txtNote.Clear();
            cboStatus.SelectedIndex = 0; // Bỏ chọn combobox
            dtpDateofExamination.Value = DateTime.Now; // Đặt lại ngày giờ hiện tại

            selectedId = -1; // Reset ID đang chọn để tránh sửa nhầm
            cboNurse.SelectedIndex = -1;
            cboPatient.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
            cboDepartment.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingDoctor) return;

            if (cboDepartment.SelectedIndex >= 0)
            {
                string departmentId = cboDepartment.SelectedValue.ToString();
                LoadDoctorsByDepartment(departmentId); // 👍 Dùng hàm chung
            }
        }
        private bool isLoadingDoctor = false; // Cờ khóa xử lý khi đang load từ CellClick

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
            string keyword = cboPatient.Text.Trim().ToLower();

            var allPatients = bll.GetAllPatients();
            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? allPatients
                : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();

            dgvPatient.DataSource = filtered;
        }
        private void LoadDoctorsByDepartment(string departmentId, string selectedDoctorId = null)
        {
            currentNurseList = bll.GetNursesByDepartment(departmentId);

            cboNurse.DataSource = null;
            cboNurse.DataSource = currentNurseList;
            cboNurse.DisplayMember = "Name";
            cboNurse.ValueMember = "Id";

            // AutoComplete
            cboNurse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNurse.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(currentNurseList.Select(n => n.Name).ToArray());
            cboNurse.AutoCompleteCustomSource = autoSource;

            // Chọn bác sĩ nếu có
            if (!string.IsNullOrEmpty(selectedDoctorId))
            {
                cboNurse.SelectedValue = selectedDoctorId;

                if (cboNurse.SelectedValue == null || cboNurse.SelectedValue.ToString() != selectedDoctorId)
                {
                    var doctor = currentNurseList.FirstOrDefault(d => d.Id == selectedDoctorId);
                    cboNurse.Text = doctor?.Name ?? "";
                }
            }
            else
            {
                cboNurse.SelectedIndex = -1;
                cboNurse.Text = "";
            }
        }
    }
}
