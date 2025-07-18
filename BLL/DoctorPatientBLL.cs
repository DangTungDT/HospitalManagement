using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoctorPatientBLL
    {
        private DoctorPatientDAL dal = new DoctorPatientDAL();

        public List<DoctorPatientDTO> GetPatientsByDoctor(string doctorId)
        {
            return dal.GetPatientsByDoctor(doctorId);
        }

        public void AddDoctorPatient(DoctorPatientDTO dto)
        {
            dal.AddDoctorPatient(dto);
        }

        public void UpdateDoctorPatient(DoctorPatientDTO dto)
        {
            dal.UpdateDoctorPatient(dto);
        }
        public List<DoctorPatientDTO> SearchByPatientId(string doctorId, string keyword)
        {
            return dal.SearchByPatientId(doctorId, keyword);
        }
        public List<PatientSupplyHistoryDTO> GetAllPatients(string id) => dal.GetAllPatients(id);
        public bool IsDoctorPatientExists(string doctorId, string patientId, DateTime startDate)
        {
            return dal.IsDoctorPatientExists(doctorId, patientId, startDate);
        }
    }
}
