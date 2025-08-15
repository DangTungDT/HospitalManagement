using BLL;
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
    public partial class frmMedicalOrdersOfPatientNurse : Form
    {
        public frmMedicalOrdersOfPatientNurse(string doctorId, string patientId)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            this.patientId = patientId;
            LoadMedicalOrders();
            LoadPatientInfo();
        }

        private void frmMedicalOrdersOfPatientNurse_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgvOrders);
            // Đổi tên cột sang tiếng Việt
            if (dgvOrders.Columns.Count > 0)
            {
                dgvOrders.Columns["OrderType"].HeaderText = "Loại chỉ định";
                dgvOrders.Columns["ItemID"].HeaderText = "Mã vật tư";
                dgvOrders.Columns["TestTypeName"].HeaderText = "Loại xét nghiệm";
                dgvOrders.Columns["Dosage"].HeaderText = "Liều dùng";
                dgvOrders.Columns["Quantity"].HeaderText = "Số lượng";
                dgvOrders.Columns["Unit"].HeaderText = "Đơn vị";
                dgvOrders.Columns["Frequency"].HeaderText = "Tần suất";
                dgvOrders.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
                dgvOrders.Columns["EndDate"].HeaderText = "Ngày kết thúc";
                dgvOrders.Columns["Status"].HeaderText = "Trạng thái";
                dgvOrders.Columns["CreatedAt"].HeaderText = "Ngày tạo";
                dgvOrders.Columns["SignedAt"].HeaderText = "Ngày ký";
                dgvOrders.Columns["Note"].HeaderText = "Ghi chú";
                dgvOrders.Columns["HasLabTest"].HeaderText = "Có xét nghiệm";
                dgvOrders.Columns["DoctorName"].HeaderText = "Bác sĩ";
                dgvOrders.Columns["PatientName"].HeaderText = "Bệnh nhân";

                // Ẩn các cột không cần thiết (nếu muốn)
                dgvOrders.Columns["Id"].Visible = false;
                dgvOrders.Columns["PatientID"].Visible = false;
                dgvOrders.Columns["DoctorID"].Visible = false;
                dgvOrders.Columns["TestTypeID"].Visible = false;
                dgvOrders.Columns["ItemID"].Visible = false; // Nếu không cần
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
        private string doctorId;
        private string patientId;
        private void LoadMedicalOrders()
        {
            var bll = new MedicalOrderDoctorBLL();
            var orders = bll.GetMedicalOrdersOfPatientInDoctorDepartment(doctorId, patientId);
            dgvOrders.DataSource = orders;
        }
        private void LoadPatientInfo()
        {
            var bll = new MedicalOrderDoctorBLL();
            var patient = bll.GetPatientInfoById(patientId);

            if (patient != null)
            {
                lblPatientName.Text = patient.FullName;
                lblGender.Text = patient.Gender;
                lblDob.Text = patient.Dob?.ToString("dd/MM/yyyy");
                lblPhone.Text = patient.PhoneNumber;
                lblStatus.Text = patient.Status;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bll = new MedicalOrderDoctorBLL();
            string departmentId = bll.GetDepartmentIdByDoctor(doctorId);

            if (string.IsNullOrEmpty(departmentId))
            {
                MessageBox.Show("Không tìm thấy khoa của bác sĩ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra danh sách có dữ liệu không
            if (dgvOrders.DataSource == null || dgvOrders.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmMedicalOrderReportNurse frmReport = new frmMedicalOrderReportNurse(doctorId, patientId);
            frmReport.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
