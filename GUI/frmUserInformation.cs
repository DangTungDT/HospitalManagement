using System;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmUserInformation : Form
    {
        private string _username; // Lưu username đăng nhập
        private UserInfomationBLL bll = new UserInfomationBLL();

        /// <summary>
        /// Khởi tạo form với username
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        public frmUserInformation(string username)
        {
            InitializeComponent();
            _username = username;
            LoadUserInfo();
        }

        /// <summary>
        /// Lấy và hiển thị thông tin nhân viên lên form
        /// </summary>
        private void LoadUserInfo()
        {
            UserInfomationDTO staff = bll.GetStaffInfo(_username);
            if (staff != null)
            {
                // Gán dữ liệu lên các control (giả sử đã có các TextBox tương ứng)
                txtId.Text = staff.Id;
                txtName.Text = staff.Name;
                txtRole.Text = staff.Role;
                txtDob.Text = staff.Dob?.ToString("dd/MM/yyyy");
                txtGender.Text = staff.Gender;
                txtPhone.Text = staff.PhoneNumber;
                txtEmail.Text = staff.Email;
                txtAddress.Text = staff.HomeAddress;
                txtCitizenID.Text = staff.CitizenID;
                txtDepartment.Text = staff.DepartmentName;
                txtPosition.Text = staff.Position;
                txtQualification.Text = staff.Qualification;
                txtDegree.Text = staff.Degree;
                txtStatus.Text = staff.Status;
                txtStartDate.Text = staff.StartDate?.ToString("dd/MM/yyyy");
                txtNotes.Text = staff.Notes;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
