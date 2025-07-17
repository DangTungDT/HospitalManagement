using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SalaryDetailDTO
    {
        string staffId, salaryPeriod, note, createdBy;
        int salaryID, workingDays;
        DateTime salaryDate, createdAt;
        Decimal bacsicSalary, overtimeHours, allowance, bonus, deduction, incomeTax, socialInsurance;

        public string StaffId { get => staffId; set => staffId = value; }
        public string SalaryPeriod { get => salaryPeriod; set => salaryPeriod = value; }
        public string Note { get => note; set => note = value; }
        public string CreatedBy { get => createdBy; set => createdBy = value; }
        public int SalaryID { get => salaryID; set => salaryID = value; }
        public int WorkingDays { get => workingDays; set => workingDays = value; }
        public DateTime SalaryDate { get => salaryDate; set => salaryDate = DateTime.Now; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public decimal BacsicSalary { get => bacsicSalary; set => bacsicSalary = value; }
        public decimal OvertimeHours { get => overtimeHours; set => overtimeHours = value; }
        public decimal Allowance { get => allowance; set => allowance = value; }
        public decimal Bonus { get => bonus; set => bonus = value; }
        public decimal Deduction { get => deduction; set => deduction = value; }
        public decimal IncomeTax { get => incomeTax; set => incomeTax = value; }
        public decimal SocialInsurance { get => socialInsurance; set => socialInsurance = value; }
    }
}
