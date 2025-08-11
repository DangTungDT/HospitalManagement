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
    public partial class FormPatientSupplyHistoryInSameDepartmentNurseGUI : Form
    {
        public FormPatientSupplyHistoryInSameDepartmentNurseGUI(string doctorId, string patientId)
        {
            InitializeComponent();
            _doctorId = doctorId;
            _patientId = patientId;
            _bll = new SupplyHistoryBLL();
        }
        private readonly string _doctorId;
        private readonly string _patientId;
        private readonly SupplyHistoryBLL _bll;

        private void FormPatientSupplyHistoryInSameDepartmentNurseGUI_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgvSupplyHistory);
            LoadSupplyHistory();
            LoadPatientInfo();
        }
        private void groupBox3_Paint(object sender, PaintEventArgs e)
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
        private void LoadPatientInfo()
        {
            var bll = new MedicalOrderDoctorBLL();
            var patient = bll.GetPatientInfoById(_patientId);

            if (patient != null)
            {
                lblPatientName.Text = patient.FullName;
                lblGender.Text = patient.Gender;
                lblDob.Text = patient.Dob?.ToString("dd/MM/yyyy");
                lblPhone.Text = patient.PhoneNumber;
                lblStatus.Text = patient.Status;
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

        private void LoadSupplyHistory()
        {
            var list = _bll.GetPatientSupplyHistoryInSameDepartment(_doctorId, _patientId);

            if (list == null || !list.Any())
            {
                MessageBox.Show("Không có dữ liệu cấp thuốc cho bệnh nhân này.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSupplyHistory.DataSource = null;
                return;
            }

            dgvSupplyHistory.DataSource = list.Select(sh => new
            {
                MaCapThuoc = sh.Id,
                TenVatTuThuoc = sh.ItemName,
                Phong = sh.RoomName,
                TenYTa = sh.NurseName,
                TenBenhNhan = sh.PatientName,
                NgayCap = sh.DateSupply,
                LieuLuong = sh.Dosage,
                SoLuong = sh.Quantity,
                DonVi = sh.Unit,
                GhiChu = sh.Note
            }).ToList();

            // Tùy chỉnh header tiếng Việt
            dgvSupplyHistory.Columns["MaCapThuoc"].HeaderText = "Mã cấp thuốc";
            dgvSupplyHistory.Columns["TenVatTuThuoc"].HeaderText = "Tên vật tư/thuốc";
            dgvSupplyHistory.Columns["Phong"].HeaderText = "Phòng";
            dgvSupplyHistory.Columns["TenYTa"].HeaderText = "Tên y tá";
            dgvSupplyHistory.Columns["TenBenhNhan"].HeaderText = "Tên bệnh nhân";
            dgvSupplyHistory.Columns["NgayCap"].HeaderText = "Ngày cấp";
            dgvSupplyHistory.Columns["LieuLuong"].HeaderText = "Liều lượng";
            dgvSupplyHistory.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvSupplyHistory.Columns["DonVi"].HeaderText = "Đơn vị";
            dgvSupplyHistory.Columns["GhiChu"].HeaderText = "Ghi chú";

            dgvSupplyHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSupplyHistory.ReadOnly = true;
            dgvSupplyHistory.AllowUserToAddRows = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Kiểm tra DataGridView có dữ liệu hay không
            if (dgvSupplyHistory.DataSource == null || dgvSupplyHistory.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu có dữ liệu thì mở form in và truyền doctorId, patientId
            var frmReport = new FormPatientSupplyHistoryInSameDepartmentReporst(_doctorId, _patientId);
            frmReport.ShowDialog(); // Hoặc frmReport.Show() tùy ý
        }
    }
}
