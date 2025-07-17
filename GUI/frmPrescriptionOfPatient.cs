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
    public partial class frmPrescriptionOfPatient : Form
    {
        private PrescriptionOfPatientBLL bll = new PrescriptionOfPatientBLL();

        public frmPrescriptionOfPatient()
        {
            InitializeComponent();
            this.Load += frmPrescriptionOfPatient_Load;
            btnSearch.Click += BtnSearch_Click;
            btnPrintReport.Click += BtnPrintReport_Click;
        }

        private void frmPrescriptionOfPatient_Load(object sender, EventArgs e)
        {
            // Nạp danh sách bệnh nhân vào ComboBox
            var patients = bll.GetAllPatients(); // Hàm này bạn cần bổ sung ở BLL/DAL
            cboPatient.DataSource = patients;
            cboPatient.DisplayMember = "fullName";
            cboPatient.ValueMember = "id";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string patientId = cboPatient.SelectedValue?.ToString();
            DateTime? orderDate = dtpOrderDate.Checked ? dtpOrderDate.Value.Date : (DateTime?)null;
            LoadPrescriptions(patientId, orderDate);
        }

        private void BtnPrintReport_Click(object sender, EventArgs e)
        {
            if (cboPatient.SelectedIndex == -1 || string.IsNullOrEmpty(cboPatient.SelectedValue?.ToString()))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trước khi in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string patientId = cboPatient.SelectedValue?.ToString();
            DateTime? orderDate = dtpOrderDate.Checked ? dtpOrderDate.Value.Date : (DateTime?)null;
            var prescriptions = bll.GetPrescriptionReport(patientId, orderDate);
            frmReportPrescription reportForm = new frmReportPrescription(prescriptions);
            reportForm.ShowDialog();
        }

        private void LoadPrescriptions(string patientId, DateTime? orderDate)
        {
            var list = bll.GetPrescriptionReport(patientId, orderDate).ToList();
            dgvPrescriptions.DataSource = list;
            // Ẩn các cột thông tin cá nhân bệnh nhân, chỉ hiển thị chi tiết đơn thuốc
            if (dgvPrescriptions.Columns.Count > 0)
            {
                string[] showCols = { "PrescriptionID", "OrderDate", "MedicineName", "Dosage", "Quantity", "Unit", "Frequency", "Note", "DoctorName", "DoctorSignedAt" };
                foreach (DataGridViewColumn col in dgvPrescriptions.Columns)
                {
                    col.Visible = showCols.Contains(col.Name);
                }
            }
        }
    }
}
