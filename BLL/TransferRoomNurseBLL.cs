using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TransferRoomNurseBLL
    {
        TransferRoomNurseDAL dal = new TransferRoomNurseDAL();

        public int? GetCurrentRoomId(string patientId) => dal.GetCurrentRoomId(patientId);

        public List<Room> GetRoomsInDepartment(string staffId) => dal.GetRoomsInDepartment(staffId);

        public void TransferRoom(string patientId, int? fromRoomId, int toRoomId, string note)
        {
            dal.TransferRoom(patientId, fromRoomId, toRoomId, note);
        }
    }
}
