using System;
using System.Drawing;
using System.Windows.Forms;

public class frmTestTypeInfo_Doctor : Form
{
    public frmTestTypeInfo_Doctor()
    {
        // Cài đặt form
        this.Text = "Thông Tin Loại Xét Nghiệm";
        this.Size = new Size(800, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Font = new Font("Segoe UI", 11);

        // Tiêu đề
        Label lblTitle = new Label()
        {
            Text = "Thông Tin Loại Xét Nghiệm",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 50
        };
        this.Controls.Add(lblTitle);

        // GroupBox thông tin loại xét nghiệm
        GroupBox gbDetail = new GroupBox()
        {
            Text = "Thông tin chi tiết loại xét nghiệm",
            Font = new Font("Segoe UI", 12, FontStyle.Regular),
            Location = new Point((this.ClientSize.Width - Width) / 2, 60),
            Anchor = AnchorStyles.Top,
            Size = new Size(720, 120)
        };
        this.Controls.Add(gbDetail);

        // Các label và textbox
        string[] labels = { "Mã loại xét nghiệm:", "Tên loại xét nghiệm:", "Mô tả:", "Ghi chú:" };
        int[] yLabel = { 30, 65, 30, 65 };
        int[] xLabel = { 30, 30, 380, 380 };
        int[] xTextbox = { 180, 180, 500, 500 };
        int[] yTextbox = { 27, 62, 27, 62 };

        for (int i = 0; i < labels.Length; i++)
        {
            Label lbl = new Label()
            {
                Text = labels[i],
                Location = new Point(xLabel[i], yLabel[i]),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            gbDetail.Controls.Add(lbl);

            Control txt;
            if (labels[i] == "Mô tả:" || labels[i] == "Ghi chú:")
            {
                txt = new RichTextBox()
                {
                    Location = new Point(xTextbox[i], yTextbox[i]),
                    Size = new Size(180, 25),
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

        // Label danh sách loại xét nghiệm
        Label lblList = new Label()
        {
            Text = "Danh sách các loại xét nghiệm",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.Teal,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point((this.ClientSize.Width - 800) / 2, 200),
            Size = new Size(800, 30)
        };
        this.Controls.Add(lblList);

        // Tự canh giữa khi form resize
        this.Resize += (s, e) =>
        {
            lblList.Left = (this.ClientSize.Width - lblList.Width) / 2;
        };

        // DataGridView danh sách loại xét nghiệm
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

        dgv.Columns.Add("MaLoaiXN", "Mã Loại Xét Nghiệm");
        dgv.Columns.Add("TenLoaiXN", "Tên Loại Xét Nghiệm");
        dgv.Columns.Add("MoTa", "Mô Tả");
        dgv.Columns.Add("GhiChu", "Ghi Chú");

        this.Controls.Add(dgv);
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // frmTestTypeInfo_Doctor
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmTestTypeInfo_Doctor";
            this.Load += new System.EventHandler(this.frmTestTypeInfo_Doctor_Load);
            this.ResumeLayout(false);

    }

    private void frmTestTypeInfo_Doctor_Load(object sender, EventArgs e)
    {

    }
}
