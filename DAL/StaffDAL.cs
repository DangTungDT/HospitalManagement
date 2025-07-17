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
        //Hàm lấy chuỗi kết nối database sql server 
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
        HospitalManagementDataContext db = new HospitalManagementDataContext(GetFirstSqlServerInstanceName());
        
        //Hàm lấy tất cả dữ liệu trong table Staff
        public IQueryable GetAll()
        {
            return from nv in db.Staffs
                   select new
                   {
                       nv.id,
                       nv.name,
                       nv.role,
                       nv.dob,
                       nv.gender,
                       nv.phoneNumber,
                       nv.email,
                       nv.homeAddress,
                       nv.citizenID,
                       nv.departmentID,
                       nv.position,
                       nv.qualification,
                       nv.degree,
                       nv.status,
                       nv.startDate,
                       nv.Notes,
                       nv.Department
                   };
        }

        //Hàm lấy 1 dòng dữ liệu theo id staff
        public Staff Exists(string id)
        {
            Staff itemSelect = db.Staffs.Where(x => x.id == id).FirstOrDefault();
            if(itemSelect == null)
            {
                return null;
            }
            return itemSelect;
        }

        //Hàm thêm 1 dòng dữ liệu cho table 
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

        //Hàm kiểm tra ràng buộc toàn vẹn tham chiếu của dữ liệu
        private bool CheckReferentialIntegrity(string id)
        {
            try
            {
                if (db.Accounts.Any(ac => ac.staffID == id)) return false;
                if (db.MedicalRecords.Any(mr => mr.doctorID == id)) return false;
                if (db.SalaryDetails.Any(sd => sd.StaffId == id)) return false;
                if (db.LaboratoryTests.Any(lt => lt.doctorID == id)) return false;
                if (db.MedicalOrders.Any(mo => mo.DoctorID == id)) return false;
                if (db.SupplyHistories.Any(sh => sh.nurseID == id)) return false;
                if (db.DoctorPatients.Any(dp => dp.doctorID == id)) return false;
                if (db.DailyCares.Any(dc => dc.nurseID == id)) return false;
                if (db.Appointments.Any(app => app.doctorID == id)) return false;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //Hàm xóa 1 dòng dữ liệu dựa trên id staff 
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
                if(!CheckReferentialIntegrity(idDelete))
                {
                    return false; //Dữ liệu còn liên quan đến các dữ liệu ở bảng khác
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

        //Hàm cập nhật 1 dòng dữ liệu có trong table theo ID
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


        //Hàm load danh sách khoa (Do chưa có DAL của Department nên dùng đỡ)
        public IQueryable LoadDepartment()
        {
            return db.Departments.Select(x => new
            {
                x.id,
                x.departmentName
            });
        }

        //Hàm lấy dánh sách nhân viên theo khoa
        public IQueryable GetStaffByDepartmentID(string id)
        {
            try
            {
                return db.Staffs.Where(x=> x.departmentID == id).Select(x=>x);
            }catch (Exception e)
            {
                return null;
            }
        }

        public IQueryable Find(StaffDTO dto)
        {
            try
            {

                //IQueryable list = from staff in db.Staffs
                //                  where (string.IsNullOrEmpty(dto.Id) || staff.id.Contains(dto.Id))
                //                    && (string.IsNullOrEmpty(dto.Name) || staff.name.Contains(dto.Name))
                //                    && (string.IsNullOrEmpty(dto.Role) || staff.role.Contains(dto.Role))
                //                    && (string.IsNullOrEmpty(dto.Gender) || staff.gender.Contains(dto.Gender))
                //                    && (string.IsNullOrEmpty(dto.PhoneNumber) || staff.phoneNumber.Contains(dto.PhoneNumber))
                //                    && (string.IsNullOrEmpty(dto.Email) || staff.email.Contains(dto.Email))
                //                    && (string.IsNullOrEmpty(dto.HomeAddress) || staff.homeAddress.Contains(dto.HomeAddress))
                //                    && (string.IsNullOrEmpty(dto.CitizenID) || staff.citizenID.Contains(dto.CitizenID))
                //                    && (string.IsNullOrEmpty(dto.DepartmentID) || staff.departmentID.Contains(dto.DepartmentID))
                //                    && (string.IsNullOrEmpty(dto.Position) || staff.position.Contains(dto.Position))
                //                    && (string.IsNullOrEmpty(dto.Degree) || staff.degree.Contains(dto.Degree))
                //                    && (string.IsNullOrEmpty(dto.Qualification) || staff.qualification.Contains(dto.Qualification))
                //                    && (string.IsNullOrEmpty(dto.Status) || staff.status.Contains(dto.Status))
                //                    && (string.IsNullOrEmpty(dto.Notes) || staff.Notes.Contains(dto.Notes))
                //                  select staff;

                IQueryable<Staff> list = db.Staffs;

                if (!string.IsNullOrEmpty(dto.Id))
                    list = list.Where(x => x.id.Contains(dto.Id));

                if (!string.IsNullOrEmpty(dto.Name))
                    list = list.Where(x => x.name.Contains(dto.Name));

                if (!string.IsNullOrEmpty(dto.Role))
                    list = list.Where(x => x.role.Contains(dto.Role));

                if (!string.IsNullOrEmpty(dto.Gender))
                    list = list.Where(x => x.gender.Contains(dto.Gender));

                if (!string.IsNullOrEmpty(dto.PhoneNumber))
                    list = list.Where(x => x.phoneNumber.Contains(dto.PhoneNumber));

                if (!string.IsNullOrEmpty(dto.Email))
                    list = list.Where(x => x.email.Contains(dto.Email));

                if (!string.IsNullOrEmpty(dto.HomeAddress))
                    list = list.Where(x => x.homeAddress.Contains(dto.HomeAddress));

                if (!string.IsNullOrEmpty(dto.CitizenID))
                    list = list.Where(x => x.citizenID.Contains(dto.CitizenID));

                if (!string.IsNullOrEmpty(dto.DepartmentID))
                    list = list.Where(x => x.departmentID.Contains(dto.DepartmentID));

                if (!string.IsNullOrEmpty(dto.Position))
                    list = list.Where(x => x.position.Contains(dto.Position));

                if (!string.IsNullOrEmpty(dto.Degree))
                    list = list.Where(x => x.degree.Contains(dto.Degree));

                if (!string.IsNullOrEmpty(dto.Qualification))
                    list = list.Where(x => x.qualification.Contains(dto.Qualification));

                if (!string.IsNullOrEmpty(dto.Status))
                    list = list.Where(x => x.status.Contains(dto.Status));

                if (!string.IsNullOrEmpty(dto.Notes))
                    list = list.Where(x => x.Notes.Contains(dto.Notes));

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
