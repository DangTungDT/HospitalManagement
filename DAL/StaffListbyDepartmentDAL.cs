using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class StaffListbyDepartmentDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public List<StaffListbyDepartmentDTO> GetStaffByDepartment(string departmentId)
        {
            var query = from s in db.Staffs
                        join d in db.Departments on s.departmentID equals d.id
                        where string.IsNullOrEmpty(departmentId) || s.departmentID == departmentId
                        select new StaffListbyDepartmentDTO
                        {
                            StaffID = s.id,
                            StaffName = s.name,
                            StaffRole = s.role,
                            DateOfBirth = s.dob,
                            gender = s.gender,
                            phoneNumber = s.phoneNumber,
                            position = s.position,
                            DepartmentName = d.departmentName,
                            startDate = s.startDate,
                            status = s.status
                        };
            return query.ToList();
        }

        public List<DTO.DepartmentComboDTO> GetAllDepartments()
        {
            return db.Departments.Select(d => new DTO.DepartmentComboDTO { id = d.id, departmentName = d.departmentName }).ToList();
        }
    }
}
