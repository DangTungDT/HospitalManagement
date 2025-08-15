using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmPrescriptionDetailInfoDoctorGUI : Form
    {
        private PrescriptionDetailInfoDoctorBLL bll = new PrescriptionDetailInfoDoctorBLL();
        private List<PrescriptionComboDTO> prescriptionList;
        private List<ItemComboDTO> itemList;
        private List<PrescriptionDetailInfoDoctorDTO> detailList;
        private string selectedPrescriptionID; // Thêm biến để lưu PrescriptionID được chọn

        public frmPrescriptionDetailInfoDoctorGUI(string prescriptionID = null)
        {
            InitializeComponent();
            this.selectedPrescriptionID = prescriptionID;
            this.Load += frmPrescriptionDetailInfoDoctorGUI_Load;
            btnCreate.Click += btnCreate_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            dgvPrescriptionDetails.CellClick += dgvPrescriptionDetails_CellClick;
            cbItemID.SelectedIndexChanged += cbItemID_SelectedIndexChanged;
            dgvPrescriptionDetails.CellFormatting += dgvPrescriptionDetails_CellFormatting;
        }

        private void dgvPrescriptionDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPrescriptionDetails.Columns[e.ColumnIndex].Name == "Quantity" && e.Value != null)
            {
                decimal value;
                if (decimal.TryParse(e.Value.ToString(), out value))
                {
                    e.Value = value.ToString("0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void frmPrescriptionDetailInfoDoctorGUI_Load(object sender, EventArgs e)
        {
            LoadDetailList(); // Load detail list trước
            LoadComboBoxes(); // Sau đó load combobox
            
            // Nếu có PrescriptionID được truyền vào, chọn nó trong ComboBox
            if (!string.IsNullOrEmpty(selectedPrescriptionID))
            {
                cbPrescriptionID.SelectedValue = selectedPrescriptionID;
            }
        }

        private void LoadComboBoxes()
        {
            // Load ComboBox đơn thuốc (tất cả đơn thuốc)
            prescriptionList = bll.GetPrescriptions();
            cbPrescriptionID.DataSource = prescriptionList;
            cbPrescriptionID.DisplayMember = "PrescriptionName";
            cbPrescriptionID.ValueMember = "PrescriptionID";

            // Load ComboBox thuốc
            itemList = bll.GetItems();
            cbItemID.DataSource = itemList;
            cbItemID.DisplayMember = "ItemName";
            cbItemID.ValueMember = "ItemID";
        }

        private void LoadDetailList()
        {
            detailList = bll.GetAll();
            dgvPrescriptionDetails.AutoGenerateColumns = true;
            dgvPrescriptionDetails.DataSource = detailList;
            
            // Đổi tên cột hiển thị
            if (dgvPrescriptionDetails.Columns.Count > 0)
            {
                dgvPrescriptionDetails.Columns["PrescriptionID"].HeaderText = "Mã Đơn";
                dgvPrescriptionDetails.Columns["ItemName"].HeaderText = "Tên Thuốc";
                dgvPrescriptionDetails.Columns["Quantity"].HeaderText = "Số Lượng";
                dgvPrescriptionDetails.Columns["Unit"].HeaderText = "Đơn Vị";
                dgvPrescriptionDetails.Columns["Dosage"].HeaderText = "Liều Lượng";
                dgvPrescriptionDetails.Columns["Frequency"].HeaderText = "Tần Suất";
                dgvPrescriptionDetails.Columns["Note"].HeaderText = "Ghi Chú";
                
                // Ẩn cột không cần thiết
                if (dgvPrescriptionDetails.Columns.Contains("MedicalOrderID"))
                    dgvPrescriptionDetails.Columns["MedicalOrderID"].Visible = false; // Ẩn vì không cần thiết cho người dùng
                if (dgvPrescriptionDetails.Columns.Contains("ItemID"))
                    dgvPrescriptionDetails.Columns["ItemID"].Visible = false;
                if (dgvPrescriptionDetails.Columns.Contains("ItemType"))
                    dgvPrescriptionDetails.Columns["ItemType"].Visible = false;
                if (dgvPrescriptionDetails.Columns.Contains("Price"))
                    dgvPrescriptionDetails.Columns["Price"].Visible = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Enable combobox để cho phép chọn đơn thuốc khi tạo mới
            cbPrescriptionID.Enabled = true;
            
            // Kiểm tra riêng cho việc tạo mới
            if (cbPrescriptionID.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đơn thuốc!");
                return;
            }

            if (cbItemID.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thuốc!");
                return;
            }

            if (string.IsNullOrEmpty(txtQuantity.Text) || !decimal.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ!");
                return;
            }

            if (string.IsNullOrEmpty(cbUnit.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn vị!");
                return;
            }

            var dto = new PrescriptionDetailInfoDoctorDTO
            {
                PrescriptionID = cbPrescriptionID.SelectedValue?.ToString(),
                ItemID = cbItemID.SelectedValue?.ToString(),
                Quantity = decimal.Parse(txtQuantity.Text),
                Unit = FixUnitEncoding(cbUnit.Text),
                Dosage = txtDosage.Text.Trim(),
                Frequency = txtFrequency.Text.Trim(),
                Note = rtbNote.Text.Trim()
            };

            if (bll.Insert(dto))
            {
                MessageBox.Show("Tạo chi tiết đơn thuốc thành công!");
                LoadDetailList(); // Load detail list trước
                LoadComboBoxes(); // Sau đó load combobox
                ClearInput();
            }
            else
            {
                MessageBox.Show("Tạo chi tiết đơn thuốc thất bại!\n\nLý do có thể là:\n- Thuốc này đã có trong đơn thuốc\n- Đơn thuốc không tồn tại");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionDetails.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn chi tiết đơn thuốc để cập nhật!");
                return;
            }

            // Disable combobox để không cho phép thay đổi đơn thuốc khi cập nhật
            cbPrescriptionID.Enabled = false;

            if (ValidateInput())
            {
                var dto = new PrescriptionDetailInfoDoctorDTO
                {
                    MedicalOrderID = int.Parse(dgvPrescriptionDetails.CurrentRow.Cells["MedicalOrderID"].Value.ToString()), // Lấy MedicalOrderID từ dòng đang chọn
                    PrescriptionID = dgvPrescriptionDetails.CurrentRow.Cells["PrescriptionID"].Value.ToString(), // Lấy PrescriptionID từ dòng đang chọn
                    ItemID = cbItemID.SelectedValue?.ToString(),
                    Quantity = decimal.Parse(txtQuantity.Text),
                    Unit = FixUnitEncoding(cbUnit.Text),
                    Dosage = txtDosage.Text.Trim(),
                    Frequency = txtFrequency.Text.Trim(),
                    Note = rtbNote.Text.Trim()
                };

                if (bll.Update(dto))
                {
                    MessageBox.Show("Cập nhật chi tiết đơn thuốc thành công!");
                    LoadDetailList(); // Load detail list trước
                    LoadComboBoxes(); // Sau đó load combobox
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Cập nhật chi tiết đơn thuốc thất bại!");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionDetails.CurrentRow != null)
            {
                string medicalOrderId = dgvPrescriptionDetails.CurrentRow.Cells["MedicalOrderID"].Value.ToString(); // Lấy MedicalOrderID
                if (MessageBox.Show("Bạn có chắc muốn xóa chi tiết đơn thuốc này?", "Xác nhận", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (bll.Delete(medicalOrderId))
                    {
                        MessageBox.Show("Xóa chi tiết đơn thuốc thành công!");
                        LoadDetailList(); // Load detail list trước
                        LoadComboBoxes(); // Sau đó load combobox
                        ClearInput(); // ClearInput sẽ enable lại combobox
                    }
                    else
                    {
                        MessageBox.Show("Xóa chi tiết đơn thuốc thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chi tiết đơn thuốc để xóa!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDetailList(); // Load detail list trước
            LoadComboBoxes(); // Sau đó load combobox
            ClearInput(); // ClearInput sẽ enable lại combobox
        }

        private void dgvPrescriptionDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPrescriptionDetails.Rows[e.RowIndex].DataBoundItem as PrescriptionDetailInfoDoctorDTO;
                if (row != null)
                {
                    // Hiển thị đầy đủ thông tin lên các control
                    cbPrescriptionID.SelectedValue = row.PrescriptionID;
                    cbItemID.SelectedValue = row.ItemID;
                    txtQuantity.Text = row.Quantity.ToString();
                    cbUnit.Text = FixUnitEncoding(row.Unit);
                    txtDosage.Text = row.Dosage;
                    txtFrequency.Text = row.Frequency;
                    rtbNote.Text = row.Note;
                    
                    // Disable combobox Mã Đơn Thuốc để không cho phép thay đổi
                    cbPrescriptionID.Enabled = false;
                }
            }
        }

        private void cbItemID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tự động điền đơn vị khi chọn thuốc
            if (cbItemID.SelectedValue != null)
            {
                var selectedItem = itemList.Find(x => x.ItemID == cbItemID.SelectedValue.ToString());
                if (selectedItem != null)
                {
                    cbUnit.Text = FixUnitEncoding(selectedItem.Unit);
                }
            }
        }

        private bool ValidateInput()
        {
            
            if (cbItemID.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thuốc!");
                return false;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text) || !decimal.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ!");
                return false;
            }
            if (string.IsNullOrEmpty(cbUnit.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn vị!");
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            cbPrescriptionID.SelectedIndex = -1;
            cbPrescriptionID.Enabled = true; // Enable lại combobox để cho phép chọn đơn thuốc mới
            cbItemID.SelectedIndex = -1;
            txtQuantity.Text = "";
            cbUnit.Text = "";
            txtDosage.Text = "";
            txtFrequency.Text = "";
            rtbNote.Text = "";
        }

        // Helper method để xử lý đơn vị một cách nhất quán
        private string FixUnitEncoding(string unit)
        {
            if (string.IsNullOrEmpty(unit))
                return unit;
                
            // Xử lý các trường hợp lỗi encoding phổ biến
            if (unit.Contains("?") || unit.Contains("H?p") || unit.Contains("Hộp") == false && unit.Contains("H") && unit.Contains("p"))
            {
                return "Hộp";
            }
            
            // Xử lý các trường hợp khác nếu có
            if (unit.Contains("Viên") == false && unit.Contains("V") && unit.Contains("n"))
            {
                return "Viên";
            }
            
            if (unit.Contains("Chai") == false && unit.Contains("C") && unit.Contains("i"))
            {
                return "Chai";
            }
            
            return unit;
        }
    }
}
