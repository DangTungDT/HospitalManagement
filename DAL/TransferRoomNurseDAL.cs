using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TransferRoomNurseDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        // Lấy phòng hiện tại của bệnh nhân
        public int? GetCurrentRoomId(string patientId)
        {
            var latest = db.RoomTransferHistories
                .Where(r => r.patientID == patientId)
                .OrderByDescending(r => r.transferDate)
                .FirstOrDefault();

            return latest?.toRoomID;
        }

        // Lấy danh sách phòng trong khoa của nhân viên
        public List<Room> GetRoomsInDepartment(string staffId)
        {
            var departmentId = db.Staffs
                .Where(s => s.id == staffId)
                .Select(s => s.departmentID)
                .FirstOrDefault();

            return db.Rooms
                .Where(r => r.departmentID == departmentId)
                .ToList();
        }

        // Thực hiện chuyển phòng
        public void TransferRoom(string patientId, int? fromRoomId, int toRoomId, string note)
        {
            var transfer = new RoomTransferHistory
            {
                patientID = patientId,
                fromRoomID = fromRoomId,
                toRoomID = toRoomId,
                transferDate = DateTime.Now,
                note = note
            };

            db.RoomTransferHistories.InsertOnSubmit(transfer);
            db.SubmitChanges();
        }
    }
}
