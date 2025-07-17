using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class StaffListbyDepartmentBLL
    {
        private StaffListbyDepartmentDAL dal = new StaffListbyDepartmentDAL();

        public List<StaffListbyDepartmentDTO> GetStaffByDepartment(string departmentId)
        {
            return dal.GetStaffByDepartment(departmentId);
        }

        public List<DTO.DepartmentComboDTO> GetAllDepartments()
        {
            return dal.GetAllDepartments();
        }
    }
}
