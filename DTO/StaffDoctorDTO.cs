using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StaffDoctorDTO
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string CitizenID { get; set; }
        public string DepartmentID { get; set; }
        public string Position { get; set; }
        public string Qualification { get; set; }
        public string Degree { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public string Notes { get; set; }
    }
}
