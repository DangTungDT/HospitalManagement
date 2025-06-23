using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMedicineInfo_Doctor : Form
    {
        public frmMedicineInfo_Doctor()
        {
            // Cài đặt form
            this.Text = "Thông tin Thuốc";
            this.Size = new Size(850, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 11);

            // Tiêu đề
            Label lblTitle = new Label()
            {
                Text = "Thông tin Thuốc",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50
            };
            this.Controls.Add(lblTitle);

            // GroupBox thông tin chi tiết thuốc
            GroupBox gbDetail = new GroupBox()
            {
                Text = "Thông tin chi tiết 1 loại thuốc",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Location = new Point((this.ClientSize.Width - Width) / 2, 60),
                Anchor = AnchorStyles.Top,
                Size = new Size(800, 160)
            };
            this.Controls.Add(gbDetail);

            // Label và textbox bên trái
            string[] leftLabels = { "Mã Thuốc:", "Tên Thuốc:", "Đơn Vị:" };
            int[] yLeft = { 35, 70, 105 };
            for (int i = 0; i < leftLabels.Length; i++)
            {
                Label lbl = new Label()
                {
                    Text = leftLabels[i],
                    Location = new Point(30, yLeft[i]),
                    Size = new Size(110, 25),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold)
                };
                gbDetail.Controls.Add(lbl);

                TextBox txt = new TextBox()
                {
                    Location = new Point(140, yLeft[i]),
                    Size = new Size(200, 25),
                    Font = new Font("Segoe UI", 11),
                    BackColor = Color.Gainsboro,
                    BorderStyle = BorderStyle.FixedSingle,
                    ReadOnly = true
                };
                gbDetail.Controls.Add(txt);
            }

            // Label và textbox bên phải
            string[] rightLabels = { "Hàm Lượng:", "Ghi Chú:" };
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
                if (rightLabels[i] == "Ghi Chú:")
                {
                    txt = new RichTextBox()
                    {
                        Location = new Point(530, yRight[i]),
                        Size = new Size(200, 50),
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
                        Location = new Point(530, yRight[i]),
                        Size = new Size(200, 25),
                        Font = new Font("Segoe UI", 11),
                        BackColor = Color.Gainsboro,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                }
                gbDetail.Controls.Add(txt);
            }

            // Label danh sách thuốc
            Label lblList = new Label()
            {
                Text = "Danh sách Thuốc",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.Teal,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((this.ClientSize.Width - 850) / 2, 320),
                Size = new Size(850, 30)
            };
            this.Controls.Add(lblList);
            // Tự canh giữa khi form resize
            this.Resize += (s, e) =>
            {
                lblList.Left = (this.ClientSize.Width - lblList.Width) / 2;
            };
            // DataGridView danh sách thuốc
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

            dgv.Columns.Add("MaThuoc", "Mã Thuốc");
            dgv.Columns.Add("TenThuoc", "Tên Thuốc");
            dgv.Columns.Add("DonVi", "Đơn Vị");
            dgv.Columns.Add("HamLuong", "Hàm Lượng");
            dgv.Columns.Add("GhiChu", "Ghi Chú");

            this.Controls.Add(dgv);
        }

        private void frmMedicineInfo_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmMedicineInfo_Doctor
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmMedicineInfo_Doctor";
            this.Load += new System.EventHandler(this.frmMedicineInfo_Doctor_Load);
            this.ResumeLayout(false);

        }

        private void frmMedicineInfo_Doctor_Load(object sender, EventArgs e)
        {

        }
    }
}
