using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class PrescriptionInfoDoctorDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        // Lấy tất cả đơn thuốc (OrderType = 'Thuốc')
        public List<PrescriptionInfoDoctorDTO> GetAll()
        {
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join s in db.Staffs on mo.DoctorID equals s.id
                        where mo.OrderType == "Thuốc" && mo.ItemID == null // Chỉ lấy đơn thuốc gốc
                        select new PrescriptionInfoDoctorDTO
                        {
                            PrescriptionID = mo.id.ToString(),
                            PatientID = mo.PatientID,
                            DoctorID = mo.DoctorID,
                            OrderDate = mo.CreatedAt ?? DateTime.Now,
                            Note = mo.Note,
                            PatientName = p.fullName,
                            DoctorName = s.name
                        };
            return query.ToList();
        }

        // Thêm đơn thuốc mới (bản ghi gốc, không có ItemID)
        public bool Insert(PrescriptionInfoDoctorDTO dto)
        {
            try
            {
                var mo = new MedicalOrder
                {
                    PatientID = dto.PatientID,
                    DoctorID = dto.DoctorID,
                    OrderType = "Thuốc",
                    CreatedAt = dto.OrderDate,
                    Note = dto.Note,
                    ItemID = null, // Bản ghi gốc không có ItemID
                    Quantity = null,
                    Unit = null,
                    Dosage = null,
                    Frequency = null
                };
                db.MedicalOrders.InsertOnSubmit(mo);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Cập nhật đơn thuốc
        public bool Update(PrescriptionInfoDoctorDTO dto)
        {
            try
            {
                int id = int.Parse(dto.PrescriptionID);
                var mo = db.MedicalOrders.FirstOrDefault(x => x.id == id);
                if (mo == null) return false;
                mo.PatientID = dto.PatientID;
                mo.DoctorID = dto.DoctorID;
                mo.CreatedAt = dto.OrderDate;
                mo.Note = dto.Note;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Log lỗi nếu cần
                return false;
            }
        }

        // Tìm kiếm/lọc đơn thuốc
        public List<PrescriptionInfoDoctorDTO> Search(string patientId, string doctorId, DateTime? orderDate)
        {
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join s in db.Staffs on mo.DoctorID equals s.id
                        where mo.OrderType == "Thuốc" && mo.ItemID == null // Chỉ lấy đơn thuốc gốc
                        select new { mo, p, s };
            
            if (!string.IsNullOrEmpty(patientId))
                query = query.Where(x => x.mo.PatientID == patientId);
            if (!string.IsNullOrEmpty(doctorId))
                query = query.Where(x => x.mo.DoctorID == doctorId);
            if (orderDate.HasValue)
                query = query.Where(x => x.mo.CreatedAt.HasValue && x.mo.CreatedAt.Value.Date == orderDate.Value.Date);
                
            return query.Select(x => new PrescriptionInfoDoctorDTO
            {
                PrescriptionID = x.mo.id.ToString(),
                PatientID = x.mo.PatientID,
                DoctorID = x.mo.DoctorID,
                OrderDate = x.mo.CreatedAt ?? DateTime.Now,
                Note = x.mo.Note,
                PatientName = x.p.fullName,
                DoctorName = x.s.name
            }).ToList();
        }

        // Lấy danh sách bệnh nhân cho ComboBox
        public List<PatientComboDTO> GetPatients()
        {
            return db.Patients.Select(p => new PatientComboDTO { id = p.id, fullName = p.fullName }).ToList();
        }

        // Lấy danh sách bệnh nhân theo bác sĩ (chỉ những bệnh nhân được phân công cho bác sĩ này)
        public List<PatientComboDTO> GetPatientsByDoctor(string doctorId)
        {
            if (string.IsNullOrWhiteSpace(doctorId))
            {
                return new List<PatientComboDTO>();
            }

            var query = from dp in db.DoctorPatients
                        join p in db.Patients on dp.patientID equals p.id
                        where dp.doctorID == doctorId
                        select new PatientComboDTO
                        {
                            id = p.id,
                            fullName = p.fullName
                        };

            return query.Distinct().ToList();
        }

        // Lấy danh sách bác sĩ cho ComboBox
        public List<DoctorListbyDepartmentDTO> GetDoctors()
        {
            return db.Staffs.Where(s => s.role == "Bác sĩ")
                .Select(s => new DoctorListbyDepartmentDTO { DoctorID = s.id, DoctorName = s.name })
                .ToList();
        }
    }
}
