using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using GUI.Helpers;
using GUI.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUI
{
    public partial class form_rpttruyvanlichhen : Form
    {
        public form_rpttruyvanlichhen(DateTime date)
        {
            InitializeComponent();
            this.date = date;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        DateTime date;
        ApmentBLL bll = new ApmentBLL();
        private void form_rpttruyvanlichhen_Load(object sender, EventArgs e)
        {
            try
            {
                Report.crptTruyvanlichhen rp = new Report.crptTruyvanlichhen();

                // Tạo tham số
                ParameterValues prm = new ParameterValues();
                ParameterDiscreteValue prmd = new ParameterDiscreteValue();
                prmd.Value = date.Date;
                prm.Add(prmd);

                // Gán tham số vào report
                rp.DataDefinition.ParameterFields["@Date"].ApplyCurrentValues(prm);

                // Gán report vào CrystalReportViewer
                crystalReportViewer1.ReportSource = rp;
                crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {

            }
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
