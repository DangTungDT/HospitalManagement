using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InventoryDAL
       
{
        HospitalManagementDataContext db = new HospitalManagementDataContext();
        public IQueryable HienThi()
        {
            IQueryable Inventory = (from ivt in db.Inventories
                              select new {ivt.id, ivt.ItemID, ivt.Quantity, ivt.LastUpdated });
            return Inventory;
        }
        public IQueryable SearchItems(string keyword)
        {
            try
            {
                IQueryable Item = from it in db.Items
                                       where it.ItemName.Contains(keyword)
                                       select new { it.ID, it.ItemName, it.ItemType,it.Unit };
                return Item;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm kho: " + ex.Message);
            }
        }
        public bool ThemInventory(InventoryDTO dtoivt)
        {
            if (db.Inventories.Any(sp => sp.ItemID == dtoivt.IdItem && sp.Quantity==dtoivt.Quantity && sp.LastUpdated==dtoivt.LastUpdate))
            {
                return false;
            }
            try
            {
                Inventory ivt = new Inventory
                {
                    ItemID = dtoivt.IdItem,
                    Quantity = dtoivt.Quantity,
                    LastUpdated = dtoivt.LastUpdate,
                };
                db.Inventories.InsertOnSubmit(ivt);
                return true;
            }
            finally
            {
                db.SubmitChanges();
            }
        }
        public bool XoaInventory(int id)
        {
            try
            {
                Inventory xoa = (from ivt in db.Inventories
                          where ivt.id == id
                          select ivt).FirstOrDefault();
                if(xoa != null)
                {                   
                        db.Inventories.DeleteOnSubmit(xoa);
                        db.SubmitChanges();                  
                    return true;
                }
                return false;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547)
                {
                    return false;
                }
                return false;
            }
        }
        public bool CapnhatInventory(InventoryDTO dtoivt)
        {
            try
            {
                if (db.Inventories.Where(x => x.id == dtoivt.Id).FirstOrDefault() != null)
                {
                    var update = db.Inventories.Where(sp => sp.id == dtoivt.Id).FirstOrDefault();
                    if(update != null)
                    {
                        update.Quantity = dtoivt.Quantity;
                        update.LastUpdated = dtoivt.LastUpdate;
                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
                return false;
            }
            finally
            {
                db.SubmitChanges();
            }
        }
    }
}
