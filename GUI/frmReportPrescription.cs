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
using DTO;

namespace GUI
{
    public partial class frmReportPrescription : Form
    {
        private List<PrescriptionOfPatientDTO> _prescriptions;
        public frmReportPrescription(List<PrescriptionOfPatientDTO> prescriptions)
        {
            InitializeComponent();
            _prescriptions = prescriptions;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            string path = Path.Combine(Application.StartupPath, "Report", "rptPrescription.rpt");
            report.Load(path);

            // Chuyển List sang DataTable nếu cần
            var dt = ConvertToDataTable(_prescriptions);
            report.SetDataSource(dt);

            crystalReportViewer1.ReportSource = report;
        }

        // Hàm chuyển List<T> sang DataTable
        private DataTable ConvertToDataTable<T>(List<T> items)
        {
            var dt = new DataTable(typeof(T).Name);
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item, null);
                dt.Rows.Add(values);
            }
            return dt;
        }
    }
}
