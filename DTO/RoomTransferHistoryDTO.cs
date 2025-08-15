using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomTransferHistoryDTO
    {
        public int Id { get; set; }
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public string FromRoomName { get; set; }
        public string ToRoomName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime TransferDate { get; set; }
        public string Note { get; set; }
    }
}
