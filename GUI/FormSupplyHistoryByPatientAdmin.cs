using BLL;
using DAL;
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
    public partial class FormSupplyHistoryByPatientAdmin : Form
    {
        public FormSupplyHistoryByPatientAdmin(string patientId)
        {
            InitializeComponent();
            this.patientId = patientId;
        }
        private string patientId;
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
        private void FormSupplyHistoryByPatientAdmin_Load(object sender, EventArgs e)
        {
            LoadPatientInfo();
            StyleDataGridView(dgvSupplyHistory);
            LoadSupplyHistory();

        }
        private SupplyHistoryBLL supplyHistoryBLL = new SupplyHistoryBLL();
        private void LoadSupplyHistory()
        {
            var data = supplyHistoryBLL.GetSupplyHistoryByPatient(patientId);
            dgvSupplyHistory.DataSource = data;

            // Nếu muốn ẩn một số cột không cần thiết
            dgvSupplyHistory.Columns["ItemID"].Visible = false;
            dgvSupplyHistory.Columns["RoomID"].Visible = false;
            dgvSupplyHistory.Columns["NurseID"].Visible = false;
            dgvSupplyHistory.Columns["PatientID"].Visible = false;

            // Đổi tên tiêu đề cột sang tiếng Việt
            dgvSupplyHistory.Columns["Id"].HeaderText = "Mã Phiếu";
            dgvSupplyHistory.Columns["DateSupply"].HeaderText = "Ngày Cung Cấp";
            dgvSupplyHistory.Columns["TypeSupply"].HeaderText = "Loại Cung Cấp";
            dgvSupplyHistory.Columns["Dosage"].HeaderText = "Liều Lượng";
            dgvSupplyHistory.Columns["Quantity"].HeaderText = "Số Lượng";
            dgvSupplyHistory.Columns["Unit"].HeaderText = "Đơn Vị";
            dgvSupplyHistory.Columns["Note"].HeaderText = "Ghi Chú";
            dgvSupplyHistory.Columns["DepartmentName"].HeaderText = "Khoa";
            dgvSupplyHistory.Columns["ItemName"].HeaderText = "Tên Vật Tư";
            dgvSupplyHistory.Columns["NurseName"].HeaderText = "Tên Y Tá";
            dgvSupplyHistory.Columns["RoomName"].HeaderText = "Phòng";
            dgvSupplyHistory.Columns["PatientName"].HeaderText = "Bệnh Nhân";
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FormSupplyHistoryByPatientReprstAdmin frm = new FormSupplyHistoryByPatientReprstAdmin(patientId);
            frm.ShowDialog();
        }
    }
}
