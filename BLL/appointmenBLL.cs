using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class appointmenBLL
    {
        appointmentDAL daldk = new appointmentDAL();
        public IQueryable HienThi()
        {
            return daldk.HienThi();
        }
        public IQueryable LaydsBN()
        {
            return daldk.LaydsBN();
        }

        public IQueryable LaydsBS()
        {
            return daldk.LaydsBacsi();
        }
        public bool ThemDangKyLichHen(appointmentDTO dtodk)
        {
            if (daldk.Themappointment(dtodk) == true)
            {
                MessageBox.Show("Thêm thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        public void Xoaappontment(int maAPP)
        {
            if (daldk.Xoaappointment(maAPP) == true)
            {
                MessageBox.Show("Xóa thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
