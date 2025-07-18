using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemDoctorBLL
    {
        ItemDoctorDAL dal = new ItemDoctorDAL();

        public List<MedicineItemDoctorDTO> GetAllMedicines()
        {
            return dal.GetAllMedicines();
        }

        public List<MedicineItemDoctorDTO> SearchMedicines(string keyword)
        {
            return dal.SearchMedicinesByName(keyword);
        }
    }
}
