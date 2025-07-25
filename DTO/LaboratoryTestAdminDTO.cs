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
        public int MedicalOrderID { get; set; }
        public DateTime? startDate { get; set; }
        public string resultValue { get; set; }
        public string resultUnit { get; set; }
        public string result { get; set; }
        public string status { get; set; }
        public string note { get; set; }
        public string MedicalOrderDisplay { get; set; } // Hiển thị tên y lệnh
    }
}
