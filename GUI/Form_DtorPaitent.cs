using BLL;
using DAL;
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
    public partial class Form_DtorPaitent : Form
    {
        public Form_DtorPaitent()
        {
            InitializeComponent();
        }
        PatientBLL bllpt = new PatientBLL();

        DtorPaitentDAL bll = new DtorPaitentDAL();

        private void Form_DtorPaitent_Load(object sender, EventArgs e)
        {
            dgv_paitent.DataSource = bllpt.GetAll();
            dgv_doctorpaitent.DataSource = bll.GetAll();
        }
        private DoctorPatientDTO GetDTOFromForm()
        {
            return new DoctorPatientDTO
            {
                DoctorID = txt_iddoctor.Text.Trim(),
                PatientID = txt_idpaitent.Text.Trim(),
                PatientName = txt_namepaitent.Text.Trim(),
                PatientGender = rad_nam.Checked ? "Male" : rad_nu.Checked ? "Female" : "",
                PatientDob = dtp_dobpantent.Value,
                StartDate = dtp_stardate.Value,
                EndDate = dtp_enddate.Checked ? dtp_enddate.Value : (DateTime?)null,
                Role = txt_role.Text.Trim(),
                Note = txt_note.Text.Trim()
            };
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = GetDTOFromForm();

                if (string.IsNullOrEmpty(dto.DoctorID) || string.IsNullOrEmpty(dto.PatientID))
                {
                    MessageBox.Show("Vui lòng nhập ID Doctor và ID Patient!");
                    return;
                }

                bool result = bll.InsertWithPatientCheck(dto);

                MessageBox.Show(result ? "Thêm thành công!" : "Thêm thất bại!");
                dgv_doctorpaitent.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgv_paitent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_paitent.Rows[e.RowIndex];

                // ID bệnh nhân
                txt_idpaitent.Text = row.Cells[0].Value?.ToString();

                // Tên bệnh nhân
                txt_namepaitent.Text = row.Cells[1].Value?.ToString();

                // Giới tính
                rad_nam.Checked = false;
                rad_nu.Checked = false;

                string gender = row.Cells[2].Value?.ToString().Trim();
                if (string.Equals(gender, "Male", StringComparison.OrdinalIgnoreCase))
                {
                    rad_nam.Checked = true;
                }
                else if (string.Equals(gender, "Female", StringComparison.OrdinalIgnoreCase))
                {
                    rad_nu.Checked = true;
                }

                // Ngày sinh bệnh nhân
                if (row.Cells[3].Value != null && DateTime.TryParse(row.Cells[3].Value.ToString(), out DateTime dob))
                {
                    dtp_dobpantent.Value = dob;
                }
            }
        }

        private void dgv_doctorpaitent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_doctorpaitent.Rows[e.RowIndex];

                // ID Doctor
                txt_iddoctor.Text = row.Cells["DoctorID"].Value?.ToString();

                // Ngày bắt đầu
                if (row.Cells["StartDate"].Value != null && DateTime.TryParse(row.Cells["StartDate"].Value.ToString(), out DateTime startDate))
                    dtp_stardate.Value = startDate;

                // Ngày kết thúc
                if (row.Cells["EndDate"].Value != null && DateTime.TryParse(row.Cells["EndDate"].Value.ToString(), out DateTime endDate))
                {
                    dtp_enddate.Value = endDate;
                    dtp_enddate.Checked = true;
                }
                else
                {
                    dtp_enddate.Checked = false;
                }

                // Vai trò
                txt_role.Text = row.Cells["Role"].Value?.ToString();

                // Ghi chú
                txt_note.Text = row.Cells["Note"].Value?.ToString();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                var doctorID = txt_iddoctor.Text.Trim();
                var patientID = txt_idpaitent.Text.Trim();

                if (string.IsNullOrEmpty(doctorID) || string.IsNullOrEmpty(patientID))
                {
                    MessageBox.Show("Vui lòng chọn DoctorID và PatientID để xóa!");
                    return;
                }

                // Nếu muốn xóa cả Patient thì set deletePatient = true
                bool result = bll.DeleteWithCheck(doctorID, patientID, deletePatient: false);

                MessageBox.Show(result ? "Xóa thành công!" : "Xóa thất bại!");
                dgv_doctorpaitent.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = GetDTOFromForm();
                if (string.IsNullOrEmpty(dto.DoctorID) || string.IsNullOrEmpty(dto.PatientID))
                {
                    MessageBox.Show("Vui lòng chọn DoctorID và PatientID để cập nhật!");
                    return;
                }

                bool result = bll.UpdateWithPatientCheck(dto);
                MessageBox.Show(result ? "Cập nhật thành công!" : "Cập nhật thất bại!");
                dgv_doctorpaitent.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Reset TextBox
                txt_iddoctor.Clear();
                txt_idpaitent.Clear();
                txt_namepaitent.Clear();
                txt_role.Clear();
                txt_note.Clear();

                // Reset RadioButton
                rad_nam.Checked = false;
                rad_nu.Checked = false;

                // Reset DateTimePicker
                dtp_dobpantent.Value = DateTime.Now;
                dtp_stardate.Value = DateTime.Now;
                dtp_enddate.Value = DateTime.Now;
                dtp_enddate.Checked = false; // nếu ShowCheckBox = true

                // Optional: bỏ chọn DataGridView
                dgv_paitent.ClearSelection();
                dgv_doctorpaitent.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới form: " + ex.Message);
            }
        }

        private void Form_DtorPaitent_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cauhoi = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(cauhoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
