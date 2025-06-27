using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Item
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public Item(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
