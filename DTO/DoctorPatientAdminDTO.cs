using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoctorPatientAdminDTO
    {
        public string doctorID { get; set; }
        public string patientID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string role { get; set; }
        public string note { get; set; }

        // Thuộc tính để hiển thị tên trên DataGridView
        public string doctorName { get; set; }
        public string patientName { get; set; }
    }
}
