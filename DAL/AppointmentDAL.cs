using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppointmentDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<AppointmentDTO> GetAll()
        {
            var query = from a in db.Appointments
                        join d in db.Staffs on a.doctorID equals d.id
                        join p in db.Patients on a.patientID equals p.id
                        select new AppointmentDTO
                        {
                            Id = a.id,
                            StartDate = a.startDate.Value,
                            Note = a.note,
                            Status = a.status,
                            DoctorID = a.doctorID,
                            PatientID = a.patientID,
                            DoctorName = d.name,
                            PatientName = p.fullName
                        };

            return query.ToList();
        }

        public void Add(AppointmentDTO dto)
        {
            var a = new Appointment
            {
                startDate = dto.StartDate,
                note = dto.Note,
                status = dto.Status,
                doctorID = dto.DoctorID,
                patientID = dto.PatientID
            };
            db.Appointments.InsertOnSubmit(a);
            db.SubmitChanges();
        }

        public void Update(AppointmentDTO dto)
        {
            var a = db.Appointments.FirstOrDefault(x => x.id == dto.Id);
            if (a != null)
            {
                a.startDate = dto.StartDate;
                a.note = dto.Note;
                a.status = dto.Status;
                a.doctorID = dto.DoctorID;
                a.patientID = dto.PatientID;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            var a = db.Appointments.FirstOrDefault(x => x.id == id);
            if (a != null)
            {
                db.Appointments.DeleteOnSubmit(a);
                db.SubmitChanges();
            }
        }
        public List<AppointmentDTO> Search(string doctorId, string patientId, string startDateText, string status)
        {
            var query = from a in db.Appointments
                        join d in db.Staffs on a.doctorID equals d.id
                        join p in db.Patients on a.patientID equals p.id
                        select new { a, d, p };

            if (!string.IsNullOrWhiteSpace(doctorId))
                query = query.Where(x => x.a.doctorID.Contains(doctorId));

            if (!string.IsNullOrWhiteSpace(patientId))
                query = query.Where(x => x.a.patientID.Contains(patientId));

            if (DateTime.TryParse(startDateText, out DateTime startDate))
                query = query.Where(x => x.a.startDate.HasValue && x.a.startDate.Value.Date == startDate.Date);

            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(x => x.a.status.Contains(status));

            return query.Select(x => new AppointmentDTO
            {
                Id = x.a.id,
                StartDate = x.a.startDate.Value,
                Note = x.a.note,
                Status = x.a.status,
                DoctorID = x.a.doctorID,
                PatientID = x.a.patientID,
                DoctorName = x.d.name,
                PatientName = x.p.fullName
            }).ToList();
        }


        // Kiểm tra tồn tại bệnh nhân theo ID
        public bool IsPatientExists(string patientId)
        {
            return db.Patients.Any(p => p.id == patientId);
        }

        // Kiểm tra tồn tại nhân viên là bác sĩ theo ID
        public bool IsDoctorExists(string nurseId)
        {
            return db.Staffs.Any(s => s.id == nurseId && s.role.ToLower().Contains("Bác sĩ"));
        }
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
                     .Where(s => s.departmentID == departmentId && s.role.ToLower().Contains("Bác Sĩ"))
                     .Select(s => new StaffSupplyHistoryDTO
                     {
                         Id = s.id,
                         Name = s.name
                     }).ToList();
        }
        public string GetDepartmentIdByStaffId(string staffId)
        {
            return db.Staffs
                     .Where(s => s.id == staffId)
                     .Select(s => s.departmentID)
                     .FirstOrDefault();
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
