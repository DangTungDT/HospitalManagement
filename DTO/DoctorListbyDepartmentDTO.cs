using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoctorListbyDepartmentDTO
    {
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Qualification { get; set; }
        public string Degree { get; set; }
        public string Status { get; set; }
        public string DepartmentName { get; set; }
    }
}
