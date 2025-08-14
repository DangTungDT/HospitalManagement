using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DepartmentInfoDoctorBLL
    {
        private DepartmentInfoDoctorDAL dal = new DepartmentInfoDoctorDAL();

        public DepartmentInfoDoctorDTO GetDepartmentInfoByDoctorID(string doctorID)
        {
            return dal.GetDepartmentInfoByDoctorID(doctorID);
        }

        public DepartmentInfoDoctorDTO GetDepartmentInfoByUsername(string username)
        {
            return dal.GetDepartmentInfoByUsername(username);
        }

        public List<DepartmentInfoDoctorDTO> GetAllDepartments()
        {
            return dal.GetAllDepartments();
        }
    }
}
