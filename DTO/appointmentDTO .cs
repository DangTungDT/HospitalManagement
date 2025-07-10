using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class appointmentDTO
    {
        private int id;
        private DateTime starDate;
        private string note;
        private string status;
        private string doctorID;
        private string patientID;

        public appointmentDTO(int id, DateTime starDate, string note, string status, string doctorID, string patientID)
        {
            this.id = id;
            this.starDate = starDate;
            this.note = note;
            this.status = status;
            this.doctorID = doctorID;
            this.patientID = patientID;
        }

        public int Id { get => id; set => id = value; }
        public DateTime StarDate { get => starDate; set => starDate = value; }
        public string Note { get => note; set => note = value; }
        public string Status { get => status; set => status = value; }
        public string DoctorID { get => doctorID; set => doctorID = value; }
        public string PatientID { get => patientID; set => patientID = value; }
        public appointmentDTO() { }

        public appointmentDTO(DateTime starDate, string note, string status, string doctorID, string patientID)
        {
            this.starDate = starDate;
            this.note = note;
            this.status = status;
            this.doctorID = doctorID;
            this.patientID = patientID;
        }
    }
}
