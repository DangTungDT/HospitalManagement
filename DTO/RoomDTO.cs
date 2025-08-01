using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomDTO
    {
        private int ID;
        private string roomName;
        private int bedCount;
        private string departmentID;

        public RoomDTO(int iD, string roomName, int bedCount, string departmentID)
        {
            ID = iD;
            this.roomName = roomName;
            this.bedCount = bedCount;
            this.departmentID = departmentID;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public int BedCount { get => bedCount; set => bedCount = value; }
        public string DepartmentID { get => departmentID; set => departmentID = value; }
        public RoomDTO() { }
    }
}
