using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PrescriptionInfoDoctorDTO
    {
        public string PrescriptionID { get; set; }
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Note { get; set; }
        
        // Thêm properties để hiển thị tên thay vì mã
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}
