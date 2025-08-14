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
    public partial class frmTestTypeInfoDoctorGUI : Form
    {
        private TestTypeInfoDoctorBLL bll = new TestTypeInfoDoctorBLL();
        private List<TestTypeInfoDoctorDTO> testTypeList;
        private List<TestTypeInfoDoctorDTO> allTestTypes; // Lưu tất cả dữ liệu gốc

        public frmTestTypeInfoDoctorGUI()
        {
            InitializeComponent();
            this.Load += frmTestTypeInfoDoctorGUI_Load;
            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            //cboSearch.SelectedIndexChanged += cboSearch_SelectedIndexChanged;
            
            // Thêm sự kiện hover cho buttons
            btnSearch.MouseEnter += (s, e) => btnSearch.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnSearch.MouseLeave += (s, e) => btnSearch.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
        }

        private void frmTestTypeInfoDoctorGUI_Load(object sender, EventArgs e)
        {
            LoadTestTypeList();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Thêm option "Tất cả" vào đầu combobox
                cboSearch.Items.Clear();
                cboSearch.Items.Add("-- Tất cả loại xét nghiệm --");

                // Thêm tất cả loại xét nghiệm vào combobox
                if (allTestTypes != null)
                {
                    foreach (var testType in allTestTypes)
                    {
                        cboSearch.Items.Add(testType.TestTypeName);
                    }
                }

                // Chọn item đầu tiên
                if (cboSearch.Items.Count > 0)
                    cboSearch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu combobox: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTestTypeList(List<TestTypeInfoDoctorDTO> list = null)
        {
            try
            {
                if (list == null)
                {
                    allTestTypes = bll.GetAll(); // Lưu tất cả dữ liệu gốc
                    testTypeList = allTestTypes;
                }
                else
                {
                    testTypeList = list;
                }

                dgvTestTypes.AutoGenerateColumns = false;
                dgvTestTypes.DataSource = testTypeList;

                // Cấu hình cột
                if (dgvTestTypes.Columns.Count == 0)
                {
                    dgvTestTypes.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "TestTypeID",
                        HeaderText = "Mã Loại Xét Nghiệm",
                        Name = "TestTypeID",
                        Width = 150
                    });

                    dgvTestTypes.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "TestTypeName",
                        HeaderText = "Tên Loại Xét Nghiệm",
                        Name = "TestTypeName",
                        Width = 300
                    });
                }

                // Cập nhật thông tin số lượng
                UpdateStatusInfo();

                // Kiểm tra nếu không có dữ liệu
                if (testTypeList.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu loại xét nghiệm nào!\nVui lòng kiểm tra kết nối database hoặc thêm dữ liệu mẫu.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\nVui lòng kiểm tra kết nối database.", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testTypeList = new List<TestTypeInfoDoctorDTO>();
                allTestTypes = new List<TestTypeInfoDoctorDTO>();
                dgvTestTypes.DataSource = testTypeList;
            }
        }

        private void UpdateStatusInfo()
        {
            // Cập nhật tiêu đề với số lượng
            int totalCount = allTestTypes?.Count ?? 0;
            int filteredCount = testTypeList?.Count ?? 0;
            
            if (totalCount == filteredCount)
            {
                lblTitle.Text = $"Danh Sách Loại Xét Nghiệm ({totalCount} loại)";
            }
            else
            {
                lblTitle.Text = $"Danh Sách Loại Xét Nghiệm ({filteredCount}/{totalCount} loại)";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reset combobox về "Tất cả"
            if (cboSearch.Items.Count > 0)
                cboSearch.SelectedIndex = 0;
            
            // Hiển thị lại tất cả dữ liệu
            LoadTestTypeList();
        }

        //private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Tự động filter khi chọn item trong combobox
        //    FilterData();
        //}

        private void FilterData()
        {
            try
            {
                if (cboSearch.SelectedIndex <= 0 || cboSearch.SelectedIndex >= cboSearch.Items.Count)
                {
                    // Hiển thị tất cả
                    testTypeList = allTestTypes;
                }
                else
                {
                    // Lọc theo loại xét nghiệm được chọn
                    string selectedTestType = cboSearch.SelectedItem.ToString();
                    testTypeList = allTestTypes.FindAll(x => x.TestTypeName == selectedTestType);
                }

                dgvTestTypes.DataSource = testTypeList;
                UpdateStatusInfo();

                // Thông báo kết quả tìm kiếm
                if (cboSearch.SelectedIndex > 0)
                {
                    MessageBox.Show($"Đã tìm thấy {testTypeList.Count} kết quả cho loại xét nghiệm: {cboSearch.SelectedItem}", 
                        "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
