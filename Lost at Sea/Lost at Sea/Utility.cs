using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lost_at_Sea
{
    public static class Utility
    {
        public static string GetUserInput(string Title)
        {
            string userInput;
            WriteLine(Title);
            userInput = ReadLine();
            userInput = userInput.Trim();

            while (String.IsNullOrEmpty(userInput))
            {
                WriteLine("Please enter a value.");
                userInput = ReadLine();
                userInput = userInput.Trim();
            }
            return userInput;
        }

        public static int GetUserInputInt(string Title)
        {
            int result = -1;
            string userInput;
            WriteLine(Title);
            userInput = ReadLine();
            userInput = userInput.Trim();
            
            while (String.IsNullOrEmpty(userInput))
            {
                WriteLine("Please enter a value.");
                userInput = ReadLine();
                userInput = userInput.Trim();
            }
            int.TryParse(userInput, out result);
            return result;
        }

        public static bool Affirm(string Title)
        {
            WriteLine(Title);
            while (true)
            {
                ConsoleKey UserInput = ReadKey().Key;
                switch (UserInput)
                {
                    case ConsoleKey.N:
                        return false;
                    case ConsoleKey.Y:
                        return true;
                    default:
                        WriteLine("Please press Y/N to affirm or deny.");
                        break;
                }
            }
        }

        public static void Line()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Write("-");
            }
            Write("\n");
        }

        public static void Center(string input)
        {
            int half = WindowWidth / 2;
            half = half - (input.Length / 2);
            if (half > 0)
            {
                for (int i = 0; i < half; i++)
                {
                    Write(" ");
                }
                Write(input);
            }
            else
            {
                Write(input);
            }
            Write("\n");
        }
    }
}
