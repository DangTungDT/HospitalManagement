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
    public class RoomBLL
    {
        RoomDAL dalroom = new RoomDAL();
        public IQueryable HienThi()
        {
            return dalroom.Hienthi();
        }
        public IQueryable Laydpm()
        {
            return dalroom.LayDepartment();
        }
        public void ThemRoom(RoomDTO dtoroom)
        {
            if (dalroom.ThemRoom(dtoroom) == true)
            {
                MessageBox.Show("Thêm thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void XoaRoom(int maRoom)
        {
            if (dalroom.Xoaroom(maRoom) == true)
            {
                MessageBox.Show("Xóa thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CapnhatRoom(RoomDTO dtoroom)
        {
            if (dalroom.CapnhatRoom(dtoroom) == true)
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
