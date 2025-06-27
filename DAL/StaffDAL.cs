using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StaffDAL
    {
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

                //string stringConnection = $"Data Source={fullName};Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False";

                return "Data Source=DESKTOP-6LE6PT2\\SQLEXPRESS;Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False"; // Trả về instance đầu tiên tìm thấy
                
            }

            return "Data Source=DESKTOP-6LE6PT2\\SQLEXPRESS;Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False"; // Không tìm thấy
        }
        HospitalManagementDataContext db = new HospitalManagementDataContext(GetFirstSqlServerInstanceName());
        
        public IQueryable GetAll()
        {
            return from nv in db.Staffs select nv;
        }

        private Staff Exists(string id)
        {
            Staff itemSelect = db.Staffs.Where(x => x.id == id).FirstOrDefault();
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
                Staff oldItem = db.Staffs.Where(x => x.id == item.Id).FirstOrDefault();

                // Cập nhật các thuộc tính
                oldItem.name = item.Name ?? oldItem.name; // Giữ giá trị cũ nếu null
                oldItem.role = item.Role ?? oldItem.role;
                oldItem.dob = item.Dob;
                oldItem.gender = item.Gender;
                oldItem.phoneNumber = item.PhoneNumber ?? oldItem.phoneNumber;
                oldItem.email = item.Email ?? oldItem.email;
                oldItem.homeAddress = item.HomeAddress ?? oldItem.homeAddress;
                oldItem.citizenID = item.CitizenID ?? oldItem.citizenID;
                oldItem.departmentID = item.DepartmentID ?? oldItem.departmentID;
                oldItem.position = item.Position ?? oldItem.position;
                oldItem.qualification = item.Qualification ?? oldItem.qualification;
                oldItem.degree = item.Degree ?? oldItem.degree;
                oldItem.status = item.Status;
                oldItem.startDate = item.StartDate;
                oldItem.Notes = item.Notes ?? oldItem.Notes;
                db.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IQueryable LoadDepartment()
        {
            return db.Departments.Select(x => new
            {
                x.id,
                x.departmentName
            });
        }
    }
}
