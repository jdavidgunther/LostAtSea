using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lost_at_Sea
{
    public class Item
    {
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }
    }
}
