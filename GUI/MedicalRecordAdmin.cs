using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class MedicalRecordAdmin : Form
    {
        MedicalRecordBLL bll = new MedicalRecordBLL();

        public MedicalRecordAdmin()
        {
            InitializeComponent();
            this.Load += MedicalRecordAdmin_Load;
            dgvDanhSachHoSo.CellClick += dgvDanhSachHoSo_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnThoat.Click += btnThoat_Click;
        }

        #region "Load & Setup"
        private void MedicalRecordAdmin_Load(object sender, EventArgs e)
        {
            dtpNgayTao.ShowCheckBox = true;
            dtpNgayTao.Checked = true;

            LoadComboBoxes();
            LoadDataGridView();
            ClearFields();
        }

        private void LoadDataGridView()
        {
            dgvDanhSachHoSo.DataSource = bll.GetAll();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvDanhSachHoSo.Columns["id"].Visible = true;
            dgvDanhSachHoSo.Columns["id"].HeaderText = "Mã Hồ Sơ";
            dgvDanhSachHoSo.Columns["patientID"].Visible = false;
            dgvDanhSachHoSo.Columns["doctorID"].Visible = false;
            dgvDanhSachHoSo.Columns["PatientName"].HeaderText = "Bệnh Nhân";
            dgvDanhSachHoSo.Columns["DoctorName"].HeaderText = "Bác Sĩ";
            dgvDanhSachHoSo.Columns["createdDate"].HeaderText = "Ngày Tạo";
            dgvDanhSachHoSo.Columns["diagnosis"].HeaderText = "Chẩn Đoán";
            dgvDanhSachHoSo.Columns["vitalSigns"].HeaderText = "Dấu Hiệu Sinh Tồn";
        }

        private void LoadComboBoxes()
        {
            cboBenhNhan.DataSource = bll.GetPatients();
            cboBenhNhan.DisplayMember = "Name";
            cboBenhNhan.ValueMember = "Id";

            cboBacSi.DataSource = bll.GetDoctors();
            cboBacSi.DisplayMember = "Name";
            cboBacSi.ValueMember = "Id";
        }
        #endregion

        #region "Event Handlers"
        private void dgvDanhSachHoSo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvDanhSachHoSo.Rows[e.RowIndex];
            txtMaHoSo.Text = row.Cells["id"].Value?.ToString() ?? "";
            cboBenhNhan.SelectedValue = row.Cells["patientID"].Value;
            cboBacSi.SelectedValue = row.Cells["doctorID"].Value;
            SetDateTimePickerValue(dtpNgayTao, row.Cells["createdDate"].Value);
            txtChanDoan.Text = GetStringValue(row.Cells["diagnosis"].Value);
            txtKeHoachDieuTri.Text = GetStringValue(row.Cells["treatmentPlan"].Value);
            txtDonThuoc.Text = GetStringValue(row.Cells["prescription"].Value);
            txtGhiChu.Text = GetStringValue(row.Cells["notes"].Value);
            ParseVitalSigns(GetStringValue(row.Cells["vitalSigns"].Value));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (bll.Add(GetDTOFromForm()))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                //ClearFields();
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHoSo.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hồ sơ để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MedicalRecordDTO dto = GetDTOFromForm();
            dto.id = (int)dgvDanhSachHoSo.CurrentRow.Cells["id"].Value;

            if (bll.Update(dto))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                //ClearFields();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHoSo.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hồ sơ để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = (int)dgvDanhSachHoSo.CurrentRow.Cells["id"].Value;
            if (MessageBox.Show($"Bạn có chắc muốn xóa hồ sơ #{id} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bll.Delete(id))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    //ClearFields();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadDataGridView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Helper Methods"
        private void ClearFields()
        {
            cboBenhNhan.SelectedIndex = -1;
            cboBacSi.SelectedIndex = -1;
            dtpNgayTao.Value = DateTime.Now;
            dtpNgayTao.Checked = true;
            txtChanDoan.Clear();
            txtKeHoachDieuTri.Clear();
            txtDonThuoc.Clear();
            txtGhiChu.Clear();
            txtHuyetAp.Clear();
            nudNhietDo.Value = 0;
            nudNhipTim.Value = 0;
            txtMaHoSo.Text = "";
            cboBenhNhan.Focus();
        }

        private MedicalRecordDTO GetDTOFromForm()
        {
            return new MedicalRecordDTO
            {
                patientID = cboBenhNhan.SelectedValue?.ToString(),
                doctorID = cboBacSi.SelectedValue?.ToString(),
                createdDate = dtpNgayTao.Checked ? (DateTime?)dtpNgayTao.Value : null,
                diagnosis = txtChanDoan.Text,
                treatmentPlan = txtKeHoachDieuTri.Text,
                prescription = txtDonThuoc.Text,
                notes = txtGhiChu.Text,
                vitalSigns = CombineVitalSigns() // Kết hợp các giá trị dấu hiệu sinh tồn
            };
        }

        /// <summary>
        /// Kết hợp các giá trị từ các control dấu hiệu sinh tồn thành một chuỗi duy nhất.
        /// </summary>
        private string CombineVitalSigns()
        {
            var parts = new List<string>();
            if (!string.IsNullOrWhiteSpace(txtHuyetAp.Text)) parts.Add($"Huyết áp: {txtHuyetAp.Text}");
            if (nudNhietDo.Value > 0) parts.Add($"Nhiệt độ: {nudNhietDo.Value}°C");
            if (nudNhipTim.Value > 0) parts.Add($"Nhịp tim: {nudNhipTim.Value} lần/phút");
            // Thêm các dấu hiệu khác nếu có (ví dụ: nhịp thở)
            // if (nudNhipTho.Value > 0) parts.Add($"Nhịp thở: {nudNhipTho.Value} lần/phút");

            return string.Join(", ", parts);
        }

        /// <summary>
        /// Tách chuỗi dấu hiệu sinh tồn để điền vào các control riêng lẻ.
        /// Sửa lỗi hiển thị nhiệt độ: parse đúng phần thập phân, loại bỏ ký tự °C
        /// </summary>
        private void ParseVitalSigns(string vitalSignsString)
        {
            // Reset các control trước khi parse
            txtHuyetAp.Clear();
            nudNhietDo.Value = 0;
            nudNhipTim.Value = 0;

            if (string.IsNullOrWhiteSpace(vitalSignsString)) return;

            var parts = vitalSignsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                var keyValue = part.Split(new[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (keyValue.Length != 2) continue;

                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim();

                switch (key)
                {
                    case "Huyết áp":
                        txtHuyetAp.Text = value;
                        break;
                    case "Nhiệt độ":
                        value = value.Replace("°C", "").Trim().Replace(',', '.');
                        if (float.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float temp))
                            nudNhietDo.Value = (decimal)temp;
                        break;
                    case "Nhịp tim":
                        if (decimal.TryParse(value.Replace("lần/phút", "").Trim(), out decimal pulse))
                            nudNhipTim.Value = pulse;
                        break;
                }
            }
        }

        private string GetStringValue(object value) => value?.ToString() ?? "";
        private void SetDateTimePickerValue(DateTimePicker dtp, object value)
        {
            if (value != null && DateTime.TryParse(value.ToString(), out DateTime date))
            {
                dtp.Value = date;
                dtp.Checked = true;
            }
            else
            {
                dtp.Checked = false;
            }
        }
        #endregion

    }
}
