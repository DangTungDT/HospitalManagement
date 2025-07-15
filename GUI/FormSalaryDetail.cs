using DTO;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace GUI
{
    public partial class FormSalaryDetail : Form
    {
        //Biến toàn cục
        StaffBLL StaffBLL = new StaffBLL();
        SalaryBLL SalaryBll = new SalaryBLL();
        SalaryDetailBLL SalaryDetailBll = new SalaryDetailBLL();
        string IDStaffLogin;
        public FormSalaryDetail()
        {
            InitializeComponent();
        }
        public FormSalaryDetail(string id)
        {
            InitializeComponent();
            IDStaffLogin = id;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormSalaryDetail_Load(object sender, EventArgs e)
        {
            //Load dữ liệu cho combobox Department
            cbbDepartmentID.DataSource = StaffBLL.LoadDepartment();
            cbbDepartmentID.DisplayMember = "departmentName";
            cbbDepartmentID.ValueMember = "id";

            //Load dữ liệu cho combobox BasicSalary
            cbbBasicSalary.DataSource = SalaryBll.GetAll();
            cbbBasicSalary.DisplayMember = "BasicSalary";
            cbbBasicSalary.ValueMember = "id";

            //Thêm dữ liệu cho combobox Year dữ trên năm hiện tại
            int year = DateTime.Now.Year;
            for(int i = -2; i< 3;  i++)
            {
                cbbYear.Items.Add(year +i);
            }

            //Lấy ngày trả lương là ngày hiện tại
            dtpSalaryDate.Value = DateTime.Now;

            //Load dữ liệu cho datagridview Staff theo id Depart lấy của combobox Department
            dgvStaff.DataSource = StaffBLL.GetStaffByDepartmentID(cbbDepartmentID.SelectedValue.ToString());

            //Load dữ liệu datagridview SalaryDetail
            dgvSalaryDetail.DataSource = SalaryBll.GetAll();

            //Load dữ liệu và để chèn vào txtCreateStaff
            string staffCreate = StaffBLL.Exists(IDStaffLogin);
            if (!string.IsNullOrEmpty(staffCreate))
            {
                //Trường hợp có dữ liệu người thêm
                txtCreateStaff.Text = staffCreate.Split('_')[1] + " " + staffCreate.Split('_')[0];
            }
            else
            {
                //Trường hợp không có dữ liệu người thêm
                //txtCreateStaff.Text = "";
                txtCreateStaff.Text = "Dang Thanh Tung_Bac Si_Ngoai chan thuong";
            }


            
        }

        private void cbbDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load lại dữ liệu cho datagridview Staff theo id Depart lấy của combobox Department
            dgvStaff.DataSource = StaffBLL.GetStaffByDepartmentID(cbbDepartmentID.SelectedValue.ToString());
        }

        private void cbbBasicSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Tạo biến
            Control[] arrControl = new Control[8] { cbbBasicSalary, txtWorkingDays, txtOvertimeHours, txtAllowance, txtBonus, txtDeduction, txtIncomeTax, txtSocialInsurance };
            int workingDays = 0;
            Decimal[] arrDecimal = new Decimal[7];
            int y = 0;

            //Chèn dữ liệu vào cho mảng arrDecimal từ các control
            for (int i = 0; i < 8; i++)
            {
                //bắt control txtWorkingDays để sử lý riêng (do có 1 mình nó là kiểu int)
                if (arrControl[i] == txtWorkingDays)
                {
                    if (!string.IsNullOrEmpty(arrControl[i].Text))
                    {
                        //Trường hợp control có dữ liệu
                        workingDays = int.Parse(arrControl[i].Text);
                    }
                    continue;
                }

                //Sử lý các trường hợp của control để chèn dữ liệu vào mảng chính xác không null
                if (string.IsNullOrEmpty(arrControl[i].Text))
                {
                    arrDecimal[y] = 0;
                }
                else
                {
                    arrDecimal[y] = decimal.Parse(arrControl[i].Text);
                }
                y++;
            }

            //Thực hiện thêm và bắt trường hợp sảy ra
            int result = SalaryDetailBll.Add(new SalaryDetailDTO()
            {
                SalaryID = int.Parse(cbbBasicSalary.SelectedValue.ToString().Trim()),
                StaffId = dgvStaff.Rows[dgvStaff.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim(),
                SalaryPeriod = cbbMonth.Text.Trim() + "/" + cbbYear.Text.Trim(),
                BacsicSalary = arrDecimal[0],
                WorkingDays = workingDays,
                OvertimeHours = arrDecimal[1],
                Allowance = arrDecimal[2],
                Bonus = arrDecimal[3],
                Deduction = arrDecimal[4],
                IncomeTax = arrDecimal[5],
                SocialInsurance = arrDecimal[6],
                Note = txtNote.Text.Trim(),
                CreatedAt = DateTime.Now,
                CreatedBy = txtCreateStaff.Text

            });

            //Văng theo từng trường hợp
            switch (result)
            {
                case -2:
                    MessageBox.Show("Vui lòng nhập thông tin chính xác !");
                    break;
                case -1:
                    MessageBox.Show("Dữ liệu đã tồn tại vui!");
                    break;
                case 0:
                    MessageBox.Show("Thêm thành công !");
                    break;
                case 1:
                    MessageBox.Show("Thêm thất bại");
                    break;
                case 2:
                    MessageBox.Show("Lỗi không thể thêm");
                    break;
            }

            //Load lại datagridview SalaryDetail
            dgvSalaryDetail.DataSource = SalaryDetailBll.GetAll();
        }

        private void panelFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txtWorkingDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtWorkingDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtOvertimeHours_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtAllowance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtBonus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtDeduction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtIncomeTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtSocialInsurance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bạn đã bấm Enter!");
                e.Handled = true; // Ngăn không cho xử lý tiếp (nếu cần)
            }
        }

        private void txtOvertimeHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtAllowance_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtBonus_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtIncomeTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }

        private void txtSocialInsurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho nhập ký tự không hợp lệ
            }
        }
    }
}
