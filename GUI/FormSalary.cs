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
    public partial class FormSalary : Form
    {
        SalaryBLL bll = new SalaryBLL();
        int ID = 0;
        public FormSalary()
        {
            InitializeComponent();
        }

        private void FormSalary_Load(object sender, EventArgs e)
        {
            dgvBasicSalary.DataSource = bll.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBasicSalary.Text))
            {
                labelCheck.Text = "Vui lòng nhập lương !";
                labelCheck.ForeColor = Color.Red;
            }
            else
            {
                int result = bll.Add(new SalaryDTO() { BasicSalary = Decimal.Parse(txtBasicSalary.Text) });
                switch (result)
                {
                    case -2:
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                        break;
                    case -1:
                        MessageBox.Show("Thông tin đã tồn tại", "Thông báo");
                        break;
                    case 0:
                        MessageBox.Show("Thêm thành công ", "Thông báo");
                        break;
                    case 1:
                        MessageBox.Show("Lỗi không thể thêm", "Thông báo");
                        break;
                    case -3:
                        MessageBox.Show("Lương không được âm", "Thông báo");
                        break;
                    case 2:
                        MessageBox.Show("Lỗi không thể thêm !", "Thông báo");
                        break;
                }
                dgvBasicSalary.DataSource = bll.GetAll();
                labelCheck.Text = "";
            }
        }

        private void txtBasicSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(txtBasicSalary.Text))
                {
                    labelCheck.Text = "Vui lòng nhập lương !";
                    labelCheck.ForeColor = Color.Red;
                }
                else
                {
                    if (bll.Delete(Decimal.Parse(txtBasicSalary.Text)))
                    {
                        MessageBox.Show("Xóa thành công ", "Thông báo");
                        txtBasicSalary.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại ", "Thông báo");
                    }
                    dgvBasicSalary.DataSource = bll.GetAll();
                    labelCheck.Text = "";
                }
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtBasicSalary.Text))
            {
                labelCheck.Text = "Vui lòng nhập lương !";
                labelCheck.ForeColor = Color.Red;
            }
            else
            {
                if(ID == 0)
                {
                    MessageBox.Show("Vui lòng chọn lại trong danh sách ", "Thông báo");
                }
                else
                {
                    if (bll.Update(new SalaryDTO() { BasicSalary = Decimal.Parse(txtBasicSalary.Text), Id = ID }))
                    {
                        MessageBox.Show("Cập nhật thành công ", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại ", "Thông báo");
                    }
                    dgvBasicSalary.DataSource = bll.GetAll();
                    labelCheck.Text = "";
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            labelCheck.Text = "";
            txtBasicSalary.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBasicSalary_Click(object sender, EventArgs e)
        {
            int cellSelected = dgvBasicSalary.CurrentCell.RowIndex;
            if (cellSelected > -1 && dgvBasicSalary.Rows[cellSelected].Cells.Count > 0 &&
                dgvBasicSalary.Rows[cellSelected].Cells[1].Value != null)
            {
                ID = int.Parse(dgvBasicSalary.Rows[cellSelected].Cells[0].Value.ToString());
                txtBasicSalary.Text = dgvBasicSalary.Rows[cellSelected].Cells[1].Value.ToString();
            }
        }
    }
}
