using DAL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StaffBLL
    {
        //Biến toàn cục
        StaffDAL dal = new StaffDAL();

        public IQueryable LoadDepartment()
        {
            return dal.LoadDepartment();
        }
        public IQueryable GetAll()
        {
            return dal.GetAll();
        }
        public IQueryable GetStaffByDepartmentID(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                return dal.GetStaffByDepartmentID(id);
            }return null;
        }
        public int Add(StaffDTO staff)
        {
            try
            {
                //Kiểm tra dữ liệu đầu vào
                if(!IsValid(staff))
                {
                    return -2; //bắt dữ liệu không hợp lệ
                }

                return dal.Add(staff);
            }catch (Exception ex)
            {
                return 2; //Lỗi sảy ra khi đang tương tác lớp của DAL và BLL
            }
        }

        public bool Delete(string idDelete)
        {
            //Kiểm tra dữ liệu đầu vào
            if(string.IsNullOrEmpty(idDelete) || idDelete.Length > 10)
            {
                return false;
            }
            return dal.Delete(idDelete);
            
        }

        public bool Update(StaffDTO item)
        {
            //Kiểm tra dữ liệu đầu vào
            if (!IsValid(item))
            {
                return false; //bắt dữ liệu không hợp lệ
            }
            return dal.Update(item);
        }

        //Hàm kiểm tra dữ liệu hợp lệ
        private bool IsValid(StaffDTO staff)
        {
            //Kiểm tra tuổi (dưới 16 thì không được lao động nên sẽ không hợp lệ)
            int age = DateTime.Now.Year - staff.Dob.Year;
            if(staff.Dob > DateTime.Today.AddYears(-age))
            {
                age--;
                
            }
            if(age <16)
            {
                return false;
            }

            //Kiểm tra giá trị của các field trong đối tượng, không được null hay rỗng và StartDate bằng ngày hiện tại
            if(staff == null || string.IsNullOrEmpty(staff.Name) || string.IsNullOrEmpty(staff.Id) ||
                string.IsNullOrEmpty(staff.Role) || string.IsNullOrEmpty(staff.Gender) ||
                string.IsNullOrEmpty(staff.PhoneNumber) || string.IsNullOrEmpty(staff.Email) || string.IsNullOrEmpty(staff.HomeAddress) ||
                string.IsNullOrEmpty(staff.CitizenID) || string.IsNullOrEmpty(staff.DepartmentID) || string.IsNullOrEmpty(staff.Position) ||
                string.IsNullOrEmpty(staff.Qualification) || string.IsNullOrEmpty(staff.Degree) || string.IsNullOrEmpty(staff.Status) ||
                staff.StartDate.Date != DateTime.Now.Date || string.IsNullOrEmpty(staff.Notes) || staff.StartDate.Date != DateTime.Today)
            {
                return false;
            }
            return true;
        }
    }
}
