using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// Lớp BLL cho Hồ sơ bệnh án, chứa các logic nghiệp vụ.
    /// </summary>
    public class MedicalRecordBLL
    {
        MedicalRecordDAL dal = new MedicalRecordDAL();
        MedicalOrderDAL commonDal = new MedicalOrderDAL(); // Tái sử dụng để lấy danh sách cho ComboBox

        /// <summary>
        /// Lấy tất cả hồ sơ bệnh án.
        /// </summary>
        public List<MedicalRecordDTO> GetAll() => dal.GetAll();

        /// <summary>
        /// Lấy danh sách bệnh nhân cho ComboBox.
        /// </summary>
        public List<PatientComboboxDTO> GetPatients() => commonDal.GetPatients();

        /// <summary>
        /// Lấy danh sách bác sĩ cho ComboBox.
        /// </summary>
        public List<StaffComboboxDTO> GetDoctors() => commonDal.GetDoctors();

        /// <summary>
        /// Thêm hồ sơ bệnh án mới.
        /// </summary>
        public bool Add(MedicalRecordDTO dto)
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(dto.patientID) || string.IsNullOrWhiteSpace(dto.doctorID))
            {
                return false;
            }
            // Gán ngày tạo là ngày hiện tại nếu chưa có
            if (!dto.createdDate.HasValue)
            {
                dto.createdDate = System.DateTime.Now;
            }
            return dal.Add(dto);
        }

        /// <summary>
        /// Cập nhật hồ sơ bệnh án.
        /// </summary>
        public bool Update(MedicalRecordDTO dto)
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(dto.patientID) || string.IsNullOrWhiteSpace(dto.doctorID))
            {
                return false;
            }
            return dal.Update(dto);
        }

        /// <summary>
        /// Xóa hồ sơ bệnh án.
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
