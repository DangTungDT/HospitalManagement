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
    public partial class FromSupplyHistoryInSameDepartmentFromDateNurse : Form
    {
        public FromSupplyHistoryInSameDepartmentFromDateNurse(string doctorId)
        {
            InitializeComponent();
            _doctorId = doctorId;
            _bll = new SupplyHistoryBLL();
            dgvSupplyHistory.AllowUserToAddRows = false;
            dgvSupplyHistory.ReadOnly = true;
            dgvSupplyHistory.AutoGenerateColumns = true;
        }
        private readonly string _doctorId;
        private readonly SupplyHistoryBLL _bll;
        private void FromSupplyHistoryInSameDepartmentFromDateNurse_Load(object sender, EventArgs e)
        {
            dtpCareDate.Value = DateTime.Today;
            LoadSupplyHistory();
            StyleDataGridView(dgvSupplyHistory);

        }
        private void LoadSupplyHistory()
        {
            DateTime fromDate = dtpCareDate.Value.Date;
            var list = _bll.GetSupplyHistoryInSameDepartmentFromDate(_doctorId, fromDate);

            if (list == null || list.Count == 0)
            {
                dgvSupplyHistory.DataSource = null;
                MessageBox.Show($"Không tìm thấy bản ghi cấp thuốc/vật tư từ ngày {fromDate:yyyy-MM-dd} trong khoa của bác sĩ.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Bind trực tiếp List<SupplyHistoryDTO>
            dgvSupplyHistory.DataSource = list;

            // Thay header sang tiếng Việt (đảm bảo tên cột trùng với property DTO)
            if (dgvSupplyHistory.Columns["Id"] != null) dgvSupplyHistory.Columns["Id"].HeaderText = "Mã cấp thuốc";
            if (dgvSupplyHistory.Columns["ItemName"] != null) dgvSupplyHistory.Columns["ItemName"].HeaderText = "Tên vật tư/thuốc";
            if (dgvSupplyHistory.Columns["RoomName"] != null) dgvSupplyHistory.Columns["RoomName"].HeaderText = "Phòng";
            if (dgvSupplyHistory.Columns["NurseName"] != null) dgvSupplyHistory.Columns["NurseName"].HeaderText = "Tên y tá";
            if (dgvSupplyHistory.Columns["PatientName"] != null) dgvSupplyHistory.Columns["PatientName"].HeaderText = "Tên bệnh nhân";
            if (dgvSupplyHistory.Columns["DateSupply"] != null) dgvSupplyHistory.Columns["DateSupply"].HeaderText = "Ngày cấp";
            if (dgvSupplyHistory.Columns["Dosage"] != null) dgvSupplyHistory.Columns["Dosage"].HeaderText = "Liều lượng";
            if (dgvSupplyHistory.Columns["Quantity"] != null) dgvSupplyHistory.Columns["Quantity"].HeaderText = "Số lượng";
            if (dgvSupplyHistory.Columns["Unit"] != null) dgvSupplyHistory.Columns["Unit"].HeaderText = "Đơn vị";
            if (dgvSupplyHistory.Columns["Note"] != null) dgvSupplyHistory.Columns["Note"].HeaderText = "Ghi chú";

            // Optionally hide technical IDs if you don't want to show them
            if (dgvSupplyHistory.Columns["ItemID"] != null) dgvSupplyHistory.Columns["ItemID"].Visible = false;
            if (dgvSupplyHistory.Columns["RoomID"] != null) dgvSupplyHistory.Columns["RoomID"].Visible = false;
            if (dgvSupplyHistory.Columns["NurseID"] != null) dgvSupplyHistory.Columns["NurseID"].Visible = false;
            if (dgvSupplyHistory.Columns["PatientID"] != null) dgvSupplyHistory.Columns["PatientID"].Visible = false;
            if (dgvSupplyHistory.Columns["TypeSupply"] != null) dgvSupplyHistory.Columns["TypeSupply"].Visible = false;

            dgvSupplyHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSupplyHistory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Kiểm tra nguồn dữ liệu của DataGridView
            var dataSource = dgvSupplyHistory.DataSource as List<DTO.SupplyHistoryDTO>;

            if (dataSource == null || dataSource.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ngày từ DateTimePicker
            DateTime fromDate = dtpCareDate.Value.Date;

            // Mở form báo cáo, truyền doctorId và fromDate
            var reportForm = new FormSupplyHistoryInSameDepartmentFromDateReports(_doctorId, fromDate);
            reportForm.ShowDialog();
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

        private void groupBox3_Paint_1(object sender, PaintEventArgs e)
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
