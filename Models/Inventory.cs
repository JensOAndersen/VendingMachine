using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface IInventory
    {
        List<VendorItem> Items { get; set; }
    }

    public class DrinkInventory : IInventory
    {
        private List<VendorItem> items;

        public DrinkInventory()
        {
            Items = new List<VendorItem>()
            {
                new VendorItem("Pepsi",35),
                new VendorItem("Coke", 25),
                new VendorItem("Soda",45)
            };
        }

        public List<VendorItem> Items
        {
            get { return items; }
            set { items = value; }
        }
    }

    public class FoodInventory : IInventory
    {
        private List<VendorItem> items;

        public FoodInventory()
        {
            Items = new List<VendorItem>()
            {
                new VendorItem("Leek",7),
                new VendorItem("Onion", 15),
                new VendorItem("T-Bone",76)
            };
        }

        public List<VendorItem> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
    