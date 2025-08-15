using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class PrescriptionDetailInfoDoctorBLL
    {
        private PrescriptionDetailInfoDoctorDAL dal = new PrescriptionDetailInfoDoctorDAL();

        // Lấy tất cả chi tiết đơn thuốc
        public List<PrescriptionDetailInfoDoctorDTO> GetAll()
        {
            return dal.GetAll();
        }

        // Lấy chi tiết đơn thuốc theo mã đơn thuốc
        public List<PrescriptionDetailInfoDoctorDTO> GetByPrescriptionID(string prescriptionID)
        {
            return dal.GetByPrescriptionID(prescriptionID);
        }

        // Thêm chi tiết đơn thuốc mới
        public bool Insert(PrescriptionDetailInfoDoctorDTO dto)
        {
            return dal.Insert(dto);
        }

        // Cập nhật chi tiết đơn thuốc
        public bool Update(PrescriptionDetailInfoDoctorDTO dto)
        {
            return dal.Update(dto);
        }

        // Xóa chi tiết đơn thuốc
        public bool Delete(string medicalOrderID)
        {
            return dal.Delete(medicalOrderID);
        }

        // Lấy danh sách đơn thuốc cho ComboBox
        public List<PrescriptionComboDTO> GetPrescriptions()
        {
            return dal.GetPrescriptions();
        }

        // Lấy danh sách thuốc cho ComboBox
        public List<ItemComboDTO> GetItems()
        {
            return dal.GetItems();
        }
    }
}
