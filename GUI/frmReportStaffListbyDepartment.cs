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
            ReportDocument report = new ReportDocument();
            string path = Path.Combine(Application.StartupPath, "Report", "rptStaffList.rpt");
            report.Load(path);

            ParameterValues para = new ParameterValues();
            ParameterDiscreteValue parav = new ParameterDiscreteValue();
            parav.Value = _maKhoa;
            para.Add(parav);
            report.DataDefinition.ParameterFields["@DepartmentID"].ApplyCurrentValues(para);

            crystalReportViewer1.ReportSource = report;
        }
    }
}
