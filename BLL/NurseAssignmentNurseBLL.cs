using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NurseAssignmentNurseBLL
    {
        private NurseAssignmentNurseDAL dal = new NurseAssignmentNurseDAL();

        public List<NurseAssignmentNurseDTO> GetAssignmentsInSameDepartment(string nurseId)
        {
            return dal.GetAssignmentsInSameDepartment(nurseId);
        }

        public bool AddAssignment(NurseAssignmentNurseDTO dto)
        {
            return dal.InsertAssignment(dto);
        }

        public bool UpdateAssignment(NurseAssignmentNurseDTO dto, string oldDoctorId, string oldPatientId, DateTime oldStartDate)
        {
            // Do không được sửa khóa chính → xóa + thêm lại
            bool deleted = dal.DeleteAssignment(oldDoctorId, oldPatientId, oldStartDate);
            if (!deleted) return false;
            return dal.InsertAssignment(dto);
        }

        public bool DeleteAssignment(string doctorId, string patientId, DateTime startDate)
        {
            return dal.DeleteAssignment(doctorId, patientId, startDate);
        }
        public bool IsDoctorPatientExists(string doctorId, string patientId, DateTime startDate)
        {
            return dal.IsDoctorPatientExists(doctorId, patientId, startDate);
        }
        public List<NurseAssignmentNurseDTO> GetNursesInSameDepartment(string nurseId)
        {
            return dal.GetNursesInSameDepartment(nurseId);
        }
        public List<NurseAssignmentNurseDTO> SearchAssignmentsByNurseAndPatient(string nurseId, string patientId)
        {
            return dal.SearchAssignmentsByNurseAndPatient(nurseId, patientId);
        }
        public bool UpdateAssignment(NurseAssignmentNurseDTO dto)
        {
            // Kiểm tra dữ liệu trước khi gọi DAL
            if (string.IsNullOrWhiteSpace(dto.DoctorID) || string.IsNullOrWhiteSpace(dto.PatientID))
                throw new ArgumentException("Thiếu thông tin bác sĩ hoặc bệnh nhân.");

            if (dto.EndDate.HasValue && dto.EndDate.Value < dto.StartDate)
                throw new ArgumentException("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.");

            return dal.UpdateAssignment(dto);
        }

    }
}
