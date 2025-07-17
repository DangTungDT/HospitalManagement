using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        //Field
        int id;
        string username, password, staffID, status;
        DateTime startDate;


        //Constructor (Dùng để tạo 1 account mới)
        public AccountDTO(string username, string password, string staffID, string status)
        {
            this.Username = username;
            this.Password = password;
            this.StaffID = staffID;
            this.Status = status;
            startDate = DateTime.Now;
        }

        //Constructor (Dùng để tạo account có đầy đủ thông tin và chứa luôn id của account)
        public AccountDTO(int id, string username, string password, string staffID, string status, DateTime startDate)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.staffID = staffID;
            this.status = status;
            this.startDate = startDate;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string StaffID { get => staffID; set => staffID = value; }
        public string Status { get => status; set => status = value; }
        public DateTime StartDate { get => startDate; set => startDate = DateTime.Now; }
    }
}
