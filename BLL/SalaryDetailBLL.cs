using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SalaryDetailBLL
    {
        SalaryDetailDAL dal = new SalaryDetailDAL();

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

        public bool CheckIsValue(SalaryDetailDTO dto)
        {
            if (dto.SalaryID < 1 || string.IsNullOrEmpty(dto.StaffId) || string.IsNullOrEmpty(dto.SalaryPeriod) ||
                dto.SalaryDate.Date > DateTime.Now.Date || dto.BacsicSalary < 0 || dto.WorkingDays < 0 ||
                dto.OvertimeHours < 0 || dto.Allowance < 0 || dto.Bonus < 0 ||
                dto.Deduction < 0 || dto.IncomeTax < 0 || dto.SocialInsurance < 0 ||
                dto.CreatedAt.Date != DateTime.Now.Date || string.IsNullOrEmpty(dto.CreatedBy))
            {
                return false;
            }
            return true;
        }
        public int Add(SalaryDetailDTO dto)
        {
            try
            {
                if(!CheckIsValue(dto))
                {
                    return -2;
                }
                return dal.Add(dto);
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

        public bool Delete(int salaryID, string staffID, DateTime salaryDate)
        {
            try
            {
                if(salaryID < 1 || string.IsNullOrEmpty(staffID) || salaryDate.Date > DateTime.Now.Date) { return false; }
                return dal.Delete(salaryID, staffID, salaryDate);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(SalaryDetailDTO dto)
        {
            try
            {
                if(!CheckIsValue(dto))
                {
                    return false;
                }
                return dal.Update(dto);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
