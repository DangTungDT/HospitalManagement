using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PatientListbyDepartmentDTO
    {
        public string PatientID { get; set; }
        public string fullName { get; set; }
        public string gender { get; set; }
        public DateTime? dob { get; set; }
        public string DepartmentName { get; set; }
        public string status { get; set; }
        public DateTime? createdDate { get; set; }
    }
}
