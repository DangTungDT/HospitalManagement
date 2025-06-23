using System;
using System.Drawing;
using System.Windows.Forms;

public class frmDoctorInfo_Doctor : Form
{
    public frmDoctorInfo_Doctor()
    {
        // Cài đặt form
        this.Text = "Thông Tin Bác Sĩ";
        this.Size = new Size(600, 400);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Font = new Font("Segoe UI", 11);

        // Tiêu đề
        Label lblTitle = new Label()
        {
            Text = "Thông Tin Bác Sĩ",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 50
        };
        this.Controls.Add(lblTitle);

        // Panel chứa thông tin
        Panel infoPanel = new Panel()
        {
            BorderStyle = BorderStyle.FixedSingle,
            Location = new Point((this.ClientSize.Width - 540) / 2, 70),
            Size = new Size(540, 260),
            BackColor = Color.WhiteSmoke
        };
        this.Controls.Add(infoPanel);
        this.Resize += (s, e) =>
        {
            infoPanel.Left = (this.ClientSize.Width - infoPanel.Width) / 2;
        };

        // Các label thuộc tính
        string[] labels = {
            "Mã bác sĩ:", "Họ và tên:", "Ngày sinh:", "Giới tính:", "SDT:",
            "Email:", "Mã khoa:", "Chuyên môn:", "Account:"
        };
        string[] values = {
            "BS001", "Nguyễn Văn A", "01/01/2005", "Nam", "03775363745",
            "23211ttt4040@mai.vn", "KH001", "Ngoại khoa", "AC001"
        };

        // Hiển thị thông tin dạng lưới 2 cột
        for (int i = 0; i < labels.Length; i++)
        {
            int row = i % 5;
            int col = i / 5;

            Label lbl = new Label()
            {
                Text = labels[i],
                Location = new Point(20 + col * 260, 20 + row * 40),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            infoPanel.Controls.Add(lbl);

            Label val = new Label()
            {
                Text = values[i],
                Location = new Point(120 + col * 260, 20 + row * 40),
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 11)
            };
            infoPanel.Controls.Add(val);
        }
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // DoctorInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(528, 276);
            this.Name = "DoctorInfoForm";
            this.Load += new System.EventHandler(this.DoctorInfoForm_Load);
            this.ResumeLayout(false);

    }

    private void DoctorInfoForm_Load(object sender, EventArgs e)
    {

    }
}
