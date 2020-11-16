using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lost_at_Sea
{
    public class Location
    {
        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public List<Item> Items
        {
            get; set;
        }

        public ConsoleColor LocationColor
        {
            get; set;
        }

        public string Art
        {
            get; set;
        }

        public List<Item> RequiredItems = new List<Item>();

        public Location()
        {

        }

        public Location(string name, string description, List<Item> items, List<Item> requiredItems, string art, ConsoleColor color)
        {
            Name = name;
            Description = description;
            Items = items;
            RequiredItems = requiredItems;
            Art = art;
            LocationColor = color;
        }

        public void LocationInfo()
        {
            WriteLine($"You are at {Name}. {Description}");
        }
    }
}
