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
    public partial class FormAdmin : Form
    {
        string IDStaffLogin;
        public FormAdmin()
        {
            InitializeComponent();
        }public FormAdmin(string id)
        {
            InitializeComponent();
            IDStaffLogin = id;
        }

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            DangNhap_GUI f = new DangNhap_GUI();
            f.ShowDialog();
            this.Close();
        }

        private void AccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAccount f = new FormAccount();
            f.ShowDialog();
            this.Close();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormStaff f = new FormStaff();
            f.ShowDialog();
            this.Close();
        }

        private void bệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPatient f = new FormPatient();
            f.ShowDialog();
            this.Close();
        }

        private void phátLươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSalaryDetail f = new FormSalaryDetail(IDStaffLogin);
            f.ShowDialog();
            this.Close();
        }

        private void bảngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSalary f = new FormSalary();
            f.ShowDialog();
            this.Close();
        }
    }
}
