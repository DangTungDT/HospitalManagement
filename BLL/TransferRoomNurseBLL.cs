using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TransferRoomNurseBLL
    {
        TransferRoomNurseDAL dal = new TransferRoomNurseDAL();

        public int? GetCurrentRoomId(string patientId) => dal.GetCurrentRoomId(patientId);

        public List<Room> GetRoomsInDepartment(string staffId) => dal.GetRoomsInDepartment(staffId);

        public void TransferRoom(string patientId, int? fromRoomId, int toRoomId, string note)
        {
            dal.TransferRoom(patientId, fromRoomId, toRoomId, note);
        }
        public List<Department> GetAllDepartments()
        {
            return dal.GetAllDepartments();
        }

        // Lấy danh sách phòng theo khoa
        public List<Room> GetRoomsByDepartment(string departmentId)
        {
            return dal.GetRoomsByDepartment(departmentId);
        }


        // Kiểm tra bệnh nhân đã ở phòng đó chưa
        public bool IsPatientInRoom(string patientId, int roomId)
        {
            return dal.IsPatientInRoom(patientId, roomId);
        }

        // Nhận phòng lần đầu
        public void AssignRoom(string patientId, int toRoomId, string note)
        {
            if (dal.IsPatientInRoom(patientId, toRoomId))
                throw new Exception("Bệnh nhân đã ở phòng này, không thể nhận phòng trùng!");

            dal.AssignRoom(patientId, toRoomId, note);
        }
        public List<RoomTransferHistoryDTO> GetAllRoomTransferHistory()
        {
            return dal.GetAllRoomTransferHistory();
        }
        public void DeleteRoomTransferHistory(int id)
        {
            dal.DeleteRoomTransferHistory(id);
        }

        public List<RoomTransferHistoryDTO> GetRoomTransferHistoryByPatient(string patientId)
        {
            return dal.GetRoomTransferHistoryByPatient(patientId);
        }
        public List<PatientSupplyHistoryDTO> GetInpatients()
        {
            return dal.GetInpatients();
        }
        public RoomTransferHistory GetLatestRoomTransferByPatient(string patientId)
        {
            return dal.GetLatestRoomTransferByPatient(patientId);
        }

        public RoomTransferHistory GetPreviousRoomTransferByPatient(string patientId)
        {
            return dal.GetPreviousRoomTransferByPatient(patientId);
        }
        // Lấy khoa hiện tại của bệnh nhân
        public string GetDepartmentIdOfPatient(string patientId)
        {
            return dal.GetDepartmentIdOfPatient(patientId);
        }

        // Lấy danh sách phòng theo khoa
        public List<Room> GetRoomsByDepartmentId(string deptId)
        {
            return dal.GetRoomsByDepartmentId(deptId);
        }
        public bool TransferRoom(string patientId, int toRoomId, string note)
        {
            if (string.IsNullOrWhiteSpace(patientId))
                throw new ArgumentException("Vui lòng chọn bệnh nhân trước khi chuyển phòng.");

            if (toRoomId <= 0)
                throw new ArgumentException("Vui lòng chọn phòng mới.");

            int? currentRoomId = dal.GetCurrentRoomId(patientId);

            if (currentRoomId.HasValue && currentRoomId.Value == toRoomId)
                throw new InvalidOperationException("Bệnh nhân đã ở trong phòng này.");

            dal.TransferRoom(patientId, currentRoomId, toRoomId, note);
            return true;
        }
        public List<RoomTransferHistoryDTO> SearchTransfers(string patientId, int? roomId)
        {
            if (string.IsNullOrEmpty(patientId) && !roomId.HasValue)
                throw new ArgumentException("Vui lòng chọn ít nhất 1 tiêu chí tìm kiếm (bệnh nhân hoặc phòng).");

            var result = dal.SearchTransfers(patientId, roomId);

            if (result.Count == 0)
                throw new Exception("Không tìm thấy dữ liệu phù hợp với tiêu chí.");

            return result;
        }
    }
}
