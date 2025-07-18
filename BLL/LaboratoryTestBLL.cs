using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LaboratoryTestBLL
    {
        private LaboratoryTestDoctorDAL dal = new LaboratoryTestDoctorDAL();

        public List<LaboratoryTestDoctorDTO> GetTestsByDoctor(string doctorId)
        {
            return dal.GetTestsByDoctor(doctorId);
        }
        public List<LaboratoryTestDoctorDTO> SearchTestsByPatientId(string doctorId, int i)
        {
            return dal.SearchTestsByOrderId(doctorId,i);
        }

        public void AddTest(LaboratoryTestDoctorDTO dto)
        {
            dal.AddTest(dto);
        }
        public List<MedicalOrderSimpleDTO> GetOrdersByAssignedPatients(string doctorId) => dal.GetOrdersByAssignedPatients(doctorId);
    }
}
