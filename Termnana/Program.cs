using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using Termnana.Configuration;
using Termnana.Features;
using Termnana.Logging;
using Termnana.Nanas;
using Termnana.Utilities;

namespace Termnana
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize system
            ConfigurationManager.LoadConfiguration();
            Logger.LogInfo("Termnana started.");
            NanaManager.LoadNanas();
            CommandAliases.LoadAliases();
            Themes.ApplyTheme();

            // Command loop
            string userName = Environment.UserName.ToLower();
            string termnana = "[yellow]termnana[/]";
            string prompt = $"{userName}@{termnana}:-$ ";

            // Initialize autocomplete with available commands and prompt text
            var availableCommands = NanaManager.Nanas.Select(n => n.CommandName).ToList();
            availableCommands.AddRange(new List<string> { "list", "help", "update-nanas", "set-theme", "run-script", "clear", "exit" });

            while (true)
            {
                string input = AutocompleteHelper.ReadLineWithAutocomplete(prompt, availableCommands);
                ExecuteCommand(input);
            }
        }

        public static void ExecuteCommand(string input)
        {
            var parsedInput = InputParser.ParseInput(input);
            if (parsedInput.Count == 0)
            {
                return;
            }

            string command = CommandAliases.ResolveAlias(parsedInput[0]);
            string[] args = parsedInput.Skip(1).ToArray();

            if (command.Equals("list", StringComparison.OrdinalIgnoreCase))
            {
                NanaManager.ListNanas();
            }
            else if (command.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                DisplayHelp();
            }
            else if (command.Equals("update-nanas", StringComparison.OrdinalIgnoreCase))
            {
                _ = NanaUpdates.UpdateNanasAsync();
            }
            else if (command.Equals("set-theme", StringComparison.OrdinalIgnoreCase) && args.Length > 0)
            {
                Themes.SetTheme(args[0]);
            }
            else if (command.Equals("run-script", StringComparison.OrdinalIgnoreCase) && args.Length > 0)
            {
                Scripting.ExecuteScript(args[0]);
            }
            else if (command.Equals("clear", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
            }
            else if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                // Prompt user before exiting
                if (PromptToExit())
                {
                    Environment.Exit(0); // Exit the application
                }
            }
            else
            {
                var nana = NanaManager.Nanas.FirstOrDefault(n => n.CommandName.Equals(command, StringComparison.OrdinalIgnoreCase));
                if (nana != null)
                {
                    if (nana is IInteractiveNana interactiveNana)
                    {
                        InteractiveMode.ExecuteInteractiveNana(interactiveNana, args);
                    }
                    else
                    {
                        nana.Execute(args);
                    }
                }
                else
                {
                    Console.WriteLine($"Error: Command '{command}' not found.");
                }
            }

            CommandHistory.AddToHistory(input);
        }

        private static void DisplayHelp()
        {
            AnsiConsole.MarkupLine("[bold]Available Commands:[/]");
            AnsiConsole.MarkupLine(" - [green]list[/]: List all available Nanas.");
            AnsiConsole.MarkupLine(" - [green]help[/]: Display this help message.");
            AnsiConsole.MarkupLine(" - [green]update-nanas[/]: Check for and update Nanas.");
            AnsiConsole.MarkupLine(" - [green]set-theme <theme>[/]: Set the application theme (e.g., dark, light).");
            AnsiConsole.MarkupLine(" - [green]run-script <path>[/]: Execute a script of commands.");
            AnsiConsole.MarkupLine(" - [green]clear[/]: Clear the console.");
            AnsiConsole.MarkupLine(" - [green]exit[/]: Exit the application.");
            // Add more help messages as needed
        }

        private static bool PromptToExit()
        {
            Console.WriteLine("Are you sure you want to exit? (Y/N)");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                char response = char.ToUpper(key.KeyChar);
                if (response == 'Y')
                {
                    return true; // User confirmed exit
                }
                else if (response == 'N')
                {
                    return false; // User canceled exit
                }
            }
        }
    }
}
