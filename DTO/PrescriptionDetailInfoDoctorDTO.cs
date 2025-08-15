using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PrescriptionDetailInfoDoctorDTO
    {
        public int MedicalOrderID { get; set; }
        public string PrescriptionID { get; set; }
        public string ItemID { get; set; }
        
        public decimal Quantity { get; set; }
        
        public string Unit { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Note { get; set; }
        
        // Thêm properties để hiển thị tên thay vì mã
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public decimal Price { get; set; }
    }

    // DTO cho ComboBox đơn thuốc
    public class PrescriptionComboDTO
    {
        public string PrescriptionID { get; set; }
        public string PrescriptionName { get; set; }
    }

    // DTO cho ComboBox thuốc
    public class ItemComboDTO
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
    }
}
