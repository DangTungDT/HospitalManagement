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
    public partial class FormTransferRoomNurseGUI : Form
    {
        public FormTransferRoomNurseGUI(string staffId, string patientId, string patientName)
        {
            InitializeComponent();
            this.staffId = staffId;
            this.patientId = patientId;
            this.patientName = patientName;
        }

        private string staffId;
        private string patientId;
        private string patientName;
        TransferRoomNurseBLL bll = new TransferRoomNurseBLL();
        private int? currentRoomId;
        private void FormTransferRoomGUI_Load(object sender, EventArgs e)
        {

            lblFullName.Text = patientName;

            // Gán DataSource trước
            var rooms = bll.GetRoomsInDepartment(staffId);
            cboNewRoom.DataSource = rooms;
            cboNewRoom.DisplayMember = "roomName";
            cboNewRoom.ValueMember = "id";
            cboNewRoom.SelectedIndex = -1;

            // Lúc này mới được gọi GetRoomNameById
            currentRoomId = bll.GetCurrentRoomId(patientId);
            lblCurrentRoom.Text = currentRoomId.HasValue
                ? GetRoomNameById(currentRoomId.Value)
                : "Chưa có";
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
        private string GetRoomNameById(int roomId)
        {
            var rooms = (List<Room>)cboNewRoom.DataSource;
            return rooms.FirstOrDefault(r => r.id == roomId)?.roomName ?? "";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cboNewRoom.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng cần chuyển đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newRoomId = (int)cboNewRoom.SelectedValue;
            string note = txtNote.Text.Trim();

            if (note.Length > 255)
            {
                MessageBox.Show("Ghi chú không được vượt quá 255 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentRoomId.HasValue && currentRoomId.Value == newRoomId)
            {
                MessageBox.Show("Phòng mới không được trùng phòng hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bll.TransferRoom(patientId, currentRoomId, newRoomId, note);

            MessageBox.Show($"Chuyển phòng thành công! Phòng hiện tại: {GetRoomNameById(newRoomId)}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật lại giao diện
            currentRoomId = newRoomId;
            lblCurrentRoom.Text = GetRoomNameById(newRoomId);
            cboNewRoom.SelectedIndex = -1;
            txtNote.Text = "";
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
