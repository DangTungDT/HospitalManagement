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
    public partial class Form_DaiLyCare_DieuDuong : Form
    {
        public Form_DaiLyCare_DieuDuong()
        {
            InitializeComponent();
        }
        DailyCareBLL bll = new DailyCareBLL();
        DailyCareDAL dal = new DailyCareDAL();
        private void Form_DaiLyCare_DieuDuong_Load(object sender, EventArgs e)
        {
            dgvDailyCare.DataSource = bll.GetAll();
            dgvPatient.DataSource = bll.GetAllPatients();
            var patients = bll.GetAllPatients();
            cboPatient.DataSource = patients;
            cboPatient.DisplayMember = "FullName"; 
            cboPatient.ValueMember = "Id";
            var rooms = bll.GetAllRooms();
            cboRoom.DataSource = rooms;
            cboRoom.DisplayMember = "RoomName";
            cboRoom.ValueMember = "Id";
            var departments = bll.GetDepartments();
            cboDepartment.DataSource = departments;
            cboDepartment.DisplayMember = "DepartmentName";
            cboDepartment.ValueMember = "Id";
            cboDepartment.SelectedIndex = -1;
        }
        private int selectedId = -1;
        private string originalPatientId = "";
        private string originalNurseId = "";
        private List<StaffSupplyHistoryDTO> currentNurseList = new List<StaffSupplyHistoryDTO>();
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

        private void btnRefresh_Click(object sender, EventArgs e)
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
                    dgvDailyCare.DataSource = bll.GetAll();
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
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                dgvDailyCare.DataSource = bll.GetAll();
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
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_DaiLyCare_DieuDuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
