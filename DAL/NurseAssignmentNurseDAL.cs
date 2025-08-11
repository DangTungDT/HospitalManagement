using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NurseAssignmentNurseDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();
        // Lấy danh sách phân công (y tá cùng khoa)
        public List<NurseAssignmentNurseDTO> GetAssignmentsInSameDepartment(string nurseId)
        {
            // Lấy khoa của y tá đăng nhập
            var departmentId = db.Staffs
                .Where(s => s.id == nurseId)
                .Select(s => s.departmentID)
                .FirstOrDefault();

            if (departmentId == null)
                return new List<NurseAssignmentNurseDTO>();

            // Lấy danh sách phân công y tá trong cùng khoa
            var query = from dp in db.DoctorPatients
                        join s in db.Staffs on dp.doctorID equals s.id
                        join p in db.Patients on dp.patientID equals p.id
                        where s.departmentID == departmentId
                              && s.role.Contains("Y tá")
                              && p.TypePatient == "Inpatient"
                        orderby s.id, dp.startDate
                        select new NurseAssignmentNurseDTO
                        {
                            DoctorID = dp.doctorID,
                            DoctorName = s.name,
                            PatientID = dp.patientID,
                            PatientName = p.fullName,
                            StartDate = dp.startDate,
                            EndDate = dp.endDate,
                            Role = dp.role, // Role phân công trong DoctorPatient
                            Note = dp.note
                        };

            return query.ToList();
        }
        public List<NurseAssignmentNurseDTO> GetNursesInSameDepartment(string nurseId)
        {
            // Lấy khoa của y tá đăng nhập
            var departmentId = db.Staffs
                .Where(s => s.id == nurseId)
                .Select(s => s.departmentID)
                .FirstOrDefault();

            if (departmentId == null)
                return new List<NurseAssignmentNurseDTO>();

            // Lấy danh sách y tá cùng khoa
            var query = from s in db.Staffs
                        where s.departmentID == departmentId
                              && s.role.Contains("Y tá")
                        orderby s.name
                        select new NurseAssignmentNurseDTO
                        {
                            DoctorID = s.id,
                            DoctorName = s.name,
                            Role = s.role
                        };

            return query.ToList();
        }


        // Thêm mới phân công
        public bool InsertAssignment(NurseAssignmentNurseDTO dto)
        {
            try
            {
                DoctorPatient entity = new DoctorPatient
                {
                    doctorID = dto.DoctorID,
                    patientID = dto.PatientID,
                    startDate = dto.StartDate,
                    endDate = dto.EndDate,
                    role = dto.Role,
                    note = dto.Note
                };
                db.DoctorPatients.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa phân công
        public bool DeleteAssignment(string doctorId, string patientId, DateTime startDate)
        {
            try
            {
                var entity = db.DoctorPatients
                    .FirstOrDefault(dp => dp.doctorID == doctorId
                                       && dp.patientID == patientId
                                       && dp.startDate == startDate);
                if (entity != null)
                {
                    db.DoctorPatients.DeleteOnSubmit(entity);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool IsDoctorPatientExists(string doctorId, string patientId, DateTime startDate)
        {
            return db.DoctorPatients.Any(dp =>
                dp.doctorID == doctorId &&
                dp.patientID == patientId &&
                dp.startDate == startDate
            );
        }
        public List<NurseAssignmentNurseDTO> SearchAssignmentsByNurseAndPatient(string nurseId, string patientId)
        {
            var query = from dp in db.DoctorPatients
                        join s in db.Staffs on dp.doctorID equals s.id
                        join p in db.Patients on dp.patientID equals p.id
                        where (string.IsNullOrEmpty(nurseId) || dp.doctorID == nurseId)
                              && (string.IsNullOrEmpty(patientId) || dp.patientID == patientId)
                              && p.status == "Inpatient" // Lọc chỉ bệnh nhân nội trú
                        orderby s.name, p.fullName, dp.startDate
                        select new NurseAssignmentNurseDTO
                        {
                            DoctorID = dp.doctorID,
                            DoctorName = s.name,
                            PatientID = dp.patientID,
                            PatientName = p.fullName,
                            StartDate = dp.startDate,
                            EndDate = dp.endDate,
                            Role = dp.role,
                            Note = dp.note
                        };

            return query.ToList();
        }
        // Cập nhật phân công
        public bool UpdateAssignment(NurseAssignmentNurseDTO dto)
        {
            try
            {
                var entity = db.DoctorPatients
                    .FirstOrDefault(dp => dp.doctorID == dto.DoctorID
                                       && dp.patientID == dto.PatientID
                                       && dp.startDate == dto.StartDate);

                if (entity == null)
                    return false; // Không tìm thấy

                // Chỉ cho sửa Role, Note và EndDate
                if (dto.EndDate.HasValue && dto.EndDate.Value < entity.startDate)
                {
                    throw new Exception("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.");
                }

                entity.role = dto.Role;
                entity.note = dto.Note;
                entity.endDate = dto.EndDate;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
