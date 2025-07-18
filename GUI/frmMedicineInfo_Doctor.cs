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
    public partial class frmMedicineInfo_Doctor : Form
    {
        public frmMedicineInfo_Doctor()
        {
            InitializeComponent();
        }
        ItemDoctorBLL itemBLL = new ItemDoctorBLL();
        private void frmMedicineInfo_Doctor_Load(object sender, EventArgs e)
        {
            var list = itemBLL.GetAllMedicines();

            // Đổ dữ liệu vào ComboBox
            cboMedicineSearch.DataSource = list;
            cboMedicineSearch.DisplayMember = "ItemName";  // Hiện tên thuốc
            cboMedicineSearch.ValueMember = "ID";          // Giá trị là mã thuốc

            // Tự động hoàn tất khi gõ gần đúng
            cboMedicineSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMedicineSearch.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Hiện tất cả thuốc ban đầu
            dgvMedicineList.DataSource = list;
            cboMedicineSearch.SelectedIndex = -1;
            cboMedicineSearch.Text = "";
            StyleDataGridView(dgvMedicineList);
        }

        private void itemID_TextChanged(object sender, EventArgs e)
        {

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = cboMedicineSearch.Text.Trim(); // Lấy từ textbox (gõ tên thuốc)
            if (!string.IsNullOrEmpty(keyword))
            {
                var results = itemBLL.SearchMedicines(keyword);
                dgvMedicineList.DataSource = results;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboMedicineSearch.SelectedIndex = -1;
            cboMedicineSearch.Text = "";
            dgvMedicineList.DataSource = itemBLL.GetAllMedicines();
        }
    }
}
