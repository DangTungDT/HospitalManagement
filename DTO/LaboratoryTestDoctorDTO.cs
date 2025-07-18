using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LaboratoryTestDoctorDTO
    {
        public int Id { get; set; }
        public int MedicalOrderID { get; set; } // 🔄 Liên kết đến y lệnh
        public DateTime? StartDate { get; set; }
        public string ResultValue { get; set; }
        public string ResultUnit { get; set; }
        public string Result { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        // ➕ Các thông tin bổ sung từ MedicalOrder
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public string DoctorID { get; set; }
        public string OrderType { get; set; }
        public string TestType { get;set;}

    }
}
