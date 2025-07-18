using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDoctorInfo_Doctor : Form
    {
        private string doctorId;
        private StaffDoctorBLL bll = new StaffDoctorBLL();

        private Label lblName, lblGender, lblDob, lblPhone, lblAddress, lblEmail;
        private Label lblPosition, lblQualification, lblDegree, lblStatus, lblStartDate, lblNotes;

        public frmDoctorInfo_Doctor(string id)
        {
            doctorId = id;
            this.Text = "Thông tin bác sĩ";
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            BuildUI();
            LoadDoctorInfo();
        }

        private void BuildUI()
        {
            var mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(40),
                ColumnCount = 2,
                RowCount = 7,
                BackColor = Color.White,
                AutoSize = true,
                AutoScroll = true
            };

            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // Tạo Panel bọc tiêu đề để căn chỉnh thủ công
            var titlePanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                Padding = new Padding(100, 10, 0, 10), // Kéo trái bằng Padding.Left
                BackColor = Color.White
            };
            var lblTitle = new Label
            {
                Text = "THÔNG TIN CÁ NHÂN",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.SteelBlue,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Margin = new Padding(300, 10, 0, 30) // Cách trái 80px, giữ đỉnh và đáy như cũ
            };
            titlePanel.Controls.Add(lblTitle);
            mainLayout.SetColumnSpan(lblTitle, 2);
            mainLayout.Controls.Add(lblTitle, 0, 0);

            Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font valueFont = new Font("Segoe UI", 12);

            int rowIndex = 1;

            // Cột trái
            AddLabelPair(mainLayout, "Họ tên:", out lblName, titleFont, valueFont, rowIndex++, 0);
            AddLabelPair(mainLayout, "Giới tính:", out lblGender, titleFont, valueFont, rowIndex++, 0);
            AddLabelPair(mainLayout, "Ngày sinh:", out lblDob, titleFont, valueFont, rowIndex++, 0);
            AddLabelPair(mainLayout, "SĐT:", out lblPhone, titleFont, valueFont, rowIndex++, 0);
            AddLabelPair(mainLayout, "Địa chỉ:", out lblAddress, titleFont, valueFont, rowIndex++, 0);
            AddLabelPair(mainLayout, "Email:", out lblEmail, titleFont, valueFont, rowIndex++, 0);

            // Cột phải
            rowIndex = 1;
            AddLabelPair(mainLayout, "Chức vụ:", out lblPosition, titleFont, valueFont, rowIndex++, 1);
            AddLabelPair(mainLayout, "Trình độ:", out lblQualification, titleFont, valueFont, rowIndex++, 1);
            AddLabelPair(mainLayout, "Học vị:", out lblDegree, titleFont, valueFont, rowIndex++, 1);
            AddLabelPair(mainLayout, "Trạng thái:", out lblStatus, titleFont, valueFont, rowIndex++, 1);
            AddLabelPair(mainLayout, "Ngày bắt đầu:", out lblStartDate, titleFont, valueFont, rowIndex++, 1);
            AddLabelPair(mainLayout, "Ghi chú:", out lblNotes, titleFont, valueFont, rowIndex++, 1);

            this.Controls.Add(mainLayout);
        }

        private void AddLabelPair(TableLayoutPanel panel, string labelText, out Label valueLabel, Font titleFont, Font valueFont, int row, int col)
        {
            var container = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                Padding = new Padding(10, 10, 10, 10),
                Margin = new Padding(5)
            };

            var lblTitle = new Label
            {
                Text = labelText,
                Font = titleFont,
                ForeColor = Color.Black,
                AutoSize = true,
                Padding = new Padding(0, 5, 10, 0)
            };

            valueLabel = new Label
            {
                Text = "(...)",
                Font = valueFont,
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                Padding = new Padding(0, 5, 0, 0)
            };

            container.Controls.Add(lblTitle);
            container.Controls.Add(valueLabel);
            panel.Controls.Add(container, col, row);
        }

        private void LoadDoctorInfo()
        {
            var doctor = bll.GetDoctorInfo(doctorId);
            if (doctor != null)
            {
                lblName.Text = doctor.Name;
                lblGender.Text = doctor.Gender;
                lblDob.Text = doctor.Dob?.ToString("dd/MM/yyyy");
                lblPhone.Text = doctor.PhoneNumber;
                lblAddress.Text = doctor.HomeAddress;
                lblEmail.Text = doctor.Email;
                lblPosition.Text = doctor.Position;
                lblQualification.Text = doctor.Qualification;
                lblDegree.Text = doctor.Degree;
                lblStatus.Text = doctor.Status;
                lblStartDate.Text = doctor.StartDate?.ToString("dd/MM/yyyy");
                lblNotes.Text = doctor.Notes;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin bác sĩ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
