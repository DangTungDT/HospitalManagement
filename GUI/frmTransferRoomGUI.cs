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
    public partial class frmTransferRoomGUI : Form
    {
        public frmTransferRoomGUI(string patientId, string patientName)
        {
            InitializeComponent();
            this.patientId = patientId;
            this.patientName = patientName;
        }
        private readonly TransferRoomNurseBLL transferRoomBLL = new TransferRoomNurseBLL();
        private readonly string patientId;
        private readonly string patientName;
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
        private void frmTransferRoomGUI_Load(object sender, EventArgs e)
        {
            lblPatientName.Text = patientName;

            // Hiển thị phòng hiện tại
            int? currentRoomId = transferRoomBLL.GetCurrentRoomId(patientId);
            if (currentRoomId.HasValue)
            {
                var currentRoom = transferRoomBLL.GetRoomsByDepartmentId(
                    transferRoomBLL.GetDepartmentIdOfPatient(patientId)
                ).Find(r => r.id == currentRoomId.Value);
                lblCurrentRoom.Text = currentRoom != null ? currentRoom.roomName : "Chưa nhận phòng";
            }
            else
            {
                lblCurrentRoom.Text = "Chưa nhận phòng";
            }

            // Load danh sách phòng mới
            string deptId = transferRoomBLL.GetDepartmentIdOfPatient(patientId);
            cboNewRoom.DataSource = transferRoomBLL.GetRoomsByDepartmentId(deptId);
            cboNewRoom.DisplayMember = "roomName";
            cboNewRoom.ValueMember = "id";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNewRoom.SelectedValue == null)
                    throw new Exception("Vui lòng chọn phòng mới.");

                int newRoomId = (int)cboNewRoom.SelectedValue;

                string note = txtNote.Text?.Trim(); // tránh null reference
                if (!string.IsNullOrEmpty(note) && note.Length > 255)
                    throw new Exception("Ghi chú không được vượt quá 255 ký tự.");

                transferRoomBLL.TransferRoom(patientId, newRoomId, note);

                MessageBox.Show("Chuyển phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
