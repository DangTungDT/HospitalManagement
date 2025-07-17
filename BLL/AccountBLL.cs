using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBLL
    {
        //Biến toàn cục
        AccountDAL dal = new DAL.AccountDAL();

        //Hàm lấy tất cả dữ liệu Department
        public IQueryable GetAllDepartment()
        {
            return dal.GetAllDepartment();
        }

        //Hàm tìm kiếm theo username (tương đối)
        public IQueryable Find(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return dal.Find(username);
        }

        //Hàm lấy tất cả dữ liệu trong bảng
        public IQueryable GetAll()
        {
            try
            {
                return dal.GetAll();
            }catch(Exception ex)
            {
                return null;
            }
                
        }

        //Hàm thêm 1 dòng dữ liệu vào bảng
        public int Add(AccountDTO dto)
        {
            try
            {
                if (dto == null || string.IsNullOrEmpty(dto.Username) || string.IsNullOrEmpty(dto.Password) ||
                    string.IsNullOrEmpty(dto.StaffID) || string.IsNullOrEmpty(dto.Status) || dto.StartDate.Date != DateTime.Now.Date ||
                    dto.Username.Length > 50 || dto.Password.Length > 255 || dto.StaffID.Length > 10 || dto.Status.Length > 100)
                {
                    return -2; // dữ liệu nhập không hợp lệ
                }
                return dal.Add(dto);
            }
            catch (Exception ex)
            {
                return 2; //Lỗi sảy ra trong quá trình kết nối 2 lớp
            }
        }

        //Hàm xóa 1 item theo id
        public bool Delete(int id)
        {
            try
            {
                if(id>0)
                {
                    return dal.Delete(id);
                }
                return false;
                
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
                if(string.IsNullOrEmpty(username) || username.Length> 50)
                {
                    return false; //Dữ liệu không hợp lệ
                }
                return dal.Delete(username);
            }
            catch (Exception ex)
            {
                return false; //Có lỗi trong quá trình cập nhật
            }
        }

        //Hàm cập nhật 1 dòng dữ liệu
        public bool Update(AccountDTO dto)
        {
            try
            {
                if (dto == null || string.IsNullOrEmpty(dto.Username) || string.IsNullOrEmpty(dto.Password) ||
                    string.IsNullOrEmpty(dto.StaffID) || string.IsNullOrEmpty(dto.Status) || dto.StartDate.Date != DateTime.Now.Date ||
                    dto.Username.Length > 50 || dto.Password.Length > 255 || dto.StaffID.Length > 10 || dto.Status.Length > 100)
                {
                    return false; // dữ liệu nhập không hợp lệ
                }
                return dal.Update(dto);
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
                return dal.DeleteAll();
            }
            catch (Exception ex)
            {
                return false; //Có lỗi sảy ra trong quá trình giao tiếp database
            }
        }
    }
}
