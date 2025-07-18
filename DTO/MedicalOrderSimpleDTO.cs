using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MedicalOrderSimpleDTO
    {
        public int OrderId { get; set; }
        public string OrderType { get; set; }

        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }

        public string TestTypeName { get; set; }
    }
}
