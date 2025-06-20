using System;
using System.Drawing;
using System.Windows.Forms;

public class frmPatientInfo_Doctor : Form
{
    public frmPatientInfo_Doctor()
    {
        // Cài đặt form
        this.Text = "Thông Tin Bệnh Nhân";
        this.Size = new Size(900, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Font = new Font("Segoe UI", 11);

        // Tiêu đề
        Label lblTitle = new Label()
        {
            Text = "Thông Tin Bệnh Nhân",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 50
        };
        this.Controls.Add(lblTitle);

        // GroupBox thông tin chi tiết bệnh nhân
        GroupBox gbDetail = new GroupBox()
        {
            Text = "Thông tin chi tiết 1 bệnh nhân",
            Font = new Font("Segoe UI", 12, FontStyle.Regular),
            Location = new Point((this.ClientSize.Width - Width) / 2, 60),
            Anchor = AnchorStyles.Top,
            Size = new Size(820, 180)
        };
        this.Controls.Add(gbDetail);

        // Các label và textbox
        string[] labels = { "Mã Bệnh Nhân:", "Họ và Tên:", "Ngày Sinh:", "Giới Tính:", "Địa Chỉ:", "SDT:", "Mã Bác Sĩ:", "Mã Khoa:" };
        int[] xLabel = { 30, 30, 30, 30, 420, 420, 420, 420 };
        int[] yLabel = { 40, 75, 110, 145, 40, 75, 110, 145 };
        int[] xTextbox = { 160, 160, 160, 160, 540, 540, 540, 540 };
        int[] yTextbox = { 37, 72, 107, 142, 37, 72, 107, 142 };

        for (int i = 0; i < labels.Length; i++)
        {
            Label lbl = new Label()
            {
                Text = labels[i],
                Location = new Point(xLabel[i], yLabel[i]),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            gbDetail.Controls.Add(lbl);

            TextBox txt = new TextBox()
            {
                Location = new Point(xTextbox[i], yTextbox[i]),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11),
                ReadOnly = true, // Không cho nhập
                BackColor = SystemColors.Control // Giống màu label
            };
            gbDetail.Controls.Add(txt);
        }

        // Label danh sách bệnh nhân
        Label lblList = new Label()
        {
            Text = "Danh sách các bệnh nhân thuộc bác sĩ phụ trách",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.Teal,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point((this.ClientSize.Width - 900) / 2, 300),
            Size = new Size(900, 30)
        };
        this.Controls.Add(lblList);
        // Tự canh giữa khi form resize
        this.Resize += (s, e) =>
        {
            lblList.Left = (this.ClientSize.Width - lblList.Width) / 2;
        };
        // DataGridView danh sách bệnh nhân
        DataGridView dgv = new DataGridView()
        {
            Dock = DockStyle.Bottom,
            Height = 230, // Chiều cao cố định
            Font = new Font("Segoe UI", 11),
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.LightCyan,
                ForeColor = Color.Black,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            },
            EnableHeadersVisualStyles = false,
            AllowUserToAddRows = false,
            ReadOnly = true,
            RowTemplate = { Height = 30 },
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            BackgroundColor = Color.White,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };

        dgv.Columns.Add("MaBN", "Mã BN");
        dgv.Columns.Add("HoTenBN", "Họ Tên BN");
        dgv.Columns.Add("NgaySinh", "Ngày Sinh");
        dgv.Columns.Add("GT", "GT");
        dgv.Columns.Add("DiaChi", "Địa Chỉ");
        dgv.Columns.Add("SDT", "SDT");
        dgv.Columns.Add("BacSi", "Bác sĩ phụ trách");
        dgv.Columns.Add("Khoa", "Khoa");

        this.Controls.Add(dgv);
    }

    private void frmPatientInfo_Doctor_Load(object sender, EventArgs e)
    {

    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // frmPatientInfo_Doctor
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmPatientInfo_Doctor";
            this.Load += new System.EventHandler(this.frmPatientInfo_Doctor_Load_1);
            this.ResumeLayout(false);

    }

    private void frmPatientInfo_Doctor_Load_1(object sender, EventArgs e)
    {

    }
}
