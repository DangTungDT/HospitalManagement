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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace GUI
{
    public partial class frmPatientInfo_Doctor : Form
    {
        DoctorPatientBLL bll = new DoctorPatientBLL();
        public frmPatientInfo_Doctor(string currentDoctorId)
        {
            InitializeComponent();
            this.doctorId = currentDoctorId;
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var patient = dgvPatient.Rows[e.RowIndex].DataBoundItem as PatientSupplyHistoryDTO;
                if (patient != null)
                {
                    cboPatient.SelectedValue = patient.Id;

                    if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != patient.Id)
                    {
                        // fallback nếu không tìm được
                        cboPatient.Text = patient.FullName;
                    }
                }
            }
        }

        private void cboPatient_TextChanged(object sender, EventArgs e)
        {
            string keyword = cboPatient.Text.Trim().ToLower();

            var allPatients = bll.GetAllPatients(doctorId);
            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? allPatients
                : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();

            dgvPatient.DataSource = filtered;
        }
        private string doctorId;
        private void frmPatientInfo_Doctor_Load(object sender, EventArgs e)
        {
            dgvDoctorPatint.DataSource = bll.GetPatientsByDoctor(doctorId);
            LoadPatients();
            StyleDataGridView(dgvDoctorPatint);
            StyleDataGridView(dgvPatient);
        }
        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;

            // Màu nền nhẹ dịu (xanh nhạt)
            Color nurseBackground = Color.FromArgb(230, 245, 255);
            this.BackColor = nurseBackground;
            e.Graphics.Clear(nurseBackground);

            Pen thickPen = new Pen(Color.RoyalBlue, 2);
            Brush textBrush = new SolidBrush(Color.RoyalBlue);

            Font font = box.Font;
            string text = box.Text;
            SizeF textSize = e.Graphics.MeasureString(text, font);

            int textPadding = 10;
            int textWidth = (int)textSize.Width + textPadding * 2;

            Rectangle borderRect = new Rectangle(
                0,
                (int)(textSize.Height / 2),
                box.Width - 1,
                box.Height - (int)(textSize.Height / 2) - 1
            );

            e.Graphics.DrawRectangle(thickPen, borderRect);

            e.Graphics.FillRectangle(
                new SolidBrush(nurseBackground),
                new Rectangle(textPadding, 0, textWidth, (int)textSize.Height)
            );

            e.Graphics.DrawString(text, font, textBrush, textPadding, 0);

            // Chỉ đổi màu chữ cho các control không phải TextBox
            foreach (Control ctrl in box.Controls)
            {
                if (!(ctrl is TextBox))
                {
                    ctrl.ForeColor = Color.RoyalBlue;
                }
            }
        }
        private void StyleDataGridView(DataGridView dgv)
        {
            // Nền tổng thể (hơi xám xanh, khác biệt với form xanh nhạt)
            dgv.BackgroundColor = Color.FromArgb(245, 248, 250); // Nhạt nhưng hơi xám -> tạo tách biệt

            // Viền & ô
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // 👉 Đổi màu đường phân cách giữa các ô (hàng dữ liệu)
            dgv.GridColor = Color.MediumSeaGreen; // Xanh lá dễ nhìn

            // Header
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;  // đậm hơn RoyalBlue
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Dữ liệu
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 60, 90); // Xanh navy nhẹ
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255); // xanh pastel khi chọn
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Hàng xen kẽ
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 253, 255); // Trắng-xanh nhạt sát trắng

            // Căn lề
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Kích thước dòng + kiểu fill
            dgv.RowTemplate.Height = 28;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void LoadPatients()
        {
            var patients = bll.GetAllPatients(doctorId);

            cboPatient.DataSource = patients;
            cboPatient.DisplayMember = "FullName"; // ✅
            cboPatient.ValueMember = "Id";         // ✅ đúng với DTO.Id

            cboPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPatient.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var auto = new AutoCompleteStringCollection();
            auto.AddRange(patients.Select(p => p.FullName).ToArray());
            cboPatient.AutoCompleteCustomSource = auto;

            cboPatient.SelectedIndex = -1;
            cboPatient.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboPatient.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string patientId = cboPatient.SelectedValue.ToString();
            DateTime today = DateTime.Today;
            // ✅ Kiểm tra trùng
            if (bll.IsDoctorPatientExists(doctorId, patientId, today))
            {
                MessageBox.Show("Bệnh nhân này đã được phân công cho bác sĩ trong ngày hôm nay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dto = new DoctorPatientDTO
            {
                DoctorID = doctorId,
                PatientID = cboPatient.SelectedValue.ToString(),
                Role = txtRole.Text.Trim(),
                Note = txtNote.Text.Trim(),
                // StartDate và EndDate xử lý trong DAL
            };

            bll.AddDoctorPatient(dto);
            ClearFIle();

            dgvDoctorPatint.DataSource = bll.GetPatientsByDoctor(doctorId);
            MessageBox.Show("Thêm phân công thành công!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDoctorPatint.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần cập nhật!", "Thông báo");
                return;
            }

            var selected = dgvDoctorPatint.CurrentRow.DataBoundItem as DoctorPatientDTO;

            if (selected == null)
                return;

            // Không cho thay đổi bệnh nhân
            if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString().Trim() != selected.PatientID.Trim())
            {
                MessageBox.Show("Không được thay đổi bệnh nhân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (selected != null)
            {
                DateTime today = DateTime.Today;
                DateTime startDate = selected.StartDate.Date; // Ngày bắt đầu từ dữ liệu gốc
                DateTime endDate = dtpEndDate.Value.Date;      // Ngày kết thúc người dùng nhập

                if (endDate < today || endDate < startDate)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày hôm nay và ngày bắt đầu khám!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var dto = new DoctorPatientDTO
            {
                DoctorID = selected.DoctorID,
                PatientID = selected.PatientID,
                StartDate = selected.StartDate,
                EndDate = dtpEndDate.Value,
                Role = txtRole.Text.Trim(),
                Note = txtNote.Text.Trim()
            };

            bll.UpdateDoctorPatient(dto);
            ClearFIle();

            dgvDoctorPatint.DataSource = bll.GetPatientsByDoctor(doctorId);
            MessageBox.Show("Cập nhật thành công!");
        }

        private void dgvDoctorPatint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selected = dgvDoctorPatint.Rows[e.RowIndex].DataBoundItem as DoctorPatientDTO;
                if (selected != null)
                {
                    // Gán thông tin bệnh nhân vào ComboBox nhưng KHÔNG thay đổi ID
                    cboPatient.SelectedValue = selected.PatientID;

                    // Nếu không hiển thị đúng, fallback bằng tên
                    if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != selected.PatientID)
                    {
                        cboPatient.Text = selected.PatientName;
                    }

                    // Role có thể null
                    txtRole.Text = selected.Role ?? "";

                    // Note có thể null
                    txtNote.Text = selected.Note ?? "";

                    // EndDate có thể null
                    if (selected.EndDate.HasValue)
                    {
                        dtpEndDate.Value = selected.EndDate.Value;
                    }
                    else
                    {
                        dtpEndDate.Value = DateTime.Today; // hoặc để trống tuỳ yêu cầu
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFIle();
            LoadData();
        }
        public void ClearFIle()
        {
            cboPatient.SelectedIndex = -1;
            txtNote.Clear();
            txtRole.Clear();
        }
        public void LoadData()
        {
            dgvDoctorPatint.DataSource = bll.GetPatientsByDoctor(doctorId);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedPatientId = cboPatient.SelectedValue?.ToString();

            if (!string.IsNullOrWhiteSpace(selectedPatientId))
            {
                var result = bll.SearchByPatientId(doctorId, selectedPatientId);

                if (result == null || result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDoctorPatint.DataSource = null;
                }
                else
                {
                    dgvDoctorPatint.DataSource = result;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần tìm trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
