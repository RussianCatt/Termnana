using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace Termnana.Features
{
    public static class AutocompleteHelper
    {
        public static string ReadLineWithAutocomplete(string prompt, List<string> availableCommands)
        {
            string input = string.Empty;
            int currentIndex = -1;
            ConsoleKeyInfo key;

            AnsiConsole.Markup(prompt);

            while (true)
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                        AnsiConsole.Write("\b \b");
                    }
                }
                else if (key.Key == ConsoleKey.Tab)
                {
                    var matchingCommands = availableCommands
                        .Where(c => c.StartsWith(input, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (matchingCommands.Count > 0)
                    {
                        currentIndex = (currentIndex + 1) % matchingCommands.Count;
                        var suggestion = matchingCommands[currentIndex];
                        AnsiConsole.Write(new string('\b', input.Length));
                        AnsiConsole.Write(new string(' ', input.Length));
                        AnsiConsole.Write(new string('\b', input.Length));
                        input = suggestion;
                        AnsiConsole.Markup($"[bold]{input}[/]");
                    }
                }
                else
                {
                    Console.Write(key.KeyChar);
                    input += key.KeyChar;
                }
            }

            return input;
        }
    }
}
