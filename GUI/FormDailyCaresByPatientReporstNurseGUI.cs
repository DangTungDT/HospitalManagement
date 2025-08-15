using DAL;
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
    public partial class FormDailyCaresByPatientReporstNurseGUI : Form
    {
        public FormDailyCaresByPatientReporstNurseGUI(string patientId)
        {
            InitializeComponent();
            this.patientId = patientId;
        }
        private string patientId;
        private void FormDailyCaresByPatientReporstNurseGUI_Load(object sender, EventArgs e)
        {
            try
            {
                // Gán tham số cho báo cáo
                var parameters = new Dictionary<string, object>
                {
                    { "@PatientId", patientId }
                };

                // Load báo cáo bằng helper
                var report = CrystalReportHelper.LoadReport("rptDailyCaresByPatientNurse.rpt", parameters);

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
