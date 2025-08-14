using BLL;
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
    public partial class Form_truyvanlichhen : Form
    {
        public Form_truyvanlichhen()
        {
            InitializeComponent();
        }
        ApmentBLL bll = new ApmentBLL();
        private void Form_truyvanlichhen_Load(object sender, EventArgs e)
        {
            dgv_lichhen.DataSource = bll.HienThi();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ApmentBLL bll = new ApmentBLL();
            DateTime selectedDate = dtp_ngayhen.Value;

            // Gọi hàm tìm kiếm trong BLL
            var report = bll.TimKiemAppointmentTheoStartDate(selectedDate);

            // Hiển thị kết quả tìm kiếm lên DataGridView
            dgv_lichhen.DataSource = report;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Form_truyvanlichhen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cauhoi = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(cauhoi == DialogResult.No)
            {
                e.Cancel = true;
            }    
        }
    }
}
