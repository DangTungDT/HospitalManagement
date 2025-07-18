using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoctorPatientDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<DoctorPatientDTO> GetPatientsByDoctor(string doctorId)
        {
            var query = from dp in db.DoctorPatients
                        join p in db.Patients on dp.patientID equals p.id
                        where dp.doctorID == doctorId
                        select new DoctorPatientDTO
                        {
                            DoctorID = dp.doctorID,
                            PatientID = dp.patientID,
                            StartDate = dp.startDate,
                            EndDate = dp.endDate,
                            Role = dp.role,
                            Note = dp.note,
                            PatientName = p.fullName,
                            PatientGender = p.gender,
                            PatientDob = p.dob
                        };

            return query.ToList();
        }

        public void AddDoctorPatient(DoctorPatientDTO dto)
        {
            DoctorPatient dp = new DoctorPatient
            {
                doctorID = dto.DoctorID,
                patientID = dto.PatientID,
                startDate = DateTime.Today, // ✅ mặc định là hôm nay
                endDate = null,             // ✅ mặc định là null
                role = dto.Role,
                note = dto.Note
            };

            db.DoctorPatients.InsertOnSubmit(dp);
            db.SubmitChanges();
        }
        public bool IsDoctorPatientExists(string doctorId, string patientId, DateTime startDate)
        {
            return db.DoctorPatients.Any(dp =>
                dp.doctorID == doctorId &&
                dp.patientID == patientId &&
                dp.startDate == startDate
            );
        }

        public void UpdateDoctorPatient(DoctorPatientDTO dto)
        {
            var record = db.DoctorPatients.FirstOrDefault(x =>
                x.doctorID == dto.DoctorID &&
                x.patientID == dto.PatientID &&
                x.startDate == dto.StartDate
            );

            if (record != null)
            {
                record.endDate = dto.EndDate;
                record.role = dto.Role;
                record.note = dto.Note;

                db.SubmitChanges();
            }
        }
        public List<DoctorPatientDTO> SearchByPatientId(string doctorId, string patientIdKeyword)
        {
            return (from dp in db.DoctorPatients
                    join p in db.Patients on dp.patientID equals p.id
                    where dp.doctorID == doctorId &&
                          p.id.Contains(patientIdKeyword) // tìm theo mã bệnh nhân
                    select new DoctorPatientDTO
                    {
                        DoctorID = dp.doctorID,
                        PatientID = dp.patientID,
                        StartDate = dp.startDate,
                        EndDate = dp.endDate,
                        Role = dp.role,
                        Note = dp.note,
                        PatientName = p.fullName,
                        PatientGender = p.gender,
                        PatientDob = p.dob
                    }).ToList();
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

            return query.Distinct().ToList(); // nếu 1 bệnh nhân được phân công nhiều lần thì tránh trùng
        }

    }
}
