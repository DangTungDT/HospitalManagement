using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DTO;
using GUI.Helpers;

namespace GUI
{
    public partial class frmReportPatientListbyDepartment : Form
    {
        private List<PatientListbyDepartmentDTO> _patients;
        public frmReportPatientListbyDepartment(List<PatientListbyDepartmentDTO> patients)
        {
            InitializeComponent();
            _patients = patients;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            var report = CrystalReportHelper.LoadReport("rptPatientList.rpt");
            if (report == null) return;
            var dt = ConvertToDataTable(_patients);
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
