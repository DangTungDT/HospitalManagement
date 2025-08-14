using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DtorPaitentDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();
        public List<DoctorPatientDTO> GetAll()
        {
            return (from dp in db.DoctorPatients
                    join p in db.Patients
                        on dp.patientID equals p.id
                    select new DoctorPatientDTO
                    {
                        DoctorID = dp.doctorID,
                        PatientID = dp.patientID,
                        StartDate = dp.startDate,
                        EndDate = dp.endDate,
                        Role = dp.role,
                        Note = dp.note,

                        // Thông tin bệnh nhân
                        PatientName = p.fullName,
                        PatientGender = p.gender,
                        PatientDob = p.dob
                    }).ToList();
        }
        public bool InsertWithPatientCheck(DoctorPatientDTO dto)
        {
            try
            {
                // Kiểm tra Patient đã tồn tại chưa
                var patient = db.Patients.FirstOrDefault(p => p.id == dto.PatientID);
                if (patient == null)
                {
                    patient = new Patient
                    {
                        id = dto.PatientID,
                        fullName = dto.PatientName,
                        gender = dto.PatientGender,
                        dob = dto.PatientDob
                    };
                    db.Patients.InsertOnSubmit(patient);
                    db.SubmitChanges();
                }

                // Thêm DoctorPatient
                DoctorPatient dp = new DoctorPatient
                {
                    doctorID = dto.DoctorID,
                    patientID = dto.PatientID,
                    startDate = dto.StartDate,
                    endDate = dto.EndDate,
                    role = dto.Role,
                    note = dto.Note
                };
                db.DoctorPatients.InsertOnSubmit(dp);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateWithPatientCheck(DoctorPatientDTO dto)
        {
            try
            {
                // Update Patient
                var patient = db.Patients.FirstOrDefault(p => p.id == dto.PatientID);
                if (patient != null)
                {
                    patient.fullName = dto.PatientName;
                    patient.gender = dto.PatientGender;
                    patient.dob = dto.PatientDob;
                }

                // Update DoctorPatient
                var dp = db.DoctorPatients.FirstOrDefault(d => d.doctorID == dto.DoctorID && d.patientID == dto.PatientID);
                if (dp != null)
                {
                    dp.startDate = dto.StartDate;
                    dp.endDate = dto.EndDate;
                    dp.role = dto.Role;
                    dp.note = dto.Note;
                }
                else
                {
                    return false; // không tìm thấy DoctorPatient để cập nhật
                }

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteWithCheck(string doctorID, string patientID, bool deletePatient = false)
        {
            try
            {
                var dp = db.DoctorPatients.FirstOrDefault(d => d.doctorID == doctorID && d.patientID == patientID);
                if (dp != null)
                {
                    db.DoctorPatients.DeleteOnSubmit(dp);
                }
                else
                {
                    return false; // không tìm thấy DoctorPatient
                }

                if (deletePatient)
                {
                    var patient = db.Patients.FirstOrDefault(p => p.id == patientID);
                    if (patient != null)
                    {
                        db.Patients.DeleteOnSubmit(patient);
                    }
                }

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
