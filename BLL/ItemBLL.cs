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
    public class ItemBLL
    {
        ItemDAL dalitem = new ItemDAL();
        public IQueryable HienThi()
        {
            return dalitem.HienThi();
        }
        public void ThemItems(ItemDTO dtoitems)
        {
            if (dalitem.ThemItem(dtoitems) == true)
            {
                MessageBox.Show("Thêm thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void XoaItems(string maItem)
        {
            if (dalitem.XoaItem(maItem) == true)
            {
                MessageBox.Show("Xóa thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CapnhatItems(ItemDTO dtoitems)
        {
            if (dalitem.CapnhatItem(dtoitems) == true)
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
