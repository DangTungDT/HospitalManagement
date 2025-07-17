using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PatientDTO
    {
        public string Id { get; set; }                // Mã bệnh nhân
        public string FullName { get; set; }          // Họ tên
        public string Gender { get; set; }           // Giới tính: Nam/Nữ/Khác
        public DateTime? Dob { get; set; }            // Ngày sinh
        public string PhoneNumber { get; set; }      // Số điện thoại
        public string TypePatient { get; set; }      // Số điện thoại
        public string CitizenID { get; set; }        // CCCD/CMND
        public string InsuranceID { get; set; }      // Mã bảo hiểm y tế
        public string Address { get; set; }          // Địa chỉ
        public string EmergencyContact { get; set; } // Người liên hệ khẩn cấp
        public string EmergencyPhone { get; set; }   // SĐT liên hệ khẩn cấp
        public string Status { get; set; }           // Trạng thái điều trị
        public DateTime CreatedDate { get; set; }    // Ngày tạo
        public DateTime UpdatedDate { get; set; }    // Ngày cập nhật
        public double Weight { get; set; }           // Cân nặng (kg)
        public double Height { get; set; }           // Chiều cao (cm)
    }
}
