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
using CrystalDecisions.CrystalReports.Engine;
using DTO;
using GUI.Helpers;

namespace GUI
{
    public partial class frmReportDoctorListbyDepartment : Form
    {
        private List<DoctorListbyDepartmentDTO> _doctors;
        public frmReportDoctorListbyDepartment(List<DoctorListbyDepartmentDTO> doctors)
        {
            InitializeComponent();
            _doctors = doctors;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            var report = CrystalReportHelper.LoadReport("rptDoctorList.rpt");
            if (report == null) return;
            var dt = ConvertToDataTable(_doctors);
            report.SetDataSource(dt);
            crystalReportViewer1.ReportSource = report;
        }

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
