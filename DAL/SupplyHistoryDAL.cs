using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SupplyHistoryDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<SupplyHistoryDTO> GetAll()
        {
            var query = from s in db.SupplyHistories
                        join item in db.Items on s.itemID equals item.ID
                        join staff in db.Staffs on s.nurseID equals staff.id
                        join room in db.Rooms on s.roomID equals room.id
                        join patient in db.Patients on s.PatientID equals patient.id into pj
                        from patient in pj.DefaultIfEmpty()
                        select new SupplyHistoryDTO
                        {
                            Id = s.id,
                            ItemID = s.itemID,
                            RoomID = s.roomID,
                            NurseID = s.nurseID,
                            Dosage = s.dosage,
                            Quantity = s.quantity ?? 0,
                            Unit = s.unit,
                            Note = s.note,
                            PatientID = s.PatientID,
                            TypeSupply = s.typeSupply,
                            DateSupply = s.dateSupply,

                            ItemName = item.ItemName,
                            NurseName = staff.name,
                            RoomName = room.roomName,
                            PatientName = patient != null ? patient.fullName : "" // ✅ FIXED
                        };

            return query.ToList();
        }


        public void Add(SupplyHistoryDTO dto)
        {
            var s = new SupplyHistory
            {
                id = dto.Id,
                itemID = dto.ItemID,
                roomID = dto.RoomID,
                nurseID = dto.NurseID,
                dosage = dto.Dosage,
                quantity = dto.Quantity,
                unit = dto.Unit,
                note = dto.Note,
                PatientID = dto.PatientID,
                typeSupply = dto.TypeSupply,
                dateSupply = dto.DateSupply
            };

            db.SupplyHistories.InsertOnSubmit(s);
            db.SubmitChanges();
        }

        public void Update(SupplyHistoryDTO dto)
        {
            var s = db.SupplyHistories.FirstOrDefault(x => x.id == dto.Id);
            if (s != null)
            {
                s.itemID = dto.ItemID;
                s.roomID = dto.RoomID;
                s.nurseID = dto.NurseID;
                s.dosage = dto.Dosage;
                s.quantity = dto.Quantity;
                s.unit = dto.Unit;
                s.note = dto.Note;
                s.PatientID = dto.PatientID;
                s.typeSupply = dto.TypeSupply;
                s.dateSupply = dto.DateSupply;

                db.SubmitChanges();
            }
        }
        public void UpdateEditableFields(SupplyHistoryDTO dto)
        {
            var s = db.SupplyHistories.FirstOrDefault(x => x.id == dto.Id);
            if (s != null)
            {
                // Chỉ update các trường được phép sửa
                s.dosage = dto.Dosage;
                s.quantity = dto.Quantity;
                s.unit = dto.Unit;
                s.note = dto.Note;
                s.dateSupply = dto.DateSupply;

                db.SubmitChanges();
            }
        }


        public void Delete(string id)
        {
            var s = db.SupplyHistories.FirstOrDefault(x => x.id == id);
            if (s != null)
            {
                db.SupplyHistories.DeleteOnSubmit(s);
                db.SubmitChanges();
            }
        }
        public List<SupplyHistoryDTO> Search(string supplyId, string itemId, string nurseId, int? roomId, string patientId)
        {
            var query = from s in db.SupplyHistories
                        join item in db.Items on s.itemID equals item.ID
                        join staff in db.Staffs on s.nurseID equals staff.id
                        join room in db.Rooms on s.roomID equals room.id
                        join patient in db.Patients on s.PatientID equals patient.id into pj
                        from patient in pj.DefaultIfEmpty()
                        select new { s, item, staff, room, patient };

            if (!string.IsNullOrWhiteSpace(supplyId))
                query = query.Where(x => x.s.id.Contains(supplyId));

            if (!string.IsNullOrWhiteSpace(itemId))
                query = query.Where(x => x.s.itemID.Contains(itemId));

            if (!string.IsNullOrWhiteSpace(nurseId))
                query = query.Where(x => x.s.nurseID.Contains(nurseId));

            if (roomId.HasValue)
                query = query.Where(x => x.s.roomID == roomId.Value);

            if (!string.IsNullOrWhiteSpace(patientId))
                query = query.Where(x => x.s.PatientID != null && x.s.PatientID.Contains(patientId));

            return query.Select(x => new SupplyHistoryDTO
            {
                Id = x.s.id,
                ItemID = x.s.itemID,
                RoomID = x.s.roomID,
                NurseID = x.s.nurseID,
                Dosage = x.s.dosage,
                Quantity = x.s.quantity ?? 0,
                Unit = x.s.unit,
                Note = x.s.note,
                PatientID = x.s.PatientID,
                TypeSupply = x.s.typeSupply,
                DateSupply = x.s.dateSupply,
                ItemName = x.item.ItemName,
                NurseName = x.staff.name,
                RoomName = x.room.roomName,
                PatientName = x.patient != null ? x.patient.fullName : "" // ✅ FIXED
            }).ToList();
        }


        public bool IsSupplyIdExists(string id)
        {
            return db.SupplyHistories.Any(s => s.id == id);
        }
        public string GenerateNextSupplyId()
        {
            var maxId = db.SupplyHistories
                .Where(s => s.id.StartsWith("SH"))
                .Select(s => s.id)
                .OrderByDescending(id => id)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(maxId))
                return "SH001";

            // Cắt bỏ 2 ký tự đầu "SH"
            string numericPart = maxId.Substring(2);

            if (int.TryParse(numericPart, out int number))
                return $"SH{(number + 1):D3}";

            return "SH001";
        }


        public bool IsItemExists(string itemID)
        {
            return db.Items.Any(p => p.ID == itemID);
        }

        public bool IsRoomExists(int roomId)
        {
            return db.Rooms.Any(r => r.id == roomId);
        }

        public bool IsNurseExists(string nurseId)
        {
            return db.Staffs.Any(s => s.id == nurseId && s.role.ToLower().Contains("y tá"));
        }
        // ✅ Thêm hàm lấy danh sách khoa
        public List<DepartmentSupplyHistoryDTO> GetDepartments()
        {
            return db.Departments.Select(d => new DepartmentSupplyHistoryDTO
            {
                Id = d.id,
                DepartmentName = d.departmentName
            }).ToList();
        }
        public bool IsPatientExists(string patientId) =>
             db.Patients.Any(p => p.id == patientId);
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
        public List<ItemSupplyHistoryDTO> GetAllItems()
        {
            return db.Items
                     .Where(i => i.IsActive)
                     .Select(i => new ItemSupplyHistoryDTO
                     {
                         ID = i.ID,
                         ItemName = i.ItemName
                     }).ToList();
        }
        public string GetDepartmentIdByNurseId(string nurseId)
        {
            return db.Staffs.FirstOrDefault(s => s.id == nurseId)?.departmentID;
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
        public List<SupplyHistoryDTO> GetPatientSupplyHistoryInSameDepartment(string doctorId)
        {
            // Lấy departmentID của bác sĩ
            var departmentId = db.Staffs
                .Where(st => st.id == doctorId)
                .Select(st => st.departmentID)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(departmentId))
                return new List<SupplyHistoryDTO>();

            var query = from sh in db.SupplyHistories
                        join p in db.Patients on sh.PatientID equals p.id into patientJoin
                        from p in patientJoin.DefaultIfEmpty()
                        join r in db.Rooms on sh.roomID equals r.id
                        join n in db.Staffs on sh.nurseID equals n.id
                        join i in db.Items on sh.itemID equals i.ID
                        where sh.typeSupply == "Patient"
                              && r.departmentID == departmentId
                              && sh.PatientID != null
                        orderby sh.dateSupply descending
                        select new SupplyHistoryDTO
                        {
                            Id = sh.id,
                            ItemID = sh.itemID,
                            RoomID = sh.roomID,
                            NurseID = sh.nurseID,
                            Dosage = sh.dosage,
                            Quantity = sh.quantity ?? 0,
                            Unit = sh.unit,
                            Note = sh.note,
                            PatientID = sh.PatientID,
                            TypeSupply = sh.typeSupply,
                            DateSupply = sh.dateSupply,

                            // Thông tin mô tả
                            ItemName = i.ItemName,
                            NurseName = n.name,
                            RoomName = r.roomName,
                            PatientName = p != null ? p.fullName : null
                        };

            return query.ToList();
        }
        public List<SupplyHistoryDTO> SearchPatientSupplyHistoryByFilters(
            string doctorId, string patientId, int? roomId, string itemId)
        {
            // Lấy departmentID của bác sĩ
            var departmentId = db.Staffs
                .Where(st => st.id == doctorId)
                .Select(st => st.departmentID)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(departmentId))
                return new List<SupplyHistoryDTO>();

            // Query cơ bản
            var query = from sh in db.SupplyHistories
                        join p in db.Patients on sh.PatientID equals p.id into patientJoin
                        from p in patientJoin.DefaultIfEmpty()
                        join r in db.Rooms on sh.roomID equals r.id
                        join n in db.Staffs on sh.nurseID equals n.id
                        join i in db.Items on sh.itemID equals i.ID
                        where sh.typeSupply == "Patient"
                              && r.departmentID == departmentId
                              && sh.PatientID != null
                        select new { sh, p, r, n, i };

            // Lọc theo bệnh nhân nếu có chọn
            if (!string.IsNullOrWhiteSpace(patientId))
                query = query.Where(x => x.sh.PatientID == patientId);

            // Lọc theo phòng nếu có chọn
            if (roomId.HasValue)
                query = query.Where(x => x.sh.roomID == roomId.Value);

            // Lọc theo thuốc nếu có chọn
            if (!string.IsNullOrWhiteSpace(itemId))
                query = query.Where(x => x.sh.itemID == itemId);

            // Trả kết quả
            return query
                .OrderByDescending(x => x.sh.dateSupply)
                .Select(x => new SupplyHistoryDTO
                {
                    Id = x.sh.id,
                    ItemID = x.sh.itemID,
                    RoomID = x.sh.roomID,
                    NurseID = x.sh.nurseID,
                    Dosage = x.sh.dosage,
                    Quantity = x.sh.quantity ?? 0,
                    Unit = x.sh.unit,
                    Note = x.sh.note,
                    PatientID = x.sh.PatientID,
                    TypeSupply = x.sh.typeSupply,
                    DateSupply = x.sh.dateSupply,

                    ItemName = x.i.ItemName,
                    NurseName = x.n.name,
                    RoomName = x.r.roomName,
                    PatientName = x.p != null ? x.p.fullName : null
                }).ToList();
        }
        public List<SupplyHistoryDTO> GetPatientSupplyHistoryInSameDepartment(string doctorId, string patientId)
        {
            // Lấy departmentId của bác sĩ
            var departmentId = db.Staffs
                                 .Where(s => s.id == doctorId)
                                 .Select(s => s.departmentID)
                                 .FirstOrDefault();

            // Nếu không tìm thấy khoa thì trả về list rỗng
            if (string.IsNullOrEmpty(departmentId))
                return new List<SupplyHistoryDTO>();

            var query = from sh in db.SupplyHistories
                        join i in db.Items on sh.itemID equals i.ID
                        join r in db.Rooms on sh.roomID equals r.id
                        join d in db.Departments on r.departmentID equals d.id
                        join n in db.Staffs on sh.nurseID equals n.id
                        join p in db.Patients on sh.PatientID equals p.id into pp
                        from p in pp.DefaultIfEmpty() // LEFT JOIN
                        where sh.typeSupply == "Patient"
                              && sh.PatientID == patientId
                              && r.departmentID == departmentId
                        orderby sh.dateSupply descending
                        select new SupplyHistoryDTO
                        {
                            Id = sh.id,
                            ItemID = sh.itemID,
                            RoomID = sh.roomID, // int
                            NurseID = sh.nurseID,
                            Dosage = sh.dosage,
                            Quantity = sh.quantity ?? 0,
                            Unit = sh.unit,
                            Note = sh.note,
                            PatientID = sh.PatientID,
                            TypeSupply = sh.typeSupply,
                            DateSupply = sh.dateSupply,

                            // Thông tin mô tả
                            ItemName = i.ItemName,
                            NurseName = n.name,
                            RoomName = r.roomName,
                            PatientName = p != null ? p.fullName : null
                        };

            return query.ToList();
        }
        public List<SupplyHistoryDTO> GetSupplyHistoryInSameDepartmentFromDate(string doctorId, DateTime fromDate)
        {
            // Lấy department của bác sĩ
            var departmentId = db.Staffs
                                 .Where(s => s.id == doctorId)
                                 .Select(s => s.departmentID)
                                 .FirstOrDefault();

            if (string.IsNullOrEmpty(departmentId))
                return new List<SupplyHistoryDTO>();

            var query = from sh in db.SupplyHistories
                        join i in db.Items on sh.itemID equals i.ID
                        join r in db.Rooms on sh.roomID equals r.id
                        join d in db.Departments on r.departmentID equals d.id
                        join n in db.Staffs on sh.nurseID equals n.id
                        join p in db.Patients on sh.PatientID equals p.id into pj
                        from p in pj.DefaultIfEmpty()
                        where sh.typeSupply == "Patient"
                              && r.departmentID == departmentId
                              && sh.dateSupply >= fromDate
                              && sh.PatientID != null
                        orderby sh.dateSupply descending
                        select new SupplyHistoryDTO
                        {
                            Id = sh.id,
                            ItemID = sh.itemID,
                            RoomID = sh.roomID,
                            NurseID = sh.nurseID,
                            Dosage = sh.dosage,
                            Quantity = sh.quantity ?? 0,
                            Unit = sh.unit,
                            Note = sh.note,
                            PatientID = sh.PatientID,
                            TypeSupply = sh.typeSupply,
                            DateSupply = sh.dateSupply,

                            // Thông tin mô tả
                            ItemName = i.ItemName,
                            NurseName = n.name,
                            RoomName = r.roomName,
                            PatientName = p != null ? p.fullName : null
                        };

            return query.ToList();
        }
    }
}



