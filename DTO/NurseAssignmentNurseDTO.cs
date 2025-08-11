using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NurseAssignmentNurseDTO
    {
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string PatientID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Role { get; set; }
        public string Note { get; set; }
        public string PatientName { get; set; }
    }
}
