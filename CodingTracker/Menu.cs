﻿using System;
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
            var menuChoices = new string[6]{"View Coding Log", "Timer", "Add Session", "Update Session", "Delete Session", "Quit"};
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
                        Database.ViewTable();
                        Console.ReadLine();
                        break;
                    case "Add Session":
                        Database.InsertSession(UserInput.GetCodeSession());
                        break;
                    case "Timer":
                        StopWatch.Timer();
                        break;
                    case "Update Session":
                        Database.UpdateSession();
                        break;
                    case "Delete Session":
                        Database.DeleteSession();
                        break;
                    case "Quit":
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;
                } 
            }
         }
    }
}
