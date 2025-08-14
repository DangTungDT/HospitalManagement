using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public class MedicalOrderYLenhDTO
    {
        public int Id { get; set; }
        public string PatientId { get; set; } = string.Empty;
        public string DoctorId { get; set; } = string.Empty;
        public string OrderType { get; set; } = string.Empty;
        public string ItemId { get; set; } = string.Empty;
        public int TestType { get; set; }
        public bool HasLabTest { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime SignedAt { get; set; }
        public string Note { get; set; } = string.Empty;

        public MedicalOrderYLenhDTO() { }

        public MedicalOrderYLenhDTO(int id, string patientId, string doctorId, string orderType, string itemId,
            int testType, bool hasLabTest, string dosage, decimal quantity, string unit, string frequency,
            DateTime startDate, DateTime endDate, string status, DateTime createdAt, DateTime signedAt, string note)
        {
            Id = id;
            PatientId = patientId ?? string.Empty;
            DoctorId = doctorId ?? string.Empty;
            OrderType = orderType ?? string.Empty;
            ItemId = itemId ?? string.Empty;
            TestType = testType;
            HasLabTest = hasLabTest;
            Dosage = dosage ?? string.Empty;
            Quantity = quantity;
            Unit = unit ?? string.Empty;
            Frequency = frequency ?? string.Empty;
            StartDate = startDate;
            EndDate = endDate;
            Status = status ?? string.Empty;
            CreatedAt = createdAt;
            SignedAt = signedAt;
            Note = note ?? string.Empty;
        }
    }
}

