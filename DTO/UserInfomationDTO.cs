using System;

namespace DTO
{
    /// <summary>
    /// Data Transfer Object cho thông tin nhân viên (Staff)
    /// </summary>
    public class UserInfomationDTO
    {
        /// <summary> Mã nhân viên </summary>
        public string Id { get; set; }
        /// <summary> Họ tên nhân viên </summary>
        public string Name { get; set; }
        /// <summary> Vai trò (Bác sĩ, Y tá, Admin, ...) </summary>
        public string Role { get; set; }
        /// <summary> Ngày sinh </summary>
        public DateTime? Dob { get; set; }
        /// <summary> Giới tính </summary>
        public string Gender { get; set; }
        /// <summary> Số điện thoại </summary>
        public string PhoneNumber { get; set; }
        /// <summary> Email </summary>
        public string Email { get; set; }
        /// <summary> Địa chỉ </summary>
        public string HomeAddress { get; set; }
        /// <summary> CCCD/CMND </summary>
        public string CitizenID { get; set; }
        /// <summary> Mã phòng ban </summary>
        public string DepartmentID { get; set; }
        /// <summary> Tên phòng ban </summary>
        public string DepartmentName { get; set; }
        /// <summary> Chức vụ </summary>
        public string Position { get; set; }
        /// <summary> Trình độ chuyên môn </summary>
        public string Qualification { get; set; }
        /// <summary> Bằng cấp </summary>
        public string Degree { get; set; }
        /// <summary> Trạng thái làm việc </summary>
        public string Status { get; set; }
        /// <summary> Ngày vào làm </summary>
        public DateTime? StartDate { get; set; }
        /// <summary> Ghi chú </summary>
        public string Notes { get; set; }
    }
}
