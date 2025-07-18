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
    public partial class frmTestInfo_Doctor : Form
    {
        public frmTestInfo_Doctor(string currentDoctorId)
        {
            InitializeComponent();
            this.doctorId = currentDoctorId;
        }
        private LaboratoryTestBLL bll = new LaboratoryTestBLL();
        private string doctorId;
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (cboMedicalOrderID.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn y lệnh trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra các trường bắt buộc
            if (
                string.IsNullOrWhiteSpace(txtResultValue.Text) ||
                string.IsNullOrWhiteSpace(txtResultUnit.Text) ||
                string.IsNullOrWhiteSpace(txtResult.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ngày xét nghiệm
            DateTime selectedDate = dtpStartDate.Value.Date;
            DateTime today = DateTime.Today;

            if (selectedDate < today)
            {
                MessageBox.Show("Ngày xét nghiệm không được nhỏ hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo DTO
            LaboratoryTestDoctorDTO dto = new LaboratoryTestDoctorDTO
            {
                MedicalOrderID = Convert.ToInt32(cboMedicalOrderID.SelectedValue), // Sửa lại chỗ này
                ResultValue = txtResultValue.Text.Trim(),
                ResultUnit = txtResultUnit.Text.Trim(),
                Result = txtResult.Text.Trim(),
                StartDate = selectedDate,
                Note = txtNote.Text.Trim()
            };

            try
            {
                bll.AddTest(dto);
                MessageBox.Show("Thêm xét nghiệm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm xét nghiệm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboMedicalOrderID.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn y lệnh để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedOrderId = Convert.ToInt32(cboMedicalOrderID.SelectedValue);

            var result = bll.SearchTestsByPatientId(doctorId, selectedOrderId);

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy xét nghiệm cho y lệnh này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvTestInfo.DataSource = result;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void dgvTestInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selected = dgvTestInfo.Rows[e.RowIndex].DataBoundItem as LaboratoryTestDoctorDTO;
                if (selected != null)
                {
                    // Gán mã y lệnh, ComboBox sẽ hiển thị tên y lệnh (OrderType)
                    cboMedicalOrderID.SelectedValue = selected.MedicalOrderID;

                    // Nếu không khớp, fallback bằng tên y lệnh
                    if (cboMedicalOrderID.SelectedValue == null || (int)cboMedicalOrderID.SelectedValue != selected.MedicalOrderID)
                    {
                        cboMedicalOrderID.SelectedIndex = -1;
                        cboMedicalOrderID.Text = selected.OrderType; // ✅ chỉ hiển thị tên y lệnh
                    }

                    txtResultValue.Text = selected.ResultValue;
                    txtResultUnit.Text = selected.ResultUnit;
                    txtResult.Text = selected.Result;
                    txtNote.Text = selected.Note;
                    dtpStartDate.Value = selected.StartDate ?? DateTime.Now;
                }
            }
        }

        private void frmTestInfo_Doctor_Load(object sender, EventArgs e)
        {
            LoadMedicalOrders();
            LoadData();
            StyleDataGridView(dgvTestInfo);
            StyleDataGridView(dgvMedicalOrderID);

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
        private void LoadMedicalOrders()
        {
            var orders = bll.GetOrdersByAssignedPatients(doctorId);

            cboMedicalOrderID.DataSource = orders;
            cboMedicalOrderID.DisplayMember = "OrderType";  // chỉ hiển thị tên y lệnh
            cboMedicalOrderID.ValueMember = "OrderId";      // giá trị là ID y lệnh

            cboMedicalOrderID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMedicalOrderID.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var auto = new AutoCompleteStringCollection();
            auto.AddRange(orders.Select(o => o.OrderType).ToArray());
            cboMedicalOrderID.AutoCompleteCustomSource = auto;

            cboMedicalOrderID.SelectedIndex = -1;
            cboMedicalOrderID.Text = "";
        }

        private void LoadData()
        {
            dgvTestInfo.DataSource = bll.GetTestsByDoctor(doctorId);
        }
        private void ClearForm()
        {
            cboMedicalOrderID.SelectedIndex = -1;
            txtResultValue.Clear();
            txtResultUnit.Clear();
            txtResult.Clear();
            txtNote.Clear();
            dtpStartDate.Value = DateTime.Now;
        }

        private void cboMedicalOrderID_TextChanged(object sender, EventArgs e)
        {
            string keyword = cboMedicalOrderID.Text.Trim().ToLower();

            var allOrders = bll.GetOrdersByAssignedPatients(doctorId);
            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? allOrders
                : allOrders.Where(o => o.PatientName.ToLower().Contains(keyword)
                                    || o.OrderType.ToLower().Contains(keyword)).ToList();

            dgvMedicalOrderID.DataSource = filtered;
        }
        private void dgvMedicalOrderID_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedOrder = dgvMedicalOrderID.Rows[e.RowIndex].DataBoundItem as MedicalOrderSimpleDTO;
                if (selectedOrder != null)
                {
                    cboMedicalOrderID.SelectedValue = selectedOrder.OrderId;

                    // Nếu không matching thì fallback hiển thị tên y lệnh
                    if (cboMedicalOrderID.SelectedValue == null || cboMedicalOrderID.SelectedValue.ToString() != selectedOrder.OrderId.ToString())
                    {
                        cboMedicalOrderID.Text = selectedOrder.OrderType;
                    }
                }
            }
        }

    }
}
