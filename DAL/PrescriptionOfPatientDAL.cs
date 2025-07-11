using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Linq.SqlClient;

namespace DAL
{
    

    public class PrescriptionOfPatientDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<PatientComboDTO> GetAllPatients()
        {
            return db.Patients.Select(p => new PatientComboDTO { id = p.id, fullName = p.fullName }).ToList();
        }

        public List<PrescriptionOfPatientDTO> GetPrescriptionReport(string patientId, DateTime? orderDate)
        {
            var query = db.MedicalOrders
                .Where(mo => mo.PatientID == patientId && mo.OrderType == "Thuốc");

            if (orderDate.HasValue)
            {
                query = query.Where(mo => SqlMethods.DateDiffDay(mo.CreatedAt, orderDate.Value) == 0);
            }

            var queryResult = from mo in query
                        join p in db.Patients on mo.PatientID equals p.id
                        join s in db.Staffs on mo.DoctorID equals s.id
                        join d in db.Departments on s.departmentID equals d.id into dJoin
                        from d in dJoin.DefaultIfEmpty()
                        join i in db.Items on mo.ItemID equals i.ID into iJoin
                        from i in iJoin.DefaultIfEmpty()
                        orderby mo.CreatedAt descending, mo.id
                        select new PrescriptionOfPatientDTO
                        {
                            PrescriptionID = mo.id,
                            PatientName = p.fullName,
                            PatientGender = p.gender,
                            PatientDOB = p.dob,
                            PatientPhone = p.phoneNumber,
                            PatientAddress = p.address,
                            PatientInsurance = p.InsuranceID,
                            DoctorName = s.name,
                            DoctorPosition = s.position,
                            DoctorQualification = s.qualification,
                            DoctorDegree = s.degree,
                            DepartmentName = d != null ? d.departmentName : "",
                            OrderDate = mo.CreatedAt,
                            DoctorSignedAt = mo.SignedAt,
                            MedicineName = i != null ? i.ItemName : "",
                            Dosage = mo.Dosage,
                            Quantity = mo.Quantity,
                            Unit = mo.Unit,
                            Frequency = mo.Frequency,
                            Note = mo.Note
                        };
            return queryResult.ToList();
        }
    }
}
