using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicalOrderDoctorDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<MedicalOrderDoctorDTO> GetMedicalOrdersByDoctor(string doctorId)
        {
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join d in db.Staffs on mo.DoctorID equals d.id
                        join tt in db.LabTestTypes on mo.TestTypeID equals tt.id into testJoin
                        from tt in testJoin.DefaultIfEmpty()
                        where mo.DoctorID == doctorId
                        select new MedicalOrderDoctorDTO
                        {
                            Id = mo.id,
                            PatientID = mo.PatientID,
                            DoctorID = mo.DoctorID,
                            OrderType = mo.OrderType,
                            ItemID = mo.ItemID,
                            TestTypeID = mo.TestTypeID,
                            HasLabTest = mo.HasLabTest,
                            Dosage = mo.Dosage,
                            Quantity = mo.Quantity,
                            Unit = mo.Unit,
                            Frequency = mo.Frequency,
                            StartDate = mo.StartDate,
                            EndDate = mo.EndDate,
                            Status = mo.Status,
                            CreatedAt = mo.CreatedAt,
                            SignedAt = mo.SignedAt,
                            Note = mo.Note,
                            PatientName = p.fullName,
                            DoctorName = d.name,
                            TestTypeName = tt != null ? tt.testTypeName : null
                        };

            return query.ToList();
        }

        public List<ItemSupplyHistoryDTO> GetAllItems()
        {
            return db.Items
                     .Where(i => i.IsActive)
                     .Select(i => new ItemSupplyHistoryDTO
                     {
                         ID = i.ID,
                         ItemName = i.ItemName
                     }).ToList();
        }
        public List<MedicalOrderDoctorDTO> SearchMedicalOrders(string doctorId, string patientName)
        {
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join d in db.Staffs on mo.DoctorID equals d.id
                        where mo.DoctorID == doctorId && p.fullName.Contains(patientName)
                        select new MedicalOrderDoctorDTO
                        {
                            Id = mo.id,
                            PatientID = mo.PatientID,
                            DoctorID = mo.DoctorID,
                            OrderType = mo.OrderType,
                            ItemID = mo.ItemID,
                            TestTypeID = mo.TestTypeID,
                            Dosage = mo.Dosage,
                            Quantity = mo.Quantity,
                            Unit = mo.Unit,
                            Frequency = mo.Frequency,
                            StartDate = mo.StartDate,
                            EndDate = mo.EndDate,
                            Status = mo.Status,
                            CreatedAt = mo.CreatedAt,
                            SignedAt = mo.SignedAt,
                            Note = mo.Note,
                            PatientName = p.fullName,
                            DoctorName = d.name
                        };

            return query.ToList();
        }

        public void AddMedicalOrder(MedicalOrderDoctorDTO dto)
        {
            var order = new MedicalOrder
            {
                PatientID = dto.PatientID,
                DoctorID = dto.DoctorID,
                OrderType = dto.OrderType,
                ItemID = dto.ItemID,
                TestTypeID = dto.TestTypeID,
                HasLabTest = dto.HasLabTest ?? false,
                Dosage = dto.Dosage,
                Quantity = dto.Quantity,
                Unit = dto.Unit,
                Frequency = dto.Frequency,
                StartDate = dto.StartDate ?? DateTime.Today,
                EndDate = dto.EndDate,
                Status = "Active",
                CreatedAt = DateTime.Now,
                SignedAt = dto.SignedAt,
                Note = dto.Note,
            };

            db.MedicalOrders.InsertOnSubmit(order);
            db.SubmitChanges();
        }

        public void UpdateMedicalOrder(MedicalOrderDoctorDTO dto)
        {
            var order = db.MedicalOrders.FirstOrDefault(m => m.id == dto.Id);
            if (order != null)
            {
                order.OrderType = dto.OrderType;
                order.ItemID = dto.ItemID;
                order.TestTypeID = dto.TestTypeID;
                order.HasLabTest = dto.HasLabTest ?? false;
                order.Dosage = dto.Dosage;
                order.Quantity = dto.Quantity;
                order.Unit = dto.Unit;
                order.Frequency = dto.Frequency;
                order.StartDate = dto.StartDate ?? order.StartDate;
                order.EndDate = dto.EndDate;
                order.Note = dto.Note;
                db.SubmitChanges();
            }
        }
        public bool CheckTestTypeIDExists(int testTypeId)
        {
            return db.LaboratoryTests.Any(t => t.id == testTypeId);
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

            return query.Distinct().ToList();
        }
        public List<LabTestTypeDocTorDTO> GetAllLabTestTypes()
        {
            return db.LabTestTypes.Select(t => new LabTestTypeDocTorDTO
            {
                Id = t.id,
                TestTypeName = t.testTypeName
            }).ToList();
        }
    }
}
