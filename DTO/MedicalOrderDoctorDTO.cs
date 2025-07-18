using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MedicalOrderDoctorDTO
    {
        public int Id { get; set; }
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public string OrderType { get; set; }
        public string ItemID { get; set; }
        public int? TestTypeID { get; set; }
        public string Dosage { get; set; }
        public decimal? Quantity { get; set; }
        public string Unit { get; set; }
        public string Frequency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? SignedAt { get; set; }
        public string Note { get; set; }

        // Hiển thị
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public bool? HasLabTest { get; set; }
        public string TestTypeName { get; set; }
    }
}
