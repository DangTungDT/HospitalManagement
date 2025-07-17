using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Lớp DAL cho Xét nghiệm, thực hiện các thao tác trên CSDL.
    /// </summary>
    public class LaboratoryTestDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        /// <summary>
        /// Lấy tất cả các kết quả xét nghiệm.
        /// </summary>
        public List<LaboratoryTestDTO> GetAll()
        {
            var query = from lt in db.LaboratoryTests
                        join p in db.Patients on lt.patientID equals p.id
                        join d in db.Staffs on lt.doctorID equals d.id
                        orderby lt.startDate descending
                        select new LaboratoryTestDTO
                        {
                            id = lt.id,
                            testName = lt.testName,
                            patientID = lt.patientID,
                            doctorID = lt.doctorID,
                            startDate = lt.startDate,
                            resultValue = lt.resultValue,
                            resultUnit = lt.resultUnit,
                            result = lt.result,
                            testType = lt.testType,
                            status = lt.status,
                            note = lt.note,
                            PatientName = p.fullName,
                            DoctorName = d.name
                        };
            return query.ToList();
        }

        /// <summary>
        /// Thêm một kết quả xét nghiệm mới.
        /// </summary>
        public bool Add(LaboratoryTestDTO dto)
        {
            try
            {
                LaboratoryTest newTest = new LaboratoryTest
                {
                    testName = dto.testName,
                    patientID = dto.patientID,
                    doctorID = dto.doctorID,
                    startDate = dto.startDate,
                    resultValue = dto.resultValue,
                    resultUnit = dto.resultUnit,
                    result = dto.result,
                    testType = dto.testType,
                    status = dto.status,
                    note = dto.note,
                };
                db.LaboratoryTests.InsertOnSubmit(newTest);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Cập nhật một kết quả xét nghiệm.
        /// </summary>
        public bool Update(LaboratoryTestDTO dto)
        {
            try
            {
                LaboratoryTest existingTest = db.LaboratoryTests.SingleOrDefault(t => t.id == dto.id);
                if (existingTest == null) return false;

                existingTest.testName = dto.testName;
                existingTest.patientID = dto.patientID;
                existingTest.doctorID = dto.doctorID;
                existingTest.startDate = dto.startDate;
                existingTest.resultValue = dto.resultValue;
                existingTest.resultUnit = dto.resultUnit;
                existingTest.result = dto.result;
                existingTest.testType = dto.testType;
                existingTest.status = dto.status;
                existingTest.note = dto.note;

                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Xóa một kết quả xét nghiệm theo ID.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                LaboratoryTest testToDelete = db.LaboratoryTests.SingleOrDefault(t => t.id == id);
                if (testToDelete == null) return false;

                db.LaboratoryTests.DeleteOnSubmit(testToDelete);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public List<LabTestTypeDTO> GetLabTestTypes()
        {
            return db.LaboratoryTests
                     .Select(t => new LabTestTypeDTO { Id = t.id, Name = t.testName })
                     .ToList();
        }
    }
}
