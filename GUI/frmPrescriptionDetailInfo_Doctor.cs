using System;
using System.Drawing;
using System.Windows.Forms;

public class frmPrescriptionDetailInfo_Doctor : Form
{
    public frmPrescriptionDetailInfo_Doctor()
    {
        // Cài đặt form
        this.Text = "Thông Tin Chi Tiết Đơn Thuốc";
        this.Size = new Size(900, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Font = new Font("Segoe UI", 11);

        // Tiêu đề
        Label lblTitle = new Label()
        {
            Text = "Thông Tin Chi Tiết Đơn Thuốc",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 50
        };
        this.Controls.Add(lblTitle);

        // GroupBox thông tin chi tiết đơn thuốc
        GroupBox gbDetail = new GroupBox()
        {
            Text = "Thông tin chi tiết đơn thuốc",
            Font = new Font("Segoe UI", 12, FontStyle.Regular),
            Location = new Point((this.ClientSize.Width - Width) / 2, 60),
            Anchor = AnchorStyles.Top,
            Size = new Size(820, 160)
        };
        this.Controls.Add(gbDetail);

        // Label và textbox bên trái
        string[] leftLabels = { "Mã Đơn Thuốc:", "Mã Thuốc:" };
        int[] yLeft = { 35, 70 };
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
        string[] rightLabels = { "Số Lượng:", "Cách Dùng:" };
        int[] yRight = { 35, 70 };
        for (int i = 0; i < rightLabels.Length; i++)
        {
            Label lbl = new Label()
            {
                Text = rightLabels[i],
                Location = new Point(420, yRight[i]),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            gbDetail.Controls.Add(lbl);

            Control txt;
            if (rightLabels[i] == "Cách Dùng:")
            {
                txt = new RichTextBox()
                {
                    Location = new Point(530, yRight[i]),
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
                    Location = new Point(530, yRight[i]),
                    Size = new Size(200, 25),
                    Font = new Font("Segoe UI", 11),
                    BackColor = Color.Gainsboro,
                    BorderStyle = BorderStyle.FixedSingle
                };
            }
            gbDetail.Controls.Add(txt);
        }

        // Các nút chức năng
        Button btnCreate = new Button()
        {
            Text = "Tạo chi tiết đơn thuốc",
            Location = new Point(180, 240),
            Size = new Size(160, 40),
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
            Text = "Cập nhật chi tiết đơn thuốc",
            Location = new Point(370, 240),
            Size = new Size(200, 40),
            BackColor = Color.LightSkyBlue,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.Black
        };
        btnUpdate.FlatAppearance.BorderSize = 0;
        btnUpdate.Region = System.Drawing.Region.FromHrgn(
            NativeMethods.CreateRoundRectRgn(0, 0, btnUpdate.Width, btnUpdate.Height, 10, 10));
        this.Controls.Add(btnUpdate);

        Button btnDelete = new Button()
        {
            Text = "Xóa chi tiết đơn thuốc",
            Location = new Point(600, 240),
            Size = new Size(160, 40),
            BackColor = Color.LightSkyBlue,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.Black
        };
        btnDelete.FlatAppearance.BorderSize = 0;
        btnDelete.Region = System.Drawing.Region.FromHrgn(
            NativeMethods.CreateRoundRectRgn(0, 0, btnDelete.Width, btnDelete.Height, 10, 10));
        this.Controls.Add(btnDelete);

        // Label danh sách chi tiết đơn thuốc
        Label lblList = new Label()
        {
            Text = "Danh sách chi tiết các đơn thuốc",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.Teal,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point((this.ClientSize.Width - 950) / 2, 330),
            Size = new Size(900, 30)
        };
        this.Controls.Add(lblList);
        // Tự canh giữa khi form resize
        this.Resize += (s, e) =>
        {
            lblList.Left = (this.ClientSize.Width - lblList.Width) / 2;
        };

        // DataGridView danh sách chi tiết đơn thuốc
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

        dgv.Columns.Add("MaDonThuoc", "Mã Đơn Thuốc");
        dgv.Columns.Add("MaThuoc", "Mã Thuốc");
        dgv.Columns.Add("SoLuong", "Số Lượng");
        dgv.Columns.Add("CachDung", "Cách Dùng");

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
            // frmPrescriptionDetailInfo
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmPrescriptionDetailInfo";
            this.Load += new System.EventHandler(this.frmPrescriptionDetailInfo_Load);
            this.ResumeLayout(false);

    }

    private void frmPrescriptionDetailInfo_Load(object sender, EventArgs e)
    {

    }
}
