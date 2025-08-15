using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Helpers;

namespace GUI
{
    public partial class frmReportStaffListbyDepartment : Form
    {
        string  _maKhoa;
        public frmReportStaffListbyDepartment(string maKhoa)
        {
            InitializeComponent();
            _maKhoa = maKhoa;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            var parameters = new System.Collections.Generic.Dictionary<string, object>
            {
                { "@DepartmentID", _maKhoa }
            };
            var report = CrystalReportHelper.LoadReport("rptStaffList.rpt", parameters);
            if (report == null) return;
            crystalReportViewer1.ReportSource = report;
        }
    }
}
