using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Lớp DAL cho Hồ sơ bệnh án, thực hiện các thao tác trên CSDL.
    /// </summary>
    public class MedicalRecordDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        /// <summary>
        /// Lấy tất cả hồ sơ bệnh án.
        /// </summary>
        public List<MedicalRecordDTO> GetAll()
        {
            var query = from mr in db.MedicalRecords
                        join p in db.Patients on mr.patientID equals p.id
                        join d in db.Staffs on mr.doctorID equals d.id
                        orderby mr.createdDate descending
                        select new MedicalRecordDTO
                        {
                            id = mr.id,
                            patientID = mr.patientID,
                            doctorID = mr.doctorID,
                            diagnosis = mr.diagnosis,
                            treatmentPlan = mr.treatmentPlan,
                            prescription = mr.prescription,
                            vitalSigns = mr.vitalSigns,
                            createdDate = mr.createdDate,
                            notes = mr.notes,
                            PatientName = p.fullName,
                            DoctorName = d.name
                        };
            return query.ToList();
        }

        /// <summary>
        /// Thêm một hồ sơ bệnh án mới.
        /// </summary>
        public bool Add(MedicalRecordDTO dto)
        {
            try
            {
                MedicalRecord newRecord = new MedicalRecord
                {
                    patientID = dto.patientID,
                    doctorID = dto.doctorID,
                    diagnosis = dto.diagnosis,
                    treatmentPlan = dto.treatmentPlan,
                    prescription = dto.prescription,
                    vitalSigns = dto.vitalSigns,
                    createdDate = dto.createdDate,
                    notes = dto.notes
                };
                db.MedicalRecords.InsertOnSubmit(newRecord);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Cập nhật một hồ sơ bệnh án.
        /// </summary>
        public bool Update(MedicalRecordDTO dto)
        {
            try
            {
                MedicalRecord existingRecord = db.MedicalRecords.SingleOrDefault(r => r.id == dto.id);
                if (existingRecord == null) return false;

                existingRecord.patientID = dto.patientID;
                existingRecord.doctorID = dto.doctorID;
                existingRecord.diagnosis = dto.diagnosis;
                existingRecord.treatmentPlan = dto.treatmentPlan;
                existingRecord.prescription = dto.prescription;
                existingRecord.vitalSigns = dto.vitalSigns;
                existingRecord.createdDate = dto.createdDate;
                existingRecord.notes = dto.notes;

                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Xóa một hồ sơ bệnh án theo ID.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                MedicalRecord recordToDelete = db.MedicalRecords.SingleOrDefault(r => r.id == id);
                if (recordToDelete == null) return false;

                db.MedicalRecords.DeleteOnSubmit(recordToDelete);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
