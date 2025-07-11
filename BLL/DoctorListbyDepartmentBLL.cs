using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DTO;
using DAL;

namespace BLL
{
    public class DoctorListbyDepartmentBLL
    {
        private DoctorListbyDepartmentDAL dal = new DoctorListbyDepartmentDAL();

        public List<DoctorListbyDepartmentDTO> GetDoctorsByDepartment(string departmentId)
        {
            return dal.GetDoctorsByDepartment(departmentId);
        }

        public List<DAL.DepartmentComboDTO> GetAllDepartments()
        {
            return dal.GetAllDepartments();
        }
    }
}
