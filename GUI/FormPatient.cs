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
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    public partial class FormPatient : Form
    {

        PatientBLL bll = new PatientBLL();
        public FormPatient()
        {
            InitializeComponent();
        }

        private void panelFillForm_Resize(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbInsuranceID_CheckedChanged(object sender, EventArgs e)
        {
            if(cbInsuranceID.Checked )
            {
                txtInsuranceID.Visible = true;
            }
            else
            {
                txtInsuranceID.Text = "";
                txtInsuranceID.Visible = false;
            }
        }

        private void FormPatient_Load(object sender, EventArgs e)
        {
            //Load data cho datagridview patient
            dgvPatient.DataSource = bll.GetAll();
            dgvPatient.Columns["citizenID"].Visible = false;
            dgvPatient.Columns["InsuranceID"].Visible = false;
            dgvPatient.Columns["address"].Visible = false;
            dgvPatient.Columns["EmergencyContact"].Visible = false;
            dgvPatient.Columns["EmergencyPhone"].Visible = false;
            dgvPatient.Columns["createdDate"].Visible = false;
            dgvPatient.Columns["updatedDate"].Visible = false;
            dgvPatient.Columns["weight"].Visible = false;
            dgvPatient.Columns["height"].Visible = false;

            //Tạo List typepatient
            List<Item> list = new List<Item>()
            {
                new Item("Nội trú","Inpatient"),
                new Item("Ngoại trú","Outpatient"),
                new Item("Khác","Other")
            };
            cbbTypePatient.DataSource = list;
            cbbTypePatient.DisplayMember = "Name";
            cbbTypePatient.ValueMember = "Code";

            //Tạo list cho Status
            list = new List<Item>()
            {
                new Item("Đang điều trị","UnderTreatment"),
                new Item("Xuất viện","Discharged"),
                new Item("Khác","Other")
            };
            cbbStatus.DataSource = list;
            cbbStatus.DisplayMember = "Name";
            cbbStatus.ValueMember = "Code";

            //Đặt dữ liệu tĩnh cho dtpCreatedDate
            dtpCreatedDate.Value = DateTime.Now;

            //Đặt dữ liệu tĩnh cho dtpUpdatedDate
            dtpUpdatedDate.Value = DateTime.Now;

        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpUpdatedDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormPatient_Resize(object sender, EventArgs e)
        {
        }

        private void panelFillForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckValueInput())
            {
                PatientDTO item = new PatientDTO()
                {
                    Id = txtID.Text,
                    FullName = txtFullName.Text,
                    Dob = dtpDob.Value,
                    PhoneNumber = txtPhoneNumber.Text,
                    TypePatient = cbbTypePatient.SelectedValue.ToString(),
                    CitizenID = txtCitizenID.Text,
                    Address = txtAddress.Text,
                    EmergencyContact = txtEmergencyName.Text,
                    EmergencyPhone = txtEmergencyPhone.Text,
                    Status = cbbStatus.SelectedValue.ToString(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Weight = double.Parse(txtWeight.Text),
                    Height = double.Parse(txtHeight.Text)

                };
                if(radGenderFemale.Checked)
                {
                    item.Gender = "Female";
                }else if(radGenderMale.Checked)
                {
                    item.Gender = "Male";
                }
                else
                {
                    item.Gender = "Other";
                }
                if(cbInsuranceID.Checked)
                {
                    item.InsuranceID = txtInsuranceID.Text;
                }
                int result = bll.Add(item);
                switch(result)
                {
                    case -2:
                        MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo");
                        break;
                    case -1:
                        MessageBox.Show("ID đã tồn tại ", "Thông báo");
                        break;
                    case 0:
                        MessageBox.Show("Thêm thành công !", "Thông báo");
                        break;
                    case 1:
                        MessageBox.Show("Lỗi khi thêm dữ liệu", "Thông báo");
                        break;
                    case 2:
                        MessageBox.Show("Lỗi khi thêm", "Thông báo");
                        break;
                }
                dgvPatient.DataSource = bll.GetAll();

            }
        }
        private bool CheckValueInput()
        {
            bool flag = true;
            if(txtID == null)
            {
                labelID.Text = "Vui lòng nhập ID";
                labelID.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                labelID.Text = "";
            }
            if (txtFullName == null)
            {
                labelFullName.Text = "Vui lòng nhập họ và tên";
                labelFullName.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                labelFullName.Text = "";
            }
            if (dtpDob == null)
            {
                labelDob.Text = "Vui lòng nhập ngày sinh đúng";
                labelDob.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                if(dtpDob.Value.Date > DateTime.Now.Date)
                {

                labelDob.Text = "";
                }
            }
            if (txtPhoneNumber == null)
            {
                labelPhoneNumber.Text = "Vui lòng nhập đúng số điện thoại";
                labelPhoneNumber.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                labelPhoneNumber.Text = "";
            }
            if (cbInsuranceID.Checked == true && txtInsuranceID == null)
            {
                labelInsuranceID.Text = "Vui lòng nhập đúng bảo hiểm y tế";
                labelInsuranceID.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                if(string.IsNullOrEmpty(txtInsuranceID.Text))
                {
                labelInsuranceID.Text = "";
                }
            }
            if (txtWeight == null)
            {
                if(int.Parse(txtWeight.Text) <= 0)
                {
                    labelWeight.Text = "Vui lòng nhập đúng cân nặng";
                    labelWeight.ForeColor = Color.Red;
                    flag = false;
                }
                
            }
            else
            {
                labelWeight.Text = "";
            }
            if ( txtHeight == null)
            {
                    labelHeight.Text = "Vui lòng nhập đúng chiều cao";
                    labelHeight.ForeColor = Color.Red;
                flag = false;
                
            }
            else
            {
                if (int.Parse(txtHeight.Text) > 0)
                {

                    labelHeight.Text = "";
                }
            }
            if (txtAddress == null)
            {
                labelAddress.Text = "Vui lòng nhập địa chỉ";
                labelAddress.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtAddress.Text))
                {
                    labelPhoneNumber.Text = "";
                }
                else
                {
                    labelAddress.Text = "Vui lòng nhập địa chỉ";
                    labelAddress.ForeColor = Color.Red;
                    flag = false;
                }

            }
            if (txtEmergencyName == null)
            {
                labelEmergencyName.Text = "Vui lòng nhập tên người thân";
                labelEmergencyName.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtEmergencyName.Text))
                {
                    labelEmergencyName.Text = "";
                }
                else
                {
                    labelEmergencyName.Text = "Vui lòng nhập địa chỉ";
                    labelEmergencyName.ForeColor = Color.Red;
                    flag = false;
                }
            }
            if (txtEmergencyPhone == null)
            {
                labelEmergencyPhone.Text = "Vui lòng nhập số điện thoại người thân";
                labelEmergencyPhone.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                labelEmergencyPhone.Text = "";
            }
            return flag;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmergencyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtCitizenID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtInsuranceID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                if (txtID != null)
                {
                    if (bll.Delete(txtID.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo");
                    }
                    dgvPatient.DataSource = bll.GetAll();
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void Clean()
        {
            txtID.Text = "";
            txtFullName.Text = "";
            radGenderFemale.Checked = false;
            radGenderMale.Checked = false;
            radGenderOther.Checked = false;
            dtpDob.Value = DateTime.Now;
            txtPhoneNumber.Text = "";
            txtCitizenID.Text = "";
            cbInsuranceID.Checked = false;
            txtInsuranceID.Text = "";
            txtWeight.Text = "";
            txtHeight.Text = "";
            txtAddress.Text = "";
            txtEmergencyName.Text = "";
            txtEmergencyPhone.Text = "";
            dtpCreatedDate.Value = DateTime.Now;
            dtpUpdatedDate.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPatient_Click(object sender, EventArgs e)
        {
            int cellSelected = dgvPatient.CurrentCell.RowIndex;
            if(cellSelected >-1 && dgvPatient.Rows[cellSelected].Cells.Count >0 &&
                dgvPatient.Rows[cellSelected].Cells[2].Value != null)
            {
                txtID.Text = dgvPatient.Rows[cellSelected].Cells[0].Value.ToString();
                txtFullName.Text = dgvPatient.Rows[cellSelected].Cells[1].Value.ToString();
                if(dgvPatient.Rows[cellSelected].Cells[2].Value.ToString().ToLower() == "male")
                {
                    radGenderOther.Checked = false;
                    radGenderFemale.Checked = false;
                    radGenderMale.Checked = true;
                }else if(dgvPatient.Rows[cellSelected].Cells[2].Value.ToString().ToLower() == "female")
                {
                    radGenderMale.Checked = false;
                    radGenderOther.Checked = false;
                    radGenderFemale.Checked = true;
                }
                else
                {
                    radGenderFemale.Checked = false;
                    radGenderMale.Checked = false;
                    radGenderOther.Checked = true;
                }
                dtpDob.Value = DateTime.Parse(dgvPatient.Rows[cellSelected].Cells[3].Value.ToString());
                txtPhoneNumber.Text = dgvPatient.Rows[cellSelected].Cells[4].Value.ToString();
                txtCitizenID.Text = dgvPatient.Rows[cellSelected].Cells[6].Value.ToString();
                if (dgvPatient.Rows[cellSelected].Cells[7].Value == null)
                {
                    cbInsuranceID.Checked = false;
                    txtInsuranceID.Text = "";
                }
                else
                {
                    cbInsuranceID.Checked = true;
                    txtInsuranceID.Text = dgvPatient.Rows[cellSelected].Cells[7].Value.ToString();

                }
                txtWeight.Text = dgvPatient.Rows[cellSelected].Cells[14].Value.ToString();
                txtHeight.Text = dgvPatient.Rows[cellSelected].Cells[15].Value.ToString();
                txtAddress.Text = dgvPatient.Rows[cellSelected].Cells[8].Value.ToString();
                txtEmergencyName.Text = dgvPatient.Rows[cellSelected].Cells[9].Value.ToString();
                txtEmergencyPhone.Text = dgvPatient.Rows[cellSelected].Cells[10].Value.ToString();
                cbbStatus.SelectedValue = dgvPatient.Rows[cellSelected].Cells[11].Value.ToString();
                dtpCreatedDate.Value = DateTime.Parse(dgvPatient.Rows[cellSelected].Cells[12].Value.ToString());
                dtpUpdatedDate.Value = DateTime.Parse(dgvPatient.Rows[cellSelected].Cells[13].Value.ToString());
                cbbTypePatient.SelectedValue = dgvPatient.Rows[cellSelected].Cells[5].Value.ToString();
            }
        }
    }
}
