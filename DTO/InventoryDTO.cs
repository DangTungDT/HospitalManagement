using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InventoryDTO
    {
        private string idItem;
        private int id;
        private int quantity;
        private DateTime lastUpdate;

        public InventoryDTO(string idItem, int id, int quantity, DateTime lastUpdate)
        {
            this.idItem = idItem;
            this.id = id;
            this.quantity = quantity;
            this.lastUpdate = lastUpdate;
        }
         public InventoryDTO(string idItem, int quantity, DateTime lastUpdate)
        {
            this.idItem = idItem;
            this.quantity = quantity;
            this.lastUpdate = lastUpdate;
        }
        public string IdItem { get => idItem; set => idItem = value; }
        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime LastUpdate { get => lastUpdate; set => lastUpdate = value; }
        public InventoryDTO() { }
    }
}
