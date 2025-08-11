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
        // Lấy tất cả chăm sóc theo khoa của y tá đăng nhập
        public List<DailyCareDTO> GetDailyCaresByDepartment(string loggedInNurseId)
        {
            return dal.GetDailyCaresByDepartment(loggedInNurseId);
        }

        // Tìm kiếm theo khoa, không lọc theo y tá
        public List<DailyCareDTO> SearchDailyCaresByDepartment(string loggedInNurseId, string patientId, string roomId, string shift)
        {
            return dal.SearchDailyCaresByDepartment(loggedInNurseId, patientId, roomId, shift);
        }

        // Thêm chăm sóc dựa vào y tá đăng nhập
        public bool AddDailyCareByNurse(DailyCareDTO dto, string loggedInNurseId)
        {
            try
            {
                dal.AddDailyCareByNurse(dto, loggedInNurseId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Sửa chăm sóc dựa vào y tá đăng nhập
        public bool UpdateDailyCareByNurse(DailyCareDTO dto, string loggedInNurseId)
        {
            try
            {
                dal.UpdateDailyCareByNurse(dto, loggedInNurseId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DailyCareDTO> SearchByPatientAndRoom(string loggedInNurseId, string patientName, string roomName, string shift)
        {
            return dal.SearchDailyCaresByDepartment(loggedInNurseId, patientName, roomName, shift);
        }
        public List<DailyCareDTO> GetDailyCaresByPatient(string patientId)
        {
            return dal.GetDailyCaresByPatientId(patientId);
        }
        public List<DailyCareDTO> GetDailyCaresInSameDepartmentAsDoctorAndDate(string doctorId, DateTime targetDate)
        {
            return dal.GetDailyCaresInSameDepartmentAsDoctorAndDate(doctorId, targetDate);
        }

    }
}
