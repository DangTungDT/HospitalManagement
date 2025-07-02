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
                              select new { ivt.ItemID, ivt.Quantity, ivt.LastUpdated });
            return Inventory;
        }
        public bool ThemInventory(InventoryDTO dtoivt)
        {
            if (db.Inventories.Any(sp => sp.ItemID == dtoivt.Id))
            {
                return false;
            }
            try
            {
                Inventory ivt = new Inventory
                {
                    ItemID = dtoivt.Id,
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
        public bool XoaInventory(string maIVT)
        {
            try
            {
                var xoa = from ivt in db.Inventories
                          where ivt.ItemID == maIVT
                          select ivt;
                foreach (var x in xoa)
                {
                    db.Inventories.DeleteOnSubmit(x);
                    db.SubmitChanges();
                }
                return true;
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
                if (db.Inventories.Where(x => x.ItemID == dtoivt.Id).FirstOrDefault() != null)
                {
                    var update = db.Inventories.Single(sp => sp.ItemID == dtoivt.Id);
                    update.Quantity = dtoivt.Quantity;
                    update.LastUpdated = dtoivt.LastUpdate;
                    db.SubmitChanges();
                    return true;
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
