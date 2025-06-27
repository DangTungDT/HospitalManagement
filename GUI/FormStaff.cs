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

        private void btnAdd_Click(object sender, EventArgs e)
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
}
