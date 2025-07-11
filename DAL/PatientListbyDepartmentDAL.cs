using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PatientListbyDepartmentDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<PatientListbyDepartmentDTO> GetPatientsByDepartment(string departmentId)
        {
            var query = from p in db.Patients
                        join dp in db.DoctorPatients on p.id equals dp.patientID
                        join s in db.Staffs on dp.doctorID equals s.id
                        join d in db.Departments on s.departmentID equals d.id into deptJoin
                        from d in deptJoin.DefaultIfEmpty()
                        where string.IsNullOrEmpty(departmentId) || s.departmentID == departmentId
                        select new PatientListbyDepartmentDTO
                        {
                            PatientID = p.id,
                            fullName = p.fullName,
                            gender = p.gender,
                            dob = p.dob,
                            DepartmentName = d != null ? d.departmentName : null,
                            status = p.status,
                            createdDate = p.createdDate
                        };
            return query.Distinct().ToList();
        }

        public List<DepartmentComboDTO> GetAllDepartments()
        {
            return db.Departments.Select(d => new DepartmentComboDTO { id = d.id, departmentName = d.departmentName }).ToList();
        }
    }
}
