using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PatientNurseDTO
    {
            public string Id { get; set; }
            public string FullName { get; set; }
            public string Gender { get; set; }
            public DateTime? DOB { get; set; }
            public string PhoneNumber { get; set; }
            public string TypePatient { get; set; }
            public string CitizenID { get; set; }
            public string InsuranceID { get; set; }
            public string Address { get; set; }
            public string EmergencyContact { get; set; }
            public string EmergencyPhone { get; set; }
            public string Status { get; set; }
            public DateTime? CreatedDate { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public float? Weight { get; set; }
            public float? Height { get; set; }

    }
}
