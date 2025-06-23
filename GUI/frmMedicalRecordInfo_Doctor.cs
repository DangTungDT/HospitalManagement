using System;
using System.Drawing;
using System.Windows.Forms;

public class frmMedicalRecordInfo : Form
{
    public frmMedicalRecordInfo()
    {
        // Cài đặt form
        this.Text = "Thông Tin Bệnh Án";
        this.Size = new Size(900, 650);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Font = new Font("Segoe UI", 11);

        // Tiêu đề
        Label lblTitle = new Label()
        {
            Text = "Thông Tin Bệnh Án",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 50
        };
        this.Controls.Add(lblTitle);

        // GroupBox thông tin bệnh án
        GroupBox gbDetail = new GroupBox()
        {
            Text = "Thông tin bệnh án",
            Font = new Font("Segoe UI", 12, FontStyle.Regular),
            Location = new Point((this.ClientSize.Width - Width) / 2, 60),
            Anchor = AnchorStyles.Top,
            Size = new Size(820, 180)
        };
        this.Controls.Add(gbDetail);

        // Label và textbox bên trái
        string[] leftLabels = { "Mã Bệnh Án:", "Mã Bệnh Nhân:", "Mã Bác Sĩ:" };
        int[] yLeft = { 35, 75, 115 };
        for (int i = 0; i < leftLabels.Length; i++)
        {
            Label lbl = new Label()
            {
                Text = leftLabels[i],
                Location = new Point(30, yLeft[i]),
                Size = new Size(130, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            gbDetail.Controls.Add(lbl);

            TextBox txt = new TextBox()
            {
                Location = new Point(160, yLeft[i]),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11),
                BackColor = Color.Gainsboro,
                BorderStyle = BorderStyle.FixedSingle
            };
            gbDetail.Controls.Add(txt);
        }

        // Label và textbox bên phải
        string[] rightLabels = { "Ngày Lập:", "Chuẩn Đoán:", "Ghi Chú:" };
        int[] yRight = { 35, 75, 115 };
        for (int i = 0; i < rightLabels.Length; i++)
        {
            Label lbl = new Label()
            {
                Text = rightLabels[i],
                Location = new Point(420, yRight[i]),
                Size = new Size(110, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            gbDetail.Controls.Add(lbl);

            Control txt;
            if (rightLabels[i] == "Ghi Chú:")
            {
                txt = new RichTextBox()
                {
                    Location = new Point(540, yRight[i]),
                    Size = new Size(200, 50),
                    Font = new Font("Segoe UI", 11),
                    BackColor = Color.Gainsboro,
                    BorderStyle = BorderStyle.FixedSingle
                };
            }
            else
            {
                txt = new TextBox()
                {
                    Location = new Point(540, yRight[i]),
                    Size = new Size(200, 25),
                    Font = new Font("Segoe UI", 11),
                    BackColor = Color.Gainsboro,
                    BorderStyle = BorderStyle.FixedSingle
                };
            }
            gbDetail.Controls.Add(txt);
        }

        // Nút chức năng
        Button btnCreate = new Button()
        {
            Text = "Tạo Bệnh Án",
            Location = new Point(250, 250),
            Size = new Size(140, 40),
            BackColor = Color.LightSkyBlue,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.Black
        };
        btnCreate.FlatAppearance.BorderSize = 0;
        btnCreate.Region = System.Drawing.Region.FromHrgn(
            NativeMethods.CreateRoundRectRgn(0, 0, btnCreate.Width, btnCreate.Height, 10, 10));
        this.Controls.Add(btnCreate);

        Button btnUpdate = new Button()
        {
            Text = "Cập Nhật Bệnh Án",
            Location = new Point(430, 250),
            Size = new Size(170, 40),
            BackColor = Color.LightSkyBlue,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.Black
        };
        btnUpdate.FlatAppearance.BorderSize = 0;
        btnUpdate.Region = System.Drawing.Region.FromHrgn(
            NativeMethods.CreateRoundRectRgn(0, 0, btnUpdate.Width, btnUpdate.Height, 10, 10));
        this.Controls.Add(btnUpdate);

        // Label danh sách bệnh án
        Label lblList = new Label()
        {
            Text = "Danh sách các bệnh án",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.Teal,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point((this.ClientSize.Width - 900) / 2, 320),
            Size = new Size(900, 30)
        };
        this.Controls.Add(lblList);
        // Tự canh giữa khi form resize
        this.Resize += (s, e) =>
        {
            lblList.Left = (this.ClientSize.Width - lblList.Width) / 2;
        };
        // DataGridView danh sách bệnh án
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

        dgv.Columns.Add("MaBA", "Mã Bệnh Án");
        dgv.Columns.Add("MaBN", "Mã Bệnh Nhân");
        dgv.Columns.Add("MaBS", "Mã Bác Sĩ");
        dgv.Columns.Add("NgayLap", "Ngày Lập");
        dgv.Columns.Add("ChuanDoan", "Chuẩn Đoán");
        dgv.Columns.Add("GhiChu", "Ghi Chú");

        this.Controls.Add(dgv);
    }

    // Để bo góc nút
    private static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // frmMedicalRecordInfo
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmMedicalRecordInfo";
            this.Load += new System.EventHandler(this.frmMedicalRecordInfo_Load);
            this.ResumeLayout(false);

    }

    private void frmMedicalRecordInfo_Load(object sender, EventArgs e)
    {

    }
}
