using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LaboratoryTestDoctorDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();
        public List<LaboratoryTestDoctorDTO> GetTestsByDoctor(string doctorId)
        {
            var query = from t in db.LaboratoryTests
                        join o in db.MedicalOrders on t.MedicalOrderID equals o.id
                        join p in db.Patients on o.PatientID equals p.id
                        join tt in db.LabTestTypes on o.TestTypeID equals tt.id into testTypeJoin
                        from tt in testTypeJoin.DefaultIfEmpty()
                        where o.DoctorID == doctorId // ❌ KHÔNG lọc TestTypeID != null
                        select new LaboratoryTestDoctorDTO
                        {
                            Id = t.id,
                            MedicalOrderID = t.MedicalOrderID,
                            StartDate = t.startDate,
                            ResultValue = t.resultValue,
                            ResultUnit = t.resultUnit,
                            Result = t.result,
                            Status = t.status,
                            Note = t.note,

                            PatientID = o.PatientID,
                            PatientName = p.fullName,
                            DoctorID = o.DoctorID,
                            OrderType = o.OrderType,
                            TestType = tt != null ? tt.testTypeName : "Chưa xác định" // ✅ nếu null thì gán chuỗi
                        };

            return query.ToList();
        }

        public List<MedicalOrderSimpleDTO> GetOrdersByAssignedPatients(string doctorId)
        {
            var query = from dp in db.DoctorPatients
                        join p in db.Patients on dp.patientID equals p.id
                        join o in db.MedicalOrders on p.id equals o.PatientID
                        join tt in db.LabTestTypes on o.TestTypeID equals tt.id into ttJoin
                        from tt in ttJoin.DefaultIfEmpty()
                        where dp.doctorID == doctorId
                              && o.HasLabTest == true
                              && o.Status == "Active" // ✅ Chỉ lấy y lệnh đang hoạt động
                        select new MedicalOrderSimpleDTO
                        {
                            OrderId = o.id,
                            OrderType = o.OrderType,
                            TestTypeName = tt != null ? tt.testTypeName : null,

                            PatientId = p.id.Trim(),
                            PatientName = p.fullName.Trim(),
                            Gender = p.gender,
                            Dob = p.dob,
                            PhoneNumber = p.phoneNumber,
                            Status = p.status
                        };

            return query.Distinct().ToList();
        }


        public List<LaboratoryTestDoctorDTO> SearchTestsByOrderId(string doctorId, int orderId)
        {
            var query = from t in db.LaboratoryTests
                        join o in db.MedicalOrders on t.MedicalOrderID equals o.id
                        join p in db.Patients on o.PatientID equals p.id
                        join tt in db.LabTestTypes on o.TestTypeID equals tt.id into testTypeJoin
                        from tt in testTypeJoin.DefaultIfEmpty()
                        where o.DoctorID == doctorId && o.id == orderId
                        select new LaboratoryTestDoctorDTO
                        {
                            Id = t.id,
                            MedicalOrderID = t.MedicalOrderID,
                            StartDate = t.startDate,
                            ResultValue = t.resultValue,
                            ResultUnit = t.resultUnit,
                            Result = t.result,
                            Status = t.status,
                            Note = t.note,

                            PatientID = o.PatientID,
                            PatientName = p.fullName,
                            DoctorID = o.DoctorID,
                            OrderType = o.OrderType,
                            TestType = tt != null ? tt.testTypeName : null
                        };

            return query.ToList();
        }

        public void AddTest(LaboratoryTestDoctorDTO dto)
        {
            var test = new LaboratoryTest
            {
                MedicalOrderID = dto.MedicalOrderID,
                startDate = dto.StartDate ?? DateTime.Now,
                resultValue = dto.ResultValue,
                resultUnit = dto.ResultUnit,
                result = dto.Result,
                status = "Completed", // ✅ Luôn mặc định là Completed
                note = dto.Note
            };

            db.LaboratoryTests.InsertOnSubmit(test);

            // ✅ Cập nhật trạng thái y lệnh thành Completed
            var order = db.MedicalOrders.FirstOrDefault(o => o.id == dto.MedicalOrderID);
            if (order != null)
            {
                order.Status = "Completed";
            }

            db.SubmitChanges();
        }

    }
}
