using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AppointmentDTO
    {
        public AppointmentDTO(int id, DateTime startDate, string note, string status, string doctorID, string patientID, string doctorName, string patientName)
        {
            Id = id;
            StartDate = startDate;
            Note = note;
            Status = status;
            DoctorID = doctorID;
            PatientID = patientID;
            DoctorName = doctorName;
            PatientName = patientName;
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string DoctorID { get; set; }
        public string PatientID { get; set; }

        // 👇 Thêm mô tả
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public AppointmentDTO() { }
    }

}
