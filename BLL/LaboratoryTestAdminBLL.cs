using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// Lớp BLL cho Xét nghiệm, chứa các logic nghiệp vụ.
    /// </summary>
    public class LaboratoryTestAdminBLL
    {
        LaboratoryTestDAL dal = new LaboratoryTestDAL();
        MedicalOrderDAL commonDal = new MedicalOrderDAL(); // Dùng lại DAL của MedicalOrder để lấy danh sách cho ComboBox

        /// <summary>
        /// Lấy tất cả kết quả xét nghiệm.
        /// </summary>
        public List<LaboratoryTestDTO> GetAll() => dal.GetAll();

        // Lấy danh sách y lệnh cho combobox
        public List<MedicalOrderComboDTO> GetMedicalOrdersForLabTest() => dal.GetMedicalOrdersForLabTest();

        // Lấy danh sách loại xét nghiệm
        public List<LabTestTypeDTO> GetLabTestTypes() => dal.GetLabTestTypes();

        // Thêm kết quả xét nghiệm
        public bool Add(LaboratoryTestDTO dto)
        {
            if (dto.MedicalOrderID <= 0)
                return false;
            return dal.Add(dto);
        }

        // Cập nhật kết quả xét nghiệm
        public bool Update(LaboratoryTestDTO dto)
        {
            if (dto.MedicalOrderID <= 0)
                return false;
            return dal.Update(dto);
        }

        public bool Delete(int id) => dal.Delete(id);
    }
}
