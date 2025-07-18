using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MedicineItemDoctorDTO
    {
        public string ID { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
    }
}
