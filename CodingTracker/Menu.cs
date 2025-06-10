using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace CodingTracker
{
    class Menu
    {
        internal static void GetMainMenu()
        {
            var menuChoices = new string[4]{"View Coding Log", "Add Session", "Delete Session", "Quit"};
            bool running = true;
            while(running){
            Console.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Menu")
                .AddChoices(menuChoices));

            switch (choice)
                {
                    case "View Coding Log":
                        Console.WriteLine("Viewing something...");
                        Console.ReadLine();
                        break;
                    case "Add Session":
                        Console.WriteLine("Adding something...");
                        Console.ReadLine();
                        break;
                    case "Delete Session":
                        Console.WriteLine("Deleting something...");
                        Console.ReadLine();
                        break;
                    case "Quit":
                        Console.WriteLine("Quitting something...");
                        Console.ReadLine();
                        running = false;
                        break;
                } 
            }
         }
    }
}
