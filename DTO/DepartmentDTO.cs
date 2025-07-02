using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DepartmentDTO
    {
        private string id;
        private string departmentName;
        private string description;

        public DepartmentDTO(string id, string departmentName, string description)
        {
            this.id = id;
            this.departmentName = departmentName;
            this.description = description;
        }

        public string Id { get => id; set => id = value; }
        public string DepartmentName { get => departmentName; set => departmentName = value; }
        public string Description { get => description; set => description = value; }
        public DepartmentDTO() { }
    }
}
