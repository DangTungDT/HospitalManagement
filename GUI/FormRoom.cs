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
    public partial class FormRoom : Form
    {
        public FormRoom()
        {
            InitializeComponent();
        }
        RoomBLL bllroom = new RoomBLL();
        RoomDTO dtoroom = new RoomDTO();
        private void FormRoom_Load(object sender, EventArgs e)
        {
            dgv_phong.DataSource = bllroom.HienThi();
            cbo_bophan.DataSource = bllroom.Laydpm();
            cbo_bophan.DisplayMember = "departmentName";
            cbo_bophan.ValueMember = "id";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            bllroom.ThemRoom(new RoomDTO(int.Parse(txtIdRoom.Text), txtNameRoom.Text, int.Parse(txtBedCount.Text), cbo_bophan.SelectedValue.ToString()));

            // Cập nhật DataGridView để hiển thị thông tin vừa nhập
            dgv_phong.DataSource = bllroom.HienThi();
        }

        private void dgv_phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e != null)
            {
                txtIdRoom.Text = dgv_phong.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameRoom.Text = dgv_phong.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtBedCount.Text = dgv_phong.Rows[e.RowIndex].Cells[2].Value.ToString();              
                cbo_bophan.SelectedValue = dgv_phong.Rows[e.RowIndex].Cells[3].Value.ToString();              
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult cauhoi = MessageBox.Show("bạn có muốn xóa không?", "thông báo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cauhoi == DialogResult.Yes)
            {
                bllroom.XoaRoom(int.Parse(txtIdRoom.Text));
                dgv_phong.DataSource = bllroom.HienThi();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            bllroom.CapnhatRoom(new RoomDTO(int.Parse(txtIdRoom.Text), txtNameRoom.Text, int.Parse(txtBedCount.Text), cbo_bophan.SelectedValue.ToString()));
            dgv_phong.DataSource = bllroom.HienThi();
        }

        private void FormRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txtIdRoom.Clear();
            txtNameRoom.Clear();
            txtBedCount.Clear();
            cbo_bophan.SelectedItem = null;
        }
    }
}
