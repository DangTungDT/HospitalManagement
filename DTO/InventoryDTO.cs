using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InventoryDTO
    {
        private string id;
        private int quantity;
        private DateTime lastUpdate;

        public InventoryDTO(string id, int quantity, DateTime lastUpdate)
        {
            this.id = id;
            this.quantity = quantity;
            this.lastUpdate = lastUpdate;
        }

        public string Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime LastUpdate { get => lastUpdate; set => lastUpdate = value; }
        public InventoryDTO() { }
    }
}
