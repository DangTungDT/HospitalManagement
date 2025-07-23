using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Lớp Data Access Layer (DAL) cho bảng DoctorPatient.
    /// Chứa các phương thức để tương tác trực tiếp với cơ sở dữ liệu.
    /// </summary>
    public class DoctorPatientAdminDAL
    {
        // Khởi tạo đối tượng DataContext của LINQ to SQL
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        /// <summary>
        /// Lấy tất cả các bản ghi phân công từ cơ sở dữ liệu.
        /// Sử dụng LINQ để join các bảng DoctorPatient, Staff, và Patient để lấy tên.
        /// </summary>
        /// <returns>Một danh sách các đối tượng DoctorPatientDTO.</returns>
        public List<DoctorPatientAdminDTO> GetAll()
        {
            // Join 3 bảng để lấy thông tin đầy đủ cho việc hiển thị
            var query = from dp in db.DoctorPatients
                        join doc in db.Staffs on dp.doctorID equals doc.id // Join với bảng Staff để lấy tên bác sĩ
                        join pat in db.Patients on dp.patientID equals pat.id // Join với bảng Patient để lấy tên bệnh nhân
                        orderby dp.startDate descending // Sắp xếp theo ngày bắt đầu giảm dần
                        select new DoctorPatientAdminDTO
                        {
                            doctorID = dp.doctorID,
                            patientID = dp.patientID,
                            startDate = (DateTime)dp.startDate,
                            endDate = dp.endDate,
                            role = dp.role,
                            note = dp.note,
                            doctorName = doc.name, // Lấy tên bác sĩ
                            patientName = pat.fullName // Lấy tên bệnh nhân
                        };
            return query.ToList();
        }

        /// <summary>
        /// Lấy danh sách tất cả các nhân viên có vai trò là "Bác sĩ".
        /// Dùng để điền vào ComboBox chọn bác sĩ.
        /// </summary>
        /// <returns>Danh sách các đối tượng Staff.</returns>
        public List<Staff> GetDoctors()
        {
            return db.Staffs.Where(s => s.role == "Bác sĩ").ToList();
        }

        /// <summary>
        /// Lấy danh sách tất cả bệnh nhân.
        /// Dùng để điền vào ComboBox chọn bệnh nhân.
        /// </summary>
        /// <returns>Danh sách các đối tượng Patient.</returns>
        public List<Patient> GetPatients()
        {
            return db.Patients.ToList();
        }

        /// <summary>
        /// Thêm một bản ghi phân công mới vào cơ sở dữ liệu.
        /// </summary>
        /// <param name="dp">Đối tượng DoctorPatientDTO chứa thông tin cần thêm.</param>
        /// <returns>True nếu thêm thành công, False nếu thất bại.</returns>
        public bool Add(DoctorPatientAdminDTO dp)
        {
            try
            {
                // Tạo một đối tượng DoctorPatient (từ LINQ to SQL) từ DoctorPatientDTO
                DoctorPatient newDp = new DoctorPatient
                {
                    doctorID = dp.doctorID,
                    patientID = dp.patientID,
                    startDate = dp.startDate,
                    endDate = dp.endDate,
                    role = dp.role,
                    note = dp.note
                };
                // Thêm vào hàng đợi và lưu thay đổi
                db.DoctorPatients.InsertOnSubmit(newDp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                // Nếu có lỗi (ví dụ: vi phạm khóa chính), trả về false
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin một bản ghi phân công đã có.
        /// </summary>
        /// <param name="dp">Đối tượng DoctorPatientDTO chứa thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, False nếu thất bại.</returns>
        public bool Update(DoctorPatientAdminDTO dp)
        {
            try
            {
                // Tìm bản ghi hiện có dựa trên khóa chính phức hợp
                DoctorPatient existingDp = db.DoctorPatients.SingleOrDefault(d => d.doctorID == dp.doctorID && d.patientID == dp.patientID && d.startDate == dp.startDate);
                if (existingDp == null) return false; // Không tìm thấy bản ghi

                // Cập nhật các trường có thể thay đổi
                existingDp.endDate = dp.endDate;
                existingDp.role = dp.role;
                existingDp.note = dp.note;

                // Lưu thay đổi
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                // Nếu có lỗi, trả về false
                return false;
            }
        }

        /// <summary>
        /// Xóa một bản ghi phân công khỏi cơ sở dữ liệu.
        /// </summary>
        /// <param name="doctorId">Mã bác sĩ của bản ghi cần xóa.</param>
        /// <param name="patientId">Mã bệnh nhân của bản ghi cần xóa.</param>
        /// <param name="startDate">Ngày bắt đầu của bản ghi cần xóa.</param>
        /// <returns>True nếu xóa thành công, False nếu thất bại.</returns>
        public bool Delete(string doctorId, string patientId, DateTime startDate)
        {
            try
            {
                // Tìm bản ghi cần xóa dựa trên khóa chính
                DoctorPatient dpToDelete = db.DoctorPatients.SingleOrDefault(d => d.doctorID == doctorId && d.patientID == patientId && d.startDate == startDate);
                if (dpToDelete == null) return false; // Không tìm thấy

                // Xóa khỏi hàng đợi và lưu thay đổi
                db.DoctorPatients.DeleteOnSubmit(dpToDelete);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                // Nếu có lỗi, trả về false
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra xem một bản ghi phân công đã tồn tại trong CSDL hay chưa.
        /// Dùng để ngăn ngừa việc tạo bản ghi trùng lặp (dựa trên khóa chính).
        /// </summary>
        /// <param name="doctorId">Mã bác sĩ.</param>
        /// <param name="patientId">Mã bệnh nhân.</param>
        /// <param name="startDate">Ngày bắt đầu.</param>
        /// <returns>True nếu đã tồn tại, False nếu chưa.</returns>
        public bool IsDuplicate(string doctorId, string patientId, DateTime startDate)
        {
            return db.DoctorPatients.Any(d => d.doctorID == doctorId && d.patientID == patientId && d.startDate == startDate);
        }
    }
}
