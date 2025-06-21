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
    public partial class FormItems : Form
    {
        bool flagTypeItem = false;
        public FormItems()
        {
            InitializeComponent();
        }

        public FormItems(string itemType)
        {
            InitializeComponent();
            flagTypeItem = true;
            label4.Text = "Thuốc";
            btnOutItems.Text = "Lấy Thuốc";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            
        }

        private void FormItems_Load(object sender, EventArgs e)
        {
            txtSearchID.Text = "Tìm kiếm theo ID";
            txtSearchID.ForeColor = Color.Gray;

            txtSearchName.Text = "Tìm kiếm theo Tên";
            txtSearchName.ForeColor = Color.Gray;

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearchID_Enter(object sender, EventArgs e)
        {
            if (txtSearchID.Text == "Tìm kiếm theo ID")
            {
                txtSearchID.Text = "";
                txtSearchID.ForeColor = Color.Black;
            }
        }

        private void txtSearchID_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearchID.Text))
            {
                txtSearchID.Text = "Tìm kiếm theo ID";
                txtSearchID.ForeColor = Color.Gray;
            }
        }

        private void txtSearchName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchName.Text))
            {
                txtSearchName.Text = "Tìm kiếm theo Tên";
                txtSearchName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchName_Enter(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "Tìm kiếm theo Tên")
            {
                txtSearchName.Text = "";
                txtSearchName.ForeColor = Color.Black;
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
