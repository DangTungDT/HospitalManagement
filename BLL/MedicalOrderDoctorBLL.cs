using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicalOrderDoctorBLL
    {
        private MedicalOrderDoctorDAL dal = new MedicalOrderDoctorDAL();

        public List<MedicalOrderDoctorDTO> GetOrdersByDoctor(string doctorId)
        {
            return dal.GetMedicalOrdersByDoctor(doctorId);
        }

        public List<MedicalOrderDoctorDTO> SearchOrders(string doctorId, string patientName)
        {
            return dal.SearchMedicalOrders(doctorId, patientName);
        }

        public void AddOrder(MedicalOrderDoctorDTO dto)
        {
            dal.AddMedicalOrder(dto);
        }

        public void UpdateOrder(MedicalOrderDoctorDTO dto)
        {
            dal.UpdateMedicalOrder(dto);
        }
        public List<PatientSupplyHistoryDTO> GetAllPatients(string id) => dal.GetAllPatients(id);
        public List<ItemSupplyHistoryDTO> GetAllItems()
        {
            return dal.GetAllItems();
        }
        public bool IsTestTypeIDValid(int testTypeId)
        {
            return dal.CheckTestTypeIDExists(testTypeId);
        }
        public List<LabTestTypeDocTorDTO> GetAllLabTestTypes()
        {
            return dal.GetAllLabTestTypes();
        }
        public List<PatientSupplyHistoryDTO> GetPatientsByDoctorDepartment(string doctorId)
        {
            return dal.GetPatientsByDoctorDepartment(doctorId);
        }
        // MedicalOrderDoctorBLL.cs
        public List<MedicalOrderDoctorDTO> SearchMedicalOrdersByDoctorDepartment(string doctorId, string orderType, string patientName)
        {
            return dal.SearchMedicalOrdersByDoctorDepartment(doctorId, orderType, patientName);
        }
        public List<MedicalOrderDoctorDTO> GetMedicalOrdersInDepartmentOfDoctor(string doctorId)
        {
            return dal.GetMedicalOrdersInDepartmentOfDoctor(doctorId);
        }

        public void CompleteMedicalOrder(int medicalOrderId)
        {
            var dal = new MedicalOrderDoctorDAL();
            dal.CompleteMedicalOrder(medicalOrderId);
        }
        public List<MedicalOrderDoctorDTO> GetMedicalOrdersOfPatientInDoctorDepartment(string doctorId, string patientId)
        {
            MedicalOrderDoctorDAL dal = new MedicalOrderDoctorDAL();
            return dal.GetMedicalOrdersOfPatientInDoctorDepartment(doctorId, patientId);
        }
        public PatientSupplyHistoryDTO GetPatientInfoById(string patientId)
        {
            var dal = new MedicalOrderDoctorDAL();
            return dal.GetPatientInfoById(patientId);
        }
        public string GetDepartmentIdByDoctor(string doctorId) => dal.GetDepartmentIdByDoctor(doctorId);
        public List<RoomSupplyHistoryDTO> GetRoomsByDoctorDepartment(string doctorId) => dal.GetRoomsByDoctorDepartment(doctorId);
    }
}
