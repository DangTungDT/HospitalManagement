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
    public partial class FormRoomTransferHistoryDetail : Form
    {
        public FormRoomTransferHistoryDetail(string patientId, string patientName)
        {
            InitializeComponent();
            _patientId = patientId;
            _patientName = patientName;
        }
        TransferRoomNurseBLL bll = new TransferRoomNurseBLL();
        string _patientId;
        string _patientName;
        private void FormRoomTransferHistoryDetail_Load(object sender, EventArgs e)
        {
            LoadPatientInfo();
            dgvHistory.DataSource = bll.GetRoomTransferHistoryByPatient(_patientId);
        }
        private void LoadPatientInfo()
        {
            var bll = new MedicalOrderDoctorBLL();
            var patient = bll.GetPatientInfoById(_patientId);

            if (patient != null)
            {
                lblPatientName.Text = patient.FullName;
                lblGender.Text = patient.Gender;
                lblDob.Text = patient.Dob?.ToString("dd/MM/yyyy");
                lblPhone.Text = patient.PhoneNumber;
                lblStatus.Text = patient.Status;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
