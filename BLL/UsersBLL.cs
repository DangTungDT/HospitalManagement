using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsersBLL
    {
        UsersDAL dal = new UsersDAL();

        public UsersDTO GetAccountByUsername(string username) => dal.GetAccountByUsername(username);
        public List<UsersDTO> GetAllUsers() => dal.GetAllUsers();
        public bool AddUser(UsersDTO u) => dal.AddUser(u);
        public bool EditUser(UsersDTO u) => dal.EditUser(u);
        public bool DeleteUser(int userID) => dal.DeleteUser(userID);
        public bool IsUsernameUnique(string username) => dal.IsUsernameUnique(username);
        public List<UsersDTO> SearchUsersByUsername(string keyword) => dal.SearchUsersByUsername(keyword);
        public IQueryable Get() => dal.Get();
        public bool IsStaffAlreadyHasAccount(string staffId) => dal.CheckStaffHasAccount(staffId);
        public bool IsStaffExists(string staffId) => dal.IsStaffExists(staffId);
   

    }
}
