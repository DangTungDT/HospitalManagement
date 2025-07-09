using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// DTO cho bảng Xét nghiệm (LaboratoryTest).
    /// </summary>
    public class LaboratoryTestDTO
    {
        public int id { get; set; }
        public string testName { get; set; }
        public string patientID { get; set; }
        public string doctorID { get; set; }
        public DateTime? startDate { get; set; }
        public string resultValue { get; set; }
        public string resultUnit { get; set; }
        public string result { get; set; }
        public string testType { get; set; }
        public string status { get; set; }
        public string note { get; set; }

        // --- Thuộc tính bổ sung cho giao diện ---
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}
