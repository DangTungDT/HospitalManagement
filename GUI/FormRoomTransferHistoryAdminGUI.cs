using BLL;
using DAL;
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
    public partial class FormRoomTransferHistoryAdminGUI : Form
    {
        public FormRoomTransferHistoryAdminGUI()
        {
            InitializeComponent();
        }
        private void LoadSearchComboboxes()
        {

            // ===== Khoa =====
            var departments = bll.GetAllDepartments();

            cboDepartment.DataSource = new List<Department>(departments);
            cboDepartment.DisplayMember = "departmentName";
            cboDepartment.ValueMember = "id";
            cboDepartment.SelectedIndex = -1;

            cboDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDepartment.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoCompleteDept = new AutoCompleteStringCollection();
            autoCompleteDept.AddRange(departments.Select(d => d.departmentName).ToArray());
            cboDepartment.AutoCompleteCustomSource = autoCompleteDept;

            // ===== Phòng (ban đầu trống, sẽ load khi chọn khoa) =====
            cboRoom.DataSource = null;
            cboRoom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboRoom.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
        TransferRoomNurseBLL bll = new TransferRoomNurseBLL();
        private void FormRoomTransferHistoryAdminGUI_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgvAllHistory);
            StyleDataGridView(dgvPatient);
            LoadInpatients();
            LoadSearchComboboxes();
            // Load toàn bộ lịch sử
            LoadAllHistory();
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
        private void LoadInpatients()
        {
            var inpatients = bll.GetInpatients(); // giờ trả về List<PatientSupplyHistoryDTO>

            // Gán cho combobox
            cboPatient.DataSource = inpatients;
            cboPatient.DisplayMember = "FullName";
            cboPatient.ValueMember = "Id";
            cboPatient.SelectedIndex = -1;
            cboPatient.Text = string.Empty; // reset hiển thị
            // Gợi ý autocomplete
            cboPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPatient.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoCompletePatient = new AutoCompleteStringCollection();
            autoCompletePatient.AddRange(inpatients.Select(p => p.FullName).ToArray());
            cboPatient.AutoCompleteCustomSource = autoCompletePatient;

            // Gán cho DataGridView
            dgvPatient.AutoGenerateColumns = true;
            dgvPatient.DataSource = inpatients;
            CustomizePatientGrid();
        }


        private void LoadAllHistory()
        {
            dgvAllHistory.DataSource = bll.GetAllRoomTransferHistory();
            // Có thể format lại cột ở đây nếu cần
        }
        string currentPatientId;
        int? currentRoomId;

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedIndex != -1)
            {
                string deptId = cboDepartment.SelectedValue.ToString();
                var rooms = bll.GetRoomsByDepartment(deptId);

                cboRoom.DataSource = new List<Room>(rooms);
                cboRoom.DisplayMember = "roomName";
                cboRoom.ValueMember = "id";
                cboRoom.SelectedIndex = -1;

                var autoCompleteRoom = new AutoCompleteStringCollection();
                autoCompleteRoom.AddRange(rooms.Select(r => r.roomName).ToArray());
                cboRoom.AutoCompleteCustomSource = autoCompleteRoom;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentPatientId) || cboRoom.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân và phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra độ dài ghi chú
            string note = txtNote.Text.Trim();
            if (note.Length > 255)
            {
                MessageBox.Show("Ghi chú không được vượt quá 255 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem bệnh nhân đã có phòng chưa
            var currentRoom = bll.GetCurrentRoomId(currentPatientId);
            if (currentRoom != null) // đã có phòng
            {
                MessageBox.Show("Bệnh nhân đã được phân phòng, không thể phân phòng mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bll.AssignRoom(currentPatientId, (int)cboRoom.SelectedValue, note);
                MessageBox.Show("Nhận phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadAllHistory();
                currentRoomId = bll.GetCurrentRoomId(currentPatientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPatient.SelectedIndex != -1)
            {
                currentPatientId = cboPatient.SelectedValue.ToString();
                dgvAllHistory.DataSource = bll.GetRoomTransferHistoryByPatient(currentPatientId);
                currentRoomId = bll.GetCurrentRoomId(currentPatientId);
            }
        }
        private void dgvAllHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string patientId = dgvAllHistory.Rows[e.RowIndex].Cells["PatientID"].Value.ToString();
                string patientName = dgvAllHistory.Rows[e.RowIndex].Cells["PatientName"].Value.ToString();

                FormRoomTransferHistoryDetail frm = new FormRoomTransferHistoryDetail(patientId, patientName);
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cboPatient.SelectedIndex = -1;
            cboDepartment.SelectedIndex = -1;
            cboRoom.SelectedIndex = -1;
            txtNote.Clear();
            LoadAllHistory();
        }

        private void cboPatient_TextChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                string keyword = cboPatient.Text.Trim().ToLower();
                var allPatients = bll.GetInpatients();
                var filtered = string.IsNullOrWhiteSpace(keyword)
                    ? allPatients
                    : allPatients.Where(p => p.FullName.ToLower().Contains(keyword)).ToList();
                dgvPatient.DataSource = filtered;
            }));
        }

        private void dgvAllHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo click vào dòng hợp lệ, không phải header
            {
                DataGridViewRow row = dgvAllHistory.Rows[e.RowIndex];

                // Lấy thông tin từ cột
                currentPatientId = row.Cells["PatientID"].Value?.ToString();
                string patientName = row.Cells["PatientName"].Value?.ToString();
                string departmentName = row.Cells["DepartmentName"].Value?.ToString();
                string toRoomName = row.Cells["ToRoomName"].Value?.ToString();
                string note = row.Cells["Note"].Value?.ToString();

                // Gán vào các control
                cboPatient.SelectedIndex = cboPatient.FindStringExact(patientName);
                cboDepartment.SelectedIndex = cboDepartment.FindStringExact(departmentName);
                cboRoom.SelectedIndex = cboRoom.FindStringExact(toRoomName);
                txtNote.Text = note;

                // Lấy currentRoomId từ BLL (nếu cần)
                currentRoomId = bll.GetCurrentRoomId(currentPatientId);
            }
        }
        private bool TryGetSelectedPatient(out string patientId, out string patientName)
        {
            patientId = null;
            patientName = null;

            // Ưu tiên ComboBox nếu có chọn hợp lệ
            if (cboPatient.SelectedIndex != -1 && cboPatient.SelectedValue != null)
            {
                patientId = cboPatient.SelectedValue.ToString();
                patientName = cboPatient.Text;
                return true;
            }

            // Nếu không, thử lấy từ dgvPatient
            if (dgvPatient.CurrentRow != null)
            {
                var patient = dgvPatient.CurrentRow.DataBoundItem as PatientSupplyHistoryDTO;
                if (patient != null)
                {
                    patientId = patient.Id;
                    patientName = patient.FullName;
                    return true;
                }
            }

            // Cuối cùng thử lấy từ dgvAllHistory
            if (dgvAllHistory.CurrentRow != null)
            {
                patientId = dgvAllHistory.CurrentRow.Cells["PatientID"].Value?.ToString();
                patientName = dgvAllHistory.CurrentRow.Cells["PatientName"].Value?.ToString();
                if (!string.IsNullOrEmpty(patientId)) return true;
            }

            return false;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentPatientId))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần xóa lịch sử!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận trước khi xóa
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lịch sử chuyển phòng mới nhất của bệnh nhân này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
            {
                return; // Người dùng không đồng ý -> thoát
            }

            // Lấy bản ghi mới nhất
            var latest = bll.GetLatestRoomTransferByPatient(currentPatientId);
            if (latest == null)
            {
                MessageBox.Show("Không tìm thấy lịch sử chuyển phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy bản ghi trước đó
            var previous = bll.GetPreviousRoomTransferByPatient(currentPatientId);

            // Xóa bản ghi mới nhất
            bll.DeleteRoomTransferHistory(latest.id);

            // Thông báo và xử lý logic nếu cần
            if (previous != null)
            {
                MessageBox.Show($"Bệnh nhân đã trở lại phòng: {previous.toRoomID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bệnh nhân hiện chưa có phòng (nhận mới bị xóa).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Load lại dữ liệu

            ClearForm();
            LoadAllHistory();
        }
        private void ClearForm()
        {
            cboPatient.SelectedIndex = -1;
            cboRoom.SelectedIndex = -1;
            txtNote.Clear();
            dgvAllHistory.DataSource = null;

            currentPatientId = null;
            currentRoomId = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedPatient(out string patientId, out string patientName))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân để chuyển phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmTransferRoomGUI frm = new frmTransferRoomGUI(patientId, patientName);
            frm.FormClosed += (s, args) =>
            {
                LoadAllHistory();
            };
            frm.ShowDialog();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ ComboBox
            string patientId = cboPatient.SelectedValue?.ToString();
            int? roomId = cboRoom.SelectedValue != null ? (int?)Convert.ToInt32(cboRoom.SelectedValue) : null;

            // Kiểm tra xem người dùng có chọn ít nhất 1 mục không
            if (string.IsNullOrEmpty(patientId) && !roomId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn trong danh sách ít nhất 1 tiêu chí (bệnh nhân hoặc phòng).",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // dừng việc tìm kiếm
            }

            try
            {
                var result = bll.SearchTransfers(patientId, roomId);
                dgvAllHistory.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
