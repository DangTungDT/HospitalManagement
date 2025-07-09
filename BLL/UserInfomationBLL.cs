using DTO;
using DAL;

namespace BLL
{
    /// <summary>
    /// Business Logic Layer cho thông tin nhân viên
    /// </summary>
    public class UserInfomationBLL
    {
        private UserInfomationDAL dal = new UserInfomationDAL();

        /// <summary>
        /// Lấy thông tin nhân viên theo username
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <returns>StaffDTO chứa thông tin nhân viên</returns>
        public StaffDTO GetStaffInfo(string username)
        {
            return dal.GetStaffByUsername(username);
        }
    }
}
