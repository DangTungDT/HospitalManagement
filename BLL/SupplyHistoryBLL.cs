using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SupplyHistoryBLL
    {
        private SupplyHistoryDAL dal = new SupplyHistoryDAL();

        public List<SupplyHistoryDTO> GetAll() => dal.GetAll();
        public void Add(SupplyHistoryDTO dto) => dal.Add(dto);
        public void Update(SupplyHistoryDTO dto) => dal.Update(dto);
        public void Delete(string id) => dal.Delete(id);
        // ✅ Cho phép nullable
        public List<SupplyHistoryDTO> Search(string supplyId, string itemId, string nurseId, int? roomId, string patientId)
        {
            return dal.Search(supplyId, itemId, nurseId, roomId, patientId);
        }

        public bool CheckItemExists(string patientId) => dal.IsItemExists(patientId);
        public bool CheckRoomExists(int roomId) => dal.IsRoomExists(roomId);
        public bool CheckNurseExists(string nurseId) => dal.IsNurseExists(nurseId);
        public List<DepartmentSupplyHistoryDTO> GetDepartments() => dal.GetDepartments();
        public List<StaffSupplyHistoryDTO> GetNursesByDepartment(string departmentId) => dal.GetNursesByDepartment(departmentId);
        public bool IsSupplyIdExists(string id) => dal.IsSupplyIdExists(id);
        public string GenerateNextSupplyId() => dal.GenerateNextSupplyId();
        public bool IsPatientExists(string patientId) => dal.IsPatientExists(patientId);
        public List<ItemSupplyHistoryDTO> GetAllItems()
        {
            return dal.GetAllItems();
        }
        public string GetDepartmentIdByNurseId(string nurseId)
        {
            return dal.GetDepartmentIdByNurseId(nurseId);
        }
        public List<RoomSupplyHistoryDTO> GetAllRooms() => dal.GetAllRooms();
        public List<PatientSupplyHistoryDTO> GetAllPatients() => dal.GetAllPatients();
        public List<SupplyHistoryDTO> GetPatientSupplyHistoryInSameDepartment(string doctorId) => dal.GetPatientSupplyHistoryInSameDepartment(doctorId);
        public void UpdateEditableFields(SupplyHistoryDTO dto)
        {
            dal.UpdateEditableFields(dto);
        }
        public List<SupplyHistoryDTO> SearchPatientSupplyHistoryByFilters(
               string doctorId, string patientId, int? roomId, string itemId)
        {
            return dal.SearchPatientSupplyHistoryByFilters(doctorId, patientId, roomId, itemId);
        }
        public List<SupplyHistoryDTO> GetPatientSupplyHistoryInSameDepartment(string doctorId, string patientId)
        {
            return dal.GetPatientSupplyHistoryInSameDepartment(doctorId, patientId);
        }
        public List<SupplyHistoryDTO> GetSupplyHistoryInSameDepartmentFromDate(string doctorId, DateTime fromDate)
        {
            return dal.GetSupplyHistoryInSameDepartmentFromDate(doctorId, fromDate);
        }
    }
}
