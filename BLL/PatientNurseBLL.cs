using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PatientNurseBLL
    {
        PatientNurseDAL dal = new PatientNurseDAL();
        public List<PatientNurseDTO> GetPatientsByDoctorDepartment(string doctorId)
        {
            return dal.GetPatientsByDoctorDepartment(doctorId);
        }
        public List<PatientNurseDTO> GetPatientsByDepartment(string departmentId)
        {
            return dal.GetPatientsByDepartment(departmentId);
        }

        // Tìm kiếm gần đúng theo tên, sđt, bhyt trong khoa
        public List<PatientNurseDTO> SearchPatientsByDoctorDepartment(string doctorId, string fullName, string phone, string insuranceId)
        {
            return dal.SearchPatientsByDoctorDepartment(doctorId, fullName, phone, insuranceId);
        }

        public string GetDepartmentIdOfLoggedInUser(string staffId)
        {
            return dal.GetDepartmentIdOfStaff(staffId);
        }
        public List<PatientListbyDepartmentDTO> GetPatientsByDepartmentt(string departmentId)
        {
            return dal.GetPatientsByDepartment_ForReport(departmentId);
        }

    }
}
