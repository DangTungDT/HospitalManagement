using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SalaryDetailDAL
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

                string stringConnection = $"Data Source={fullName};Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False";
                return stringConnection;
                //return "Data Source=DESKTOP-6LE6PT2\\SQLEXPRESS;Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False"; // Trả về instance đầu tiên tìm thấy

            }

            return "Data Source=DESKTOP-6LE6PT2\\SQLEXPRESS;Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False"; // Không tìm thấy
        }
        HospitalManagementDataContext db = new HospitalManagementDataContext(GetFirstSqlServerInstanceName());

        public IQueryable GetAll()
        {
            try
            {
                return db.SalaryDetails.Select(x => new
                {
                    x.SalaryID,
                    x.StaffId,
                    x.SalaryPeriod,
                    x.SalaryDate,
                    x.BasicSalary,
                    x.WorkingDays,
                    x.OvertimeHours,
                    x.Allowance,
                    x.Bonus,
                    x.Deduction,
                    x.IncomeTax,
                    x.SocialInsurance,
                    x.NetSalary,
                    x.Note,
                    x.CreatedAt,
                    x.CreatedBy
                });
            }catch(Exception ex)
            {
                return null;
            }
        }
        private SalaryDetail find(int salaryID, string staffID, DateTime salaryDate)
        {
            return db.SalaryDetails.Where(x => x.SalaryID == salaryID && x.StaffId == staffID && x.SalaryDate == salaryDate).FirstOrDefault();
        }
        public int Add(SalaryDetailDTO dto)
        {
            try
            {
                if(find(dto.SalaryID, dto.StaffId, dto.SalaryDate) != null)
                {
                    return -1; //Phần tử đã tồn tại 
                }
                SalaryDetail x = new SalaryDetail()
                {
                    SalaryID = dto.SalaryID,
                    StaffId = dto.StaffId,
                    SalaryPeriod = dto.SalaryPeriod,
                    SalaryDate = dto.SalaryDate,
                    BasicSalary = dto.BacsicSalary,
                    WorkingDays = dto.WorkingDays,
                    OvertimeHours = dto.OvertimeHours,
                    Allowance = dto.Allowance,
                    Bonus = dto.Bonus,
                    Deduction = dto.Deduction,
                    IncomeTax = dto.IncomeTax,
                    SocialInsurance = dto.SocialInsurance,
                    Note = dto.Note,
                    CreatedAt = dto.CreatedAt,
                    CreatedBy = dto.CreatedBy
                };
                db.SalaryDetails.InsertOnSubmit(x);
                db.SubmitChanges();
                return 0;

            }catch(Exception ex)
            {
                return 1;
            }
        }

        public bool Delete(int salaryID, string staffID, DateTime salaryDate)
        {
            try
            {
                SalaryDetail item = find(salaryID, staffID, salaryDate);
                if(item == null)
                {
                    return false;
                }
                db.SalaryDetails.DeleteOnSubmit(item);
                db.SubmitChanges(); return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool Update(SalaryDetailDTO dto)
        {
            try
            {
                SalaryDetail item = find(dto.SalaryID, dto.StaffId, dto.SalaryDate);
                if(item == null)
                {
                    return false;
                }
                item.SalaryPeriod = dto.SalaryPeriod;
                item.BasicSalary = dto.BacsicSalary;
                item.WorkingDays = dto.WorkingDays;
                item.OvertimeHours = dto.OvertimeHours;
                item.Allowance = dto.Allowance;
                item.Bonus = dto.Bonus;
                item.Deduction = dto.Deduction;
                item.IncomeTax = dto.IncomeTax;
                item.SocialInsurance = dto.SocialInsurance;
                item.Note = dto.Note;
                item.CreatedAt = dto.CreatedAt;
                item.CreatedBy = dto.CreatedBy;
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
