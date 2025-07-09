using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// Lớp BLL cho Xét nghiệm, chứa các logic nghiệp vụ.
    /// </summary>
    public class LaboratoryTestBLL
    {
        LaboratoryTestDAL dal = new LaboratoryTestDAL();
        MedicalOrderDAL commonDal = new MedicalOrderDAL(); // Dùng lại DAL của MedicalOrder để lấy danh sách cho ComboBox

        /// <summary>
        /// Lấy tất cả kết quả xét nghiệm.
        /// </summary>
        public List<LaboratoryTestDTO> GetAll() => dal.GetAll();

        /// <summary>
        /// Lấy danh sách bệnh nhân cho ComboBox.
        /// </summary>
        public List<PatientComboboxDTO> GetPatients() => commonDal.GetPatients();

        /// <summary>
        /// Lấy danh sách bác sĩ cho ComboBox.
        /// </summary>
        public List<StaffComboboxDTO> GetDoctors() => commonDal.GetDoctors();

        /// <summary>
        /// Thêm kết quả xét nghiệm.
        /// </summary>
        public bool Add(LaboratoryTestDTO dto)
        {
            // Có thể thêm các quy tắc kiểm tra dữ liệu ở đây
            if (string.IsNullOrWhiteSpace(dto.testName) || string.IsNullOrWhiteSpace(dto.patientID) || string.IsNullOrWhiteSpace(dto.doctorID))
            {
                return false; // Trả về false nếu thiếu thông tin bắt buộc
            }
            return dal.Add(dto);
        }

        /// <summary>
        /// Cập nhật kết quả xét nghiệm.
        /// </summary>
        public bool Update(LaboratoryTestDTO dto)
        {
            // Có thể thêm các quy tắc kiểm tra dữ liệu ở đây
            if (string.IsNullOrWhiteSpace(dto.testName) || string.IsNullOrWhiteSpace(dto.patientID) || string.IsNullOrWhiteSpace(dto.doctorID))
            {
                return false;
            }
            return dal.Update(dto);
        }

        /// <summary>
        /// Xóa kết quả xét nghiệm.
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// Lấy danh sách loại xét nghiệm.
        /// </summary>
        public List<LabTestTypeDTO> GetLabTestTypes()
        {
            return dal.GetLabTestTypes();
        }
    }
}
