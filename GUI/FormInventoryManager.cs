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
    public partial class FormInventoryManager : Form
    {
        bool flagType = false;
        public FormInventoryManager()
        {
            InitializeComponent();
            
        }

        public FormInventoryManager(string Type)
        {
            InitializeComponent();
            flagType = true;
            this.Text = "Quản lý thuốc";
        }

        private void FormInventoryManager_Load(object sender, EventArgs e)
        {
            if(flagType)
            {
                ShowForm(new FormItems("Thuoc"), trangChủToolStripMenuItem, lịchSửToolStripMenuItem);
            }
            else
            {
                ShowForm(new FormItems(), trangChủToolStripMenuItem, lịchSửToolStripMenuItem);
            }
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(flagType)
            {
                ShowForm(new FormItems("Thuoc"), trangChủToolStripMenuItem, lịchSửToolStripMenuItem);
            }
            else
            {
                ShowForm(new FormItems(), trangChủToolStripMenuItem, lịchSửToolStripMenuItem);

            }

        }
        private void ShowForm(Form form, ToolStripMenuItem buttonOn, ToolStripMenuItem buttonOff)
        {
            // Đóng hết các form con cũ
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            // Gán MDI parent TRƯỚC
            form.MdiParent = this;

            // Gán thuộc tính hiển thị
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill; // Bắt form con chiếm toàn bộ vùng hiển thị

            // Gán trạng thái full màn hình
            form.WindowState = FormWindowState.Maximized;

            // Hiển thị form con
            form.Show();

            // Cập nhật lại giao diện
            form.BringToFront();
            form.Refresh();
            this.PerformLayout(); // ép layout cập nhật

            // Màu menu
            buttonOn.BackColor = Color.FromArgb(0, 192, 0);
            buttonOff.BackColor = Color.Lime;
        }


        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( flagType )
            {
                ShowForm(new FormHistoryOutItem("Thuoc"), lịchSửToolStripMenuItem, trangChủToolStripMenuItem);
            }
            else
            {
                ShowForm(new FormHistoryOutItem(), lịchSửToolStripMenuItem, trangChủToolStripMenuItem);
            }
        }

        private void FormInventoryManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            DangNhap_GUI f = new DangNhap_GUI();
            f.ShowDialog();
            this.Close();
        }
    }
}
