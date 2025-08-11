using GUI.Helpers;
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
    public partial class frmMedicalOrderReportNurse : Form
    {
        public frmMedicalOrderReportNurse(string doctorId, string patientId)
        {
            InitializeComponent();
            this.doctorid = doctorId;
            this.patientId = patientId; 
        }
        private string doctorid;
        private string patientId;

        private void frmMedicalOrderReportNurse_Load(object sender, EventArgs e)
        {
            try
            {
                // Gán tham số cho báo cáo
                var parameters = new Dictionary<string, object>
                {
                    { "@DoctorId", doctorid },
                    { "@PatientId", patientId }
                };

                // Load báo cáo bằng helper
                var report = CrystalReportHelper.LoadReport("rptMedicalOrderNurse.rpt", parameters);

                if (report != null)
                    crystalReportViewer1.ReportSource = report;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
