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
    public partial class frmInpatientManagementGUI : Form
    {
        public frmInpatientManagementGUI(string doctorId)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            LoadPatientsForDoctor(doctorId);
            LoadSearchComboboxes();
        }
        PatientNurseBLL bll = new PatientNurseBLL();
        private void frmInpatientManagement_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgvPatient); // Gọi hàm tuỳ chỉnh DGV
       
        }
        public event Action<string, string> OnTransferRoomRequested;
        private void LoadSearchComboboxes()
        {
            var patients = currentPatients;

            // ===== Họ tên =====
            cboFullName.DataSource = new List<PatientNurseDTO>(patients);
            cboFullName.DisplayMember = "FullName";
            cboFullName.ValueMember = "Id";
            cboFullName.SelectedIndex = -1;

            cboFullName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboFullName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoCompleteFullName = new AutoCompleteStringCollection();
            autoCompleteFullName.AddRange(patients.Select(p => p.FullName).ToArray());
            cboFullName.AutoCompleteCustomSource = autoCompleteFullName;

            // ===== SĐT =====
            cboPhone.DataSource = new List<PatientNurseDTO>(patients);
            cboPhone.DisplayMember = "PhoneNumber";
            cboPhone.ValueMember = "Id";
            cboPhone.SelectedIndex = -1;

            cboPhone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPhone.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoCompletePhone = new AutoCompleteStringCollection();
            autoCompletePhone.AddRange(patients.Select(p => p.PhoneNumber).ToArray());
            cboPhone.AutoCompleteCustomSource = autoCompletePhone;

            // ===== Mã BHYT =====
            cboInsuranceID.DataSource = new List<PatientNurseDTO>(patients);
            cboInsuranceID.DisplayMember = "InsuranceID";
            cboInsuranceID.ValueMember = "InsuranceID";
            cboInsuranceID.SelectedIndex = -1;

            cboInsuranceID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboInsuranceID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoCompleteInsurance = new AutoCompleteStringCollection();
            autoCompleteInsurance.AddRange(patients.Select(p => p.InsuranceID).ToArray());
            cboInsuranceID.AutoCompleteCustomSource = autoCompleteInsurance;
        }


        private string doctorId;
        private List<PatientNurseDTO> currentPatients = new List<PatientNurseDTO>();

        private void LoadPatientsForDoctor(string doctorId)
        {
            PatientNurseBLL bll = new PatientNurseBLL();
            currentPatients = bll.GetPatientsByDoctorDepartment(doctorId);

            dgvPatient.AutoGenerateColumns = true;
            dgvPatient.DataSource = currentPatients;

            // 👉 Đổi tên cột sang tiếng Việt nếu muốn
            dgvPatient.Columns["FullName"].HeaderText = "Họ tên";
            dgvPatient.Columns["Gender"].HeaderText = "Giới tính";
            dgvPatient.Columns["DOB"].HeaderText = "Ngày sinh";
            dgvPatient.Columns["PhoneNumber"].HeaderText = "SĐT";
            dgvPatient.Columns["TypePatient"].HeaderText = "Loại BN";
            dgvPatient.Columns["InsuranceID"].HeaderText = "Mã BHYT";
            dgvPatient.Columns["Weight"].HeaderText = "Cân nặng (kg)";
            dgvPatient.Columns["Height"].HeaderText = "Chiều cao (cm)";
            dgvPatient.Columns["Address"].HeaderText = "Địa chỉ";
            dgvPatient.Columns["Status"].HeaderText = "Trạng thái";
            dgvPatient.Columns["CreatedDate"].HeaderText = "Ngày nhập viện";
            dgvPatient.Columns["UpdatedDate"].HeaderText = "Ngày cập nhật";
            dgvPatient.Columns["CitizenID"].HeaderText = "CMND/CCCD";
            dgvPatient.Columns["EmergencyContact"].HeaderText = "Người liên hệ khẩn cấp";
            dgvPatient.Columns["EmergencyPhone"].HeaderText = "SĐT khẩn cấp";

            dgvPatient.ClearSelection();

            // Tự động chọn dòng đầu tiên nếu có dữ liệu
            if (currentPatients.Count > 0)
            {
                dgvPatient.Rows[0].Selected = true;
                dgvPatient.CurrentCell = dgvPatient.Rows[0].Cells[1];
            }
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

        private void btnSearh_Click(object sender, EventArgs e)
        {

            string name = cboFullName.Text.Trim();
            string phone = cboPhone.Text.Trim();
            string insuranceId = cboInsuranceID.SelectedValue?.ToString() ?? "";

            var results = new PatientNurseBLL().SearchPatientsByDoctorDepartment(doctorId, name, phone, insuranceId);
            dgvPatient.DataSource = results;
            dgvPatient.ClearSelection();
        }

        private void btnTransferRoom_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            // Giả sử cboFullName là ComboBox chính chứa bệnh nhân
            if (cboFullName.SelectedIndex == -1 || cboFullName.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần chuyển phòng từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Lấy dữ liệu dòng đang được chọn
            DataGridViewRow selectedRow = dgvPatient.CurrentRow;

            // Kiểm tra chắc chắn cột Id không null
            if (selectedRow.Cells["Id"].Value == null || selectedRow.Cells["FullName"].Value == null)
            {
                MessageBox.Show("Dữ liệu bệnh nhân không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string patientId = selectedRow.Cells["Id"].Value.ToString();
            string fullName = selectedRow.Cells["FullName"].Value.ToString();

            FormTransferRoomNurseGUI transferForm = new FormTransferRoomNurseGUI(doctorId, patientId, fullName);
            transferForm.MdiParent = this.MdiParent;
            transferForm.ShowDialog();
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.CurrentRow != null && dgvPatient.CurrentRow.DataBoundItem is PatientNurseDTO selectedPatient)
            {
                cboFullName.Text = selectedPatient.FullName;
                cboPhone.Text = selectedPatient.PhoneNumber;
                cboInsuranceID.SelectedValue = selectedPatient.InsuranceID;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách bệnh nhân theo khoa của nhân viên đang đăng nhập
                var patients = bll.GetPatientsByDoctorDepartment(doctorId); // hoặc staffAccountId
                cboFullName.SelectedIndex = -1;
                cboPhone.SelectedIndex = -1;
                cboInsuranceID.SelectedIndex = -1;

                dgvPatient.DataSource = patients;
                dgvPatient.ClearSelection();

                MessageBox.Show("Làm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporst_Click(object sender, EventArgs e)
        {
            string staffId = doctorId; // <-- truyền từ login vào form

            PatientNurseBLL bll = new PatientNurseBLL();

            // ✅ Gọi đúng hàm để lấy mã khoa
            string departmentId = bll.GetDepartmentIdOfLoggedInUser(staffId);
            if (string.IsNullOrEmpty(departmentId))
            {
                MessageBox.Show("Không lấy được mã khoa của nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Gọi hàm BLL để lấy danh sách bệnh nhân theo khoa
            List<PatientListbyDepartmentDTO> patients = bll.GetPatientsByDepartmentt(departmentId);

            if (patients == null || patients.Count == 0)
            {
                MessageBox.Show("Không có bệnh nhân nào trong khoa này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ Mở form báo cáo
            frmReportPatientListbyDepartment reportForm = new frmReportPatientListbyDepartment(patients);
            reportForm.ShowDialog();
        }
    }
}
