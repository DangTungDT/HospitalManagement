using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LabTestTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? testTypeID { get; set; }
        public string testTypeName { get; set; }
    }
}
