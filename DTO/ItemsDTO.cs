using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemsDTO
    {
        private string id;
        private string itemName;
        private string ItemType;
        private string Unit;
        private decimal Price;
        private DateTime CreatedAt;
        private bool IsActive;

        public ItemsDTO(string id, string itemName, string itemType, string unit, decimal price, DateTime createdAt, bool isActive)
        {
            this.id = id;
            this.itemName = itemName;
            ItemType = itemType;
            Unit = unit;
            Price = price;
            CreatedAt = createdAt;
            IsActive = isActive;
        }

        public string Id { get => id; set => id = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string ItemType1 { get => ItemType; set => ItemType = value; }
        public string Unit1 { get => Unit; set => Unit = value; }
        public decimal Price1 { get => Price; set => Price = value; }
        public DateTime CreatedAt1 { get => CreatedAt; set => CreatedAt = value; }
        public bool IsActive1 { get => IsActive; set => IsActive = value; }
        public ItemsDTO() { }
    }
}
