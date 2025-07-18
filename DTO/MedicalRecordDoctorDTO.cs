using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MedicalRecordDoctorDTO
    {
        public int Id { get; set; }
        public string PatientID { get; set; }
        public string PatientName { get; set; } 

        public string DoctorID { get; set; }
        public string DoctorName { get; set; } 

        public string Diagnosis { get; set; }
        public string TreatmentPlan { get; set; }
        public string Prescription { get; set; }
        public string VitalSigns { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Notes { get; set; }
    }
}
