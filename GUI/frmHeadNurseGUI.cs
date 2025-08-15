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
        public frmHeadNurseGUI( string maAcc)
        {
            InitializeComponent();
            this.maAccount = maAcc;
        }
        private string maAccount;
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
            var inpatientForm = new frmInpatientManagementGUI(maAccount);
            inpatientForm.OnTransferRoomRequested += HandleTransferRoomRequest;

            OpenChildForm(inpatientForm);
        }
        private void HandleTransferRoomRequest(string patientId, string fullName)
        {
            var transferForm = new FormTransferRoomNurseGUI(maAccount, patientId, fullName);
            OpenChildForm(transferForm);
        }

        private void btnMedicalRecord_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMedicalRecordGUI(maAccount));
        }

        private void btnDailyCare_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDailyCareGUI(maAccount));
        }

        private void btnTaskAssignment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTaskAssignmentGUI(maAccount));
        }

        private void btnMedicalInventory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMedicalInventoryGUI(maAccount));
        }

        private void frmHeadNurseGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            DangNhap_GUI f = new DangNhap_GUI();
            f.ShowDialog();
            this.Close();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
