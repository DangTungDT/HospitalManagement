using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SalaryDTO
    {
        int id;
        Decimal basicSalary;

        public int Id { get => id; set => id = value; }
        public decimal BasicSalary { get => basicSalary; set => basicSalary = value; }
    }
}
