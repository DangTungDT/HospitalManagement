using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DailyCareDTO
    {
        public DailyCareDTO(int id, string shift, string bloodPressure, decimal bodyTempearature, int pulseRate, DateTime? dateCare, string note, string patientID, int roomID, string nurseID, string nurseName, string patientName, string roomName)
        {
            Id = id;
            Shift = shift;
            BloodPressure = bloodPressure;
            BodyTempearature = bodyTempearature;
            PulseRate = pulseRate;
            DateCare = dateCare;
            Note = note;
            PatientID = patientID;
            RoomID = roomID;
            NurseID = nurseID;
            NurseName = nurseName;
            PatientName = patientName;
            RoomName = roomName;
        }

        public int Id { get; set; }
        public string Shift { get; set; }
        public string BloodPressure { get; set; }
        public decimal BodyTempearature { get; set; }
        public int PulseRate { get; set; }
        public DateTime? DateCare { get; set; }
        public string Note { get; set; }
        public string PatientID { get; set; }
        public int RoomID { get; set; }
        public string NurseID { get; set; }

        // Thông tin mô tả (tùy nếu cần dùng)
        public string NurseName { get; set; }
        public string PatientName { get; set; }
        public string RoomName { get; set; }
        public DailyCareDTO() { }
    }
}
