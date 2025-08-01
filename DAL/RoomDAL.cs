using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        public IQueryable Hienthi()
        {
            IQueryable Room = (from room in db.Rooms
                               select new { room.id, room.roomName, room.bedCount, room.departmentID });
            return Room;
        }
        public IQueryable LayDepartment()
        {
            IQueryable DPM = (from dpm in db.Departments
                              select new { dpm.id, dpm.departmentName });
            return DPM;
        }
        public bool ThemRoom(RoomDTO dtoroom)
        {
            if (db.Rooms.Any(sp => sp.roomName == dtoroom.RoomName && sp.departmentID == dtoroom.DepartmentID))
            {
                return false;
            }
            try
            {
                Room room = new Room
                {
                    roomName = dtoroom.RoomName,
                    bedCount = dtoroom.BedCount,
                    departmentID = dtoroom.DepartmentID,
                };
                db.Rooms.InsertOnSubmit(room);
                return true;
            }
            finally
            {
                db.SubmitChanges();
            }
        }
        public bool Xoaroom(int maRoom)
        {
            try
            {
                if (db.DailyCares.Any(sp => sp.roomID == maRoom) || db.SupplyHistories.Any(sp => sp.roomID == maRoom))
                {
                    return false;
                }
                var xoa = from room in db.Rooms
                          where room.id == maRoom
                          select room;
                foreach (var x in xoa)
                {
                    db.Rooms.DeleteOnSubmit(x);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547)
                {
                    return false;
                }
                return false;
            }
        }
        public bool CapnhatRoom(RoomDTO dtoroom)
        {
            try
            {
                var room = db.Rooms.SingleOrDefault(x => x.id == dtoroom.ID1);
                if (room != null)
                {
                    room.roomName = dtoroom.RoomName;
                    room.bedCount = dtoroom.BedCount;
                    room.departmentID = dtoroom.DepartmentID; // Ensure type matches
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., to a file or console for debugging)
                Console.WriteLine($"Error updating room: {ex.Message}");
                return false;
            }
        }
    }
}

