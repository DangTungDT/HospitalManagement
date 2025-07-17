using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StaffListbyDepartmentDTO
    {
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string StaffRole { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string gender { get; set; }
        public string phoneNumber { get; set; }
        public string position { get; set; }
        public string DepartmentName { get; set; }
        public DateTime? startDate { get; set; }
        public string status { get; set; }
    }
}
