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
    public partial class frmDailyCareGUI : Form
    {
        public frmDailyCareGUI(string doctorId)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            LoadPatientsForDoctor(doctorId);
            LoadSearchComboboxes();
        }
        private string doctorId;
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
        MedicalOrderDoctorBLL blla = new MedicalOrderDoctorBLL();
        private void LoadSearchComboboxes()
        {
            // Lấy danh sách bệnh nhân theo khoa của bác sĩ
            var patients = blla.GetPatientsByDoctorDepartment(doctorId);
            cboPatient.DataSource = patients;
            cboPatient.DisplayMember = "FullName"; // ✅ đúng tên property viết hoa
            cboPatient.ValueMember = "Id";
            cboPatient.SelectedIndex = -1;

            // ✅ Thiết lập tìm kiếm gần đúng cho cboPatient
            cboPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPatient.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoCompletePatient = new AutoCompleteStringCollection();
            autoCompletePatient.AddRange(patients.Select(p => p.FullName).ToArray());
            cboPatient.AutoCompleteCustomSource = autoCompletePatient;

            // Lấy danh sách phòng theo khoa
            var rooms = blla.GetRoomsByDoctorDepartment(doctorId);
            cboRoom.DataSource = rooms;
            cboRoom.DisplayMember = "RoomName";
            cboRoom.ValueMember = "Id";
            cboRoom.SelectedIndex = -1;

            // ✅ Thiết lập tìm kiếm gần đúng cho cboRoom
            cboRoom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboRoom.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoCompleteRoom = new AutoCompleteStringCollection();
            autoCompleteRoom.AddRange(rooms.Select(r => r.RoomName).ToArray());
            cboRoom.AutoCompleteCustomSource = autoCompleteRoom;
        }

        private void frmDailyCareGUI_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgvUsers);
            StyleDataGridView(dgvPatient);
            LoadData();
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
        DailyCareBLL bll = new DailyCareBLL();
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string shift = cboShift.Text.Trim();
            string bloodPressure = txtBloodPressure.Text.Trim();
            string tempText = txtTemperature.Text.Trim();
            string pulseText = txtCircuit.Text.Trim();
            string note = txtNote.Text.Trim();

            // ✅ Nurse là trưởng khoa đang đăng nhập
            string nurseId = doctorId; // <-- biến này phải được gán khi đăng nhập
            DateTime careDate = DateTime.Today;

            string patientID = cboPatient.SelectedValue?.ToString();
            int? roomId = cboRoom.SelectedValue as int?;

            if (string.IsNullOrWhiteSpace(patientID) || !roomId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân và phòng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(bloodPressure) ||
                string.IsNullOrWhiteSpace(tempText) ||
                string.IsNullOrWhiteSpace(pulseText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tempText, out decimal bodyTemperature))
            {
                MessageBox.Show("Nhiệt độ phải là số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(pulseText, out int pulseRate))
            {
                MessageBox.Show("Mạch phải là số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dto = new DailyCareDTO
            {
                Shift = shift,
                BloodPressure = bloodPressure,
                BodyTempearature = bodyTemperature,
                PulseRate = pulseRate,
                Note = note,
                PatientID = patientID,
                RoomID = roomId.Value,
                NurseID = nurseId,
                DateCare = careDate
            };

            try
            {
                bll.AddDailyCareByNurse(dto, doctorId);
                MessageBox.Show("Thêm chăm sóc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int selectedId;
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["Id"].Value);

                // Gán dữ liệu cơ bản
                cboShift.Text = row.Cells["Shift"].Value?.ToString();
                txtBloodPressure.Text = row.Cells["BloodPressure"].Value?.ToString();
                txtTemperature.Text = row.Cells["BodyTempearature"].Value?.ToString();
                txtCircuit.Text = row.Cells["PulseRate"].Value?.ToString();
                txtNote.Text = row.Cells["Note"].Value?.ToString();

                // ✅ Gán bệnh nhân
                string patientId = row.Cells["PatientID"].Value?.ToString();
                string patientName = row.Cells["PatientName"].Value?.ToString(); // Giả sử có cột này

                cboPatient.SelectedValue = patientId;
                if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != patientId)
                {
                    cboPatient.Text = patientName; // fallback nếu không tìm thấy trong list
                }

                // ✅ Gán phòng
                int roomId = Convert.ToInt32(row.Cells["RoomID"].Value);
                string roomName = row.Cells["RoomName"].Value?.ToString(); // Giả sử có cột này

                cboRoom.SelectedValue = roomId;
                if (cboRoom.SelectedValue == null || (int)cboRoom.SelectedValue != roomId)
                {
                    cboRoom.Text = roomName;
                }

                // ❌ Không cho sửa bệnh nhân và phòng
                cboPatient.Enabled = false;
                cboRoom.Enabled = false;
            }
        }
        private void LoadData()
        {
            try
            {
                var data = bll.GetDailyCaresByDepartment(doctorId); // doctorId là nurse đang đăng nhập
                dgvUsers.DataSource = data;
                // Tùy chỉnh tên cột hiển thị nếu cần
                dgvUsers.Columns["Id"].Visible = false;
                dgvUsers.Columns["PatientID"].Visible = false;
                dgvUsers.Columns["RoomID"].Visible = false;
                dgvUsers.Columns["NurseID"].Visible = false;

                dgvUsers.Columns["PatientName"].HeaderText = "Bệnh nhân";
                dgvUsers.Columns["RoomName"].HeaderText = "Phòng";
                dgvUsers.Columns["NurseName"].HeaderText = "Y tá";
                dgvUsers.Columns["Shift"].HeaderText = "Ca";
                dgvUsers.Columns["BloodPressure"].HeaderText = "Huyết áp";
                dgvUsers.Columns["BodyTempearature"].HeaderText = "Nhiệt độ";
                dgvUsers.Columns["PulseRate"].HeaderText = "Mạch";
                dgvUsers.Columns["DateCare"].HeaderText = "Ngày chăm sóc";
                dgvUsers.Columns["Note"].HeaderText = "Ghi chú";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            cboShift.SelectedIndex = -1;
            txtBloodPressure.Clear();
            txtTemperature.Clear();
            txtCircuit.Clear();
            txtNote.Clear();
            cboPatient.SelectedIndex = -1;
            cboRoom.SelectedIndex = -1;
            dgvUsers.ClearSelection();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string shift = cboShift.Text.Trim();
            string bloodPressure = txtBloodPressure.Text.Trim();
            string tempText = txtTemperature.Text.Trim();
            string pulseText = txtCircuit.Text.Trim();
            string note = txtNote.Text.Trim();

            string patientID = cboPatient.SelectedValue?.ToString();
            int? roomId = cboRoom.SelectedValue as int?;

            if (string.IsNullOrWhiteSpace(bloodPressure) ||
                string.IsNullOrWhiteSpace(tempText) ||
                string.IsNullOrWhiteSpace(pulseText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tempText, out decimal bodyTemperature))
            {
                MessageBox.Show("Nhiệt độ phải là số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(pulseText, out int pulseRate))
            {
                MessageBox.Show("Mạch phải là số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dto = new DailyCareDTO
            {
                Id = selectedId,
                Shift = shift,
                BloodPressure = bloodPressure,
                BodyTempearature = bodyTemperature,
                PulseRate = pulseRate,
                Note = note,
                RoomID = roomId ?? 0, // đảm bảo không null
                DateCare = DateTime.Today
            };

            try
            {
                bll.UpdateDailyCareByNurse(dto, doctorId);
                MessageBox.Show("Cập nhật chăm sóc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPatient_TextChanged(object sender, EventArgs e)
        {
            string keyword = cboPatient.Text.Trim().ToLower();

            var allPatients = blla.GetPatientsByDoctorDepartment(doctorId);
            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? allPatients
                : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();

            dgvPatient.DataSource = filtered;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    bll.Delete(selectedId);
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
            cboPatient.Enabled = true;
            cboRoom.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string patientId = cboPatient.SelectedValue?.ToString() ?? "";
                string roomId = cboRoom.SelectedValue?.ToString() ?? "";
                string shift = cboShift.SelectedItem?.ToString() ?? "";

                // Gọi BLL (lưu ý dùng đúng tên hàm thật ở BLL của bạn)
                List<DailyCareDTO> results = bll.SearchDailyCaresByDepartment(doctorId, patientId, roomId, shift);

                if (results.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvUsers.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnDailyCaresOfPatient_Click(object sender, EventArgs e)
        {
            string selectedPatientId = null;

            // Kiểm tra ComboBox đã chọn
            if (cboPatient.Items.Count == 0 || cboPatient.SelectedIndex == -1 || cboPatient.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID bệnh nhân từ ComboBox
            selectedPatientId = cboPatient.SelectedValue.ToString();

            // (Không bắt buộc) Ưu tiên lấy từ DataGridView nếu có
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var row = dgvUsers.SelectedRows[0].DataBoundItem as DailyCareDTO;
                if (row != null)
                {
                    selectedPatientId = row.PatientID;
                }
            }

            // Kiểm tra lần cuối
            if (string.IsNullOrEmpty(selectedPatientId))
            {
                MessageBox.Show("Không thể xác định bệnh nhân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mở form mới chỉ truyền mã bệnh nhân
            frmDailyCaresOfPatientNurseGUI frm = new frmDailyCaresOfPatientNurseGUI(selectedPatientId);
            frm.ShowDialog();
        }

        private void btnDailyCaresInSameDepartmentAsDoctorAndDate_Click(object sender, EventArgs e)
        {
            FormDailyCarePainetNurseGUI frm = new FormDailyCarePainetNurseGUI(doctorId);
            frm.ShowDialog();
        }

        private void cboPatient_EnabledChanged(object sender, EventArgs e)
        {

        }
    }
}
