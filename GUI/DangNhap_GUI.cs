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
    public partial class DangNhap_GUI : Form
    {
        UsersBLL bll = new UsersBLL();
        public DangNhap_GUI()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
                Login(txtUserName.Text, txtPassword.Text);
        }

        private void DangNhap_GUI_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login(txtUserName.Text, txtPassword.Text);
            }
        }

        private void Login(string username, string password)
        {
            UsersDTO accountLogin = bll.GetAccountByUsername(username);
            if(accountLogin != null)
            {
                password = HashStringSHA256(password);
                if (password.Equals(accountLogin.PasswordHash.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    // Cắt chuỗi để lấy phần quyền
                    string[] parts = username.Split('_');
                    string role = parts[0].ToLower();

                    this.Hide();  // Ẩn form Login trước

                    if (role == "quanlykho")
                    {
                        FormInventoryManager f = new FormInventoryManager();
                        f.ShowDialog();
                    }
                    else if (role == "bacsi")
                    {
                        frmMenuDoctor f = new frmMenuDoctor();
                        f.ShowDialog();
                    }
                    else if (role == "dieuduong")
                    {
                        frmHeadNurseGUI f = new frmHeadNurseGUI();
                        f.ShowDialog();
                    }
                    else if (role == "admin")
                    {
                        FormAdmin f = new FormAdmin();
                        f.ShowDialog();
                    }
                    else if (role == "quanlythuoc")
                    {
                        FormInventoryManager f = new FormInventoryManager("quanlythuoc");
                        f.ShowDialog();
                    }

                    // Sau khi form con đóng thì mới đóng form Login
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Thất bại!");
            }
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

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login(txtUserName.Text, txtPassword.Text);
            }
        }
    }
}
