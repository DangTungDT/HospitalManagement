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
    public class SalaryDAL
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
                return db.Salary.Select(x => new
                {
                    x.id,
                    x.BasicSalary
                });
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        private Salary find(Decimal salary)
        {
            return db.Salary.Where(x => x.BasicSalary == salary).FirstOrDefault();
        }
        private Salary findbyID(int id)
        {
            return db.Salary.Where(x => x.id == id).FirstOrDefault();
        }
        public int Add(SalaryDTO dto)
        {
            try
            {
                if (find(dto.BasicSalary) != null)
                {
                    return -1; //đã có dữ liệu
                }
                Salary newItem = new Salary()
                {
                    BasicSalary = dto.BasicSalary
                };
                db.Salary.InsertOnSubmit(newItem);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                return 1; //Lỗi không add được với database
            }
        }

        public bool Delete(Decimal salary)
        {
            try
            {
                Salary itemD = db.Salary.Where(x => x.BasicSalary == salary).FirstOrDefault();
                if (itemD == null)
                {
                    return false;
                }
                db.Salary.DeleteOnSubmit(itemD);
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(SalaryDTO item)
        {
            try
            {
                //kiểm tra tồn tại
                if (findbyID(item.Id) == null)
                {
                    return false; //Dữ liệu cần cập nhật không tồn tại
                }

                //Lấy dữ liệu và cập nhật
                Salary oldItem = db.Salary.Where(x => x.id == item.Id).FirstOrDefault();

                // Cập nhật các thuộc tính
                oldItem.BasicSalary = item.BasicSalary;
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
