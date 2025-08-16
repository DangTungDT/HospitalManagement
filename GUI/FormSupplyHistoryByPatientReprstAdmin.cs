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
    public partial class FormSupplyHistoryByPatientReprstAdmin : Form
    {
        public FormSupplyHistoryByPatientReprstAdmin(string paniteID)
        {
            InitializeComponent();
            this.PaniteId = paniteID;
        }
        private string PaniteId;
        private void FormSupplyHistoryByPatientReprstAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@patientId", PaniteId }
                };

                var report = CrystalReportHelper.LoadReport("rptSupplyHistoryByPatient.rpt", parameters);
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
