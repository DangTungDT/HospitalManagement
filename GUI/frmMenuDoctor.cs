
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
    public partial class frmMenuDoctor : Form
    {
        private string maAccount;

        public frmMenuDoctor(string maAccount)
        {
            InitializeComponent();
            this.maAccount = maAccount;
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

        private void panel_Body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThongTinBacSi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDoctorInfo_Doctor(maAccount));
        }

        private void btnKhoaCongTac_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDepartmentInfoDoctorGUI(maAccount));
        }

        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPatientInfo_Doctor(maAccount));
        }

        private void btnBenhAn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMedicalRecordInfo_Doctor(maAccount));
        }

        private void btnThuoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMedicineInfo_Doctor());
        }

        private void btnDonThuoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPrescriptionDoctorGUI(maAccount));
        }

        private void btnChiTietDonThuoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPrescriptionDetailInfoDoctorGUI());
        }

        private void btnXetNghiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTestInfo_Doctor(maAccount));
        }

        private void btnLoaiXetNghiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTestTypeInfoDoctorGUI());
        }

        private void frmMenuDoctor_Load(object sender, EventArgs e)
        {

        }

        private void btnMedicalOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMedicalOrderDoctorGUI(maAccount));
        }
    }
}
