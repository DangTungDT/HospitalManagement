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
    /// Lớp BLL cho Y lệnh, chứa các logic nghiệp vụ.
    /// </summary>
    public class MedicalOrderBLL
    {
        MedicalOrderDAL dal = new MedicalOrderDAL();

        public List<MedicalOrderDTO> GetAll() => dal.GetAll();

        #region "Lấy dữ liệu cho ComboBox"
        public List<PatientComboboxDTO> GetPatients() => dal.GetPatients();
        public List<StaffComboboxDTO> GetDoctors() => dal.GetDoctors();
        public List<ItemComboboxDTO> GetItems() => dal.GetItems();
        public List<LabTestComboboxDTO> GetLabTests() => dal.GetLabTests();
        #endregion

        /// <summary>
        /// Thêm y lệnh mới với các kiểm tra logic.
        /// </summary>
        public bool Add(MedicalOrderDTO mo)
        {
            // Quy tắc: Ngày kết thúc không được trước ngày bắt đầu
            if (mo.EndDate.HasValue && mo.StartDate.HasValue && mo.EndDate < mo.StartDate)
            {
                return false;
            }
            // Quy tắc: Số lượng (nếu có) phải lớn hơn 0
            if (mo.Quantity.HasValue && mo.Quantity <= 0)
            {
                return false;
            }

            return dal.Add(mo);
        }

        /// <summary>
        /// Cập nhật y lệnh với các kiểm tra logic.
        /// </summary>
        public bool Update(MedicalOrderDTO mo)
        {
            // Quy tắc: Ngày kết thúc không được trước ngày bắt đầu
            if (mo.EndDate.HasValue && mo.StartDate.HasValue && mo.EndDate < mo.StartDate)
            {
                return false;
            }
            // Quy tắc: Số lượng (nếu có) phải lớn hơn 0
            if (mo.Quantity.HasValue && mo.Quantity <= 0)
            {
                return false;
            }

            return dal.Update(mo);
        }

        /// <summary>
        /// Xóa y lệnh.
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        
    }
}
