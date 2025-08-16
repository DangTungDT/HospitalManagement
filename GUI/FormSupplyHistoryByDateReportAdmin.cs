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
    public partial class FormSupplyHistoryByDateReportAdmin : Form
    {
        private DateTime Date;
        public FormSupplyHistoryByDateReportAdmin(DateTime date)
        {
            InitializeComponent();
            this.Date = date;
        }

        private void FormSupplyHistoryByDateReportAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@dateSupply", Date }
                };

                var report = CrystalReportHelper.LoadReport("rptSupplyHistoryByDate.rpt", parameters);
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
