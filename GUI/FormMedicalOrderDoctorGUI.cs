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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace GUI
{
    public partial class FormMedicalOrderDoctorGUI : Form
    {
        public FormMedicalOrderDoctorGUI(string currentDoctorId)
        {
            InitializeComponent();
            this.doctorId = currentDoctorId;
        }
        private string doctorId;
        MedicalOrderDoctorBLL bll = new MedicalOrderDoctorBLL();
        private void FormMedicalOrderDoctorGUI_Load(object sender, EventArgs e)
        {
            dgvMedicalOrder.DataSource = bll.GetOrdersByDoctor(doctorId);
            LoadItems();
            LoadPatients();
            StyleDataGridView(dgvMedicalOrder);
            StyleDataGridView(dgvPatient);
            LoadLabTestTypes();
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
            var patients = bll.GetAllPatients(doctorId);

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

            var allPatients = bll.GetAllPatients(doctorId);
            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? allPatients
                : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();

            dgvPatient.DataSource = filtered;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedOrderId))
            {
                MessageBox.Show("Vui lòng chọn một y lệnh để cập nhật.", "Chưa chọn y lệnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra bắt buộc
            if (cboPatient.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtOrderType.Text))
            {
                MessageBox.Show("Vui lòng nhập loại y lệnh.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMedicinesAndSupplies.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thuốc/vật tư.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtQuantity.Text.Trim(), out decimal quantity))
            {
                MessageBox.Show("Số lượng phải là số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🔒 Kiểm tra không cho sửa PatientID
            if (originalOrder != null)
            {
                var selectedPatientId = cboPatient.SelectedValue?.ToString()?.Trim();
                var originalPatientId = originalOrder.PatientID?.Trim();

                if (!string.Equals(selectedPatientId, originalPatientId, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Không được thay đổi bệnh nhân trong y lệnh!", "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 🔒 Không cho sửa ItemID
            if (cboMedicinesAndSupplies.SelectedValue?.ToString() != originalOrder.ItemID)
            {
                MessageBox.Show("Không được thay đổi thuốc/vật tư!", "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Lấy TestTypeID từ ComboBox
            int? testTypeID = null;
            if (checkHasLabTest.Checked && cboTestTypeID.SelectedValue != null)
            {
                testTypeID = (int?)cboTestTypeID.SelectedValue;

                // 🔒 Không cho sửa TestTypeID
                if ((originalOrder.TestTypeID ?? -1) != (testTypeID ?? -1))
                {
                    MessageBox.Show("Không được thay đổi loại xét nghiệm!", "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MedicalOrderDoctorDTO dto = new MedicalOrderDoctorDTO
            {
                Id = int.Parse(selectedOrderId),
                PatientID = cboPatient.SelectedValue.ToString(),
                DoctorID = doctorId,
                OrderType = txtOrderType.Text.Trim(),
                ItemID = cboMedicinesAndSupplies.SelectedValue?.ToString(),
                TestTypeID = testTypeID,
                HasLabTest = checkHasLabTest.Checked,
                Dosage = string.IsNullOrWhiteSpace(txtDosage.Text) ? null : txtDosage.Text.Trim(),
                Quantity = quantity,
                Unit = string.IsNullOrWhiteSpace(txtUnit.Text) ? null : txtUnit.Text.Trim(),
                Frequency = string.IsNullOrWhiteSpace(txtFrequency.Text) ? null : txtFrequency.Text.Trim(),
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Checked ? dtpEndDate.Value : (DateTime?)null,
                SignedAt = dtpSignedAt.Checked ? dtpSignedAt.Value : (DateTime?)null,
                Note = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim()
            };

            try
            {
                bll.UpdateOrder(dto);
                MessageBox.Show("Cập nhật y lệnh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData(); // Load lại danh sách
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra chọn bệnh nhân (bắt buộc)
            if (cboPatient.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra OrderType (bắt buộc)
            if (string.IsNullOrWhiteSpace(txtOrderType.Text))
            {
                MessageBox.Show("Vui lòng nhập loại y lệnh (Order Type).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số lượng (bắt buộc và là số)
            decimal quantity;
            if (!decimal.TryParse(txtQuantity.Text.Trim(), out quantity))
            {
                MessageBox.Show("Số lượng phải là số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy TestTypeID nếu HasLabTest được chọn
            int? testTypeID = null;
            if (checkHasLabTest.Checked)
            {
                if (cboTestTypeID.SelectedValue != null)
                {
                    testTypeID = (int)cboTestTypeID.SelectedValue;

                    // Kiểm tra TestTypeID có tồn tại trong DB
                    if (!bll.IsTestTypeIDValid(testTypeID.Value))
                    {
                        MessageBox.Show("Loại xét nghiệm không tồn tại!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Tạo DTO
            MedicalOrderDoctorDTO dto = new MedicalOrderDoctorDTO
            {
                PatientID = cboPatient.SelectedValue.ToString(),
                DoctorID = doctorId,  // từ biến đăng nhập
                OrderType = txtOrderType.Text.Trim(),
                ItemID = cboMedicinesAndSupplies.SelectedValue?.ToString(), // có thể null
                TestTypeID = testTypeID,
                HasLabTest = checkHasLabTest.Checked,
                Dosage = string.IsNullOrWhiteSpace(txtDosage.Text) ? null : txtDosage.Text.Trim(),
                Quantity = quantity,
                Unit = string.IsNullOrWhiteSpace(txtUnit.Text) ? null : txtUnit.Text.Trim(),
                Frequency = string.IsNullOrWhiteSpace(txtFrequency.Text) ? null : txtFrequency.Text.Trim(),
                StartDate = dtpStartDate.Value,
                EndDate = null,
                SignedAt = dtpSignedAt.Checked ? dtpSignedAt.Value : (DateTime?)null,
                Note = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim(),
            };

            try
            {
                bll.AddOrder(dto);
                MessageBox.Show("Thêm y lệnh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm y lệnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshData()
        {
            dgvMedicalOrder.DataSource = bll.GetOrdersByDoctor(doctorId);
            selectedOrderId = "";
            ClearInputFields();
        }
        private void LoadLabTestTypes()
        {
            var labTests = bll.GetAllLabTestTypes();
            cboTestTypeID.DataSource = labTests;
            cboTestTypeID.DisplayMember = "TestTypeName";
            cboTestTypeID.ValueMember = "Id";
            cboTestTypeID.SelectedIndex = -1;

            cboTestTypeID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTestTypeID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private string selectedOrderId = "";
        private void ClearInputFields()
        {
            txtOrderType.Clear();
            txtDosage.Clear();
            txtQuantity.Clear();
            txtUnit.Clear();
            txtFrequency.Clear();
            txtNote.Clear();
            cboMedicinesAndSupplies.SelectedIndex = -1;
            cboMedicinesAndSupplies.Text = "";
            cboPatient.SelectedIndex = -1;
            cboPatient.Text = "";
            cboTestTypeID.SelectedIndex = -1;
            cboTestTypeID.Text = "";
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            dtpSignedAt.Value = DateTime.Today;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboPatient.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patientName = cboPatient.Text.Trim(); // Lấy tên hiển thị từ ComboBox

            try
            {
                var result = bll.SearchOrders(doctorId, patientName);

                if (result == null || result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy y lệnh nào khớp với bệnh nhân!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMedicalOrder.DataSource = null;
                }
                else
                {
                    dgvMedicalOrder.DataSource = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm y lệnh!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private MedicalOrderDoctorDTO originalOrder = null; 
        List<LabTestTypeDocTorDTO> testTypeList;      // dữ liệu loại xét nghiệm

        private void dgvMedicalOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selected = dgvMedicalOrder.Rows[e.RowIndex].DataBoundItem as MedicalOrderDoctorDTO;
                if (selected != null)
                {
                    selectedOrderId = selected.Id.ToString();
                    originalOrder = selected;

                    // Bệnh nhân
                    if (cboPatient.DataSource != null)
                    {
                        cboPatient.SelectedValue = selected.PatientID;

                        if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != selected.PatientID)
                        {
                            cboPatient.SelectedIndex = -1;
                            cboPatient.Text = selected.PatientName;
                        }
                    }

                    // Thuốc/Vật tư
                    cboMedicinesAndSupplies.SelectedValue = selected.ItemID;
                    if (cboMedicinesAndSupplies.SelectedValue == null || cboMedicinesAndSupplies.SelectedValue.ToString() != selected.ItemID)
                    {
                        var item = itemList.FirstOrDefault(i => i.ID == selected.ItemID);
                        cboMedicinesAndSupplies.Text = item?.ItemName ?? "";
                    }

                    // Các trường nhập liệu
                    txtOrderType.Text = selected.OrderType;
                    txtDosage.Text = selected.Dosage;
                    txtQuantity.Text = selected.Quantity?.ToString() ?? "";
                    txtUnit.Text = selected.Unit;
                    txtFrequency.Text = selected.Frequency;
                    txtNote.Text = selected.Note;

                    dtpStartDate.Value = selected.StartDate ?? DateTime.Today;

                    if (selected.EndDate.HasValue)
                    {
                        dtpEndDate.Value = selected.EndDate.Value;
                        dtpEndDate.Checked = true;
                    }
                    else
                    {
                        dtpEndDate.Value = DateTime.Today;
                        dtpEndDate.Checked = false;
                    }

                    if (selected.SignedAt.HasValue)
                    {
                        dtpSignedAt.Value = selected.SignedAt.Value;
                        dtpSignedAt.Checked = true;
                    }
                    else
                    {
                        dtpSignedAt.Value = DateTime.Today;
                        dtpSignedAt.Checked = false;
                    }

                    // ✅ Xét nghiệm
                    checkHasLabTest.Checked = selected.HasLabTest ?? false;
                    cboTestTypeID.Enabled = checkHasLabTest.Checked;

                    if (selected.TestTypeID.HasValue)
                    {
                        cboTestTypeID.SelectedValue = selected.TestTypeID.Value;

                        if (cboTestTypeID.SelectedValue == null || (int)cboTestTypeID.SelectedValue != selected.TestTypeID.Value)
                        {
                            // Nếu không khớp, hiển thị text thủ công
                            var selectedTest = testTypeList.FirstOrDefault(t => t.Id == selected.TestTypeID.Value);
                            cboTestTypeID.Text = selectedTest?.TestTypeName ?? selected.TestTypeName;
                        }
                    }
                    else
                    {
                        cboTestTypeID.SelectedIndex = -1;
                        cboTestTypeID.Text = "";
                    }
                }
            }
        }

        private void checkHasLabTest_CheckedChanged(object sender, EventArgs e)
        {
            cboTestTypeID.Enabled = checkHasLabTest.Checked;

            if (!checkHasLabTest.Checked)
            {
                cboTestTypeID.SelectedIndex = -1;
                cboTestTypeID.Text = "";
            }
        }
    }
}
