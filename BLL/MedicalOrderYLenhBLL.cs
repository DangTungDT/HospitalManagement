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
    public class MedicalOrderYLenhBLL
    {
        MedicalOrderYLenhDAL dalylenh = new MedicalOrderYLenhDAL();
        public IQueryable HienThi()
        {
           return dalylenh.HienThi();
        }
        public void ThemYlenh(MedicalOrderYLenhDTO dtoylenh)
        {
            if (dalylenh.ThemMediticalYlenh(dtoylenh) == true)
            {
                MessageBox.Show("Thêm thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
