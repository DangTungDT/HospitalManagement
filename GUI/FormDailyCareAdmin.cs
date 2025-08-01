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
    public partial class FormDailyCareAdmin : Form
    {
        public FormDailyCareAdmin()
        {
            InitializeComponent();
        }
        DailyCareBLL bll = new DailyCareBLL();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string shift = cboShift.Text.Trim();
            string bloodPressure = txtBloodPressure.Text.Trim();
            string tempText = txtTemperature.Text.Trim();
            string pulseText = txtCircuit.Text.Trim();
            string note = txtNote.Text;

            string nurseName = cboNurse.Text.Trim();
            var selectedNurse = currentNurseList
                .FirstOrDefault(n => n.Name.Equals(nurseName, StringComparison.OrdinalIgnoreCase));

            // ✅ Lấy RoomID từ ComboBox
            int? roomId = cboRoom.SelectedValue as int?;

            // ✅ Lấy PatientID từ ComboBox
            string patientID = cboPatient.SelectedValue?.ToString();

            // ⚠ Kiểm tra hợp lệ của bệnh nhân
            if (cboPatient.SelectedValue == null && !string.IsNullOrWhiteSpace(cboPatient.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân hợp lệ từ danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedNurse == null)
            {
                MessageBox.Show("Không được để trống y tá hoặc không tìm thấy y tá với tên đã nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nurseId = selectedNurse.Id;

            if (!bll.CheckNurseExists(nurseId))
            {
                MessageBox.Show("Y tá không hợp lệ hoặc không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ⚠ Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(bloodPressure) ||
                string.IsNullOrWhiteSpace(tempText) || string.IsNullOrWhiteSpace(pulseText) || !roomId.HasValue)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tempText, out decimal bodyTemperature))
            {
                MessageBox.Show("Nhiệt độ phải là một số hợp lệ (VD: 36.5).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(pulseText, out int pulseRate))
            {
                MessageBox.Show("Mạch phải là một số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!bll.CheckPatientExists(patientID))
            {
                MessageBox.Show("Không tìm thấy bệnh nhân với mã: " + patientID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!bll.CheckRoomExists(roomId.Value))
            {
                MessageBox.Show("Không tìm thấy phòng với mã: " + roomId, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                NurseID = nurseId
            };

            try
            {
                bll.Add(dto);
                MessageBox.Show("Thêm dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            cboShift.SelectedIndex = 0;
            txtBloodPressure.Clear();
            txtTemperature.Clear();
            txtCircuit.Clear();
            txtNote.Clear();
            cboNurse.SelectedIndex = -1;
            cboDepartment.SelectedIndex = -1;
            cboRoom.SelectedIndex = -1;
            cboPatient.SelectedIndex = -1;
            selectedId = -1;
            cboShift.SelectedIndex = -1;
        }

        private void LoadData()
        {
            dgvDailyCare.DataSource = bll.GetAll();
        }
        private List<StaffSupplyHistoryDTO> currentNurseList = new List<StaffSupplyHistoryDTO>();
        private void FormDailyCareAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
            cboShift.SelectedIndex = -1;
            LoadDepartments();
            LoadRooms();     // ✅ Gọi để nạp phòng
            LoadPatients();  // ✅ Gọi để nạp bệnh nhân

            cboDepartment.SelectedIndexChanged += cboDepartment_SelectedIndexChanged;
            cboNurse.TextChanged += cboNurse_TextChanged;
            StyleDataGridView(dgvDailyCare);
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

        private void LoadRooms()
        {
            var rooms = bll.GetAllRooms();
            cboRoom.DataSource = rooms;
            cboRoom.DisplayMember = "RoomName";
            cboRoom.ValueMember = "Id";

            cboRoom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboRoom.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var auto = new AutoCompleteStringCollection();
            auto.AddRange(rooms.Select(r => r.RoomName).ToArray());
            cboRoom.AutoCompleteCustomSource = auto;

            cboRoom.SelectedIndex = -1;
            cboRoom.Text = "";
        }
        private void LoadDepartments()
        {
            var departments = bll.GetDepartments();
            cboDepartment.DataSource = departments;
            cboDepartment.DisplayMember = "DepartmentName";
            cboDepartment.ValueMember = "Id";
            cboDepartment.SelectedIndex = -1;
        }
        private int selectedId = -1; // -1: chưa chọn gì
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần sửa từ bảng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string shift = cboShift.Text.Trim();
            string bloodPressure = txtBloodPressure.Text.Trim();
            string tempText = txtTemperature.Text.Trim();
            string pulseText = txtCircuit.Text.Trim();
            string note = txtNote.Text.Trim();

            // 👉 Lấy từ ComboBox bệnh nhân
            string patientId = cboPatient.SelectedValue?.ToString();

            // 👉 Lấy từ ComboBox phòng
            int? roomId = cboRoom.SelectedValue as int?;

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(bloodPressure) ||
                string.IsNullOrWhiteSpace(tempText) || string.IsNullOrWhiteSpace(pulseText) | !roomId.HasValue)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để cập nhật.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tempText, out decimal bodyTemperature))
            {
                MessageBox.Show("Nhiệt độ phải là một số hợp lệ (VD: 36.5).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(pulseText, out int pulseRate))
            {
                MessageBox.Show("Mạch phải là số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!bll.CheckRoomExists(roomId.Value))
            {
                MessageBox.Show("Không tìm thấy phòng với mã: " + roomId, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Không cho thay đổi bệnh nhân
            if (!string.Equals(patientId, originalPatientId, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được thay đổi bệnh nhân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ✅ Lấy NurseID từ SelectedValue
            string selectedNurseId = cboNurse.SelectedValue?.ToString()?.Trim();

            if (!string.IsNullOrWhiteSpace(cboNurse.Text) &&
                selectedNurseId != null &&
                !string.Equals(selectedNurseId, originalNurseId, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được thay đổi y tá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // ✅ Không cho thay đổi y tá
            if (!string.Equals(selectedNurseId, originalNurseId, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được thay đổi y tá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo DTO cập nhật
            var dto = new DailyCareDTO
            {
                Id = selectedId,
                Shift = shift,
                BloodPressure = bloodPressure,
                BodyTempearature = bodyTemperature,
                PulseRate = pulseRate,
                Note = note,
                PatientID = originalPatientId,
                NurseID = originalNurseId,
                RoomID = roomId.Value
            };

            try
            {
                bll.Update(dto);
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDailyCare_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDailyCare.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["Id"].Value);

                cboShift.Text = row.Cells["Shift"].Value?.ToString();
                txtBloodPressure.Text = row.Cells["BloodPressure"].Value?.ToString();
                txtTemperature.Text = row.Cells["BodyTempearature"].Value?.ToString();
                txtCircuit.Text = row.Cells["PulseRate"].Value?.ToString().Trim();
                txtNote.Text = row.Cells["Note"].Value?.ToString();

                string patientId = row.Cells["PatientID"].Value?.ToString()?.Trim();
                string roomIdStr = row.Cells["RoomID"].Value?.ToString()?.Trim();
                string nurseId = row.Cells["NurseID"].Value?.ToString()?.Trim();

                originalPatientId = patientId ?? "";
                originalNurseId = nurseId ?? "";

                // 👇 Cập nhật comboBox bệnh nhân
                if (!string.IsNullOrEmpty(patientId))
                {
                    cboPatient.SelectedValue = patientId;

                    // fallback nếu binding không được
                    if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != patientId)
                    {
                        var allPatients = bll.GetAllPatients();
                        var patient = allPatients.FirstOrDefault(p => p.Id == patientId);
                        if (patient != null)
                        {
                            cboPatient.Text = patient.FullName;
                        }
                    }
                }

                // 👇 Cập nhật comboBox phòng
                if (int.TryParse(roomIdStr, out int roomId))
                {
                    cboRoom.SelectedValue = roomId;

                    // fallback nếu binding không được
                    if (cboRoom.SelectedValue == null || cboRoom.SelectedValue.ToString() != roomId.ToString())
                    {
                        var allRooms = bll.GetAllRooms();
                        var room = allRooms.FirstOrDefault(r => r.Id == roomId);
                        if (room != null)
                        {
                            cboRoom.Text = room.RoomName;
                        }
                    }
                }


                AppointmentBLL blla = new AppointmentBLL();
                string nurseDeptId = blla.GetDepartmentIdByStaffId(nurseId);
                if (!string.IsNullOrEmpty(nurseDeptId))
                {
                    cboDepartment.SelectedValue = nurseDeptId;
                    currentNurseList = bll.GetNursesByDepartment(nurseDeptId);

                    cboNurse.DataSource = currentNurseList;
                    cboNurse.DisplayMember = "Name";
                    cboNurse.ValueMember = "Id";

                    cboNurse.SelectedValue = nurseId;
                }
                else
                {
                    cboNurse.Text = "";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa từ bảng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bll.Delete(selectedId);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string patientId = cboPatient.SelectedValue?.ToString();
            string roomId = cboRoom.SelectedValue?.ToString();
            string nurseId = cboNurse.SelectedValue?.ToString(); // lấy từ combobox
            string shift = cboShift.Text.Trim(); // có thể dùng .Text thay vì SelectedValue

            var result = bll.Search(patientId, roomId, nurseId, shift);

            if (result.Any())
            {
                dgvDailyCare.DataSource = result;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDailyCare.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedIndex >= 0)
            {
                string departmentId = cboDepartment.SelectedValue.ToString();

                currentNurseList = bll.GetNursesByDepartment(departmentId);

                // GÁN danh sách y tá vào combobox (bắt buộc để dropdown hoạt động)
                cboNurse.DataSource = currentNurseList;
                cboNurse.DisplayMember = "Name";
                cboNurse.ValueMember = "Id";

                // Thiết lập AutoComplete
                cboNurse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboNurse.AutoCompleteSource = AutoCompleteSource.CustomSource;

                var autoSource = new AutoCompleteStringCollection();
                autoSource.AddRange(currentNurseList.Select(n => n.Name).ToArray());
                cboNurse.AutoCompleteCustomSource = autoSource;

                cboNurse.Text = "";          // Reset textbox
                cboNurse.SelectedIndex = -1; // Không chọn mặc định
            }
        }

        private void cboNurse_TextChanged(object sender, EventArgs e)
        {
           
        }
        private string originalPatientId = "";
        private string originalNurseId = "";

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
            string keyword = cboPatient.Text.Trim().ToLower();

            var allPatients = bll.GetAllPatients();
            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? allPatients
                : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();

            dgvPatient.DataSource = filtered;
        }

        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}