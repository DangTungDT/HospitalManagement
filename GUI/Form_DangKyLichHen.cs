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
    public partial class Form_DangKyLichHen : Form
    {
        public Form_DangKyLichHen()
        {
            InitializeComponent();
        }
        appointmentDTO dtodk = new appointmentDTO();
        appointmenBLL blldk = new appointmenBLL();

        private void Form_DangKyLichHen_Load(object sender, EventArgs e)
        {
            dgv_dangkylichhen.DataSource = blldk.HienThi();
            cbo_tenbacsi.DataSource = blldk.LaydsBS();
            cbo_tenbacsi.DisplayMember = "name";
            cbo_tenbacsi.ValueMember = "doctorID";
            cbo_tenbenhnhan.DataSource = blldk.LaydsBN();
            cbo_tenbenhnhan.DisplayMember = "fullName";
            cbo_tenbenhnhan.ValueMember = "id";
        }

        private void cbo_tenbacsi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_mabenhnhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            blldk.ThemDangKyLichHen(new appointmentDTO(DateTime.Parse(dtp_datestar.Text),txt_note.Text,txt_status.Text,cbo_tenbacsi.SelectedValue.ToString(),cbo_tenbenhnhan.SelectedValue.ToString()));
            dgv_dangkylichhen.DataSource = blldk.HienThi();
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
    }
}

