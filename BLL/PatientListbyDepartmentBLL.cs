using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class PatientListbyDepartmentBLL
    {
        private PatientListbyDepartmentDAL dal = new PatientListbyDepartmentDAL();

        public List<PatientListbyDepartmentDTO> GetPatientsByDepartment(string departmentId)
        {
            return dal.GetPatientsByDepartment(departmentId);
        }

        public List<DAL.DepartmentComboDTO> GetAllDepartments()
        {
            return dal.GetAllDepartments();
        }
    }
}
