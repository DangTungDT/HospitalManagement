using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        public List<Department> GetAllDepartments()
        {
            return db.Departments.ToList();
        }

        // Lấy danh sách phòng theo khoa (không cần staffId)
        public List<Room> GetRoomsByDepartment(string departmentId)
        {
            return db.Rooms
                .Where(r => r.departmentID == departmentId)
                .ToList();
        }

        // Kiểm tra bệnh nhân đã ở phòng đó chưa
        public bool IsPatientInRoom(string patientId, int roomId)
        {
            var currentRoomId = GetCurrentRoomId(patientId);
            return currentRoomId.HasValue && currentRoomId.Value == roomId;
        }

        // Nhận phòng lần đầu cho bệnh nhân
        public void AssignRoom(string patientId, int toRoomId, string note)
        {
            var transfer = new RoomTransferHistory
            {
                patientID = patientId,
                fromRoomID = null,
                toRoomID = toRoomId,
                transferDate = DateTime.Now,
                note = note
            };

            db.RoomTransferHistories.InsertOnSubmit(transfer);
            db.SubmitChanges();
        }
        // Lấy lịch sử nhận/chuyển phòng của bệnh nhân
        public List<RoomTransferHistoryDTO> GetAllRoomTransferHistory()
        {
            var query = from rth in db.RoomTransferHistories
                        join p in db.Patients on rth.patientID equals p.id
                        join fr in db.Rooms on rth.fromRoomID equals fr.id into frTemp
                        from fr in frTemp.DefaultIfEmpty()
                        join tr in db.Rooms on rth.toRoomID equals tr.id
                        join dept in db.Departments on tr.departmentID equals dept.id
                        orderby rth.transferDate descending
                        select new RoomTransferHistoryDTO
                        {
                            Id = rth.id,
                            PatientID = p.id,
                            PatientName = p.fullName,
                            FromRoomName = fr != null ? fr.roomName : "(Nhận mới)",
                            ToRoomName = tr.roomName,
                            DepartmentName = dept.departmentName,
                            TransferDate = rth.transferDate ?? DateTime.Now,
                            Note = rth.note
                        };

            return query.ToList();
        }

        public List<RoomTransferHistoryDTO> GetRoomTransferHistoryByPatient(string patientId)
        {
            var query = from rth in db.RoomTransferHistories
                        join p in db.Patients on rth.patientID equals p.id
                        join fr in db.Rooms on rth.fromRoomID equals fr.id into frTemp
                        from fr in frTemp.DefaultIfEmpty()
                        join tr in db.Rooms on rth.toRoomID equals tr.id
                        join dept in db.Departments on tr.departmentID equals dept.id
                        where rth.patientID == patientId
                        orderby rth.transferDate descending
                        select new RoomTransferHistoryDTO
                        {
                            Id = rth.id,
                            PatientID = p.id,
                            PatientName = p.fullName,
                            FromRoomName = fr != null ? fr.roomName : "(Nhận mới)",
                            ToRoomName = tr.roomName,
                            DepartmentName = dept.departmentName,
                            TransferDate = rth.transferDate ?? DateTime.Now,

                            Note = rth.note
                        };

            return query.ToList();
        }


        // Xóa 1 bản ghi lịch sử
        public void DeleteRoomTransferHistory(int id)
        {
            var history = db.RoomTransferHistories.FirstOrDefault(r => r.id == id);
            if (history != null)
            {
                db.RoomTransferHistories.DeleteOnSubmit(history);
                db.SubmitChanges();
            }
        }

        // Lấy danh sách bệnh nhân nội trú
        public List<PatientSupplyHistoryDTO> GetInpatients()
        {
            return db.Patients
                     .Where(p => p.TypePatient == "Inpatient")
                     .OrderBy(p => p.fullName)
                     .Select(p => new PatientSupplyHistoryDTO
                     {
                         Id = p.id.Trim(),
                         FullName = p.fullName.Trim(),
                         Gender = p.gender,
                         Dob = p.dob,
                         PhoneNumber = p.phoneNumber,
                         Status = p.status
                     })
                     .ToList();
        }
        // Lấy bản ghi mới nhất của bệnh nhân
        public RoomTransferHistory GetLatestRoomTransferByPatient(string patientId)
        {
            return db.RoomTransferHistories
                     .Where(r => r.patientID == patientId)
                     .OrderByDescending(r => r.transferDate)
                     .FirstOrDefault();
        }

        // Lấy bản ghi trước bản ghi mới nhất của bệnh nhân
        public RoomTransferHistory GetPreviousRoomTransferByPatient(string patientId)
        {
            return db.RoomTransferHistories
                     .Where(r => r.patientID == patientId)
                     .OrderByDescending(r => r.transferDate)
                     .Skip(1) // bỏ bản ghi mới nhất
                     .FirstOrDefault();
        }
        public string GetDepartmentIdOfPatient(string patientId)
        {
            var lastTransfer = db.RoomTransferHistories
                .Where(r => r.patientID == patientId)
                .OrderByDescending(r => r.transferDate)
                .FirstOrDefault();

            if (lastTransfer == null) return null;

            return db.Rooms
                .Where(r => r.id == lastTransfer.toRoomID)
                .Select(r => r.departmentID) // string
                .FirstOrDefault();
        }

        public List<Room> GetRoomsByDepartmentId(string deptId)
        {
            return db.Rooms
                .Where(r => r.departmentID == deptId)
                .ToList();
        }
        public List<RoomTransferHistoryDTO> SearchTransfers(string patientId, int? roomId)
        {
            var query = from rth in db.RoomTransferHistories
                        join p in db.Patients on rth.patientID equals p.id
                        join fr in db.Rooms on rth.fromRoomID equals fr.id into frTemp
                        from fr in frTemp.DefaultIfEmpty()
                        join tr in db.Rooms on rth.toRoomID equals tr.id
                        join dept in db.Departments on tr.departmentID equals dept.id
                        where (string.IsNullOrEmpty(patientId) || p.id == patientId)
                              && (!roomId.HasValue || rth.toRoomID == roomId.Value || rth.fromRoomID == roomId.Value)
                        orderby rth.transferDate descending
                        select new RoomTransferHistoryDTO
                        {
                            Id = rth.id,
                            PatientID = p.id,
                            PatientName = p.fullName,
                            FromRoomName = fr != null ? fr.roomName : "(Nhận mới)",
                            ToRoomName = tr.roomName,
                            DepartmentName = dept.departmentName,
                            TransferDate = rth.transferDate ?? DateTime.Now,
                            Note = rth.note
                        };

            return query.ToList();
        }
    }
}
