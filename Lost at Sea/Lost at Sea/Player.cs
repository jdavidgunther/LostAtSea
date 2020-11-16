using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lost_at_Sea
{
    public class Player
    {
        public string Name { get; set; }
        public Location CurrentLocation { get; set; }

        public List<Item> Inventory = new List<Item>();

        public void PrintInventory()
        {
            List<string> names = new List<string>();

            foreach (var item in Inventory)
            {
                names.Add(item.Name);
            }

            string ListofNames = String.Join(", ", names);

            string ItemLabel = Inventory.Count == 1 ? "item" : "items";
            string Grammar = Inventory.Count == 1 ? "it is" : "they are";

            WriteLine($"You currently have {Inventory.Count} {ItemLabel} and {Grammar} {ListofNames}.");
        }

        public void ShowInventory()
        {
            int index = 1;
            foreach (var Item in Inventory)
            {
                WriteLine($"{index++}: {Item.Name} - {Item.Description}");
            }
        }

        public Player()
        {

        }

        public void CollectItem(Item item)
        {
            Inventory.Add(item);
            WriteLine($"You picked up {item.Name}.");
            PrintInventory();
        }
    }
}
