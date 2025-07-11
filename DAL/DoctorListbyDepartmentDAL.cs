using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoctorListbyDepartmentDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<DoctorListbyDepartmentDTO> GetDoctorsByDepartment(string departmentId)
        {
            var query = from s in db.Staffs
                        join d in db.Departments on s.departmentID equals d.id
                        where s.role == "Bác sĩ"
                              && (string.IsNullOrEmpty(departmentId) || s.departmentID == departmentId)
                        select new DoctorListbyDepartmentDTO
                        {
                            DoctorID = s.id,
                            DoctorName = s.name,
                            DateOfBirth = s.dob,
                            Gender = s.gender,
                            PhoneNumber = s.phoneNumber,
                            Email = s.email,
                            Position = s.position,
                            Qualification = s.qualification,
                            Degree = s.degree,
                            Status = s.status,
                            DepartmentName = d.departmentName
                        };
            return query.ToList();
        }

        public List<DepartmentComboDTO> GetAllDepartments()
        {
            return db.Departments.Select(d => new DepartmentComboDTO { id = d.id, departmentName = d.departmentName }).ToList();
        }
    }

    public class DepartmentComboDTO
    {
        public string id { get; set; }
        public string departmentName { get; set; }
    }
}
