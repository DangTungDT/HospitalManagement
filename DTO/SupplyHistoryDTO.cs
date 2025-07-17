using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SupplyHistoryDTO
    {
        public string Id { get; set; }
        public string ItemID { get; set; }
        public int RoomID { get; set; }
        public string NurseID { get; set; }
        public string Dosage { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string Note { get; set; }

        public string PatientID { get; set; }
        public string TypeSupply { get; set; }
        public DateTime? DateSupply { get; set; }

        // Thông tin mô tả
        public string ItemName { get; set; }
        public string NurseName { get; set; }
        public string RoomName { get; set; }
        public string PatientName { get; set; }
    }
}
