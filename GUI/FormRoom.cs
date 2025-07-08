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
            // Kiểm tra tên phòng
            if (string.IsNullOrWhiteSpace(txtNameRoom.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số giường hợp lệ
            if (string.IsNullOrWhiteSpace(txtBedCount.Text) || !int.TryParse(txtBedCount.Text, out int bedCount) || bedCount <= 0)
            {
                MessageBox.Show("Số giường phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra bộ phận đã chọn chưa
            if (cbo_bophan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bộ phận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm phòng nếu mọi thứ hợp lệ
            RoomDTO room = new RoomDTO
            {
                RoomName = txtNameRoom.Text.Trim(),
                BedCount = bedCount,
                DepartmentID = cbo_bophan.SelectedValue.ToString()
            };

            bllroom.ThemRoom(room);
            dgv_phong.DataSource = bllroom.HienThi();
        }

        private void dgv_phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e != null)
            {
                txtIdRoom.Text = dgv_phong.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtNameRoom.Text = dgv_phong.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtBedCount.Text = dgv_phong.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();              
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
            // Kiểm tra tên phòng
            if (string.IsNullOrWhiteSpace(txtNameRoom.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số giường hợp lệ
            if (string.IsNullOrWhiteSpace(txtBedCount.Text) || !int.TryParse(txtBedCount.Text, out int bedCount) || bedCount <= 0)
            {
                MessageBox.Show("Số giường phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra bộ phận đã chọn chưa
            if (cbo_bophan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bộ phận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm phòng nếu mọi thứ hợp lệ
            RoomDTO room = new RoomDTO
            {
                RoomName = txtNameRoom.Text.Trim(),
                BedCount = bedCount,
                DepartmentID = cbo_bophan.SelectedValue.ToString()
            };

            bllroom.CapnhatRoom(room);
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
