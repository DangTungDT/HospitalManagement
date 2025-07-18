using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class ItemDoctorDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<MedicineItemDoctorDTO> GetAllMedicines()
        {
            return db.Items
                     .Where(i => i.ItemType == "Medicine" && i.IsActive == true)
                     .Select(i => new MedicineItemDoctorDTO
                     {
                         ID = i.ID,
                         ItemName = i.ItemName,
                         Unit = i.Unit,
                         Price = i.Price
                     }).ToList();
        }

        public List<MedicineItemDoctorDTO> SearchMedicinesByName(string keyword)
        {
            return db.Items
                     .Where(i => i.ItemType == "Medicine" && i.IsActive == true && i.ItemName.Contains(keyword))
                     .Select(i => new MedicineItemDoctorDTO
                     {
                         ID = i.ID,
                         ItemName = i.ItemName,
                         Unit = i.Unit,
                         Price = i.Price
                     }).ToList();
        }
    }
}
