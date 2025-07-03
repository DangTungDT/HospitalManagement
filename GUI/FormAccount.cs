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
using System.Security.Cryptography;

namespace GUI
{
    public partial class FormAccount : Form
    {
        AccountBLL bll = new AccountBLL();
        StaffBLL bllStaff = new StaffBLL();
        List<Item> list = new List<Item>()
            {
                new Item("Hoạt động", "Activity"),
                new Item("Ngưng hoạt động", "Inactivity")
            };
        public FormAccount()
        {
            InitializeComponent();
        }

        private bool CheckInput()
        {
            bool flag = true;
            if(string.IsNullOrEmpty(txtUsername.Text))
            {
                labErroUsername.Text = "Vui lòng nhập tài khoản";
                labErroUsername.ForeColor = Color.Red;
                flag = false;
            }
            if(string.IsNullOrEmpty(txtPassword.Text))
            {
                labPassword.Text = "Vui lòng nhập mật khẩu";
                labPassword.ForeColor = Color.Red;
                flag = false;
            }
            if(string.IsNullOrEmpty(txtCheckPass.Text))
            {
                labCheckPass.Text = "Vui lòng nhập lại mật khẩu";
                labCheckPass.ForeColor = Color.Red;
                flag = false;
            }
            if(txtPassword.Text != txtCheckPass.Text)
            {
                labCheckPass.Text = "Nhập mật khẩu không trùng khớp";
                labCheckPass.ForeColor = Color.Red;
                flag = false;
            }
            return flag;

        }
        private int Add()
        {
            string passHash = HashStringSHA256(txtPassword.Text);
            return bll.Add(new AccountDTO(txtUsername.Text, passHash, cbbStaffID.SelectedValue.ToString(), cbbStatus.SelectedValue.ToString()));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labPassword_Click(object sender, EventArgs e)
        {

        }

        private void FormAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtCheckPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void dtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void cbbStaffID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void cbbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void Clean()
        {
            txtUsername.Text = "";
            dtpStartDate.Value = DateTime.Now;
            txtCheckPass.Text = "";
            txtPassword.Text = "";
            labErroUsername.Text = "";
            labPassword.Text = "";
            labCheckPass.Text = "";
            cbbDepartmentID.DataSource = bll.GetAllDepartment();

            cbbStatus.SelectedValue = "Activity";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckInput())
            {
                int result = Add();
                switch(result)
                {
                    case -2:
                        MessageBox.Show("Vui lòng nhập thông tin chính xác","Thông báo");
                        break;
                    case -1:
                            MessageBox.Show("Tài khoản đã tồn tại !", "Thông báo");
                        break;
                    case 0:
                        MessageBox.Show("Thêm thành công ! ", "Thông báo");
                        
                        dgvAccount.DataSource = bll.GetAll();
                        Clean();
                        break;
                    case 1:
                        MessageBox.Show("Lỗi sảy ra trong qua trình thêm", "Thông báo");
                        break;
                    case 2:
                        MessageBox.Show("Lỗi sảy ra khi kết nối lớp", "Thông báo");
                        break;
                }
            }
        }

        private void FormAccount_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtCheckPass.UseSystemPasswordChar = true;
            //Load Account 
            dgvAccount.DataSource = bll.GetAll();
            dgvAccount.Columns["password"].Visible = false;
            dgvAccount.Columns["staffID"].Visible = false;

            //Load Status
            cbbStatus.DataSource = list;
            cbbStatus.DisplayMember = "Name";
            cbbStatus.ValueMember = "Code";

            //Load Department
            cbbDepartmentID.DataSource = bll.GetAllDepartment();
            cbbDepartmentID.DisplayMember = "departmentName";
            cbbDepartmentID.ValueMember = "id";
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbbDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
                cbbStaffID.DataSource = bllStaff.GetStaffByDepartmentID(cbbDepartmentID.SelectedValue.ToString());
                cbbStaffID.DisplayMember = "name";
                cbbStaffID.ValueMember = "id";
         
        }

        // Hàm mã hóa SHA256
        private static string HashStringSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2")); // chuyển byte sang hex
                }
                return sb.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult questionDelete = MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(questionDelete == DialogResult.Yes)
            {
                if(bll.Delete(txtUsername.Text))
                {
                    MessageBox.Show("Xóa thành công !", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !", "Thông báo");
                }
                dgvAccount.DataSource = bll.GetAll();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(bll.Update(new AccountDTO(txtUsername.Text, HashStringSHA256(txtPassword.Text), cbbStaffID.ValueMember.ToString(), cbbStatus.ValueMember.ToString())))
            {
                MessageBox.Show("Cập nhật thành công !", "Thông báo");
                dgvAccount.DataSource = bll.GetAll();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại !", "Thông báo");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccount_Click(object sender, EventArgs e)
        {
            int cellSelect = dgvAccount.CurrentCell.RowIndex;
            if(cellSelect > -1 &&
                dgvAccount.Rows[cellSelect].Cells.Count >0 &&
                dgvAccount.Rows[cellSelect].Cells[1].Value != null)
            {
                txtUsername.Text = dgvAccount.Rows[cellSelect].Cells[1].Value.ToString();
                dtpStartDate.Value = DateTime.Parse(dgvAccount.Rows[cellSelect].Cells[5].Value.ToString());
                cbbStaffID.SelectedValue = dgvAccount.Rows[cellSelect].Cells[3].Value.ToString();
                cbbDepartmentID.SelectedValue = dgvAccount.Rows[cellSelect].Cells[7].Value.ToString();
                
                if(dgvAccount.Rows[cellSelect].Cells[6].Value.ToString().Substring(0,1).ToLower() == "a")
                {
                    cbbStatus.SelectedValue = "Activity";
                }
                else
                {
                    cbbStatus.SelectedValue = "Inactivity";
                }
            }
        }

        private void pButton_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
