using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lost_at_Sea
{
    public class World
    {
        public List<Location> Locations { get; set; }

        public string Name
        {
            get; set;
        }

        public Player CurrentPlayer
        {
            get; set;
        }

        public Item WinCondition { get; set; }
        public Item LoseCondition { get; set; }

        public World(string name, Player player, Location defaultLocation, List<Location> locations, Item winCondition, Item loseCondition)
        {
            Name = name;
            CurrentPlayer = player;
            CurrentPlayer.CurrentLocation = defaultLocation;
            Locations = locations;
            WinCondition = winCondition;
            LoseCondition = loseCondition;
            SetUpPlayer();
        }

        public void SetUpPlayer()
        {
            WriteLine($"Welcome to {Name}");
            CurrentPlayer.Name = Utility.GetUserInput("What is your name?");
            WriteLine($"Location: {CurrentPlayer.CurrentLocation.Name}");
        }

        public bool ChangeLocation()
        {
            int index = 1;
            foreach (var Location in Locations)
            {
                WriteLine($"{index++}: {Location.Name} - {Location.Description}");
            }

            int userChoice = 0;
            string userInput = Utility.GetUserInput("Where would you like to go?");
            int.TryParse(userInput, out userChoice);
            if (userChoice > 0 && userChoice <= Locations.Count)
            {
                userChoice--;
                Location newLocation = Locations[userChoice];

                bool HasRequiredItems = true;

                foreach (var Item in newLocation.RequiredItems)
                {
                    if (!CurrentPlayer.Inventory.Contains(Item))
                    {
                        HasRequiredItems = false;
                        break;
                    }
                }

                if (HasRequiredItems)
                {
                    CurrentPlayer.CurrentLocation = newLocation;
                    return true;
                }

                else
                {
                    WriteLine("You're not able to go there yet. Maybe if you find some items to help you can access that area.");
                    return false;
                }
            }
            WriteLine("That's not somewhere you can go");
            return false;
        }

        public void DisplayLocationItems()
        {
            if (CurrentPlayer.CurrentLocation.Items.Count > 0)
            {
                int index = 1;
                WriteLine("There are items on the ground.");
                foreach (var Item in CurrentPlayer.CurrentLocation.Items)
                {
                    WriteLine($"{index++}: {Item.Name} - {Item.Description}");
                }

                int userChoice = 0;
                string userInput = Utility.GetUserInput("What would you like to pick up?");
                int.TryParse(userInput, out userChoice);
                if (userChoice > 0 && userChoice <= CurrentPlayer.CurrentLocation.Items.Count)
                {
                    userChoice--;
                    Item PickedUp = CurrentPlayer.CurrentLocation.Items[userChoice];
                    CurrentPlayer.CollectItem(PickedUp);
                    CurrentPlayer.CurrentLocation.Items.Remove(PickedUp);
                }

                else
                {
                    WriteLine("That item doesn't exist.");
                }
            }

            else
            {
                WriteLine("There are no more items here.");
            }
        }

        public void Menu()
        {
            Clear();
            WriteLine($"Welcome {CurrentPlayer.Name} to {Name}. " +
                $"\n\nYou and your crew are at sea in search of a new land to colonize. You've been at sea for months, never coming across any land." +
                $"\nAs you're about to lose all hope, you get a glimpse of an island. You decide to take a raft over to the island while your crew anchors the boat." +
                $"\nAs you get ever closer to the island, a freak storm emerges tossing you off the raft. You get thrown around by the waves and are knocked out." + 
                $"\nYou soon awake on the island with your raft no where to be seen. Sitting on the beach you only have one option to possible get back to your ship." + 
                $"\n\nYou are able to move, search, look at inventory, clear the page, quit ,and get help with the following commands." +
                $"\nMove, Search, Inventory, Clear, Quit, Help");

            bool WinGame = false;
            bool quit = false;

            while (!WinGame && !quit)
            {
                switch (ReadLine().ToLower().Trim())
                {
                    case "move":
                        if (ChangeLocation())
                        {
                            ForegroundColor = CurrentPlayer.CurrentLocation.LocationColor;
                            Clear();
                            WriteLine($"Location: {CurrentPlayer.CurrentLocation.Name}");
                            WriteLine($"{CurrentPlayer.CurrentLocation.Art}");
                        }
                        break;
                    case "search":
                        DisplayLocationItems();
                        break;
                    case "inventory":
                        CurrentPlayer.ShowInventory();
                        break;
                    case "build":
                        if (CurrentPlayer.Inventory.Count >= 4)
                        {
                            WinGame = true;
                            WriteLine($"You build a boat out of the {CurrentPlayer.Inventory.Count} materials you found and made it back to your ship.");
                            WriteLine($"\n\nCongratulations {CurrentPlayer.Name}, You Win! Press any to exit");
                            ReadKey();
                            Environment.Exit(0);
                        }
                        else
                        {
                            WinGame = false;
                            WriteLine($"You build a boat out of the {CurrentPlayer.Inventory.Count} materials you found." +
                                "unfortunatly the boat falls apart leaving you stranded on the island for ever.");
                            WriteLine($"\n\nSorry {CurrentPlayer.Name}, You Lose! Press any key to exit");
                            ReadKey();
                            Environment.Exit(0);
                        }
                        break;
                    case "clear":
                        Clear();
                        break;
                    case "help":
                        if (CurrentPlayer.CurrentLocation.Name != "Sea")
                        {
                            WriteLine("Available Commands: Inventory, Search, Clear, Move, Quit (you don't want to do this)");
                        }
                        else
                        {                          
                            WriteLine("Available Commands: Inventory, Search, Clear, Move, Build, Quit");
                        }
                        break;
                    case "quit":
                        if (Utility.Affirm("Are you sure you really want to quit? Press Y/N"))
                        {
                            quit = true;
                            WriteLine("Ok then. press any key to close the window");
                            ReadKey();
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
                        break;


                }
            }
        }

        public void Clear()
        {
            Console.Clear();
            Utility.Line();
            Utility.Center($"Player: {CurrentPlayer.Name}  Location: {CurrentPlayer.CurrentLocation.Name}  Inventory: {CurrentPlayer.Inventory.Count}");
            Utility.Line();
        }
    }
}
