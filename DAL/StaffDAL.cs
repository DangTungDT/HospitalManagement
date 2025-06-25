using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StaffDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();
        public IQueryable GetAll()
        {
            return from nv in db.Staffs select nv;
        }

        private Staff Exists(string id)
        {
            Staff itemSelect = (from nv in db.Staffs where nv.id == id select nv).First();
            if(itemSelect == null)
            {
                return null;
            }
            return itemSelect;
        }
        public int Add(StaffDTO staff)
        {
            try
            {
                if(Exists(staff.Id) != null)
                {
                    return -1; //Đối tượng muốn thêm đã tồn tại trong database
                }
                Staff newStaff = new Staff
                {
                    id = staff.Id,
                    name = staff.Name,
                    role = staff.Role,
                    dob = staff.Dob,
                    gender = staff.Gender,
                    phoneNumber = staff.PhoneNumber,
                    email = staff.Email,
                    homeAddress = staff.HomeAddress,
                    citizenID = staff.CitizenID,
                    departmentID = staff.DepartmentID,
                    position = staff.Position,
                    qualification = staff.Qualification,
                    degree = staff.Degree,
                    status = staff.Status,
                    startDate = staff.StartDate,
                    Notes = staff.Notes
                };
                db.Staffs.InsertOnSubmit(newStaff);
                db.SubmitChanges();
                return 0; //Thêm thành công
            }
            catch (Exception ex)
            {
                return 1; //Có lỗi sảy ra trong quá trình thêm
            }
        }

        public bool Delete(string idDelete)
        {
            try
            {
                //Lấy dữ liệu staff cần xóa và kiểm tra có tồn tại trong database không
                Staff itemSelect = Exists(idDelete);
                if (itemSelect == null)
                {
                    return false; //dữ liệu cần xóa không tồn tại trong database
                }
                
                //Xóa
                db.Staffs.DeleteOnSubmit(itemSelect);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false; //Lỗi khi xóa
            }
        }

        public bool Update(StaffDTO item)
        {
            try
            {
                //kiểm tra tồn tại
                if (Exists(item.Id) == null)
                {
                    return false; //Dữ liệu cần cập nhật không tồn tại
                }

                //Lấy dữ liệu và cập nhật
                Staff oldItem = db.Staffs.Single(x => x.id == item.Id);
                oldItem.id = item.Id;
                oldItem.name = item.Name;
                oldItem.role = item.Role;
                oldItem.dob = item.Dob;
                oldItem.gender = item.Gender;
                oldItem.phoneNumber = item.PhoneNumber;
                oldItem.email = item.Email;
                oldItem.homeAddress = item.HomeAddress;
                oldItem.citizenID = item.CitizenID;
                oldItem.departmentID = item.DepartmentID;
                oldItem.position = item.Position;
                oldItem.qualification = item.Qualification;
                oldItem.degree = item.Degree;
                oldItem.status = item.Status;
                oldItem.startDate = item.StartDate;
                oldItem.Notes = item.Notes;
                db.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
