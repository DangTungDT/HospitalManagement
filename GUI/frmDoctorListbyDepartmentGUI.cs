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
    public partial class frmDoctorListbyDepartmentGUI : Form
    {
        private DoctorListbyDepartmentBLL bll = new DoctorListbyDepartmentBLL();
        private List<DoctorListbyDepartmentDTO> currentDoctors = new List<DoctorListbyDepartmentDTO>();

        public frmDoctorListbyDepartmentGUI()
        {
            InitializeComponent();
            this.Load += frmDoctorListbyDepartmentGUI_Load;
            btnSearch.Click += BtnSearch_Click;
            btnPrintReport.Click += BtnPrintReport_Click;
        }

        private void frmDoctorListbyDepartmentGUI_Load(object sender, EventArgs e)
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
            currentDoctors = bll.GetDoctorsByDepartment(departmentId);
            dgvDoctors.DataSource = currentDoctors;
            // Ẩn/hiện cột, đặt header nếu muốn
        }

        private void BtnPrintReport_Click(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedIndex == -1 || string.IsNullOrEmpty(cboDepartment.SelectedValue?.ToString()))
            {
                MessageBox.Show("Vui lòng chọn khoa trước khi in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmReportDoctorListbyDepartment reportForm = new frmReportDoctorListbyDepartment(currentDoctors);
            reportForm.ShowDialog();
        }
    }
}
