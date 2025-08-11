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
    public partial class frmMedicalInventoryGUI : Form
    {
        private string doctorId;
        public frmMedicalInventoryGUI(string doctorID)
        {
            InitializeComponent();
            this.doctorId = doctorID;
        }
        public void LoadRoom()
        {
            MedicalOrderDoctorBLL bll = new MedicalOrderDoctorBLL();
            // Lấy danh sách phòng theo khoa
            var rooms = bll.GetRoomsByDoctorDepartment(doctorId);
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
        private void frmMedicalInventoryGUI_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgvSupplyHistory);
            StyleDataGridView(dgvPatient);
            LoadSupplyHistory();
            LoadRoom();
            LoadPatientsForDoctor(doctorId);
            LoadItems();
         
        }
        private List<ItemSupplyHistoryDTO> itemList = new List<ItemSupplyHistoryDTO>();

        private void LoadItems()
        {
            itemList = bll.GetAllItems();

            cboMedicinesAndSupplies.DataSource = itemList;
            cboMedicinesAndSupplies.DisplayMember = "ItemName";
            cboMedicinesAndSupplies.ValueMember = "ID";

            cboMedicinesAndSupplies.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMedicinesAndSupplies.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(itemList.Select(i => i.ItemName).ToArray());
            cboMedicinesAndSupplies.AutoCompleteCustomSource = autoSource;

            cboMedicinesAndSupplies.SelectedIndex = -1;
            cboMedicinesAndSupplies.Text = "";
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
        SupplyHistoryBLL bll = new SupplyHistoryBLL();
        private void LoadSupplyHistory()
        {
            var list = bll.GetPatientSupplyHistoryInSameDepartment(doctorId);
            dgvSupplyHistory.DataSource = list;

            // Ẩn bớt cột không cần thiết
            dgvSupplyHistory.Columns["Id"].HeaderText = "Mã cung cấp";
            dgvSupplyHistory.Columns["ItemID"].Visible = false;
            dgvSupplyHistory.Columns["RoomID"].Visible = false;
            dgvSupplyHistory.Columns["NurseID"].Visible = false;
            dgvSupplyHistory.Columns["PatientID"].Visible = false;
            dgvSupplyHistory.Columns["TypeSupply"].Visible = false;

            // Set header text dễ nhìn
            dgvSupplyHistory.Columns["ItemName"].HeaderText = "Tên vật tư";
            dgvSupplyHistory.Columns["NurseName"].HeaderText = "Y tá cung cấp";
            dgvSupplyHistory.Columns["RoomName"].HeaderText = "Phòng";
            dgvSupplyHistory.Columns["PatientName"].HeaderText = "Bệnh nhân";
            dgvSupplyHistory.Columns["Dosage"].HeaderText = "Liều dùng";
            dgvSupplyHistory.Columns["Quantity"].HeaderText = "Số lượng";
            dgvSupplyHistory.Columns["Unit"].HeaderText = "Đơn vị";
            dgvSupplyHistory.Columns["Note"].HeaderText = "Ghi chú";
            dgvSupplyHistory.Columns["DateSupply"].HeaderText = "Ngày cung cấp";
        }

        private void cboPatient_TextChanged(object sender, EventArgs e)
        {
            string keyword = cboPatient.Text.Trim().ToLower();
            MedicalOrderDoctorBLL bll = new MedicalOrderDoctorBLL();
            var allPatients = bll.GetPatientsByDoctorDepartment(doctorId);
            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? allPatients
                : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();

            dgvPatient.DataSource = filtered;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtMedicineSupplyID.Text.Trim();

            // Mặc định typeSupply = "Patient"
            string typeSupply = "Patient";

            // Bác sĩ đăng nhập làm nurseID
            string nurseId = doctorId;

            // Kiểm tra bắt buộc
            if (cboMedicinesAndSupplies.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vật tư hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string itemId = cboMedicinesAndSupplies.SelectedValue.ToString();

            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDosage.Text))
            {
                MessageBox.Show("Vui lòng nhập liều dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosage = txtDosage.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string unit = txtUnit.Text.Trim();

            // Bệnh nhân bắt buộc chọn từ combobox
            if (cboPatient.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string patientID = cboPatient.SelectedValue.ToString();

            // Phòng cũng bắt buộc
            if (cboRoom.SelectedValue == null || !int.TryParse(cboRoom.SelectedValue.ToString(), out int roomId))
            {
                MessageBox.Show("Vui lòng chọn phòng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra độ dài theo DB
            if (!string.IsNullOrEmpty(id) && id.Length > 10)
            {
                MessageBox.Show("Mã cung cấp không được vượt quá 10 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dosage.Length > 255)
            {
                MessageBox.Show("Liều dùng không được vượt quá 255 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (unit.Length > 255)
            {
                MessageBox.Show("Đơn vị không được vượt quá 255 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string note = txtNote.Text.Trim();
            if (string.IsNullOrEmpty(note)) note = null; // note có thể null

            // Nếu id rỗng thì tự sinh, nếu nhập thì kiểm tra trùng
            if (string.IsNullOrEmpty(id))
            {
                id = bll.GenerateNextSupplyId();
            }
            else if (bll.IsSupplyIdExists(id))
            {
                MessageBox.Show("Mã cung cấp đã tồn tại, vui lòng nhập mã khác hoặc để trống để hệ thống tự sinh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dto = new SupplyHistoryDTO
            {
                Id = id,
                ItemID = itemId,
                RoomID = roomId,
                NurseID = nurseId,
                Dosage = dosage,
                Quantity = quantity,
                Unit = unit,
                Note = note,
                PatientID = patientID,
                TypeSupply = typeSupply,
                DateSupply = DateTime.Today // mặc định hôm nay
            };
            // Note thì tùy, ở đây giới hạn 1000 ký tự
            if (!string.IsNullOrEmpty(note) && note.Length > 1000)
            {
                MessageBox.Show("Ghi chú quá dài (tối đa 1000 ký tự).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                bll.Add(dto);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); // Hàm xóa trắng form
                LoadSupplyHistory();    // Hàm load lại DataGridView
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            txtMedicineSupplyID.Clear();
            cboMedicinesAndSupplies.SelectedIndex = -1;
            txtDosage.Clear();
            txtQuantity.Clear();
            txtUnit.Clear();
            txtNote.Clear();
            cboPatient.SelectedIndex = -1;
            cboRoom.SelectedIndex = -1;
            // Bật lại các control để cho phép nhập liệu mới
            txtMedicineSupplyID.Enabled = true;
            cboMedicinesAndSupplies.Enabled = true;
            cboPatient.Enabled = true;
            cboRoom.Enabled = true;
            dgvSupplyHistory.DataSource = null;
            dgvPatient.DataSource = null;
        }
        private void dgvSupplyHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplyHistory.Rows[e.RowIndex];

                txtMedicineSupplyID.Text = row.Cells["Id"].Value?.ToString() ?? "";

                // ItemID
                string itemId = row.Cells["ItemID"].Value?.ToString();
                if (!string.IsNullOrEmpty(itemId))
                    cboMedicinesAndSupplies.SelectedValue = itemId;
                else
                    cboMedicinesAndSupplies.SelectedIndex = -1;

                txtDosage.Text = row.Cells["Dosage"].Value?.ToString() ?? "";
                txtQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
                txtUnit.Text = row.Cells["Unit"].Value?.ToString() ?? "";
                txtNote.Text = row.Cells["Note"].Value?.ToString() ?? "";

                // Patient
                string patientId = row.Cells["PatientID"].Value?.ToString();
                string patientName = row.Cells["PatientName"].Value?.ToString();
                if (!string.IsNullOrEmpty(patientId))
                    cboPatient.SelectedValue = patientId;
                else
                    cboPatient.SelectedIndex = -1;

                if (cboPatient.SelectedValue == null || cboPatient.SelectedValue?.ToString() != patientId)
                    cboPatient.Text = patientName ?? "";

                // Room
                int roomId = 0; // gán giá trị mặc định
                if (row.Cells["RoomID"].Value != null && int.TryParse(row.Cells["RoomID"].Value.ToString(), out roomId))
                {
                    cboRoom.SelectedValue = roomId;
                }
                else
                {
                    cboRoom.SelectedIndex = -1;
                }

                if (cboRoom.SelectedValue == null || !int.TryParse(cboRoom.SelectedValue.ToString(), out int selRoomId) || selRoomId != roomId)
                {
                    cboRoom.Text = row.Cells["RoomName"].Value?.ToString() ?? "";
                }
                // Disable các control không được phép sửa
                txtMedicineSupplyID.Enabled = false;
                cboMedicinesAndSupplies.Enabled = false;
                cboPatient.Enabled = false;
                cboRoom.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadSupplyHistory();
            LoadPatientsForDoctor(doctorId);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra có dòng nào được chọn không
            if (dgvSupplyHistory.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn mục cung cấp trong danh sách để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã cung cấp từ dòng được chọn
            string id = dgvSupplyHistory.CurrentRow.Cells["Id"].Value?.ToString();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Mã cung cấp không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận xóa
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa mã cung cấp: {id}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bll.Delete(id);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearFields();
                    LoadSupplyHistory(); // Load lại dữ liệu cho DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng chưa
            if (string.IsNullOrWhiteSpace(txtMedicineSupplyID.Text))
            {
                MessageBox.Show("Vui lòng chọn bản ghi để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy ID từ textbox
            string id = txtMedicineSupplyID.Text.Trim();

            // Validate Quantity
            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Dosage
            if (string.IsNullOrWhiteSpace(txtDosage.Text))
            {
                MessageBox.Show("Vui lòng nhập liều dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosage = txtDosage.Text.Trim();
            if (dosage.Length > 255)
            {
                MessageBox.Show("Liều dùng không được vượt quá 255 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Unit
            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string unit = txtUnit.Text.Trim();
            if (unit.Length > 255)
            {
                MessageBox.Show("Đơn vị không được vượt quá 255 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ghi chú có thể null, giới hạn 1000 ký tự
            string note = txtNote.Text.Trim();
            if (!string.IsNullOrEmpty(note) && note.Length > 1000)
            {
                MessageBox.Show("Ghi chú quá dài (tối đa 1000 ký tự).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(note)) note = null;

            // Lấy lại các giá trị cũ từ combo (không cho sửa)
            string itemId = cboMedicinesAndSupplies.SelectedValue?.ToString();
            int roomId = Convert.ToInt32(cboRoom.SelectedValue);
            string patientID = cboPatient.SelectedValue?.ToString();
            string nurseId = doctorId; // vẫn giữ bác sĩ đang đăng nhập
            string typeSupply = "Patient"; // giữ nguyên loại

            var dto = new SupplyHistoryDTO
            {
                Id = id,
                Dosage = dosage,
                Quantity = quantity,
                Unit = unit,
                Note = note,
                DateSupply = DateTime.Today // luôn là hôm nay khi sửa
            };

            try
            {
                bll.UpdateEditableFields(dto);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadSupplyHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string originalPatientId = null;

        private void cboPatient_TextChanged_1(object sender, EventArgs e)
        {
            MedicalOrderDoctorBLL bll = new MedicalOrderDoctorBLL();
            this.BeginInvoke(new Action(() =>
            {
                string keyword = cboPatient.Text.Trim().ToLower();
                var allPatients = bll.GetPatientsByDoctorDepartment(doctorId);
                var filtered = string.IsNullOrWhiteSpace(keyword)
                    ? allPatients
                    : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();
                dgvPatient.DataSource = filtered;
            }));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string patientId = cboPatient.SelectedValue != null && cboPatient.SelectedValue.ToString() != ""
                       ? cboPatient.SelectedValue.ToString()
                       : null;

            int? roomId = cboRoom.SelectedValue != null && cboRoom.SelectedValue.ToString() != ""
                          ? Convert.ToInt32(cboRoom.SelectedValue)
                          : (int?)null;

            string itemId = cboMedicinesAndSupplies.SelectedValue != null && cboMedicinesAndSupplies.SelectedValue.ToString() != ""
                            ? cboMedicinesAndSupplies.SelectedValue.ToString()
                            : null;

            var result = bll.SearchPatientSupplyHistoryByFilters(doctorId, patientId, roomId, itemId);

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvSupplyHistory.DataSource = result;
        }

        private void btnPatientInformation_Click(object sender, EventArgs e)
        {
            string selectedPatientId = null;

            // Kiểm tra ComboBox
            if (cboPatient.Items.Count == 0 || cboPatient.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID từ ComboBox (chỉ lấy khi thực sự đã chọn)
            if (cboPatient.SelectedValue != null)
            {
                selectedPatientId = cboPatient.SelectedValue.ToString();
            }

            // (Tùy chọn) Nếu muốn ưu tiên DataGridView khi có chọn dòng
            if (dgvPatient.SelectedRows.Count > 0)
            {
                var patient = dgvPatient.SelectedRows[0].DataBoundItem as PatientSupplyHistoryDTO;
                if (patient != null)
                    selectedPatientId = patient.Id;
            }

            // Nếu vẫn không có ID bệnh nhân
            if (string.IsNullOrEmpty(selectedPatientId))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy doctorId từ form hiện tại
            string currentDoctorId = this.doctorId;

            // Mở form mới với 2 mã
            FormPatientSupplyHistoryInSameDepartmentNurseGUI frm = new FormPatientSupplyHistoryInSameDepartmentNurseGUI(currentDoctorId, selectedPatientId);
            frm.ShowDialog();
        }

        private void btnPrintPatientList_Click(object sender, EventArgs e)
        {
            FromSupplyHistoryInSameDepartmentFromDateNurse frm = new FromSupplyHistoryInSameDepartmentFromDateNurse(doctorId);
            frm.ShowDialog();
        }
    }
}
