using DTO;
using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DAL
{
    public class AccountDAL
    {
        //Biến toàn cục
        HospitalManagementDataContext db = new HospitalManagementDataContext(GetFirstSqlServerInstanceName());


        //Hàm lấy chuỗi kết nối database
        public static string GetFirstSqlServerInstanceName()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            foreach (DataRow row in table.Rows)
            {
                string serverName = row["ServerName"].ToString();
                string instanceName = row["InstanceName"].ToString();

                string fullName = string.IsNullOrEmpty(instanceName)
                    ? serverName
                    : $"{serverName}\\{instanceName}";

                string stringConnection = $"Data Source={fullName};Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False";
                return stringConnection;
                //return "Data Source=DESKTOP-6LE6PT2\\SQLEXPRESS;Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False"; // Trả về instance đầu tiên tìm thấy

            }
            return "Data Source=DESKTOP-6LE6PT2\\SQLEXPRESS;Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False"; // Không tìm thấy
        }


        //Hàm lấy danh sách Account theo Username
        public IQueryable Find(string username)
        {
            try
            {
                IQueryable queryable = from ac in db.Accounts
                                      join nv in db.Staffs on ac.staffID equals nv.id
                                      join pb in db.Departments on nv.departmentID equals pb.id
                                      where ac.username.Contains(username)
                                      select new
                                      {
                                          AccountID = ac.id,
                                          ac.username,
                                          ac.password,
                                          ac.staffID,
                                          nv.name,
                                          ac.startDate,
                                          ac.status,
                                          DepartmentID = pb.id
                                      };
                return queryable;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        //Hàm lấy dữ liệu theo username
        private Account Exists(string username)
        {
            Account itemSelect = db.Accounts.Where(x => x.username == username).FirstOrDefault();
            if (itemSelect == null)
            {
                return null; //dữ liệu không tồn tại
            }
            return itemSelect; //Lấy thành công
        }

        //Hàm lấy tất cả dữ liệu trong bảng
        public IQueryable GetAll()
        {
            try
            {
                //IQueryable accounts = db.Accounts.Select(x => new
                //{
                //    x.id,
                //    x.username,
                //    x.startDate,

                //    x.status
                //});

                IQueryable accounts = from ac in db.Accounts
                                      join nv in db.Staffs on ac.staffID equals nv.id
                                      join pb in db.Departments on nv.departmentID equals pb.id
                                      select new
                                      {
                                          AccountID = ac.id,
                                          ac.username,
                                          ac.password,
                                          ac.staffID,
                                          nv.name,
                                          ac.startDate,
                                          ac.status,
                                          DepartmentID = pb.id
                                      };

                if (accounts !=null)
                {
                    return accounts;
                }
                return null; //Lấy thất bại
            }catch (Exception ex)
            {
                return null; //Có lỗi trong quá trình lấy
            }
        }

        //Hàm thêm 1 dòng dữ liệu vào bảng
        public int Add(AccountDTO dto)
        {
            try
            {
                if(Exists(dto.Username) != null)
                {
                    return -1; //Usernme đã tồn tại trong database
                }
                Account newAccount = new Account()
                {
                    username = dto.Username,
                    password = dto.Password,
                    startDate = dto.StartDate,
                    staffID = dto.StaffID,
                    status = dto.Status
                };
                db.Accounts.InsertOnSubmit(newAccount);
                db.SubmitChanges();
                return 0; //Thêm thành công
            }catch(Exception ex)
            {
                return 1; //Lỗi sảy ra trong qua trình thêm
            }
        }


        //Check foreign key
        public bool CheckForeignKey(string staffID)
        {
            Staff check = db.Staffs.Where(x=> x.id == staffID).FirstOrDefault();
            if (check != null)
            {
                return true;
            }
            return false;
        }

        //Hàm xóa 1 item theo id
        public bool Delete(int id)
        {
            try
            {
                Account itemDelete = db.Accounts.Where(x => x.id == id).FirstOrDefault();
                if(CheckForeignKey(itemDelete.staffID))
                {
                    return false; //Dữ liệu xóa liên quan đến các dữ liệu khác
                }
                if (itemDelete != null)
                {
                    db.Accounts.DeleteOnSubmit(itemDelete);
                    return true; //Xóa thành công
                }
                return false; // dữ liệu không có trong database
            }
            catch (Exception ex)
            {
                return false; //Có lỗi trong quá trình cập nhật
            }

        }

        //Hàm xóa 1 item theo Username
        public bool Delete(string username)
        {
            try
            {
                Account itemDelete = db.Accounts.Where(x => x.username == username).FirstOrDefault();
                if (itemDelete != null)
                {
                    db.Accounts.DeleteOnSubmit(itemDelete);
                    return true; //Xóa thành công
                }
                return false; // dữ liệu không có trong database
            }
            catch(Exception ex)
            {
                return false; //Có lỗi trong quá trình cập nhật
            }
        }

        //Hàm cập nhật 1 dòng dữ liệu
        public bool Update(AccountDTO item)
        {
            try
            {
                Account itemUpdate = db.Accounts.Where(x =>x.id == item.Id || x.username.Trim() == item.Username.Trim()).FirstOrDefault();
                if (itemUpdate == null)
                {
                    return false; //Dữ liệu không có để cập nhật
                }
                itemUpdate.password = item.Password;
                itemUpdate.startDate = item.StartDate;
                itemUpdate.staffID = item.StaffID;
                itemUpdate.status = item.Status;
                db.SubmitChanges();
                return true; //Cập nhật thành công
            }
            catch (Exception ex)
            {
                return false; //Có lỗi trong quá trình update
            }
            
        }

        //Hàm xóa tất cả dữ liệu
        public bool DeleteAll()
        {
            try
            {
                db.Accounts.DeleteAllOnSubmit(db.Accounts);
                return true; //Xóa thành công
            }catch(Exception ex)
            {
                return false; //Có lỗi sảy ra trong quá trình giao tiếp database
            }
        }

        //Hàm lấy khoa
        public IQueryable GetAllDepartment()
        {
            try
            {
                return db.Departments.Select(x => x);

            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
