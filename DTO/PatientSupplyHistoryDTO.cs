using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PatientSupplyHistoryDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
    }
}
