using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicalRecordDoctorDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        // Lấy tất cả bệnh án của bác sĩ đó (theo doctorID)
        public List<MedicalRecordDoctorDTO> GetMedicalRecordsByDoctor(string doctorId)
        {
            var query = from mr in db.MedicalRecords
                        join p in db.Patients on mr.patientID equals p.id
                        join d in db.Staffs on mr.doctorID equals d.id
                        where mr.doctorID == doctorId
                        select new MedicalRecordDoctorDTO
                        {
                            Id = mr.id,
                            PatientID = mr.patientID,
                            PatientName = p.fullName,
                            DoctorID = mr.doctorID,
                            DoctorName = d.name,
                            Diagnosis = mr.diagnosis,
                            TreatmentPlan = mr.treatmentPlan,
                            Prescription = mr.prescription,
                            VitalSigns = mr.vitalSigns,
                            CreatedDate = mr.createdDate ?? DateTime.Now,
                            Notes = mr.notes
                        };

            return query.ToList();
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
        public List<MedicalRecordDoctorDTO> SearchMedicalRecordsByPatient(string doctorId, string patientId)
        {
            var query = from mr in db.MedicalRecords
                        join p in db.Patients on mr.patientID equals p.id
                        join d in db.Staffs on mr.doctorID equals d.id
                        where mr.doctorID == doctorId && mr.patientID == patientId
                        select new MedicalRecordDoctorDTO
                        {
                            Id = mr.id,
                            PatientID = mr.patientID,
                            PatientName = p.fullName,
                            DoctorID = mr.doctorID,
                            DoctorName = d.name,
                            Diagnosis = mr.diagnosis,
                            TreatmentPlan = mr.treatmentPlan,
                            Prescription = mr.prescription,
                            VitalSigns = mr.vitalSigns,
                            CreatedDate = mr.createdDate ?? DateTime.Now,
                            Notes = mr.notes
                        };

            return query.ToList();
        }
        public void AddMedicalRecord(MedicalRecordDoctorDTO dto)
        {
            var record = new MedicalRecord
            {
                patientID = dto.PatientID,
                doctorID = dto.DoctorID,
                diagnosis = dto.Diagnosis,
                treatmentPlan = dto.TreatmentPlan,
                prescription = dto.Prescription,
                vitalSigns = dto.VitalSigns,
                createdDate = DateTime.Now,
                notes = dto.Notes
            };

            db.MedicalRecords.InsertOnSubmit(record);
            db.SubmitChanges();
        }
    }
}
