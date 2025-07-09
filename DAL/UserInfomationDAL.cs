using System.Linq;
using DTO;

namespace DAL
{
    /// <summary>
    /// Data Access Layer cho thông tin nhân viên
    /// </summary>
    public class UserInfomationDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        /// <summary>
        /// Lấy thông tin nhân viên theo username tài khoản
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <returns>StaffDTO chứa thông tin nhân viên</returns>
        public StaffDTO GetStaffByUsername(string username)
        {
            var result = (from acc in db.Accounts
                          join s in db.Staffs on acc.staffID equals s.id
                          join d in db.Departments on s.departmentID equals d.id into dept
                          from d in dept.DefaultIfEmpty()
                          where acc.username == username
                          select new StaffDTO
                          {
                              Id = s.id,
                              Name = s.name,
                              Role = s.role,
                              Dob = s.dob,
                              Gender = s.gender,
                              PhoneNumber = s.phoneNumber,
                              Email = s.email,
                              HomeAddress = s.homeAddress,
                              CitizenID = s.citizenID,
                              DepartmentID = s.departmentID,
                              DepartmentName = d != null ? d.departmentName : string.Empty,
                              Position = s.position,
                              Qualification = s.qualification,
                              Degree = s.degree,
                              Status = s.status,
                              StartDate = s.startDate,
                              Notes = s.Notes
                          }).FirstOrDefault();
            return result;
        }
    }
}
