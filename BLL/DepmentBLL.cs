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
    public class DepmentBLL
    {
        DepmentDAL daldpm = new DepmentDAL();
        public IQueryable HienThi()
        {
            return daldpm.HienThi();
        }
        public void ThemDepartment(DepmentDTO dtodpm)
        {
            if (daldpm.ThemDPM(dtodpm) == true)
            {
                MessageBox.Show("Thêm thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void XoaDepartment(string maDPM)
        {
            if (daldpm.XoaDPNM(maDPM) == true)
            {
                MessageBox.Show("Xóa thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CapnhatDepartment(DepmentDTO dtodpm)
        {
            if (daldpm.CapnhatDPM(dtodpm) == true)
            {
                MessageBox.Show("Cập nhật thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
