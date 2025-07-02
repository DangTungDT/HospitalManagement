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
    public partial class Form_Items : Form
    {
        public Form_Items()
        {
            InitializeComponent();
        }
        ItemBLL bllitem = new ItemBLL();
        ItemsDTO dtoitem = new ItemsDTO();
        private void Form_Items_Load(object sender, EventArgs e)
        {
            cboTypeItem.DataSource = items;
            cboTypeItem.DisplayMember = "Name";
            cboTypeItem.ValueMember = "Value";
            dgv_items.DataSource = bllitem.HienThi();
        }
        public class Item
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        List<Item> items = new List<Item> 
        {
            new Item { Name = "Thuốc", Value="Medicine"},
            new Item { Name = "Thiết bị", Value="Equipment"},
            new Item { Name = "Dụng cụ", Value="Tool"},
            new Item { Name = "Khác", Value="Other Supplies"},
        };

        private void btn_them_Click(object sender, EventArgs e)
        {
            bllitem.ThemItems(new ItemsDTO(txtIdItem.Text, txtNameItem.Text, cboTypeItem.SelectedValue.ToString(), txtUnit.Text, decimal.Parse(txtPrice.Text), DateTime.Parse(dtp_CreatedAt.Text), click()));
            dgv_items.DataSource = bllitem.HienThi();
        }
        private bool click()
        {
            if (radActive.Checked)
            {
                return true;
            }
            else if (radInActive.Checked)
            {
                return false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trạng thái.");
                // Trường hợp không chọn gì: mặc định trả false hoặc bạn có thể throw exception tùy logic
                return false;
            }
        }

        private void dgv_items_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e != null)
            {
                txtIdItem.Text = dgv_items.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameItem.Text = dgv_items.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboTypeItem.SelectedValue = dgv_items.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtUnit.Text = dgv_items.Rows[e.RowIndex].Cells[3].Value.ToString();

                // Giá
                decimal price;
                if (decimal.TryParse(dgv_items.Rows[e.RowIndex].Cells[4].Value.ToString(), out price))
                {
                    txtPrice.Text = price.ToString("0.##");
                }

                // Ngày tạo
                DateTime createdAt;
                if (DateTime.TryParse(dgv_items.Rows[e.RowIndex].Cells[5].Value.ToString(), out createdAt))
                {
                    dtp_CreatedAt.Value = createdAt;
                }

                // Trạng thái
                bool status = Convert.ToBoolean(dgv_items.Rows[e.RowIndex].Cells[6].Value);
                if (status)
                {
                    radActive.Checked = true;
                }
                else
                {
                    radInActive.Checked = true;
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            bllitem.CapnhatItems(new ItemsDTO(txtIdItem.Text, txtNameItem.Text, cboTypeItem.SelectedValue.ToString(), txtUnit.Text, decimal.Parse(txtPrice.Text), DateTime.Parse(dtp_CreatedAt.Text), click()));
            dgv_items.DataSource = bllitem.HienThi();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult cauhoi = MessageBox.Show("bạn có muốn xóa không?", "thông báo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cauhoi == DialogResult.Yes)
            {
                bllitem.XoaItems(txtIdItem.Text);
                dgv_items.DataSource = bllitem.HienThi();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Items_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txtIdItem.Clear();
            txtNameItem.Clear();
            cboTypeItem.SelectedItem = null;
            txtUnit.Clear();
            txtPrice.Clear();

        }
    }
}
