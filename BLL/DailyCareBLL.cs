using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DailyCareBLL
    {
        private DailyCareDAL dal = new DailyCareDAL();

        public List<DailyCareDTO> GetAll() => dal.GetAll();

        public void Add(DailyCareDTO dto)
        {
            // Validate here if needed
            dal.Add(dto);
        }

        public void Update(DailyCareDTO dto)
        {
            // Business rules if any
            dal.Update(dto);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }
        public List<DailyCareDTO> Search(string patientId, string roomId, string nurseId, string shift)
        {
            return dal.Search(patientId, roomId, nurseId, shift);
        }
        public bool CheckPatientExists(string patientId) => dal.IsPatientExists(patientId);
        public bool CheckRoomExists(int roomId) => dal.IsRoomExists(roomId);
        public bool CheckNurseExists(string nurseId) => dal.IsNurseExists(nurseId);
        public List<DepartmentSupplyHistoryDTO> GetDepartments() => dal.GetDepartments();
        public List<StaffSupplyHistoryDTO> GetNursesByDepartment(string departmentId) => dal.GetNursesByDepartment(departmentId);
        public List<StaffSupplyHistoryDTO> GetAllNurses() => dal.GetAllNurses();
        public List<RoomSupplyHistoryDTO> GetAllRooms() => dal.GetAllRooms();
        public List<PatientSupplyHistoryDTO> GetAllPatients() => dal.GetAllPatients();

    }
}
