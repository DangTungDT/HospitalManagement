using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();
        public IQueryable HienThi()
        {
            IQueryable item = (from it in db.Items
                               select new { it.ID, it.ItemName, it.ItemType, it.Unit, it.Price, it.CreatedAt, it.IsActive });
            return item;
        }
        public bool ThemItem(ItemDTO dtoitem)
        {
            if (db.Items.Any(sp => sp.ID == dtoitem.Id))
            {
                return false;
            }
            try
            {
                Item dtoit = new Item
                {
                    ID = dtoitem.Id,
                    ItemName = dtoitem.ItemName,
                    ItemType = dtoitem.ItemType1,
                    Unit = dtoitem.Unit1,
                    Price = dtoitem.Price1,
                    CreatedAt = dtoitem.CreatedAt1,
                    IsActive = dtoitem.IsActive1

                };
                db.Items.InsertOnSubmit(dtoit);
                return true;
            }
            finally
            {
                db.SubmitChanges();
            }
        }
        public bool XoaItem(string maItem)
        {
            try
            {
                var xoa = from item in db.Items
                          where item.ID == maItem
                          select item;
                foreach (var x in xoa)
                {
                    db.Items.DeleteOnSubmit(x);
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
        public bool CapnhatItem(ItemDTO dtoitem)
        {
            try
            {
                if (db.Items.Where(x => x.ID == dtoitem.Id).FirstOrDefault() != null)
                {
                    var update = db.Items.Single(sp => sp.ID == dtoitem.Id);
                    update.ItemName = dtoitem.ItemName;
                    update.ItemType = dtoitem.ItemType1;
                    update.Unit = dtoitem.Unit1;
                    update.Price = dtoitem.Price1;
                    update.CreatedAt = dtoitem.CreatedAt1;
                    update.IsActive = dtoitem.IsActive1;
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
