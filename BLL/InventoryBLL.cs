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
    public class InventoryBLL
    {
        InventoryDAL dalivt = new InventoryDAL();
        public IQueryable HienThi()
        {
            return dalivt.HienThi();
        }
        public IQueryable SearchItems(string keyword)
        {
            return dalivt.SearchItems(keyword);
        }
        public void ThemInventory(InventoryDTO dtoivt)
        {          
            if (dtoivt.LastUpdate.Date > DateTime.Now.Date)
            {
                MessageBox.Show("ngày cập nhật không được lớn hơn ngày hiện tại!!!!", "Thông báo!");
            }
            else if (string.IsNullOrEmpty(dtoivt.IdItem))
            {
                MessageBox.Show("vui lòng chọn vật phẩm chính xác!!", "Thông báo!");
            }
            else if (dtoivt.Quantity < 0)
            {
                MessageBox.Show("số lượng phải lớn hơn 0!!", "Thông báo!");
            }
            else
            {
                if (dalivt.ThemInventory(dtoivt) == true)
                {
                    MessageBox.Show("Thêm thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void XoaInventory(int maIVT)
        {
            if (dalivt.XoaInventory(maIVT) == true)
            {
                MessageBox.Show("Xóa thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CapnhatInventory(InventoryDTO dtoivt)
        {
            if (dalivt.CapnhatInventory(dtoivt) == true)
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
