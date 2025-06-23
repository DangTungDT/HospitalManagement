using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmHeadNurseGUI : Form
    {
        public frmHeadNurseGUI()
        {
            InitializeComponent();
        }

        private void frmHeadNurse_Load(object sender, EventArgs e)
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

        private void btnInpatientManagement_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInpatientManagementGUI());
        }

        private void btnMedicalRecord_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMedicalRecordGUI());
        }

        private void btnDailyCare_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDailyCareGUI());
        }

        private void btnTaskAssignment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTaskAssignmentGUI());
        }

        private void btnMedicalInventory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMedicalInventoryGUI());
        }
    }
}
