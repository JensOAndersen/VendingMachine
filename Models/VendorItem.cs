using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class VendorItem
    {
        private string name;
        private int value;

        public VendorItem(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name { get => name; }
        public int Value { get => value; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
