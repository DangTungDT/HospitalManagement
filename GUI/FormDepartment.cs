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
    public partial class FormDepartment : Form
    {
        public FormDepartment()
        {
            InitializeComponent();
        }
        DepartmentBLL blldpm = new DepartmentBLL();
        DepartmentDTO dtodpm = new DepartmentDTO();
        private void FormDepartment_Load(object sender, EventArgs e)
        {
            //dgv_phongban.DataSource = blldpm.HienThi();
            try
            {
                var data = blldpm.HienThi();
                if (data == null) throw new Exception("Dữ liệu phòng ban rỗng.");
                dgv_phongban.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_phongban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1 && e != null)
            //{
            //    txtIdDepartment.Text = dgv_phongban.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            //    txtDepartmentName.Text = dgv_phongban.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            //    txtDescription.Text = dgv_phongban.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            //}
            if (e.RowIndex >= 0)
            {
                txtIdDepartment.Text = dgv_phongban.Rows[e.RowIndex].Cells[0].Value?.ToString().Trim() ?? "";
                txtDepartmentName.Text = dgv_phongban.Rows[e.RowIndex].Cells[1].Value?.ToString().Trim() ?? "";
                txtDescription.Text = dgv_phongban.Rows[e.RowIndex].Cells[2].Value?.ToString().Trim() ?? "";
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            //blldpm.ThemDepartment(new DepartmentDTO(txtIdDepartment.Text, txtDepartmentName.Text, txtDescription.Text));
            //dgv_phongban.DataSource = blldpm.HienThi();
            if (string.IsNullOrWhiteSpace(txtIdDepartment.Text) || string.IsNullOrWhiteSpace(txtDepartmentName.Text))
            {
                MessageBox.Show("Mã phòng ban và tên phòng ban không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            blldpm.ThemDepartment(new DepartmentDTO(txtIdDepartment.Text, txtDepartmentName.Text, txtDescription.Text));
            dgv_phongban.DataSource = blldpm.HienThi();        
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult cauhoi = MessageBox.Show("bạn có muốn xóa không?", "thông báo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cauhoi == DialogResult.Yes)
            {
                blldpm.XoaDepartment(txtIdDepartment.Text);
                dgv_phongban.DataSource = blldpm.HienThi();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdDepartment.Text) || string.IsNullOrWhiteSpace(txtDepartmentName.Text))
            {
                MessageBox.Show("Mã phòng ban và tên phòng ban không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            blldpm.CapnhatDepartment(new DepartmentDTO(txtIdDepartment.Text, txtDepartmentName.Text, txtDescription.Text));
            dgv_phongban.DataSource = blldpm.HienThi();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDepartment_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txtIdDepartment.Clear();
            txtDepartmentName.Clear();
            txtDescription.Clear();
            try
            {
                dgv_phongban.DataSource = blldpm.HienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
