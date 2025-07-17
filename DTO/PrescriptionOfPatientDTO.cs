using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PrescriptionOfPatientDTO
    {
        public int PrescriptionID { get; set; }
        public string PatientName { get; set; }
        public string PatientGender { get; set; }
        public DateTime? PatientDOB { get; set; }
        public string PatientPhone { get; set; }
        public string PatientAddress { get; set; }
        public string PatientInsurance { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPosition { get; set; }
        public string DoctorQualification { get; set; }
        public string DoctorDegree { get; set; }
        public string DepartmentName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DoctorSignedAt { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public decimal? Quantity { get; set; }
        public string Unit { get; set; }
        public string Frequency { get; set; }
        public string Note { get; set; }
    }
}
