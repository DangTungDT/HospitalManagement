using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Data Transfer Object cho Y lệnh (Medical Order).
    /// </summary>
    public class MedicalOrderDTO
    {
        /// <summary>
        /// Mã y lệnh (Khóa chính, tự tăng).
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Mã bệnh nhân (FK).
        /// </summary>
        public string PatientID { get; set; }

        /// <summary>
        /// Mã bác sĩ ra y lệnh (FK).
        /// </summary>
        public string DoctorID { get; set; }

        /// <summary>
        /// Loại y lệnh (ví dụ: Thuốc, Xét nghiệm).
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// Mã vật tư/thuốc (FK, có thể null).
        /// </summary>
        public string ItemID { get; set; }

        /// <summary>
        /// Mã loại xét nghiệm (FK, có thể null).
        /// </summary>
        public int? TestTypeID { get; set; }

        /// <summary>
        /// Liều lượng.
        /// </summary>
        public string Dosage { get; set; }

        /// <summary>
        /// Số lượng.
        /// </summary>
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Đơn vị tính.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Tần suất sử dụng.
        /// </summary>
        public string Frequency { get; set; }

        /// <summary>
        /// Ngày bắt đầu.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Ngày kết thúc (có thể null).
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Trạng thái của y lệnh (ví dụ: Active, Completed).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Thời gian tạo y lệnh.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Thời gian bác sĩ ký duyệt (có thể null).
        /// </summary>
        public DateTime? SignedAt { get; set; }

        /// <summary>
        /// Ghi chú thêm.
        /// </summary>
        public string Note { get; set; }

        // --- Các thuộc tính bổ sung để hiển thị trên DataGridView ---

        /// <summary>
        /// Tên bệnh nhân.
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// Tên bác sĩ.
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// Tên vật tư/thuốc.
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Tên xét nghiệm.
        /// </summary>
        public string TestName { get; set; }
    }

    public class LoaiYLenhDTO
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
    }
}
