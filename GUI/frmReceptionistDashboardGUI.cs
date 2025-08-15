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
    public partial class frmReceptionistDashboardGUI : Form
    {
        public frmReceptionistDashboardGUI()
        {
            InitializeComponent();
        }

        private void frmReceptionistDashboardGUI_Load(object sender, EventArgs e)
        {

        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnPatientAdmission_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPatientAdmissionGUI());
        }

        private void btnMedicalRegistration_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMedicalRegistrationGUI());
        }

        private void btnAppointmentManagement_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAppointmentManagement());
        }

        private void btnPatientSearch_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPatientSearchGUI());
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {

        }
    }
}
