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
    public partial class FormHistoryOutItem : Form
    {
        public FormHistoryOutItem()
        {
            InitializeComponent();
        }
        
        public FormHistoryOutItem(string itemType)
        {
            InitializeComponent();
            label4.Text = "Lịch sử lấy thuốc";
            btnFind.Text = "Tìm thuốc";
            
        }
        private void FormHistoryItemOut_Load(object sender, EventArgs e)
        {
            txtItemID.Text = "Nhập ID của sản phẩm";
            txtItemID.ForeColor = Color.Gray;

            txtItemName.Text = "Nhập tên của sản phẩm";
            txtItemName.ForeColor = Color.Gray;

            txtRecipientName.Text = "Nhập tên người nhận hàng";
            txtRecipientName.ForeColor = Color.Gray;

            txtDispatcherName.Text = "Nhập tên người xuất hàng";
            txtDispatcherName.ForeColor = Color.Gray;
        }

        private void txtItemID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemID.Text))
            {
                txtItemID.Text = "Nhập ID của sản phẩm";
                txtItemID.ForeColor = Color.Gray;
            }
        }

        private void txtItemID_Enter(object sender, EventArgs e)
        {
            if (txtItemID.Text == "Nhập ID của sản phẩm")
            {
                txtItemID.Text = "";
                txtItemID.ForeColor = Color.Black;
            }
        }

        private void txtItemName_Enter(object sender, EventArgs e)
        {
            if (txtItemName.Text == "Nhập tên của sản phẩm")
            {
                txtItemName.Text = "";
                txtItemName.ForeColor = Color.Black;
            }
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                txtItemName.Text = "Nhập tên của sản phẩm";
                txtItemName.ForeColor = Color.Gray;
            }
        }

        private void txtRecipientName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecipientName.Text))
            {
                txtRecipientName.Text = "Nhập tên người nhận hàng";
                txtRecipientName.ForeColor = Color.Gray;
            }
        }

        private void txtRecipientName_Enter(object sender, EventArgs e)
        {
            if (txtRecipientName.Text == "Nhập tên người nhận hàng")
            {
                txtRecipientName.Text = "";
                txtRecipientName.ForeColor = Color.Black;
            }
        }

        private void txtDispatcherName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDispatcherName.Text))
            {
                txtDispatcherName.Text = "Nhập tên người xuất hàng";
                txtDispatcherName.ForeColor = Color.Gray;
            }
        }

        private void txtDispatcherName_Enter(object sender, EventArgs e)
        {
            if (txtDispatcherName.Text == "Nhập tên người xuất hàng")
            {
                txtDispatcherName.Text = "";
                txtDispatcherName.ForeColor = Color.Black;
            }
        }
    }
}
