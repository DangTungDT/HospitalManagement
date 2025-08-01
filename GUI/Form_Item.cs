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
    public partial class Form_Item : Form
    {
        public Form_Item()
        {
            InitializeComponent();
        }
        ItemBLL bllitem = new ItemBLL();
        ItemDTO dtoitem = new ItemDTO();
        private void Form_Item_Load(object sender, EventArgs e)
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
            // 1. Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtIdItem.Text) ||
                string.IsNullOrWhiteSpace(txtNameItem.Text) ||
                string.IsNullOrWhiteSpace(txtUnit.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin các trường bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra định dạng giá
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Kiểm tra combobox đã chọn chưa
            if (cboTypeItem.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại vật tư.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Kiểm tra trạng thái có được chọn không
            bool? status = GetItemStatus();
            if (status == null)
            {
                // Hàm GetItemStatus sẽ hiển thị MessageBox nên chỉ cần return
                return;
            }

            // 5. Tạo DTO và gọi BLL
            ItemDTO item = new ItemDTO(
                txtIdItem.Text.Trim(),
                txtNameItem.Text.Trim(),
                cboTypeItem.SelectedValue.ToString(),
                txtUnit.Text.Trim(),
                price,
                dtp_CreatedAt.Value,
                status.Value
            );

            bllitem.ThemItems(item);
            dgv_items.DataSource = bllitem.HienThi();

        }
        private bool? GetItemStatus()
        {
            if (radActive.Checked)
                return true;
            else if (radInActive.Checked)
                return false;
            else
            {
                MessageBox.Show("Vui lòng chọn trạng thái hoạt động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void dgv_items_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e != null)
            {
                txtIdItem.Text = dgv_items.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtNameItem.Text = dgv_items.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                cboTypeItem.SelectedValue = dgv_items.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtUnit.Text = dgv_items.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();

                // Giá
                decimal price;
                if (decimal.TryParse(dgv_items.Rows[e.RowIndex].Cells[4].Value.ToString().Trim(), out price))
                {
                    txtPrice.Text = price.ToString("0.##");
                }

                // Ngày tạo
                DateTime createdAt;
                if (DateTime.TryParse(dgv_items.Rows[e.RowIndex].Cells[5].Value.ToString().Trim(), out createdAt))
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

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtIdItem.Text) ||
                string.IsNullOrWhiteSpace(txtNameItem.Text) ||
                string.IsNullOrWhiteSpace(txtUnit.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin các trường bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra định dạng giá
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Kiểm tra combobox đã chọn chưa
            if (cboTypeItem.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại vật tư.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Kiểm tra trạng thái có được chọn không
            bool? status = GetItemStatus();
            if (status == null)
            {
                return; // Hàm đã hiển thị MessageBox
            }

            // 5. Tạo DTO và cập nhật
            ItemDTO item = new ItemDTO(
                txtIdItem.Text.Trim(),
                txtNameItem.Text.Trim(),
                cboTypeItem.SelectedValue.ToString(),
                txtUnit.Text.Trim(),
                price,
                dtp_CreatedAt.Value,
                status.Value
            );

            bllitem.CapnhatItems(item);
            dgv_items.DataSource = bllitem.HienThi();

        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txtIdItem.Clear();
            txtNameItem.Clear();
            cboTypeItem.SelectedItem = null;
            txtUnit.Clear();
            txtPrice.Clear();
        }

        private void Form_Item_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
