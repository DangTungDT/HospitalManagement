using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmPrescriptionDoctorGUI : Form
    {
        private PrescriptionInfoDoctorBLL bll = new PrescriptionInfoDoctorBLL();
        private List<PatientComboDTO> patientList;
        private List<PrescriptionInfoDoctorDTO> prescriptionList;
        private readonly StaffDoctorBLL staffBll = new StaffDoctorBLL();
        private string currentDoctorId;
        private TextBox txtDoctorNameReadonly;

        public frmPrescriptionDoctorGUI()
        {
            InitializeComponent();
            this.Load += frmPrescriptionDoctorGUI_Load;
            btnCreate.Click += btnCreate_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnViewDetail.Click += btnViewDetail_Click;
            dgvPrescriptions.CellClick += dgvPrescriptions_CellClick;
            btnRefresh.Click += btnRefresh_Click;
            btnSearch.Click += btnSearch_Click;
        }

        public frmPrescriptionDoctorGUI(string doctorId) : this()
        {
            currentDoctorId = doctorId;
        }

        private void frmPrescriptionDoctorGUI_Load(object sender, EventArgs e)
        {
            // Nếu có doctorId, chỉ load bệnh nhân thuộc bác sĩ đó
            if (!string.IsNullOrWhiteSpace(currentDoctorId))
            {
                patientList = bll.GetPatientsByDoctor(currentDoctorId);
            }
            else
            {
                patientList = bll.GetPatients();
            }
            cbPatient.DataSource = patientList;
            cbPatient.DisplayMember = "fullName";
            cbPatient.ValueMember = "id";

            // Hiển thị tên bác sĩ đăng nhập ở TextBox readonly, ẩn combobox bác sĩ
            SetupDoctorReadonlyField();

            // ComboBox tìm kiếm bệnh nhân
            cbSearchPatient.DataSource = new List<PatientComboDTO>(patientList) { new PatientComboDTO { id = "", fullName = "--Tất cả--" } };
            cbSearchPatient.DisplayMember = "fullName";
            cbSearchPatient.ValueMember = "id";
            cbSearchPatient.SelectedIndex = cbSearchPatient.Items.Count - 1;

            // Mặc định hiển thị danh sách đơn thuốc của riêng bác sĩ này nếu có
            if (!string.IsNullOrWhiteSpace(currentDoctorId))
            {
                var list = bll.Search(null, currentDoctorId, null);
                LoadPrescriptionList(list);
            }
            else
            {
                LoadPrescriptionList();
            }
        }

        private void LoadPrescriptionList(List<PrescriptionInfoDoctorDTO> list = null)
        {
            if (list == null) prescriptionList = bll.GetAll();
            else prescriptionList = list;
            
            // Hiển thị tên thay vì mã trong DataGridView
            dgvPrescriptions.AutoGenerateColumns = true;
            dgvPrescriptions.DataSource = prescriptionList;
            

            if (dgvPrescriptions.Columns.Count > 0)
            {
                dgvPrescriptions.Columns["PrescriptionID"].HeaderText = "Mã Đơn";
                dgvPrescriptions.Columns["PatientName"].HeaderText = "Bệnh Nhân";
                dgvPrescriptions.Columns["DoctorName"].HeaderText = "Bác Sĩ";
                dgvPrescriptions.Columns["OrderDate"].HeaderText = "Ngày Kê";
                dgvPrescriptions.Columns["Note"].HeaderText = "Ghi Chú";
                
              
                if (dgvPrescriptions.Columns.Contains("PatientID"))
                    dgvPrescriptions.Columns["PatientID"].Visible = false;
                if (dgvPrescriptions.Columns.Contains("DoctorID"))
                    dgvPrescriptions.Columns["DoctorID"].Visible = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cbPatient.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!");
                return;
            }

            var dto = new PrescriptionInfoDoctorDTO
            {
                PatientID = cbPatient.SelectedValue?.ToString(),
                DoctorID = string.IsNullOrWhiteSpace(currentDoctorId) ? null : currentDoctorId,
                OrderDate = dtpOrderDate.Value,
                Note = rtbNote.Text.Trim()
            };
            
            if (bll.Insert(dto))
            {
                MessageBox.Show("Tạo đơn thuốc thành công! Mã đơn thuốc sẽ được tự động tạo.");
                LoadPrescriptionList();
                ClearInput();
            }
            else
            {
                MessageBox.Show("Tạo đơn thuốc thất bại!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var dto = new PrescriptionInfoDoctorDTO
            {
                PrescriptionID = txtPrescriptionID.Text.Trim(),
                PatientID = cbPatient.SelectedValue?.ToString(),
                DoctorID = string.IsNullOrWhiteSpace(currentDoctorId) ? null : currentDoctorId,
                OrderDate = dtpOrderDate.Value,
                Note = rtbNote.Text.Trim()
            };
            if (bll.Update(dto))
            {
                MessageBox.Show("Cập nhật đơn thuốc thành công!");
                LoadPrescriptionList();
                ClearInput();
            }
            else
            {
                MessageBox.Show("Cập nhật đơn thuốc thất bại!");
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptions.CurrentRow != null)
            {
                string prescriptionId = dgvPrescriptions.CurrentRow.Cells["PrescriptionID"].Value.ToString();
                var frmDetail = new frmPrescriptionDetailInfoDoctorGUI(prescriptionId);
                frmDetail.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn thuốc để xem chi tiết!");
            }
        }

        // Sự kiện: Khi click vào dòng trong DataGridView, hiển thị dữ liệu lên các control phía trên
        private void dgvPrescriptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPrescriptions.Rows[e.RowIndex].DataBoundItem as PrescriptionInfoDoctorDTO;
                if (row != null)
                {
                    txtPrescriptionID.Text = row.PrescriptionID;
                    cbPatient.SelectedValue = row.PatientID;
                    cbDoctor.SelectedValue = row.DoctorID;
                    dtpOrderDate.Value = row.OrderDate;
                    rtbNote.Text = row.Note;
                }
            }
        }

        // Nút Làm Mới: xóa trắng các control nhập liệu
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void ClearInput()
        {
            txtPrescriptionID.Text = "";
            cbPatient.SelectedIndex = -1;
            dtpOrderDate.Value = DateTime.Now;
            rtbNote.Text = "";
        }

        // Tìm kiếm theo mã bệnh nhân
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string patientId = cbSearchPatient.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(patientId))
            {
                var filtered = bll.Search(patientId, currentDoctorId, null);
                LoadPrescriptionList(filtered);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(currentDoctorId))
                {
                    LoadPrescriptionList(bll.Search(null, currentDoctorId, null));
                }
                else
                {
                    LoadPrescriptionList();
                }
            }
        }

        private void SetupDoctorReadonlyField()
        {
            try
            {
                // Ẩn combobox bác sĩ nếu tồn tại và thay bằng TextBox readonly
                if (cbDoctor != null)
                {
                    cbDoctor.Visible = false;
                    // Tạo textbox trùng vị trí/kích thước
                    txtDoctorNameReadonly = new TextBox();
                    txtDoctorNameReadonly.ReadOnly = true;
                    txtDoctorNameReadonly.Enabled = false;
                    txtDoctorNameReadonly.TabStop = false;
                    txtDoctorNameReadonly.Location = cbDoctor.Location;
                    txtDoctorNameReadonly.Size = cbDoctor.Size;
                    txtDoctorNameReadonly.Name = "txtDoctorNameReadonly";
                    cbDoctor.Parent.Controls.Add(txtDoctorNameReadonly);
                    txtDoctorNameReadonly.BringToFront();
                }

                if (!string.IsNullOrWhiteSpace(currentDoctorId))
                {
                    var info = staffBll.GetDoctorInfo(currentDoctorId);
                    if (info != null)
                    {
                        if (txtDoctorNameReadonly != null)
                        {
                            txtDoctorNameReadonly.Text = info.Name;
                        }
                    }
                }
            }
            catch { }
        }
    }
}