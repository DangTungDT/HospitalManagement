using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AppointmentBLL
    {
        AppointmentDAL dal = new AppointmentDAL();

        public List<AppointmentDTO> GetAll() => dal.GetAll();
        public void Add(AppointmentDTO dto) => dal.Add(dto);
        public void Update(AppointmentDTO dto) => dal.Update(dto);
        public void Delete(int id) => dal.Delete(id);
        public List<AppointmentDTO> Search(string doctorId, string patientId, string startDate, string status) =>
            dal.Search(doctorId, patientId, startDate, status);
        public bool CheckPatientExists(string patientId) => dal.IsPatientExists(patientId);
        public bool CheckDoctorExists(string nurseId) => dal.IsDoctorExists(nurseId);
        public List<DepartmentSupplyHistoryDTO> GetDepartments() => dal.GetDepartments();
        public List<StaffSupplyHistoryDTO> GetNursesByDepartment(string departmentId) => dal.GetNursesByDepartment(departmentId);
        public string GetDepartmentIdByStaffId(string staffId) => dal.GetDepartmentIdByStaffId(staffId);
        public List<PatientSupplyHistoryDTO> GetAllPatients() => dal.GetAllPatients();
    }
}
