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
    public partial class FromSupplyHistoryAdmin : Form
    {
        public FromSupplyHistoryAdmin()
        {
            InitializeComponent();
        }
        SupplyHistoryBLL bll = new SupplyHistoryBLL();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtMedicineSupplyID.Text.Trim();
            if (cboMedicinesAndSupplies.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vật tư hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string itemId = cboMedicinesAndSupplies.SelectedValue.ToString();

            string dosage = txtDosage.Text.Trim();
            string unit = txtUnit.Text.Trim();
            string note = txtNote.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();

            // iểm tra nếu người dùng nhập mà không chọn đúng bệnh nhân
            if (cboPatient.SelectedValue == null && !string.IsNullOrWhiteSpace(cboPatient.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân hợp lệ từ danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string patientID = cboPatient.SelectedValue?.ToString(); // dùng SelectedValue

            // Lấy y tá từ combobox
            if (cboNurse.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn y tá hoặc không tim thấy y tá với tên đã nhập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nurseId = cboNurse.SelectedValue.ToString();

            // Lấy typeSupply
            if (cbotypeSupply.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại cấp phát.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string typeSupply = cbotypeSupply.SelectedItem.ToString();

            // Kiểm tra bắt buộc
            if (string.IsNullOrWhiteSpace(quantityText))
            {
                MessageBox.Show("Vui lòng nhập số lượng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu để trống => tự động tạo ID mới
            if (string.IsNullOrEmpty(id))
            {
                id = bll.GenerateNextSupplyId();
            }
            else
            {
                // Nếu nhập tay mà bị trùng => báo lỗi
                if (bll.IsSupplyIdExists(id))
                {
                    MessageBox.Show("Mã cung cấp đã tồn tại. Vui lòng nhập mã khác hoặc để trống để hệ thống tự sinh mã.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!int.TryParse(quantityText, out int quantity))
            {
                MessageBox.Show("Số lượng phải là số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(patientID) && !bll.IsPatientExists(patientID))
            {
                MessageBox.Show("Không tìm thấy bệnh nhân với mã: " + patientID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(cboRoom.SelectedValue?.ToString(), out int roomId))
            {
                MessageBox.Show("Vui lòng chọn phòng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!bll.CheckRoomExists(roomId))
            {
                MessageBox.Show("Không tìm thấy phòng với mã: " + roomId, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!bll.CheckNurseExists(nurseId))
            {
                MessageBox.Show("Y tá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!bll.CheckItemExists(itemId))
            {
                MessageBox.Show("Không tìm thấy vật tư có mã: " + itemId, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                PatientID = patientID,
                Unit = unit,
                Note = note,
                TypeSupply = typeSupply,
                DateSupply = DateTime.Today
            };

            try
            {
                bll.Add(dto);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData()
        {
            dgvSupplyHistory.DataSource = bll.GetAll();
        }

        private void ClearFields()
        {
            txtMedicineSupplyID.Clear();
            txtDosage.Clear();
            txtQuantity.Clear();
            txtUnit.Clear();
            txtNote.Clear();
            cboNurse.SelectedIndex = -1;
            cbotypeSupply.SelectedIndex = -1;
            cboDepartment.SelectedIndex = -1;
            cboMedicinesAndSupplies.SelectedIndex = -1;
            cboRoom.SelectedIndex = -1;
            cboPatient.SelectedIndex = -1;
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

        private void FromSupplyHistoryAdmin_Load(object sender, EventArgs e)
        {
            LoadItems();
            LoadData();
            LoadDepartments();
            LoadRooms();     // ✅ Gọi để nạp phòng
            LoadPatients();  // ✅ Gọi để nạp bệnh nhân

            cboDepartment.SelectedIndexChanged += cboDepartment_SelectedIndexChanged;
            cboNurse.TextChanged += cboNurse_TextChanged;
            StyleDataGridView(dgvPatient);
            StyleDataGridView(dgvSupplyHistory);
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

        private string originalPatientId = "";
        private string originalNurseId = "";
        private void LoadDepartments()
        {
            var departments = bll.GetDepartments();
            cboDepartment.DataSource = departments;
            cboDepartment.DisplayMember = "DepartmentName";
            cboDepartment.ValueMember = "Id";
            cboDepartment.SelectedIndex = -1;
        }
        private List<StaffSupplyHistoryDTO> currentNurseList = new List<StaffSupplyHistoryDTO>();

        private void dgvSupplyHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSupplyHistory.Rows[e.RowIndex];
                var dto = row.DataBoundItem as SupplyHistoryDTO;
                if (dto == null) return;

                txtMedicineSupplyID.Text = dto.Id;
                txtDosage.Text = dto.Dosage;
                txtQuantity.Text = dto.Quantity.ToString();
                txtUnit.Text = dto.Unit;
                txtNote.Text = dto.Note;
                cbotypeSupply.SelectedItem = dto.TypeSupply;

                // ✅ Vật tư
                var selectedItem = itemList.FirstOrDefault(i => i.ID == dto.ItemID);
                if (selectedItem != null)
                {
                    cboMedicinesAndSupplies.SelectedValue = selectedItem.ID;
                    if (cboMedicinesAndSupplies.SelectedValue == null ||
                        cboMedicinesAndSupplies.SelectedValue.ToString() != selectedItem.ID)
                    {
                        cboMedicinesAndSupplies.Text = selectedItem.ItemName;
                    }
                }
                else
                {
                    cboMedicinesAndSupplies.SelectedIndex = -1;
                    cboMedicinesAndSupplies.Text = "";
                }

                originalNurseId = string.IsNullOrWhiteSpace(dto.NurseID) ? null : dto.NurseID.Trim();
                originalPatientId = string.IsNullOrWhiteSpace(dto.PatientID) ? null : dto.PatientID.Trim();

                if (!string.IsNullOrEmpty(originalPatientId))
                {
                    if (cboPatient.DataSource == null || cboPatient.Items.Count == 0)
                    {
                        LoadPatients();
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        cboPatient.SelectedValue = originalPatientId;

                        if (cboPatient.SelectedValue == null ||
                            cboPatient.SelectedValue.ToString() != originalPatientId)
                        {
                            var pat = bll.GetAllPatients().FirstOrDefault(p => p.Id == originalPatientId);
                            cboPatient.Text = pat?.FullName ?? "";
                        }
                    }));
                }
                else
                {
                    cboPatient.SelectedIndex = -1;
                    cboPatient.Text = "";
                }
                string nurseDeptId = bll.GetDepartmentIdByNurseId(originalNurseId);

                cboDepartment.SelectedIndexChanged -= cboDepartment_SelectedIndexChanged;

                if (!string.IsNullOrEmpty(nurseDeptId))
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        cboDepartment.SelectedValue = nurseDeptId;
                        LoadNursesByDepartment(nurseDeptId, originalNurseId);
                    }));
                }
                else
                {
                    cboDepartment.SelectedIndex = -1;
                    cboNurse.DataSource = null;
                    cboNurse.Text = "";
                }

                cboDepartment.SelectedIndexChanged += cboDepartment_SelectedIndexChanged;

                // ✅ Load tên phòng
                cboRoom.SelectedValue = dto.RoomID;
                if (cboRoom.SelectedValue == null ||
                    cboRoom.SelectedValue.ToString() != dto.RoomID.ToString())
                {
                    var room = bll.GetAllRooms().FirstOrDefault(r => r.Id == dto.RoomID);
                    cboRoom.Text = room?.RoomName ?? "";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMedicineSupplyID.Text))
            {
                MessageBox.Show("Vui lòng chọn bản ghi để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bll.Delete(txtMedicineSupplyID.Text);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMedicineSupplyID.Text))
            {
                MessageBox.Show("Vui lòng chọn bản ghi để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMedicinesAndSupplies.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vật tư hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string itemId = cboMedicinesAndSupplies.SelectedValue.ToString();

            string dosage = txtDosage.Text.Trim();
            string unit = txtUnit.Text.Trim();
            string note = txtNote.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();
            string roomText = cboRoom.Text.Trim();
            string tySubbly = cbotypeSupply.Text.Trim();
            // Lấy lại ID y tá đang chọn trong combobox
            string currentNurseId = cboNurse.SelectedValue?.ToString()?.Trim();
            string currentPatientId = cboPatient.SelectedValue?.ToString()?.Trim();


            if (string.IsNullOrWhiteSpace(itemId) || string.IsNullOrWhiteSpace(dosage)||
                string.IsNullOrWhiteSpace(roomText) || string.IsNullOrWhiteSpace(quantityText)||
                 string.IsNullOrWhiteSpace(note) || string.IsNullOrWhiteSpace(tySubbly))


            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // ✅ Lấy roomId đúng
            if (!int.TryParse(cboRoom.SelectedValue?.ToString(), out int roomId))
            {
                MessageBox.Show("Vui lòng chọn phòng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Lấy quantity như cũ
            if (!int.TryParse(quantityText, out int quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!bll.CheckRoomExists(roomId))
            {
                MessageBox.Show($"Không có phòng {roomId} trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!bll.CheckItemExists(itemId))
            {
                MessageBox.Show($"Không có thuốc {itemId} trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            bool originalIsNull = string.IsNullOrWhiteSpace(originalPatientId);
            bool currentIsNull = string.IsNullOrWhiteSpace(currentPatientId);

            if ((string.IsNullOrWhiteSpace(originalPatientId) && !string.IsNullOrWhiteSpace(currentPatientId)) ||
                (!string.IsNullOrWhiteSpace(originalPatientId) && !string.Equals(currentPatientId, originalPatientId, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Không được thay đổi bệnh nhân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!string.IsNullOrWhiteSpace(cboNurse.Text) &&
                currentNurseId != null &&
                !string.Equals(currentNurseId, originalNurseId, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được thay đổi y tá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dto = new SupplyHistoryDTO
            {
                Id = txtMedicineSupplyID.Text.Trim(),
                ItemID = itemId,
                RoomID = roomId,
                Dosage = dosage,
                NurseID = originalNurseId,
                PatientID = string.IsNullOrWhiteSpace(originalPatientId) ? null : originalPatientId, // 👈 Gán null nếu rỗng
                Quantity = quantity,
                Unit = unit,
                Note = note,
                DateSupply = DateTime.Today,
                TypeSupply = tySubbly
            };
            try
            {
                bll.Update(dto);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string supplyId = txtMedicineSupplyID.Text.Trim();
            string nurseId = cboNurse.SelectedValue?.ToString();

            int? roomId = cboRoom.SelectedValue as int?;

            string itemId = null;
            if (cboMedicinesAndSupplies.SelectedValue != null)
            {
                itemId = cboMedicinesAndSupplies.SelectedValue.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(cboMedicinesAndSupplies.Text))
            {
                var match = itemList.FirstOrDefault(i =>
                    i.ItemName.Trim().Equals(cboMedicinesAndSupplies.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (match != null)
                {
                    itemId = match.ID;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy vật tư phù hợp với tên đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // ✅ Xử lý mã bệnh nhân (PatientID)
            string patientId = null;
            if (cboPatient.SelectedValue != null)
            {
                patientId = cboPatient.SelectedValue.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(cboPatient.Text))
            {
                var allPatients = bll.GetAllPatients();
                var match = allPatients.FirstOrDefault(p => p.FullName.Trim().Equals(cboPatient.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (match != null)
                {
                    patientId = match.Id;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bệnh nhân phù hợp với tên đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var result = bll.Search(supplyId, itemId, nurseId, roomId, patientId);
            dgvSupplyHistory.DataSource = result;

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedIndex >= 0)
            {
                string departmentId = cboDepartment.SelectedValue.ToString();
                LoadNursesByDepartment(departmentId); // Không truyền nurseId => reset
            }
        }

        private void cboNurse_TextChanged(object sender, EventArgs e)
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
        private void LoadNursesByDepartment(string departmentId, string nurseId = null)
        {
            // Lấy danh sách y tá
            currentNurseList = bll.GetNursesByDepartment(departmentId);

            // Gán vào combobox
            cboNurse.DataSource = currentNurseList;
            cboNurse.DisplayMember = "Name";
            cboNurse.ValueMember = "Id";

            // Gán AutoComplete
            cboNurse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNurse.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var auto = new AutoCompleteStringCollection();
            auto.AddRange(currentNurseList.Select(n => n.Name).ToArray());
            cboNurse.AutoCompleteCustomSource = auto;

            // Gán SelectedValue nếu truyền vào
            if (!string.IsNullOrWhiteSpace(nurseId))
            {
                cboNurse.SelectedValue = nurseId;

                // Nếu không khớp → fallback gán Text
                if (cboNurse.SelectedValue == null || cboNurse.SelectedValue.ToString() != nurseId)
                {
                    var nurse = currentNurseList.FirstOrDefault(n => n.Id == nurseId);
                    cboNurse.Text = nurse?.Name ?? "";
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
