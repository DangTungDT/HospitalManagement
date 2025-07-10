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
        ItemBLL itbll = new ItemBLL();
        private void FormInventory_Load(object sender, EventArgs e)
        {
            dgv_khovattu.DataSource = ivtbll.HienThi();
            dgvitem.DataSource = itbll.HienThi();
            dgvitem.Columns["Price"].Visible = false;
            dgvitem.Columns["CreatedAt"].Visible = false;
            dgvitem.Columns["IsActive"].Visible = false;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            ivtbll.ThemInventory(new InventoryDTO(txt_iditem.Text,
                
                int.Parse(txtQuantity.Text), 
                DateTime.Parse(dtpLastUpdate.Text)));
            dgv_khovattu.DataSource = ivtbll.HienThi();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult cauhoi = MessageBox.Show("bạn có muốn xóa không?", "thông báo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cauhoi == DialogResult.Yes)
            {
                ivtbll.XoaInventory(int.Parse(dgv_khovattu.Rows[dgv_khovattu.CurrentCell.RowIndex].Cells[0].Value.ToString()));
                dgv_khovattu.DataSource = ivtbll.HienThi();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            ivtbll.CapnhatInventory(new InventoryDTO(txt_iditem.Text,
                int.Parse(dgv_khovattu.Rows[dgv_khovattu.CurrentCell.RowIndex].Cells[0].Value.ToString()),
                int.Parse(txtQuantity.Text),
                DateTime.Parse(dtpLastUpdate.Text)));
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
                txtQuantity.Text = dgv_khovattu.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtpLastUpdate.Text = dgv_khovattu.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
           // txtIdItem.Clear();
            txtQuantity.Clear();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvitem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e != null)
            {
                txt_iditem.Text = dgvitem.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_nameitem.Text = dgvitem.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void txt_nameitem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_nameitem.Text.Trim();
            dgvitem.DataSource = ivtbll.SearchItems(keyword);
        }
    }
}
