using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DepartmentInfoDoctorDTO
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPosition { get; set; }
        public string DoctorQualification { get; set; }
        public string DoctorDegree { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
        public int StaffCount { get; set; }
        public int RoomCount { get; set; }
        public int PatientCount { get; set; }
    }
}
