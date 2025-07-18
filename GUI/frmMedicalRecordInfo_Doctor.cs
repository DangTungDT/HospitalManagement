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
    public partial class frmMedicalRecordInfo_Doctor : Form
    {
        public frmMedicalRecordInfo_Doctor(string currentDoctorId)
        {
            InitializeComponent();
            this.doctorId = currentDoctorId;
        }
        MedicalRecordDoctorBLL bll = new MedicalRecordDoctorBLL();
        private string doctorId;
        private void frmMedicalRecordInfo_Doctor_Load(object sender, EventArgs e)
        {
            dgvMedicalRecord.DataSource = bll.GetRecordsByDoctor(doctorId);
            LoadPatients();
            StyleDataGridView(dgvMedicalRecord);
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
        private void cboPatient_TextChanged(object sender, EventArgs e)
        {
            string keyword = cboPatient.Text.Trim().ToLower();

            var allPatients = bll.GetAllPatients(doctorId);
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
            if (cboPatient.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra từng trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Vui lòng nhập chẩn đoán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnosis.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTreatmentPlan.Text))
            {
                MessageBox.Show("Vui lòng nhập kế hoạch điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTreatmentPlan.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrescription.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrescription.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVitalSigns.Text))
            {
                MessageBox.Show("Vui lòng nhập dấu hiệu sinh tồn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVitalSigns.Focus();
                return;
            }

            var dto = new MedicalRecordDoctorDTO
            {
                PatientID = cboPatient.SelectedValue.ToString(),
                DoctorID = doctorId,
                Diagnosis = txtDiagnosis.Text.Trim(),
                TreatmentPlan = txtTreatmentPlan.Text.Trim(),
                Prescription = txtPrescription.Text.Trim(),
                VitalSigns = txtVitalSigns.Text.Trim(),
                Notes = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim()
            };

            try
            {
                bll.AddMedicalRecord(dto);
                MessageBox.Show("Thêm bệnh án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bệnh án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboPatient.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trong danh sách để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedPatientId = cboPatient.SelectedValue.ToString();

            try
            {
                var result = bll.SearchRecordsByPatient(doctorId, selectedPatientId);

                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy bệnh án nào cho bệnh nhân đã chọn.", "Thông báo");
                }

                dgvMedicalRecord.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm bệnh án: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvMedicalRecord.DataSource = bll.GetRecordsByDoctor(doctorId);
            cboPatient.SelectedIndex = -1;
            txtDiagnosis.Clear();
            txtTreatmentPlan.Clear();
            txtPrescription.Clear();
            txtVitalSigns.Clear();
            txtNote.Clear();
        }
        private void RefreshData()
        {
            dgvMedicalRecord.DataSource = bll.GetRecordsByDoctor(doctorId);
            cboPatient.SelectedIndex = -1;
            txtDiagnosis.Clear();
            txtTreatmentPlan.Clear();
            txtPrescription.Clear();
            txtVitalSigns.Clear();
            txtNote.Clear();
            cboPatient.Focus();
        }

        private void dgvMedicalRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selected = dgvMedicalRecord.Rows[e.RowIndex].DataBoundItem as MedicalRecordDoctorDTO;

                if (selected != null)
                {
                    // ✅ Gán bệnh nhân (chỉ hiển thị)
                    cboPatient.SelectedValue = selected.PatientID;

                    // Fallback nếu ID không match hoặc lỗi binding
                    if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != selected.PatientID)
                    {
                        cboPatient.Text = selected.PatientName;
                    }

                    // ✅ Các trường thông tin bệnh án
                    txtDiagnosis.Text = selected.Diagnosis ?? "";
                    txtTreatmentPlan.Text = selected.TreatmentPlan ?? "";
                    txtPrescription.Text = selected.Prescription ?? "";
                    txtVitalSigns.Text = selected.VitalSigns ?? "";
                    txtNote.Text = selected.Notes ?? "";
                }
            }
        }
    }
}
