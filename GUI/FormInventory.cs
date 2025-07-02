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
    public partial class FormInventory : Form
    {
        public FormInventory()
        {
            InitializeComponent();
        }

        private void txtBedCount_TextChanged(object sender, EventArgs e)
        {

        }
        InventoryBLL ivtbll = new InventoryBLL();
        InventoryDTO ivtdto = new InventoryDTO();
        private void FormInventory_Load(object sender, EventArgs e)
        {
            dgv_khovattu.DataSource = ivtbll.HienThi();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            ivtbll.ThemInventory(new InventoryDTO(txtIdItem.Text, int.Parse(txtQuantity.Text), DateTime.Parse(dtpLastUpdate.Text)));
            dgv_khovattu.DataSource = ivtbll.HienThi();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult cauhoi = MessageBox.Show("bạn có muốn xóa không?", "thông báo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cauhoi == DialogResult.Yes)
            {
                ivtbll.XoaInventory(txtIdItem.Text);
                dgv_khovattu.DataSource = ivtbll.HienThi();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            ivtbll.CapnhatInventory(new InventoryDTO(txtIdItem.Text, int.Parse(txtQuantity.Text), DateTime.Parse(dtpLastUpdate.Text)));
            dgv_khovattu.DataSource = ivtbll.HienThi();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInventory_FormClosing(object sender, FormClosingEventArgs e)
        {         
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dgv_khovattu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e != null)
            {
                txtIdItem.Text = dgv_khovattu.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtQuantity.Text = dgv_khovattu.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpLastUpdate.Text = dgv_khovattu.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txtIdItem.Clear();
            txtQuantity.Clear();
            
        }
    }
}
