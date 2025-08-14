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
    public partial class FormMenu_LeTan : Form
    {
        public FormMenu_LeTan()
        {
            InitializeComponent();
        }
        string Idstaff;
        public FormMenu_LeTan(string Id)
        {          
            InitializeComponent();
            Idstaff = Id;
        }

        private void đăngKýLicg5GToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngKýLịchHẹnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAppointmentAdmin a =new FormAppointmentAdmin();
            a.Show();
            
        }

        private void thêmBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPatient b = new FormPatient();
            b.Show();
               
        }

        private void tìmKiếmBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatientSearchGUI c = new frmPatientSearchGUI();
            c.Show();
        }

        private void truyVấnLịchHẹnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_truyvanlichhen b = new Form_truyvanlichhen();
            b.Show();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap_GUI c = new DangNhap_GUI();
            c.Show();
            this.Hide();  
        }
    }
}
