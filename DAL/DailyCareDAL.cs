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
        // Lấy tất cả chăm sóc của bệnh nhân cùng khoa với y tá đăng nhập
        public List<DailyCareDTO> GetDailyCaresByDepartment(string loggedInNurseId)
        {
            var departmentId = db.Staffs
                                 .Where(s => s.id == loggedInNurseId)
                                 .Select(s => s.departmentID)
                                 .FirstOrDefault();

            var query = from dc in db.DailyCares
                        join p in db.Patients on dc.patientID equals p.id
                        join s in db.Staffs on dc.nurseID equals s.id
                        join r in db.Rooms on dc.roomID equals r.id
                        where r.departmentID == departmentId
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

                            PatientName = p.fullName,
                            NurseName = s.name,
                            RoomName = r.roomName
                        };

            return query.ToList();
        }

        // Thêm chăm sóc, tự động gán y tá là người đăng nhập
        public void AddDailyCareByNurse(DailyCareDTO dto, string loggedInNurseId)
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
                nurseID = loggedInNurseId
            };
            db.DailyCares.InsertOnSubmit(dc);
            db.SubmitChanges();
        }

        // Sửa chăm sóc, chỉ sửa được bởi chính y tá đăng nhập
        public void UpdateDailyCareByNurse(DailyCareDTO dto, string loggedInNurseId)
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
                dc.nurseID = loggedInNurseId;
                db.SubmitChanges();
            }
        }

        // Tìm kiếm nhưng không lọc theo y tá, chỉ theo khoa
        public List<DailyCareDTO> SearchDailyCaresByDepartment(
            string loggedInNurseId,
            string patientId,
            string roomId,
            string shift)
        {
            var departmentId = db.Staffs
                                 .Where(s => s.id == loggedInNurseId)
                                 .Select(s => s.departmentID)
                                 .FirstOrDefault();

            var query = from dc in db.DailyCares
                        join p in db.Patients on dc.patientID equals p.id
                        join s in db.Staffs on dc.nurseID equals s.id
                        join r in db.Rooms on dc.roomID equals r.id
                        where r.departmentID == departmentId
                           && (string.IsNullOrEmpty(patientId) || dc.patientID.Contains(patientId))
                           && (string.IsNullOrEmpty(roomId) || dc.roomID.ToString().Contains(roomId))
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

                            PatientName = p.fullName,
                            NurseName = s.name,
                            RoomName = r.roomName
                        };

            return query.ToList();
        }
        public List<DailyCareDTO> GetDailyCaresByPatientId(string patientId)
        {
            var query = from dc in db.DailyCares
                        join p in db.Patients on dc.patientID equals p.id
                        join s in db.Staffs on dc.nurseID equals s.id into nurseJoin
                        from nurse in nurseJoin.DefaultIfEmpty()
                        join r in db.Rooms on dc.roomID equals r.id into roomJoin
                        from room in roomJoin.DefaultIfEmpty()
                        where dc.patientID.Trim() == patientId.Trim()
                        orderby dc.dateCare descending, dc.shift
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
                            PatientName = p.fullName,
                            NurseName = nurse.name,
                            RoomName = room.roomName
                        };

            return query.ToList();
        }
        public List<DailyCareDTO> GetDailyCaresInSameDepartmentAsDoctorAndDate(string doctorId, DateTime targetDate)
        {
            using (var db = new HospitalManagementDataContext())
            {
                // Lấy department của bác sĩ (nếu null => trả rỗng)
                var departmentId = db.Staffs
                                     .Where(doc => doc.id == doctorId)
                                     .Select(doc => doc.departmentID)
                                     .FirstOrDefault();

                if (departmentId == null)
                    return new List<DailyCareDTO>();

                var query = from dc in db.DailyCares
                            join p in db.Patients on dc.patientID equals p.id
                            join nurseJoin in db.Staffs on dc.nurseID equals nurseJoin.id into nurses
                            from s in nurses.DefaultIfEmpty()            // y tá có thể null
                            join roomJoin in db.Rooms on dc.roomID equals roomJoin.id into rooms
                            from r in rooms.DefaultIfEmpty()            // phòng có thể null
                            join d in db.Departments on r.departmentID equals d.id into depts
                            from dept in depts.DefaultIfEmpty()
                            where r.departmentID == departmentId
                                  && p.TypePatient == "Inpatient"
                                  && dc.dateCare >= targetDate
                            orderby dc.dateCare descending
                            select new DailyCareDTO
                            {
                                Id = dc.id,
                                Shift = dc.shift,
                                BloodPressure = dc.bloodPressure,
                                // xử lý kiểu nullable -> non-nullable với giá trị mặc định
                                BodyTempearature = dc.bodyTempearature ?? 0m,
                                PulseRate = dc.pulseRate ?? 0,
                                DateCare = dc.dateCare,
                                Note = dc.note,
                                PatientID = p.id,
                                RoomID = dc.roomID ?? 0,
                                NurseID = dc.nurseID,
                                NurseName = s != null ? s.name : null,
                                PatientName = p.fullName,
                                RoomName = r != null ? r.roomName : null
                            };

                return query.ToList();
            }
        }
    }
}
