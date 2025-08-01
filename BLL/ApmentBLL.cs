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
    public class ApmentBLL
    {
        ApmentDAL daldk = new ApmentDAL();
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
        public bool ThemDangKyLichHen(ApmentDTO dtodk)
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
        public bool SuaLichHen(ApmentDTO dtodk)
        {
            if (dtodk == null || dtodk.Id <= 0 || string.IsNullOrEmpty(dtodk.DoctorID) || string.IsNullOrEmpty(dtodk.PatientID))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool result = daldk.CapnhatLichHen(dtodk);
            if (result)
            {
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}

