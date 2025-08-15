using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicalOrderDoctorDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<MedicalOrderDoctorDTO> GetMedicalOrdersByDoctor(string doctorId)
        {
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join d in db.Staffs on mo.DoctorID equals d.id
                        join tt in db.LabTestTypes on mo.TestTypeID equals tt.id into testJoin
                        from tt in testJoin.DefaultIfEmpty()
                        where mo.DoctorID == doctorId
                        select new MedicalOrderDoctorDTO
                        {
                            Id = mo.id,
                            PatientID = mo.PatientID,
                            DoctorID = mo.DoctorID,
                            OrderType = mo.OrderType,
                            ItemID = mo.ItemID,
                            TestTypeID = mo.TestTypeID,
                            HasLabTest = mo.HasLabTest,
                            Dosage = mo.Dosage,
                            Quantity = mo.Quantity,
                            Unit = mo.Unit,
                            Frequency = mo.Frequency,
                            StartDate = mo.StartDate,
                            EndDate = mo.EndDate,
                            Status = mo.Status,
                            CreatedAt = mo.CreatedAt,
                            SignedAt = mo.SignedAt,
                            Note = mo.Note,
                            PatientName = p.fullName,
                            DoctorName = d.name,
                            TestTypeName = tt != null ? tt.testTypeName : null
                        };

            return query.ToList();
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
        public List<MedicalOrderDoctorDTO> SearchMedicalOrders(string doctorId, string patientName)
        {
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join d in db.Staffs on mo.DoctorID equals d.id
                        where mo.DoctorID == doctorId && p.fullName.Contains(patientName)
                        select new MedicalOrderDoctorDTO
                        {
                            Id = mo.id,
                            PatientID = mo.PatientID,
                            DoctorID = mo.DoctorID,
                            OrderType = mo.OrderType,
                            ItemID = mo.ItemID,
                            TestTypeID = mo.TestTypeID,
                            Dosage = mo.Dosage,
                            Quantity = mo.Quantity,
                            Unit = mo.Unit,
                            Frequency = mo.Frequency,
                            StartDate = mo.StartDate,
                            EndDate = mo.EndDate,
                            Status = mo.Status,
                            CreatedAt = mo.CreatedAt,
                            SignedAt = mo.SignedAt,
                            Note = mo.Note,
                            PatientName = p.fullName,
                            DoctorName = d.name
                        };

            return query.ToList();
        }

        public void AddMedicalOrder(MedicalOrderDoctorDTO dto)
        {
            var order = new MedicalOrder
            {
                PatientID = dto.PatientID,
                DoctorID = dto.DoctorID,
                OrderType = dto.OrderType,
                ItemID = dto.ItemID,
                TestTypeID = dto.TestTypeID,
                HasLabTest = dto.HasLabTest ?? false,
                Dosage = dto.Dosage,
                Quantity = dto.Quantity,
                Unit = dto.Unit,
                Frequency = dto.Frequency,
                StartDate = dto.StartDate ?? DateTime.Today,
                EndDate = dto.EndDate,
                Status = "Active",
                CreatedAt = DateTime.Now,
                SignedAt = dto.SignedAt,
                Note = dto.Note,
            };

            db.MedicalOrders.InsertOnSubmit(order);
            db.SubmitChanges();
        }

        public void UpdateMedicalOrder(MedicalOrderDoctorDTO dto)
        {
            var order = db.MedicalOrders.FirstOrDefault(m => m.id == dto.Id);
            if (order != null)
            {
                order.OrderType = dto.OrderType;
                order.ItemID = dto.ItemID;
                order.TestTypeID = dto.TestTypeID;
                order.HasLabTest = dto.HasLabTest ?? false;
                order.Dosage = dto.Dosage;
                order.Quantity = dto.Quantity;
                order.Unit = dto.Unit;
                order.Frequency = dto.Frequency;
                order.StartDate = dto.StartDate ?? order.StartDate;
                order.EndDate = dto.EndDate;
                order.Note = dto.Note;
                db.SubmitChanges();
            }
        }
        public bool CheckTestTypeIDExists(int testTypeId)
        {
            return db.LaboratoryTests.Any(t => t.id == testTypeId);
        }

        public List<PatientSupplyHistoryDTO> GetAllPatients(string doctorId)
        {
            var query = from dp in db.DoctorPatients
                        join p in db.Patients on dp.patientID equals p.id
                        where dp.doctorID == doctorId
                        select new PatientSupplyHistoryDTO
                        {
                            Id = p.id.Trim(),
                            FullName = p.fullName.Trim(),
                            Gender = p.gender,
                            Dob = p.dob,
                            PhoneNumber = p.phoneNumber,
                            Status = p.status
                        };

            return query.Distinct().ToList();
        }
        public List<LabTestTypeDocTorDTO> GetAllLabTestTypes()
        {
            return db.LabTestTypes.Select(t => new LabTestTypeDocTorDTO
            {
                Id = t.id,
                TestTypeName = t.testTypeName
            }).ToList();
        }
        public List<PatientSupplyHistoryDTO> GetPatientsByDoctorDepartment(string doctorId)
        {
            var departmentId = db.Staffs
                .Where(s => s.id == doctorId)
                .Select(s => s.departmentID)
                .FirstOrDefault();

            if (departmentId == null) return new List<PatientSupplyHistoryDTO>();

            // Lấy tất cả các lần chuyển phòng thuộc khoa của bác sĩ
            var validTransfers = from t in db.RoomTransferHistories
                                 join r in db.Rooms on t.toRoomID equals r.id
                                 where r.departmentID == departmentId
                                 select new { Transfer = t, Room = r };

            // Lấy lần chuyển mới nhất cho mỗi bệnh nhân
            var latestTransfers = validTransfers
                .GroupBy(x => x.Transfer.patientID)
                .Select(g => g.OrderByDescending(x => x.Transfer.transferDate).FirstOrDefault());

            // Join lại với bệnh nhân và lọc loại "Inpatient"
            var query = from lt in latestTransfers
                        join p in db.Patients on lt.Transfer.patientID equals p.id
                        where p.TypePatient == "Inpatient" // ✅ CHỈ bệnh nhân nội trú
                        select new PatientSupplyHistoryDTO
                        {
                            Id = p.id.Trim(),
                            FullName = p.fullName.Trim(),
                            Gender = p.gender,
                            Dob = p.dob,
                            PhoneNumber = p.phoneNumber,
                            Status = p.status
                        };

            return query.ToList();
        }
        public List<MedicalOrderDoctorDTO> SearchMedicalOrdersByDoctorDepartment(string doctorId, string orderType, string patientName)
        {
            var departmentId = db.Staffs
                                 .Where(s => s.id == doctorId)
                                 .Select(s => s.departmentID)
                                 .FirstOrDefault();

            if (departmentId == null) return new List<MedicalOrderDoctorDTO>();

            // Tìm bệnh nhân có lần chuyển phòng gần nhất trong khoa đó
            var validTransfers = from t in db.RoomTransferHistories
                                 join r in db.Rooms on t.toRoomID equals r.id
                                 where r.departmentID == departmentId
                                 select new { t.patientID, t.transferDate };

            var latestTransfers = validTransfers
                .GroupBy(x => x.patientID)
                .Select(g => g.OrderByDescending(x => x.transferDate).FirstOrDefault());

            // Join với MedicalOrder và Patients (bỏ Items)
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join lt in latestTransfers on p.id equals lt.patientID
                        where p.TypePatient == "Inpatient" &&
                              (string.IsNullOrEmpty(orderType) || mo.OrderType.Contains(orderType)) &&
                              (string.IsNullOrEmpty(patientName) || p.fullName.Contains(patientName))
                        select new MedicalOrderDoctorDTO
                        {
                            Id = mo.id,
                            PatientID = p.id,
                            DoctorID = mo.DoctorID,
                            OrderType = mo.OrderType,
                            ItemID = mo.ItemID,
                            TestTypeID = mo.TestTypeID,
                            Dosage = mo.Dosage,
                            Quantity = mo.Quantity,
                            Unit = mo.Unit,
                            Frequency = mo.Frequency,
                            StartDate = mo.StartDate,
                            EndDate = mo.EndDate,
                            Status = mo.Status,
                            CreatedAt = mo.CreatedAt,
                            SignedAt = mo.SignedAt,
                            Note = mo.Note,
                            PatientName = p.fullName,
                            HasLabTest = mo.HasLabTest,
                            TestTypeName = mo.TestTypeID != null
                                ? db.LabTestTypes.FirstOrDefault(t => t.id == mo.TestTypeID).testTypeName
                                : null
                        };

            return query.ToList();
        }
        public List<MedicalOrderDoctorDTO> GetMedicalOrdersInDepartmentOfDoctor(string doctorId)
        {
            // Lấy khoa của bác sĩ
            var departmentId = db.Staffs
                                 .Where(s => s.id == doctorId)
                                 .Select(s => s.departmentID)
                                 .FirstOrDefault();

            if (departmentId == null)
                return new List<MedicalOrderDoctorDTO>();

            // Lấy lần chuyển phòng gần nhất của mỗi bệnh nhân vào phòng thuộc khoa bác sĩ
            var validTransfers = from t in db.RoomTransferHistories
                                 join r in db.Rooms on t.toRoomID equals r.id
                                 where r.departmentID == departmentId
                                 select new { t.patientID, t.transferDate };

            var latestTransfers = validTransfers
                .GroupBy(x => x.patientID)
                .Select(g => g.OrderByDescending(x => x.transferDate).FirstOrDefault());

            // Join với bảng y lệnh và bệnh nhân nội trú
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join lt in latestTransfers on p.id equals lt.patientID
                        where p.TypePatient == "Inpatient"
                        select new MedicalOrderDoctorDTO
                        {
                            Id = mo.id,
                            PatientID = p.id,
                            DoctorID = mo.DoctorID,
                            OrderType = mo.OrderType,
                            ItemID = mo.ItemID,
                            TestTypeID = mo.TestTypeID,
                            HasLabTest = mo.HasLabTest,
                            Dosage = mo.Dosage,
                            Quantity = mo.Quantity,
                            Unit = mo.Unit,
                            Frequency = mo.Frequency,
                            StartDate = mo.StartDate,
                            EndDate = mo.EndDate,
                            Status = mo.Status,
                            CreatedAt = mo.CreatedAt,
                            SignedAt = mo.SignedAt,
                            Note = mo.Note,
                            PatientName = p.fullName,
                            TestTypeName = mo.TestTypeID != null
                                ? db.LabTestTypes.FirstOrDefault(t => t.id == mo.TestTypeID).testTypeName
                                : null
                        };

            return query.ToList();
        }
        public void CompleteMedicalOrder(int medicalOrderId)
        {
            var order = db.MedicalOrders.FirstOrDefault(m => m.id == medicalOrderId);
            if (order != null)
            {
                order.Status = "Completed";
                order.EndDate = DateTime.Today;
                db.SubmitChanges();
            }
        }
        public List<MedicalOrderDoctorDTO> GetMedicalOrdersOfPatientInDoctorDepartment(string doctorId, string patientId)
        {
            // Lấy khoa của bác sĩ
            var departmentId = db.Staffs
                                 .Where(s => s.id == doctorId)
                                 .Select(s => s.departmentID)
                                 .FirstOrDefault();

            if (departmentId == null)
                return new List<MedicalOrderDoctorDTO>();

            // Xác định bệnh nhân thuộc khoa bác sĩ (dựa trên lần chuyển phòng gần nhất)
            var validTransfers = from t in db.RoomTransferHistories
                                 join r in db.Rooms on t.toRoomID equals r.id
                                 where r.departmentID == departmentId
                                 select new { t.patientID, t.transferDate };

            var latestTransfers = validTransfers
                .GroupBy(x => x.patientID)
                .Select(g => g.OrderByDescending(x => x.transferDate).FirstOrDefault());

            // Lọc đúng bệnh nhân và join với MedicalOrders
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join lt in latestTransfers on p.id equals lt.patientID
                        where p.TypePatient == "Inpatient" && p.id == patientId
                        select new MedicalOrderDoctorDTO
                        {
                            Id = mo.id,
                            PatientID = p.id,
                            DoctorID = mo.DoctorID,
                            OrderType = mo.OrderType,
                            ItemID = mo.ItemID,
                            TestTypeID = mo.TestTypeID,
                            HasLabTest = mo.HasLabTest,
                            Dosage = mo.Dosage,
                            Quantity = mo.Quantity,
                            Unit = mo.Unit,
                            Frequency = mo.Frequency,
                            StartDate = mo.StartDate,
                            EndDate = mo.EndDate,
                            Status = mo.Status,
                            CreatedAt = mo.CreatedAt,
                            SignedAt = mo.SignedAt,
                            Note = mo.Note,
                            PatientName = p.fullName,
                            TestTypeName = mo.TestTypeID != null
                                ? db.LabTestTypes.FirstOrDefault(t => t.id == mo.TestTypeID).testTypeName
                                : null
                        };

            return query.ToList();
        }
        public PatientSupplyHistoryDTO GetPatientInfoById(string patientId)
        {
            var patient = db.Patients
                .Where(p => p.id == patientId)
                .Select(p => new PatientSupplyHistoryDTO
                {
                    Id = p.id.Trim(),
                    FullName = p.fullName.Trim(),
                    Gender = p.gender,
                    Dob = p.dob,
                    PhoneNumber = p.phoneNumber,
                    Status = p.status
                })
                .FirstOrDefault();

            return patient;
        }
        public string GetDepartmentIdByDoctor(string doctorId)
        {
            using (var db = new HospitalManagementDataContext())
            {
                return db.Staffs
                         .Where(s => s.id == doctorId)
                         .Select(s => s.departmentID)
                         .FirstOrDefault();
            }
        }
        public List<RoomSupplyHistoryDTO> GetRoomsByDoctorDepartment(string doctorId)
        {
            var departmentId = db.Staffs
                                 .Where(s => s.id == doctorId)
                                 .Select(s => s.departmentID)
                                 .FirstOrDefault();

            return db.Rooms
                     .Where(r => r.departmentID == departmentId)
                     .Select(r => new RoomSupplyHistoryDTO
                     {
                         Id = r.id,
                         RoomName = r.roomName
                     }).ToList();
        }
        public List<DailyCareDTO> SearchDailyCaresByDoctorDepartment(
    string doctorId,
    string patientId,
    string roomId)
        {
            // Lấy khoa của bác sĩ đang đăng nhập
            var departmentId = db.Staffs
                                 .Where(s => s.id == doctorId)
                                 .Select(s => s.departmentID)
                                 .FirstOrDefault();

            // Truy vấn các chăm sóc thuộc khoa đó, theo điều kiện tìm kiếm gần đúng
            var query = from dc in db.DailyCares
                        join p in db.Patients on dc.patientID equals p.id
                        join s in db.Staffs on dc.nurseID equals s.id
                        join r in db.Rooms on dc.roomID equals r.id
                        where r.departmentID == departmentId
                           && (string.IsNullOrEmpty(patientId) || p.fullName.Contains(patientId) || dc.patientID.Contains(patientId))
                           && (string.IsNullOrEmpty(roomId) || r.roomName.Contains(roomId) || dc.roomID.ToString().Contains(roomId))
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

    }
}
