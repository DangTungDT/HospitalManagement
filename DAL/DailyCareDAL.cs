using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DailyCareDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<DailyCareDTO> GetAll()
        {
            var query = from dc in db.DailyCares
                        join p in db.Patients on dc.patientID equals p.id
                        join s in db.Staffs on dc.nurseID equals s.id
                        join r in db.Rooms on dc.roomID equals r.id
                        select new DailyCareDTO
                        {
                            Id = dc.id,
                            Shift = dc.shift,
                            BloodPressure = dc.bloodPressure,
                            BodyTempearature = dc.bodyTempearature ?? 0,
                            PulseRate = dc.pulseRate ?? 0,
                            DateCare = dc.dateCare,
                            Note = dc.note,
                            PatientID = dc.patientID,
                            RoomID = dc.roomID ?? 0,
                            NurseID = dc.nurseID,

                            // 👇 Thông tin mô tả
                            PatientName = p.fullName,
                            NurseName = s.name,
                            RoomName = r.roomName
                        };

            return query.ToList();
        }


        public void Add(DailyCareDTO dto)
        {
            var dc = new DailyCare
            {
                shift = dto.Shift,
                bloodPressure = dto.BloodPressure,
                bodyTempearature = dto.BodyTempearature,
                pulseRate = dto.PulseRate,
                dateCare = dto.DateCare ?? DateTime.Now,
                note = dto.Note,
                patientID = dto.PatientID,
                roomID = dto.RoomID,
                nurseID = dto.NurseID
            };
            db.DailyCares.InsertOnSubmit(dc);
            db.SubmitChanges();
        }

        public void Update(DailyCareDTO dto)
        {
            var dc = db.DailyCares.FirstOrDefault(x => x.id == dto.Id);
            if (dc != null)
            {
                dc.shift = dto.Shift;
                dc.bloodPressure = dto.BloodPressure;
                dc.bodyTempearature = dto.BodyTempearature;
                dc.pulseRate = dto.PulseRate;
                dc.dateCare = dto.DateCare ?? DateTime.Now;
                dc.note = dto.Note;
                dc.roomID = dto.RoomID;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            var dc = db.DailyCares.FirstOrDefault(x => x.id == id);
            if (dc != null)
            {
                db.DailyCares.DeleteOnSubmit(dc);
                db.SubmitChanges();
            }
        }

        public List<DailyCareDTO> Search(string patientId, string roomId, string nurseId, string shift)
        {
            var query = from dc in db.DailyCares
                        join p in db.Patients on dc.patientID equals p.id
                        join s in db.Staffs on dc.nurseID equals s.id
                        join r in db.Rooms on dc.roomID equals r.id
                        where (string.IsNullOrEmpty(patientId) || dc.patientID.Contains(patientId))
                           && (string.IsNullOrEmpty(roomId) || dc.roomID.ToString().Contains(roomId))
                           && (string.IsNullOrEmpty(nurseId) || dc.nurseID.Contains(nurseId))
                           && (string.IsNullOrEmpty(shift) || dc.shift.Contains(shift))
                        select new DailyCareDTO
                        {
                            Id = dc.id,
                            Shift = dc.shift,
                            BloodPressure = dc.bloodPressure,
                            BodyTempearature = dc.bodyTempearature ?? 0,
                            PulseRate = dc.pulseRate ?? 0,
                            DateCare = dc.dateCare,
                            Note = dc.note,
                            PatientID = dc.patientID,
                            RoomID = dc.roomID ?? 0,
                            NurseID = dc.nurseID,

                            // 👇 Thông tin mô tả
                            PatientName = p.fullName,
                            NurseName = s.name,
                            RoomName = r.roomName
                        };

            return query.ToList();
        }

        // Kiểm tra tồn tại các thực thể liên quan
        public bool IsPatientExists(string patientId) =>
            db.Patients.Any(p => p.id == patientId);

        public bool IsRoomExists(int roomId) =>
            db.Rooms.Any(r => r.id == roomId);

        public bool IsNurseExists(string nurseId) =>
            db.Staffs.Any(s => s.id == nurseId && s.role.ToLower().Contains("y tá"));
        // ✅ Thêm hàm lấy danh sách khoa
        public List<DepartmentSupplyHistoryDTO> GetDepartments()
        {
            return db.Departments.Select(d => new DepartmentSupplyHistoryDTO
            {
                Id = d.id,
                DepartmentName = d.departmentName
            }).ToList();
        }

        // ✅ Thêm hàm lấy danh sách y tá theo khoa
        public List<StaffSupplyHistoryDTO> GetNursesByDepartment(string departmentId)
        {
            return db.Staffs
                     .Where(s => s.departmentID == departmentId && s.role.ToLower().Contains("y tá"))
                     .Select(s => new StaffSupplyHistoryDTO
                     {
                         Id = s.id,
                         Name = s.name
                     }).ToList();
        }
        public List<StaffSupplyHistoryDTO> GetAllNurses()
        {
            return db.Staffs
                .Where(s => s.role.ToLower().Contains("y tá"))
                .Select(s => new StaffSupplyHistoryDTO
                {
                    Id = s.id,
                    Name = s.name,
                    DepartmentID = s.departmentID.ToString()
                }).ToList();
        }
        // ✅ Trả danh sách phòng cho combobox (id + name)
        public List<RoomSupplyHistoryDTO> GetAllRooms()
        {
            return db.Rooms.Select(r => new RoomSupplyHistoryDTO
            {
                Id = r.id,
                RoomName = r.roomName
            }).ToList();
        }

        // ✅ Trả danh sách bệnh nhân cho combobox (id + name)
        public List<PatientSupplyHistoryDTO> GetAllPatients()
        {
            return db.Patients.Select(p => new PatientSupplyHistoryDTO
            {
                Id = p.id.Trim(),
                FullName = p.fullName.Trim(),
                Gender = p.gender,
                Dob = p.dob,
                PhoneNumber = p.phoneNumber,
                Status = p.status
            }).ToList();
        }
    }
}
