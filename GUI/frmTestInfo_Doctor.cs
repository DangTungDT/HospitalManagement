using System;
using System.Drawing;
using System.Windows.Forms;

public class frmTestInfo_Doctor : Form
{
    public frmTestInfo_Doctor()
    {
        // Cài đặt form
        this.Text = "Thông Tin Xét Nghiệm";
        this.Size = new Size(950, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Font = new Font("Segoe UI", 11);

        // Tiêu đề
        Label lblTitle = new Label()
        {
            Text = "Thông Tin Xét Nghiệm",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 50
        };
        this.Controls.Add(lblTitle);

        // GroupBox thông tin chi tiết xét nghiệm
        GroupBox gbDetail = new GroupBox()
        {
            Text = "Thông tin chi tiết phiếu xét nghiệm",
            Font = new Font("Segoe UI", 12, FontStyle.Regular),
            Location = new Point((this.ClientSize.Width - Width) / 2, 60),
            Anchor = AnchorStyles.Top,
            Size = new Size(870, 220)
        };
        this.Controls.Add(gbDetail);

        // Các label và textbox (chia đều 2 bên, mỗi bên 5 trường)
        string[] leftLabels = { "Mã xét nghiệm:", "Mã bệnh nhân:", "Tên bệnh nhân:", "Ngày yêu cầu:", "Trạng thái:" };
        int[] yLeft = { 35, 70, 105, 140, 175 };
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
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true
            };
            gbDetail.Controls.Add(txt);
        }

        string[] rightLabels = { "Loại xét nghiệm:", "Kết quả:", "Chỉ số bình thường:", "Bác sĩ chỉ định:", "Ghi chú:" };
        int[] yRight = { 35, 70, 105, 140, 175 };
        for (int i = 0; i < rightLabels.Length; i++)
        {
            Label lbl = new Label()
            {
                Text = rightLabels[i],
                Location = new Point(420, yRight[i]),
                Size = new Size(140, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            gbDetail.Controls.Add(lbl);

            Control txt;
            if (rightLabels[i] == "Ghi chú:")
            {
                txt = new RichTextBox()
                {
                    Location = new Point(570, yRight[i]),
                    Size = new Size(220, 35),
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
                    Location = new Point(570, yRight[i]),
                    Size = new Size(220, 25),
                    Font = new Font("Segoe UI", 11),
                    BackColor = Color.Gainsboro,
                    BorderStyle = BorderStyle.FixedSingle,
                    ReadOnly = true
                };
            }
            gbDetail.Controls.Add(txt);
        }

        // Label danh sách phiếu xét nghiệm
        Label lblList = new Label()
        {
            Text = "Danh sách các phiếu xét nghiệm",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.Teal,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(950, 30),
            Location = new Point((this.ClientSize.Width - 950) / 2, 320), 
        };
        this.Controls.Add(lblList);
        // Tự canh giữa khi form resize
        this.Resize += (s, e) =>
        {
            lblList.Left = (this.ClientSize.Width - lblList.Width) / 2;
        };
        // DataGridView danh sách phiếu xét nghiệm
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

        dgv.Columns.Add("MaXN", "Mã Xét Nghiệm");
        dgv.Columns.Add("MaBN", "Mã BN");
        dgv.Columns.Add("TenBN", "Tên BN");
        dgv.Columns.Add("NgayYeuCau", "Ngày Yêu Cầu");
        dgv.Columns.Add("LoaiXN", "Loại Xét Nghiệm");
        dgv.Columns.Add("KetQua", "Kết Quả");
        dgv.Columns.Add("ChiSoBinhThuong", "Chỉ Số Bình Thường");
        dgv.Columns.Add("BacSiChiDinh", "Bác Sĩ Chỉ Định");
        dgv.Columns.Add("TrangThai", "Trạng Thái");
        dgv.Columns.Add("GhiChu", "Ghi Chú");

        this.Controls.Add(dgv);
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // frmTestInfo_Doctor
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmTestInfo_Doctor";
            this.Load += new System.EventHandler(this.frmTestInfo_Doctor_Load);
            this.ResumeLayout(false);

    }

    private void frmTestInfo_Doctor_Load(object sender, EventArgs e)
    {

    }
}
