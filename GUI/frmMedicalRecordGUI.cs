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

namespace GUI
{
    public partial class frmMedicalRecordGUI : Form
    {
        private string doctorId;
        public frmMedicalRecordGUI(string doctorId)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            LoadPatientsForDoctor(doctorId);
        }

        private void frmMedicalRecordGUI_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgvMedicalOrders); // Gọi hàm tuỳ chỉnh DGV
            StyleDataGridView(dgvPatient);
            LoadSearchComboboxes();
            LoadMedicalOrdersByDepartment();
        }
        private void LoadPatientsForDoctor(string doctorId)
        {
            MedicalOrderDoctorBLL bll = new MedicalOrderDoctorBLL();
            var patients = bll.GetPatientsByDoctorDepartment(doctorId);

            dgvPatient.AutoGenerateColumns = true;
            dgvPatient.DataSource = patients;

            CustomizePatientGrid();
        }

        private void LoadSearchComboboxes()
        {
            var bll = new MedicalOrderDoctorBLL();
            string doctorId = this.doctorId;

            // ✅ 1. Load Patient ComboBox với Id & FullName
            var allPatients = bll.GetPatientsByDoctorDepartment(doctorId); // List<PatientDTO>

            cboPatient.DataSource = allPatients;
            cboPatient.DisplayMember = "FullName";
            cboPatient.ValueMember = "Id";
            cboPatient.SelectedIndex = -1;
            cboPatient.Text = "";

            cboPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPatient.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoCompletePatient = new AutoCompleteStringCollection();
            autoCompletePatient.AddRange(allPatients.Select(p => p.FullName).ToArray());
            cboPatient.AutoCompleteCustomSource = autoCompletePatient;

            var orders = bll.SearchMedicalOrdersByDoctorDepartment(doctorId, "", "");
            var orderTypes = orders
                .Select(o => o.OrderType)
                .Where(type => !string.IsNullOrEmpty(type))
                .Distinct()
                .ToList();

            cboOrderType.DataSource = orderTypes;
            cboOrderType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboOrderType.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoCompleteOrder = new AutoCompleteStringCollection();
            autoCompleteOrder.AddRange(orderTypes.ToArray());
            cboOrderType.AutoCompleteCustomSource = autoCompleteOrder;
            cboOrderType.SelectedIndex = -1;
            cboOrderType.Text = "";
        }
        private void groupBox1_Paint(object sender, PaintEventArgs e)
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
        MedicalOrderDoctorBLL bll = new MedicalOrderDoctorBLL();

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string orderType = cboOrderType.Text.Trim();
            string patientName = cboPatient.Text.Trim();

            var bll = new MedicalOrderDoctorBLL();
            var results = bll.SearchMedicalOrdersByDoctorDepartment(this.doctorId, orderType, patientName);

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvMedicalOrders.DataSource = results;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboOrderType.SelectedIndex = -1;
            cboPatient.SelectedIndex = -1;
            LoadMedicalOrdersByDepartment();
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

            var allPatients = bll.GetPatientsByDoctorDepartment(doctorId);
            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? allPatients
                : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();

            dgvPatient.DataSource = filtered;
        }

        private void dgvMedicalOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var order = dgvMedicalOrders.Rows[e.RowIndex].DataBoundItem as MedicalOrderDoctorDTO;
                if (order != null)
                {
                    // ✅ Gán bệnh nhân
                    cboPatient.SelectedValue = order.PatientID;

                    if (cboPatient.SelectedValue == null || cboPatient.SelectedValue.ToString() != order.PatientID)
                    {
                        cboPatient.Text = order.PatientName;
                    }

                    // ✅ Gán loại y lệnh
                    string orderType = order.OrderType;

                    // Nếu combobox chứa mã hợp lệ thì gán SelectedItem
                    if (cboOrderType.Items.Contains(orderType))
                    {
                        cboOrderType.SelectedItem = orderType;
                    }
                    else
                    {
                        // fallback nếu không có trong danh sách
                        cboOrderType.Text = orderType;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMedicalOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một y lệnh để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // ✅ Kiểm tra combobox y lệnh
            if (cboOrderType.SelectedValue == null || string.IsNullOrWhiteSpace(cboOrderType.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn loại y lệnh trước khi cập nhật.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Lấy dòng đang chọn
                DataGridViewRow selectedRow = dgvMedicalOrders.SelectedRows[0];

                // Lấy ID và trạng thái y lệnh
                int selectedOrderId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                string status = selectedRow.Cells["Status"].Value?.ToString();

                // Kiểm tra nếu y lệnh đã hoàn thành
                if (!string.IsNullOrEmpty(status) && status.ToLower() == "completed")
                {
                    MessageBox.Show("Y lệnh này đã hoàn thành, không thể cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gọi BLL cập nhật
                MedicalOrderDoctorBLL bll = new MedicalOrderDoctorBLL();
                bll.CompleteMedicalOrder(selectedOrderId);

                MessageBox.Show("Cập nhật y lệnh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload lại danh sách
                LoadMedicalOrdersByDepartment();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật y lệnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMedicalordersofapatient_Click(object sender, EventArgs e)
        {
            string selectedPatientId = null;

            // Kiểm tra ComboBox
            if (cboPatient.Items.Count == 0 || cboPatient.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID từ ComboBox (chỉ lấy khi thực sự đã chọn)
            if (cboPatient.SelectedValue != null)
            {
                selectedPatientId = cboPatient.SelectedValue.ToString();
            }

            // (Tùy chọn) Nếu muốn ưu tiên DataGridView khi có chọn dòng
            if (dgvPatient.SelectedRows.Count > 0)
            {
                var patient = dgvPatient.SelectedRows[0].DataBoundItem as PatientSupplyHistoryDTO;
                if (patient != null)
                    selectedPatientId = patient.Id;
            }

            // Nếu vẫn không có ID bệnh nhân
            if (string.IsNullOrEmpty(selectedPatientId))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy doctorId từ form hiện tại
            string currentDoctorId = this.doctorId;

            // Mở form mới với 2 mã
            frmMedicalOrdersOfPatientNurse frm = new frmMedicalOrdersOfPatientNurse(currentDoctorId, selectedPatientId);
            frm.ShowDialog();
        }
        private void CustomizePatientGrid()
        {
            if (dgvPatient.Columns.Count == 0) return;

            // Đổi tên cột sang tiếng Việt
            dgvPatient.Columns["Id"].HeaderText = "Mã BN";
            dgvPatient.Columns["FullName"].HeaderText = "Họ tên";
            dgvPatient.Columns["Gender"].HeaderText = "Giới tính";
            dgvPatient.Columns["Dob"].HeaderText = "Ngày sinh";
            dgvPatient.Columns["PhoneNumber"].HeaderText = "SĐT";
            dgvPatient.Columns["Status"].HeaderText = "Trạng thái";

            // Ẩn cột không cần thiết (nếu có thêm trường khác trong DTO)
            foreach (DataGridViewColumn col in dgvPatient.Columns)
            {
                if (!new[] { "Id", "FullName", "Gender", "Dob", "PhoneNumber", "Status" }.Contains(col.Name))
                {
                    col.Visible = false;
                }
            }
        }
        private void CustomizeMedicalOrderGrid()
        {
            if (dgvMedicalOrders.Columns.Count == 0) return;

            // Đổi tên cột sang tiếng Việt
            dgvMedicalOrders.Columns["Id"].HeaderText = "Mã y lệnh";
            dgvMedicalOrders.Columns["PatientName"].HeaderText = "Tên bệnh nhân";
            dgvMedicalOrders.Columns["OrderType"].HeaderText = "Loại y lệnh";
            dgvMedicalOrders.Columns["ItemID"].HeaderText = "Thuốc/Vật tư";
            dgvMedicalOrders.Columns["TestTypeName"].HeaderText = "Xét nghiệm";
            dgvMedicalOrders.Columns["Dosage"].HeaderText = "Liều dùng";
            dgvMedicalOrders.Columns["Quantity"].HeaderText = "Số lượng";
            dgvMedicalOrders.Columns["Unit"].HeaderText = "Đơn vị";
            dgvMedicalOrders.Columns["Frequency"].HeaderText = "Tần suất";
            dgvMedicalOrders.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
            dgvMedicalOrders.Columns["EndDate"].HeaderText = "Ngày kết thúc";
            dgvMedicalOrders.Columns["Status"].HeaderText = "Trạng thái";
            dgvMedicalOrders.Columns["CreatedAt"].HeaderText = "Ngày tạo";
            dgvMedicalOrders.Columns["SignedAt"].HeaderText = "Ngày ký";
            dgvMedicalOrders.Columns["Note"].HeaderText = "Ghi chú";

            // Ẩn các cột kỹ thuật không cần hiển thị
            foreach (DataGridViewColumn col in dgvMedicalOrders.Columns)
            {
                if (!new[] {
            "Id", "PatientName", "OrderType", "ItemID", "TestTypeName",
            "Dosage", "Quantity", "Unit", "Frequency", "StartDate", "EndDate",
            "Status", "CreatedAt", "SignedAt", "Note"
        }.Contains(col.Name))
                {
                    col.Visible = false;
                }
            }
        }
        private void LoadMedicalOrdersByDepartment()
        {
            var bll = new MedicalOrderDoctorBLL();
            var orders = bll.GetMedicalOrdersInDepartmentOfDoctor(this.doctorId);

            dgvMedicalOrders.AutoGenerateColumns = true;
            dgvMedicalOrders.DataSource = orders;

            CustomizeMedicalOrderGrid();
        }

       
    }
}

