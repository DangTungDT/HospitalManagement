using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsersDTO
    {
        public int UserID { get; set; } // Khóa chính
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public string StaffID { get; set; }
        public string Status { get; set; }
    }
}
