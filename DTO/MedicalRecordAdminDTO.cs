using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// DTO cho bảng Hồ sơ Bệnh án (MedicalRecord).
    /// </summary>
    public class MedicalRecordDTO
    {
        public int id { get; set; }
        public string patientID { get; set; }
        public string doctorID { get; set; }
        public string diagnosis { get; set; }
        public string treatmentPlan { get; set; }
        public string prescription { get; set; }
        public string vitalSigns { get; set; }
        public DateTime? createdDate { get; set; }
        public string notes { get; set; }

        // --- Thuộc tính bổ sung cho giao diện ---
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}
