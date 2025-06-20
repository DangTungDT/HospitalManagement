using System;
using System.Drawing;
using System.Windows.Forms;

public class frmDepartmentInfo_Doctor : Form
{
    public frmDepartmentInfo_Doctor()
    {
        // Cài đặt form
        this.Text = "Thông Tin Khoa";
        this.Size = new Size(800, 550);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Font = new Font("Segoe UI", 11);

        // Tiêu đề
        Label lblTitle = new Label()
        {
            Text = "Thông Tin Khoa Công Tác",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 50
        };
        this.Controls.Add(lblTitle);

        // GroupBox thông tin khoa
        GroupBox gbDetail = new GroupBox()
        {
            Text = "Thông tin khoa",
            Font = new Font("Segoe UI", 12, FontStyle.Regular),
            Location = new Point((this.ClientSize.Width - Width) / 2, 60),
            Anchor = AnchorStyles.Top,
            Size = new Size(720, 180)
        };
        this.Controls.Add(gbDetail);

        // Các label và textbox
        string[] labels = { "Mã khoa:", "Tên khoa:", "Trưởng khoa:", "Số lượng bác sĩ:", "SĐT liên hệ:", "Ghi chú:" };
        int[] yLabel = { 35, 70, 105, 35, 70, 105 };
        int[] xLabel = { 30, 30, 30, 380, 380, 380 };
        int[] xTextbox = { 150, 150, 150, 500, 500, 500 };
        int[] yTextbox = { 32, 67, 102, 32, 67, 102 };

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

            Control txt;
            if (labels[i] == "Ghi chú:")
            {
                txt = new RichTextBox()
                {
                    Location = new Point(xTextbox[i], yTextbox[i]),
                    Size = new Size(180, 50),
                    Font = new Font("Segoe UI", 11),
                    BackColor = Color.Gainsboro,
                    BorderStyle = BorderStyle.FixedSingle,
                    ReadOnly = true
                };
            }
            else
            {
                txt = new TextBox()
                {
                    Location = new Point(xTextbox[i], yTextbox[i]),
                    Size = new Size(180, 25),
                    Font = new Font("Segoe UI", 11),
                    BackColor = Color.Gainsboro,
                    BorderStyle = BorderStyle.FixedSingle,
                    ReadOnly = true
                };
            }
            gbDetail.Controls.Add(txt);
        }

        // Label danh sách bác sĩ thuộc khoa
        Label lblList = new Label()
        {
            Text = "Danh sách bác sĩ thuộc khoa",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.Teal,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point((this.ClientSize.Width - 800) / 2, 320),
            Size = new Size(800, 30)
        };
        this.Controls.Add(lblList);
        // Tự canh giữa khi form resize
        this.Resize += (s, e) =>
        {
            lblList.Left = (this.ClientSize.Width - lblList.Width) / 2;
        };
        // DataGridView danh sách bác sĩ
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

        dgv.Columns.Add("MaBS", "Mã Bác Sĩ");
        dgv.Columns.Add("TenBS", "Họ Tên Bác Sĩ");
        dgv.Columns.Add("ChuyenMon", "Chuyên Môn");
        dgv.Columns.Add("SDT", "SĐT");

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
            // frmDepartmentInfo_Doctor
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmDepartmentInfo_Doctor";
            this.Load += new System.EventHandler(this.frmDepartmentInfo_Doctor_Load);
            this.ResumeLayout(false);

    }

    private void frmDepartmentInfo_Doctor_Load(object sender, EventArgs e)
    {

    }
}
