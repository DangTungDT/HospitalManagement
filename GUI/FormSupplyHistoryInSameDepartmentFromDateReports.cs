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
    public partial class FormSupplyHistoryInSameDepartmentFromDateReports : Form
    {
        public FormSupplyHistoryInSameDepartmentFromDateReports(string doctorId, DateTime targetDate)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            this.targetDate = targetDate;
        }

        private string doctorId;
        private DateTime targetDate;
        private void FormSupplyHistoryInSameDepartmentFromDateReports_Load(object sender, EventArgs e)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@DoctorId", doctorId },
                    { "@FromDate", targetDate }
                };

                var report = CrystalReportHelper.LoadReport("rptSupplyHistoryInSameDepartmentFromDate.rpt", parameters);
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
