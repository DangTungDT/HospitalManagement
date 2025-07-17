using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SalaryBLL
    {
        SalaryDAL dal = new SalaryDAL();

        public IQueryable GetAll()
        {
            try
            {
                return dal.GetAll();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public int Add(SalaryDTO dto)
        {
            try
            {
                if(dto == null)
                {
                    return -2; // Dữ liệu đầu vào null
                }
                if(dto.BasicSalary <0)
                {
                    return -3; // Lương căn bản không được âm
                }

                return dal.Add(dto);
            }
            catch (Exception ex)
            {
                return 2; //Lỗi không add được với database
            }
        }

        public bool Delete(Decimal salary)
        {
            try
            {
                if (salary == null)
                {
                    return false; // Dữ liệu đầu vào null
                }
                if (salary < 0)
                {
                    return false; // Lương căn bản không được âm
                }
                return dal.Delete(salary);
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
                if (item == null)
                {
                    return false; // Dữ liệu đầu vào null
                }
                if (item.BasicSalary < 0)
                {
                    return false; // Lương căn bản không được âm
                }

                return dal.Update(item);
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
