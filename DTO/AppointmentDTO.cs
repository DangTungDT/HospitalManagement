using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string DoctorID { get; set; }
        public string PatientID { get; set; }

        // 👇 Thêm mô tả
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }

}
