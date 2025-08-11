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
    public partial class ReporstDailyCaresInSameDepartmentAsDoctorAndDateNurseGUI : Form
    {
        public ReporstDailyCaresInSameDepartmentAsDoctorAndDateNurseGUI(string doctorId, DateTime targetDate)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            this.targetDate = targetDate;
        }
        private string doctorId;
        private DateTime targetDate;

        private void ReporstDailyCaresInSameDepartmentAsDoctorAndDateNurseGUI_Load(object sender, EventArgs e)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@DoctorId", doctorId },
                    { "@TargetDate", targetDate }
                };

                var report = CrystalReportHelper.LoadReport("rptDailyCaresInSameDepartmentAsDoctorAndDateNurse.rpt", parameters);
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
