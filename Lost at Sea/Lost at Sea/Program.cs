/*
 * Lost at Sea
 * A text adventure by Jack Gunther
 * 
 * ASCII art used from https://www.asciiart.eu/
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lost_at_Sea
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Lost at Sea";

            Item Leaves = new Item("Leaves", "It's a bunch of leaves.");
            Item Stick = new Item("Stick", "Some thin branches from a tree.");
            Item Rope = new Item("Rope", "Old rope but it seems to have significant strength.");
            Item Axe = new Item("Axe", "An axe with a dulled edge.");
            Item Wood = new Item("Wood", "Wood from a cut down tree.");
            Item Boat = new Item("Boat", "You made a boat out of the materials you found on the island.");
            Item BadBoat = new Item("Crappy Boat", "You attempted to make a boat out of the materials you found on the island.");


            Location Beach = new Location()
            {
                Name = "Beach",
                Description = "The beach you woke up on. It would be a good place to build a boat back to your ship.",
                Items = new List<Item> { },               
                Art = @"
                                            ____
                                         v        _()
        _ ^ _                          v(___(__)
       '_\V/ `
       ' oX`
          X                            
          X - HELP!
          X.
          X        \O /                                      |\
          X.a##a.   M                                       |_\
       .aa########a.>>                                    __|__
    .a################aa.                                 \   /
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
                LocationColor = ConsoleColor.Cyan
            };

            Location NorthPath = new Location()
            {
                Name = "North Forest",
                Description = "A small opening in the forest and there's something on the ground.",
                Items = new List<Item> { Rope },
                Art = @"
       ^  ^  ^   ^   ^  ^   ^  ^  ^   ^  ^
      /|\/|\/|\ /|\ /|\/|\ /|\/|\/|\ /|\/|\
      /|\/|\/|\ /|\ /|\/|\ /|\/|\/|\ /|\/|\
      /|\/|\/|\ /|\ /|\/|\ /|\/|\/|\ /|\/|\",
                LocationColor = ConsoleColor.DarkGreen
            };

            Location SouthPath = new Location()
            {
                Name = "South Forest",
                Description = "Fallen trees seem to cover the path. Maybe those trees could be helpful?",
                Items = new List<Item> { Stick, Wood },
                RequiredItems = new List<Item> { Axe },
                Art = @"
       ^  ^  ^   ^   ^  ^   ^  ^  ^   ^  ^
      /|\/|\/|\ /|\ /|\/|\ /|\/|\/|\ /|\/|\
      /|\/|\/|\ /|\ /|\/|\ /|\/|\/|\ /|\/|\
      /|\/|\/|\ /|\ /|\/|\ /|\/|\/|\ /|\/|\",
                LocationColor = ConsoleColor.DarkGreen
            };

            Location EastPath = new Location()
            {
                Name = "East Forest",
                Description = "There's an opening in the forest but there seems to only be leaves covering the ground.",
                Items = new List<Item> { Leaves, Axe },
                Art = @"
       ^  ^  ^   ^   ^  ^   ^  ^  ^   ^  ^
      /|\/|\/|\ /|\ /|\/|\ /|\/|\/|\ /|\/|\
      /|\/|\/|\ /|\ /|\/|\ /|\/|\/|\ /|\/|\
      /|\/|\/|\ /|\ /|\/|\ /|\/|\/|\ /|\/|\",
                LocationColor = ConsoleColor.DarkGreen
            };

            Location Sea = new Location()
            {
                Name = "Sea",
                Description = "The sea you traveled on to get to the island as well as the way to return to your ship.",
                Items = new List<Item> { Boat, BadBoat },
                RequiredItems = new List<Item> {},
                Art = @"
          ___   ____
        /' --;^/ ,-_\     \ | /
       / / --o\ o-\ \\   --(_)--
      /-/-/|o|-|\-\\|\\   / | \
       '`  ` |-|   `` '
             |-|
             |-|O
             |-(\,__
          ...|-|\--,\_....
      ,;;;;;;;;;;;;;;;;;;;;;;;;,.
~~,;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,  ______   ---------   _____     ------",  
                LocationColor = ConsoleColor.Cyan
            };

            List<Location> Locations = new List<Location>() { Beach, NorthPath, SouthPath, EastPath, Sea};
            
            Player Player1 = new Player();
            World world = new World("Lost at Sea", Player1, Beach, Locations, Boat, BadBoat);

            world.Menu();
        }
    }
}
