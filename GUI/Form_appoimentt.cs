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
    public partial class Form_appoimentt : Form
    {
        public Form_appoimentt()
        {
            InitializeComponent();
        }
        ApmentDTO dtodk = new ApmentDTO();
        ApmentBLL blldk = new ApmentBLL();
        private void Form_appoimentt_Load(object sender, EventArgs e)
        {
            dgv_dangkylichhen.DataSource = blldk.HienThi();
            cbo_tenbacsi.DataSource = blldk.LaydsBS();
            cbo_tenbacsi.DisplayMember = "name";
            cbo_tenbacsi.ValueMember = "doctorID";
            cbo_tenbenhnhan.DataSource = blldk.LaydsBN();
            cbo_tenbenhnhan.DisplayMember = "fullName";
            cbo_tenbenhnhan.ValueMember = "id";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dtp_datestar.Text) || !DateTime.TryParse(dtp_datestar.Text, out DateTime dateStart))
                {
                    MessageBox.Show("Vui lòng chọn một ngày hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dateStart < DateTime.Today)
                {
                    MessageBox.Show("Ngày hẹn không được là ngày trong quá khứ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txt_note.Text) && txt_note.Text.Length > 200)
                {
                    MessageBox.Show("Ghi chú không được vượt quá 200 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string[] validStatuses = { "Chưa xác nhận", "Đã xác nhận", "Hủy" };
                if (string.IsNullOrWhiteSpace(txt_status.Text) || !validStatuses.Contains(txt_status.Text))
                {
                    MessageBox.Show("Trạng thái không hợp lệ! Vui lòng nhập một trong các trạng thái: " + string.Join(", ", validStatuses),
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cbo_tenbacsi.SelectedValue == null || string.IsNullOrWhiteSpace(cbo_tenbacsi.SelectedValue.ToString()))
                {
                    MessageBox.Show("Vui lòng chọn bác sĩ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cbo_tenbenhnhan.SelectedValue == null || string.IsNullOrWhiteSpace(cbo_tenbenhnhan.SelectedValue.ToString()))
                {
                    MessageBox.Show("Vui lòng chọn bệnh nhân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                blldk.ThemDangKyLichHen(new ApmentDTO(
                    dateStart,
                    txt_note.Text,
                    txt_status.Text,
                    cbo_tenbacsi.SelectedValue.ToString(),
                    cbo_tenbenhnhan.SelectedValue.ToString()
                ));
                dgv_dangkylichhen.DataSource = blldk.HienThi();
                MessageBox.Show("Thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult cauhoi = MessageBox.Show("bạn có muốn xóa không?", "thông báo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cauhoi == DialogResult.Yes)
            {
                blldk.Xoaappontment(int.Parse(dgv_dangkylichhen.Rows[dgv_dangkylichhen.CurrentCell.RowIndex].Cells[0].Value.ToString()));
                dgv_dangkylichhen.DataSource = blldk.HienThi();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_dangkylichhen.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một lịch hẹn để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int selectedId;
                try
                {
                    selectedId = (int)dgv_dangkylichhen.CurrentRow.Cells["Id"].Value;
                    if (selectedId <= 0)
                    {
                        MessageBox.Show("ID lịch hẹn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể lấy ID lịch hẹn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!DateTime.TryParse(dtp_datestar.Text, out DateTime starDate))
                {
                    MessageBox.Show("Ngày không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (starDate < DateTime.Today)
                {
                    MessageBox.Show("Ngày hẹn không được là ngày trong quá khứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cbo_tenbacsi.SelectedValue == null || string.IsNullOrWhiteSpace(cbo_tenbacsi.SelectedValue.ToString()))
                {
                    MessageBox.Show("Vui lòng chọn bác sĩ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbo_tenbenhnhan.SelectedValue == null || string.IsNullOrWhiteSpace(cbo_tenbenhnhan.SelectedValue.ToString()))
                {
                    MessageBox.Show("Vui lòng chọn bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string[] validStatuses = { "Chưa xác nhận", "Đã xác nhận", "Hủy" }; // Danh sách trạng thái hợp lệ
                if (string.IsNullOrWhiteSpace(txt_status.Text) || !validStatuses.Contains(txt_status.Text))
                {
                    MessageBox.Show($"Trạng thái không hợp lệ! Vui lòng nhập một trong các trạng thái: {string.Join(", ", validStatuses)}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txt_note.Text) && txt_note.Text.Length > 200)
                {
                    MessageBox.Show("Ghi chú không được vượt quá 200 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool result = blldk.SuaLichHen(new ApmentDTO(
                    selectedId,
                    starDate,
                    txt_note.Text,
                    txt_status.Text,
                    cbo_tenbacsi.SelectedValue.ToString(),
                    cbo_tenbenhnhan.SelectedValue.ToString()
                ));
                if (result)
                {
                    dgv_dangkylichhen.DataSource = blldk.HienThi();
                    MessageBox.Show("Sửa lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa lịch hẹn thất bại! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_dangkylichhen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e != null)
            {
                txt_id.Text = dgv_dangkylichhen.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                dtp_datestar.Value = DateTime.Parse(dgv_dangkylichhen.Rows[e.RowIndex].Cells[1].Value.ToString().Trim());
                txt_note.Text = dgv_dangkylichhen.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txt_status.Text = dgv_dangkylichhen.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                cbo_tenbacsi.SelectedValue = dgv_dangkylichhen.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbo_tenbenhnhan.SelectedValue = dgv_dangkylichhen.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_appoimentt_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
