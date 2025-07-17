using BLL;
using DTO;
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
    public partial class FormStaff : Form
    {
        //Biến toàn cục
        StaffBLL bll = new StaffBLL();
        public FormStaff()
        {
            InitializeComponent();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private bool CheckValue()
        {
            // Kiểm tra TextBox
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("ID không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Phone Number không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHomeAddress.Text))
            {
                MessageBox.Show("Home Address không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCitizenID.Text))
            {
                MessageBox.Show("Citizen ID không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Position không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtQualification.Text))
            {
                MessageBox.Show("Qualification không được để trống!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                MessageBox.Show("Note không được để trống!");
                return false;
            }

            // Kiểm tra ComboBox SelectedValue
            if (cobRole.SelectedValue == null || string.IsNullOrWhiteSpace(cobRole.SelectedValue.ToString()))
            {
                MessageBox.Show("Role không được để trống!");
                return false;
            }
            if (cobGender.SelectedValue == null || string.IsNullOrWhiteSpace(cobGender.SelectedValue.ToString()))
            {
                MessageBox.Show("Gender không được để trống!");
                return false;
            }
            if (cobDepartmentID.SelectedValue == null || string.IsNullOrWhiteSpace(cobDepartmentID.SelectedValue.ToString()))
            {
                MessageBox.Show("Department ID không được để trống!");
                return false;
            }
            if (cobDegree.SelectedValue == null || string.IsNullOrWhiteSpace(cobDegree.SelectedValue.ToString()))
            {
                MessageBox.Show("Degree không được để trống!");
                return false;
            }
            if (cobStatus.SelectedValue == null || string.IsNullOrWhiteSpace(cobStatus.SelectedValue.ToString()))
            {
                MessageBox.Show("Status không được để trống!");
                return false;
            }

            // Kiểm tra DateTimePicker (thường không null, tùy nghiệp vụ)
            if (dtpDob.Value == null)
            {
                MessageBox.Show("Date of Birth không được để trống!");
                return false;
            }
            if (dtpStartDate.Value == null)
            {
                MessageBox.Show("Start Date không được để trống!");
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckValue())
            {

                int result = bll.Add(new StaffDTO(txtID.Text, txtName.Text, cobRole.SelectedValue.ToString(), cobGender.SelectedValue.ToString(), txtPhoneNumber.Text, txtEmail.Text, txtHomeAddress.Text, txtCitizenID.Text, cobDepartmentID.SelectedValue.ToString(), txtPosition.Text, txtQualification.Text, cobDegree.Text, cobStatus.SelectedValue.ToString(), txtNote.Text, dtpDob.Value, dtpStartDate.Value));
                switch(result)
                {
                    case -2:
                        MessageBox.Show("Dữ liệu không hợp lệ vui lòng xem lại !", "Thông báo");
                        break;
                    case -1:
                        MessageBox.Show("ID vừa nhập đã tồn tại không thể thêm !", "Thông báo");
                        break;
                    case 0:
                        MessageBox.Show("Thêm thành công","Thông báo");
                        break;
                    case 1:
                        MessageBox.Show("Đã gặp sự cố khi thêm!","Thông báo");
                        break;
                    case 2:
                        MessageBox.Show("Đã gặp sự cố giữa các lớp", "Thông báo");
                        break;
                }
                dgvStaff.DataSource = bll.GetAll();
            }   
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            //Load data cho control datagridview
            dgvStaff.DataSource = bll.GetAll();

            //Load data cho cobRole
            List<Item> list = new List<Item>()
            {
                new Item("Bác sĩ", "BS"),
                new Item("Điều dưỡng", "DD"),
                new Item("Lễ tân", "LT"),
                new Item("Admin", "AD")
            };
            cobRole.DataSource = list;
            cobRole.DisplayMember = "Name";
            cobRole.ValueMember = "Code";

            //Load data cho cobGender
            list = new List<Item>()
            {
                new Item("Nam", "Male"),
                new Item("Nữ", "Female"),
                new Item("Khác", "Other")
            };
            cobGender.DataSource = list;
            cobGender.DisplayMember = "Name";
            cobGender.ValueMember = "Code";

            //Load data cho cobGender
            list = new List<Item>()
            {
                new Item("Nam", "Male"),
                new Item("Nữ", "Female"),
                new Item("Khác", "Other")
            };
            cobGender.DataSource = list;
            cobGender.DisplayMember = "Name";
            cobGender.ValueMember = "Code";

            //Load data cho cobDepartment
            cobDepartmentID.DataSource = bll.LoadDepartment();
            cobDepartmentID.DisplayMember = "departmentName";
            cobDepartmentID.ValueMember = "Id";

            //Load data cho cobDegree
            list = new List<Item>()
            {
                new Item("9/12", "9/12"),
                new Item("12/12", "12/12"),
                new Item("Cử nhân", "Bachelor"),
                new Item("Thạc sĩ", "Master"),
                new Item("Tiến sĩ", "Doctorate"),
                new Item("Khác", "Other"),
            };
            cobDegree.DataSource = list;
            cobDegree.DisplayMember = "Name";
            cobDegree.ValueMember = "Code";

            //Load data cho cobStatus
            list = new List<Item>()
            {
                new Item("Hoạt động", "Active"),
                new Item("Ngưng hoạt động", "Inactive"),
                new Item("Bị đống băng", "On Leave")
            };
            cobStatus.DataSource = list;
            cobStatus.DisplayMember = "Name";
            cobStatus.ValueMember = "Code";
            cobStatus.SelectedItem = "Active";

            dgvStaff.Columns["Department"].Visible = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bll.Delete(txtID.Text))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo");
                }
                dgvStaff.DataSource = bll.GetAll();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(CheckValue())
            {

                if(bll.Update(new StaffDTO(txtID.Text, txtName.Text, cobRole.SelectedValue.ToString(), cobGender.SelectedValue.ToString(), txtPhoneNumber.Text, txtEmail.Text, txtHomeAddress.Text, txtCitizenID.Text, cobDepartmentID.SelectedValue.ToString(), txtPosition.Text, txtQualification.Text, cobDegree.Text, cobStatus.SelectedValue.ToString(), txtNote.Text, dtpDob.Value, dtpStartDate.Value)))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại !", "Thông báo");
                }
                dgvStaff.DataSource = bll.GetAll();
            }
        }

        private void dgvStaff_Click(object sender, EventArgs e)
        {
            if(dgvStaff.CurrentCell.RowIndex > -1 && dgvStaff.Rows[dgvStaff.CurrentCell.RowIndex] != null && dgvStaff.Rows[dgvStaff.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int rowIndex = dgvStaff.CurrentCell.RowIndex;
                txtID.Text = dgvStaff.Rows[rowIndex].Cells[0].Value.ToString().Trim();
                txtName.Text = dgvStaff.Rows[rowIndex].Cells[1].Value.ToString().Trim();
                cobRole.SelectedValue = dgvStaff.Rows[rowIndex].Cells[2].Value.ToString().Trim();
                dtpDob.Value = DateTime.Parse(dgvStaff.Rows[rowIndex].Cells[3].Value.ToString().Trim());
                cobGender.SelectedValue = dgvStaff.Rows[rowIndex].Cells[4].Value.ToString().Trim();
                txtPhoneNumber.Text = dgvStaff.Rows[rowIndex].Cells[5].Value.ToString().Trim();
                txtEmail.Text = dgvStaff.Rows[rowIndex].Cells[6].Value.ToString().Trim();
                txtHomeAddress.Text = dgvStaff.Rows[rowIndex].Cells[7].Value.ToString().Trim();
                txtCitizenID.Text = dgvStaff.Rows[rowIndex].Cells[8].Value.ToString().Trim();
                cobDepartmentID.SelectedValue = dgvStaff.Rows[rowIndex].Cells[9].Value.ToString();
                txtPosition.Text = dgvStaff.Rows[rowIndex].Cells[10].Value.ToString().Trim();
                txtQualification.Text = dgvStaff.Rows[rowIndex].Cells[11].Value.ToString().Trim();
                cobDegree.Text = dgvStaff.Rows[rowIndex].Cells[12].Value.ToString().Trim();
                cobStatus.SelectedValue = dgvStaff.Rows[rowIndex].Cells[13].Value.ToString().Trim();
                dtpStartDate.Value = DateTime.Parse(dgvStaff.Rows[rowIndex].Cells[14].Value.ToString());
                txtNote.Text = dgvStaff.Rows[rowIndex].Cells[15].Value.ToString();

            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // Kiểm tra ComboBox SelectedValue
            if (cobRole.SelectedValue == null || string.IsNullOrWhiteSpace(cobRole.SelectedValue.ToString()))
            {
                MessageBox.Show("Role không được để trống!");
                return;
            }
            if (cobGender.SelectedValue == null || string.IsNullOrWhiteSpace(cobGender.SelectedValue.ToString()))
            {
                MessageBox.Show("Gender không được để trống!");
                return;
            }
            if (cobDepartmentID.SelectedValue == null || string.IsNullOrWhiteSpace(cobDepartmentID.SelectedValue.ToString()))
            {
                MessageBox.Show("Department ID không được để trống!");
                return;
            }
            if (cobDegree.SelectedValue == null || string.IsNullOrWhiteSpace(cobDegree.SelectedValue.ToString()))
            {
                MessageBox.Show("Degree không được để trống!");
                return;
            }
            if (cobStatus.SelectedValue == null || string.IsNullOrWhiteSpace(cobStatus.SelectedValue.ToString()))
            {
                MessageBox.Show("Status không được để trống!");
                return;
            }

            dgvStaff.DataSource = bll.Find(new StaffDTO(txtID.Text, txtName.Text, cobRole.SelectedValue.ToString(), cobGender.SelectedValue.ToString(), txtPhoneNumber.Text, txtEmail.Text, txtHomeAddress.Text, txtCitizenID.Text, cobDepartmentID.SelectedValue.ToString(), txtPosition.Text, txtQualification.Text, cobDegree.Text, cobStatus.SelectedValue.ToString(), txtNote.Text, dtpDob.Value, dtpStartDate.Value));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtHomeAddress.Text = "";
            txtCitizenID.Text = "";
            dtpDob.Value = DateTime.Now;
            txtPosition.Text = "";
            txtQualification.Text = "";
            cobStatus.SelectedValue = "Active";
            dtpStartDate.Value = DateTime.Now;
            txtNote.Text = "";

            dgvStaff.DataSource = bll.GetAll();
        }
    }
}
