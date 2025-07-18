using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        //Hàm lấy account theo username
        public UsersDTO GetAccountByUsername(string username)
        {
            return db.Accounts.Where(x=> x.username == username).Select(x=> new UsersDTO
            {
                UserID = x.id,
                Username = x.username,
                PasswordHash = x.password,
                StaffID = x.staffID,
                StartDate = x.startDate,
                Status = x.status

            }).FirstOrDefault();
        }
        //Hàm lấy danh sách User
        public List<UsersDTO> GetAllUsers()
        {
            return db.Accounts.Select(a => new UsersDTO
            {
                UserID = a.id,
                Username = a.username.Trim(),
                StartDate = a.startDate ?? new DateTime(1753, 1, 1),
                StaffID = a.staffID.Trim(),
                Status = a.status.Trim()
            }).ToList();
        }
        public IQueryable Get()
        {
            var dal = from el in db.Staffs
                      select el;
            return dal;
        }
        //Hàm thêm User
        public bool AddUser(UsersDTO u)
        {
            try
            {
                var newUser = new Account
                {
                    username = u.Username,
                    password = HashPassword(u.PasswordHash),
                    startDate = u.StartDate,
                    staffID = u.StaffID,
                    status = u.Status
                };

                db.Accounts.InsertOnSubmit(newUser);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Hàm sửa User
        public bool EditUser(UsersDTO u)
        {
            try
            {
                var existing = db.Accounts.SingleOrDefault(x => x.id == u.UserID);
                if (existing == null) return false;

                existing.username = u.Username;
                existing.password = HashPassword(u.PasswordHash);
                existing.startDate = u.StartDate;
                existing.status = u.Status;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Hàm xóa User
        public bool DeleteUser(int userID)
        {
            try
            {
                var user = db.Accounts.SingleOrDefault(u => u.id == userID);
                if (user == null) return false;

                string staffId = user.staffID;

                if (!string.IsNullOrEmpty(staffId))
                {
                    // Xử lý các liên kết đến Staff (doctors, nurses...)

                    // Appointment (Doctor)
                    var appointments = db.Appointments.Where(a => a.doctorID == staffId);
                    db.Appointments.DeleteAllOnSubmit(appointments);

                    // DailyCare (Nurse)
                    var dailyCares = db.DailyCares.Where(dc => dc.nurseID == staffId);
                    db.DailyCares.DeleteAllOnSubmit(dailyCares);

                    // MedicalOrder
                    var medicalOrders = db.MedicalOrders.Where(mo => mo.DoctorID == staffId);
                    db.MedicalOrders.DeleteAllOnSubmit(medicalOrders);

                    // DoctorPatient
                    var doctorPatients = db.DoctorPatients.Where(dp => dp.doctorID == staffId);
                    db.DoctorPatients.DeleteAllOnSubmit(doctorPatients);

                    // MedicalRecord
                    var medicalRecords = db.MedicalRecords.Where(mr => mr.doctorID == staffId);
                    db.MedicalRecords.DeleteAllOnSubmit(medicalRecords);

                    //// LaboratoryTest
                    //var labTests = db.LaboratoryTests.Where(lt => lt.doctorID == staffId);
                    //db.LaboratoryTests.DeleteAllOnSubmit(labTests);

                    // SupplyHistory (nurse)
                    var supplyHistories = db.SupplyHistories.Where(sh => sh.nurseID == staffId);
                    db.SupplyHistories.DeleteAllOnSubmit(supplyHistories);

                    //// Cuối cùng xóa bản ghi Staff
                    //var staff = db.Staffs.SingleOrDefault(s => s.id == staffId);
                    //if (staff != null)
                    //{
                    //    db.Staffs.DeleteOnSubmit(staff);
                    //}
                }

                // Xóa tài khoản Account
                db.Accounts.DeleteOnSubmit(user);

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Kiểm tra nhân viên có tồn tại trong hệ thống không
        public bool IsStaffExists(string staffId)
        {
            return db.Staffs.Any(s => s.id == staffId);
        }
        // Hàm kiểm tra nhân viên đã có tài khoản hay chưa
        public bool CheckStaffHasAccount(string staffId)
        {
            var existingAccount = db.Accounts.FirstOrDefault(a => a.staffID == staffId);
            return existingAccount != null;
        }
        // Kiểm tra username đã tồn tại chưa
        public bool IsUsernameUnique(string username)
        {
            return !db.Accounts.Any(u => u.username == username);
        }
        // Lấy danh sách người dùng có Username chứa chuỗi tìm kiếm
        public List<UsersDTO> SearchUsersByUsername(string keyword)
        {
            return db.Accounts
                     .Where(a => a.username.Contains(keyword))
                     .Select(a => new UsersDTO
                     {
                         UserID = a.id,
                         Username = a.username.Trim(),
                         PasswordHash = a.password.Trim(),
                         StartDate = a.startDate ?? new DateTime(1753, 1, 1),
                         StaffID = a.staffID.Trim(),
                         Status = a.status.Trim()
                     }).ToList();
        }
        //Hàm mã hóa
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2"));
                }
                return result.ToString();
            }
        }
    }
}
