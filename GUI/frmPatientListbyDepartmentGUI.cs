using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmPatientListbyDepartmentGUI : Form
    {
        private PatientListbyDepartmentBLL bll = new PatientListbyDepartmentBLL();
        private List<PatientListbyDepartmentDTO> currentPatients = new List<PatientListbyDepartmentDTO>();

        public frmPatientListbyDepartmentGUI()
        {
            InitializeComponent();
            this.Load += frmPatientListbyDepartmentGUI_Load;
            btnSearch.Click += BtnSearch_Click;
            btnPrintReport.Click += BtnPrintReport_Click;
        }

        private void frmPatientListbyDepartmentGUI_Load(object sender, EventArgs e)
        {
            var departments = bll.GetAllDepartments();
            cboDepartment.DataSource = departments;
            cboDepartment.DisplayMember = "departmentName";
            cboDepartment.ValueMember = "id";
            cboDepartment.SelectedIndex = -1;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string departmentId = cboDepartment.SelectedValue?.ToString();
            currentPatients = bll.GetPatientsByDepartment(departmentId);
            dgvPatients.DataSource = currentPatients;
        }

        private void BtnPrintReport_Click(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedIndex == -1 || string.IsNullOrEmpty(cboDepartment.SelectedValue?.ToString()))
            {
                MessageBox.Show("Vui lòng chọn khoa trước khi in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmReportPatientListbyDepartment reportForm = new frmReportPatientListbyDepartment(currentPatients);
            reportForm.ShowDialog();
        }
    }
}
