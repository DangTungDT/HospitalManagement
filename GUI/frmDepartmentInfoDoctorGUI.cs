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
    public partial class frmDepartmentInfoDoctorGUI : Form
    {
        private DepartmentInfoDoctorBLL bll = new DepartmentInfoDoctorBLL();
		private DepartmentInfoDoctorDTO departmentInfo;
		private string currentDoctorId; // Lưu doctorID hiện tại

        public frmDepartmentInfoDoctorGUI()
        {
            InitializeComponent();
            this.Load += frmDepartmentInfoDoctorGUI_Load;
            
            
            
        }

		// Constructor với doctorID để load thông tin theo tài khoản
		public frmDepartmentInfoDoctorGUI(string doctorId) : this()
        {
			currentDoctorId = doctorId;
        }

        private void frmDepartmentInfoDoctorGUI_Load(object sender, EventArgs e)
        {
            LoadDepartmentInfo();
        }

		private void LoadDepartmentInfo()
        {
            try
            {
				// Nếu có doctorID thì load theo doctorID, không thì hiển thị thông báo
				if (!string.IsNullOrEmpty(currentDoctorId))
                {
					departmentInfo = bll.GetDepartmentInfoByDoctorID(currentDoctorId);
                }
                else
                {
					MessageBox.Show("Không tìm thấy thông tin bác sĩ!\nVui lòng đăng nhập lại.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (departmentInfo != null)
                {
                    DisplayDepartmentInfo();
                    UpdateTitle();
                }
                else
                {
					MessageBox.Show("Không tìm thấy thông tin khoa công tác!\nVui lòng kiểm tra lại bác sĩ.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin: {ex.Message}\nVui lòng kiểm tra kết nối database.", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void DisplayDepartmentInfo()
        {
            // Thông tin khoa
            txtDepartmentID.Text = departmentInfo.DepartmentID ?? "";
            txtDepartmentName.Text = departmentInfo.DepartmentName ?? "";
            rtbDescription.Text = departmentInfo.Description ?? "";

            // Thông tin bác sĩ
            txtDoctorID.Text = departmentInfo.DoctorID ?? "";
            txtDoctorName.Text = departmentInfo.DoctorName ?? "";
            txtPosition.Text = departmentInfo.DoctorPosition ?? "";
            txtQualification.Text = departmentInfo.DoctorQualification ?? "";
            txtDegree.Text = departmentInfo.DoctorDegree ?? "";
            txtStatus.Text = departmentInfo.Status ?? "";

            // Ngày bắt đầu
            if (departmentInfo.StartDate.HasValue)
            {
                dtpStartDate.Value = departmentInfo.StartDate.Value;
            }
            else
            {
                dtpStartDate.Value = DateTime.Now;
            }

            // Thống kê
            txtStaffCount.Text = departmentInfo.StaffCount.ToString();
            txtRoomCount.Text = departmentInfo.RoomCount.ToString();
            txtPatientCount.Text = departmentInfo.PatientCount.ToString();

            // Cập nhật màu sắc cho trạng thái
            UpdateStatusColor();
        }

        private void UpdateStatusColor()
        {
            if (departmentInfo != null)
            {
                switch (departmentInfo.Status?.ToLower())
                {
                    case "active":
                        txtStatus.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113); // Xanh lá
                        break;
                    case "inactive":
                        txtStatus.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60); // Đỏ
                        break;
                    case "on leave":
                        txtStatus.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18); // Cam
                        break;
                    default:
                        txtStatus.ForeColor = System.Drawing.Color.Black;
                        break;
                }
            }
        }

        private void UpdateTitle()
        {
            if (departmentInfo != null)
            {
                lblTitle.Text = $"Thông Tin Khoa Công Tác - {departmentInfo.DepartmentName}";
            }
        }     

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDepartmentInfo();
        }

		// Method để cập nhật doctorID từ form khác
		public void UpdateDoctorId(string doctorId)
        {
			currentDoctorId = doctorId;
            LoadDepartmentInfo();
        }

        // Method để lấy thông tin khoa hiện tại
        public DepartmentInfoDoctorDTO GetCurrentDepartmentInfo()
        {
            return departmentInfo;
        }
    }
}
