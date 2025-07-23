using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Lớp Business Logic Layer (BLL) cho chức năng quản lý phân công Bác sĩ - Bệnh nhân.
    /// Là cầu nối giữa lớp giao diện (GUI) và lớp truy cập dữ liệu (DAL).
    /// Chứa các logic nghiệp vụ và quy tắc xác thực.
    /// </summary>
    public class DoctorPatientAdminBLL
    {
        // Khởi tạo một đối tượng của lớp DAL tương ứng
        DoctorPatientAdminDAL dal = new DoctorPatientAdminDAL();

        /// <summary>
        /// Lấy toàn bộ danh sách phân công. Chỉ đơn giản là gọi phương thức từ DAL.
        /// </summary>
        /// <returns>Danh sách các đối tượng DoctorPatientDTO.</returns>
        public List<DoctorPatientAdminDTO> GetAll() => dal.GetAll();

        /// <summary>
        /// Lấy danh sách các bác sĩ. Chỉ đơn giản là gọi phương thức từ DAL.
        /// </summary>
        /// <returns>Danh sách các đối tượng Staff.</returns>
        public List<Staff> GetDoctors() => dal.GetDoctors();

        /// <summary>
        /// Lấy danh sách các bệnh nhân. Chỉ đơn giản là gọi phương thức từ DAL.
        /// </summary>
        /// <returns>Danh sách các đối tượng Patient.</returns>
        public List<Patient> GetPatients() => dal.GetPatients();

        /// <summary>
        /// Xử lý logic để thêm một phân công mới.
        /// </summary>
        /// <param name="dp">Đối tượng DoctorPatientDTO chứa thông tin cần thêm.</param>
        /// <returns>True nếu thêm thành công, False nếu thất bại.</returns>
        public bool Add(DoctorPatientAdminDTO dp)
        {
            // ===== QUY TẮC NGHIỆP VỤ 1: Không cho phép thêm trùng lặp khóa chính =====
            if (dal.IsDuplicate(dp.doctorID, dp.patientID, dp.startDate))
            {
                // Nếu đã tồn tại, không cho thêm và trả về false
                return false;
            }

            // ===== QUY TẮC NGHIỆP VỤ 2: Ngày kết thúc phải sau hoặc bằng ngày bắt đầu =====
            if (dp.endDate.HasValue && dp.endDate < dp.startDate)
            {
                // Nếu ngày kết thúc không hợp lệ, trả về false
                return false;
            }

            // Nếu tất cả quy tắc đều hợp lệ, gọi DAL để thêm vào CSDL
            return dal.Add(dp);
        }

        /// <summary>
        /// Xử lý logic để cập nhật một phân công.
        /// </summary>
        /// <param name="dp">Đối tượng DoctorPatientDTO chứa thông tin cần cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, False nếu thất bại.</returns>
        public bool Update(DoctorPatientAdminDTO dp)
        {
            // ===== QUY TẮC NGHIỆP VỤ: Ngày kết thúc phải sau hoặc bằng ngày bắt đầu =====
            if (dp.endDate.HasValue && dp.endDate < dp.startDate)
            {
                // Nếu ngày kết thúc không hợp lệ, trả về false
                return false;
            }

            // Nếu hợp lệ, gọi DAL để cập nhật
            return dal.Update(dp);
        }

        /// <summary>
        /// Xử lý logic để xóa một phân công.
        /// Hiện tại chỉ gọi thẳng lớp DAL vì chưa có quy tắc nghiệp vụ phức tạp khi xóa.
        /// </summary>
        /// <param name="doctorId">Mã bác sĩ.</param>
        /// <param name="patientId">Mã bệnh nhân.</param>
        /// <param name="startDate">Ngày bắt đầu.</param>
        /// <returns>True nếu xóa thành công, False nếu thất bại.</returns>
        public bool Delete(string doctorId, string patientId, DateTime startDate)
        {
            return dal.Delete(doctorId, patientId, startDate);
        }
    }
}
