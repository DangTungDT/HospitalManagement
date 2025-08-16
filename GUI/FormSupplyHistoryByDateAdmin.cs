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
    public partial class FormSupplyHistoryByDateAdmin : Form
    {
        public FormSupplyHistoryByDateAdmin()
        {
            InitializeComponent();
            bll = new SupplyHistoryBLL();
        }
        private SupplyHistoryBLL bll;
        private void FormSupplyHistoryByDateAdmin_Load(object sender, EventArgs e)
        {
            // Optional: Load ngay từ đầu theo ngày hiện tại
            LoadSupplyHistory(dtpCareDate.Value);
            StyleDataGridView(dgvSupplyHistory);
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
        private void LoadSupplyHistory(DateTime selectedDate)
        {
            try
            {
                var list = bll.GetSupplyHistoryByDate(selectedDate);

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy lịch sử cung cấp thuốc trong ngày đã chọn.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvSupplyHistory.DataSource = null;
                    return;
                }

                dgvSupplyHistory.DataSource = list;

                // Tuỳ chỉnh DataGridView (nếu cần)
                dgvSupplyHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSupplyHistory.Columns["Id"].HeaderText = "Mã lịch sử";
                dgvSupplyHistory.Columns["DateSupply"].HeaderText = "Ngày cấp";
                dgvSupplyHistory.Columns["TypeSupply"].HeaderText = "Loại cấp";
                dgvSupplyHistory.Columns["Dosage"].HeaderText = "Liều lượng";
                dgvSupplyHistory.Columns["Quantity"].HeaderText = "Số lượng";
                dgvSupplyHistory.Columns["Unit"].HeaderText = "Đơn vị";
                dgvSupplyHistory.Columns["Note"].HeaderText = "Ghi chú";
                dgvSupplyHistory.Columns["PatientName"].HeaderText = "Bệnh nhân";
                dgvSupplyHistory.Columns["NurseName"].HeaderText = "Y tá";
                dgvSupplyHistory.Columns["RoomName"].HeaderText = "Phòng";
                dgvSupplyHistory.Columns["DepartmentName"].HeaderText = "Khoa";
                dgvSupplyHistory.Columns["ItemName"].HeaderText = "Tên vật tư";
                // Ẩn các cột không cần
                dgvSupplyHistory.Columns["ItemID"].Visible = false;
                dgvSupplyHistory.Columns["RoomID"].Visible = false;
                dgvSupplyHistory.Columns["NurseID"].Visible = false;
                dgvSupplyHistory.Columns["PatientID"].Visible = false;
                dgvSupplyHistory.Columns["ItemName"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpCareDate.Value.Date;
            LoadSupplyHistory(selectedDate);
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
            var reportForm = new FormSupplyHistoryByDateReportAdmin(fromDate);
            reportForm.ShowDialog();
        }
    }
}
