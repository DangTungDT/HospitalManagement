using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicalRecordDoctorBLL
    {
        private MedicalRecordDoctorDAL dal = new MedicalRecordDoctorDAL();

        public List<MedicalRecordDoctorDTO> GetRecordsByDoctor(string doctorId)
        {
            return dal.GetMedicalRecordsByDoctor(doctorId);
        }

        public void AddMedicalRecord(MedicalRecordDoctorDTO dto)
        {
            dal.AddMedicalRecord(dto);
        }

        public List<MedicalRecordDoctorDTO> SearchRecordsByPatient(string doctorId, string patientId)
        {
            return dal.SearchMedicalRecordsByPatient(doctorId, patientId);
        }
        public List<PatientSupplyHistoryDTO> GetAllPatients(string id) => dal.GetAllPatients(id);
    }
}
