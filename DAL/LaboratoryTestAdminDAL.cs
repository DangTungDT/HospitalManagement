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
                        orderby lt.startDate descending
                        select new LaboratoryTestDTO
                        {
                            id = lt.id,
                            MedicalOrderID = lt.MedicalOrderID,
                            startDate = lt.startDate,
                            resultValue = lt.resultValue,
                            resultUnit = lt.resultUnit,
                            result = lt.result,
                            status = lt.status,
                            note = lt.note
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
                    MedicalOrderID = dto.MedicalOrderID,
                    startDate = dto.startDate,
                    resultValue = dto.resultValue,
                    resultUnit = dto.resultUnit,
                    result = dto.result,
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

                existingTest.MedicalOrderID = dto.MedicalOrderID;
                existingTest.startDate = dto.startDate;
                existingTest.resultValue = dto.resultValue;
                existingTest.resultUnit = dto.resultUnit;
                existingTest.result = dto.result;
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
            return db.LabTestTypes
                     .Select(t => new LabTestTypeDTO { Id = t.id, Name = t.testTypeName })
                     .ToList();
        }

        // Lấy danh sách MedicalOrder cho combobox (bao gồm tên bệnh nhân, bác sĩ, loại y lệnh)
        public List<MedicalOrderComboDTO> GetMedicalOrdersForLabTest()
        {
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join d in db.Staffs on mo.DoctorID equals d.id
                        select new MedicalOrderComboDTO
                        {
                            Id = mo.id,
                            PatientName = p.fullName,
                            DoctorName = d.name,
                            OrderType = mo.OrderType
                        };
            return query.ToList();
        }
    }
}
