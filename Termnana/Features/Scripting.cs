using System;
using System.IO;

namespace Termnana.Features
{
    public static class Scripting
    {
        public static void ExecuteScript(string scriptPath)
        {
            if (File.Exists(scriptPath))
            {
                var scriptLines = File.ReadAllLines(scriptPath);
                foreach (var line in scriptLines)
                {
                    Program.ExecuteCommand(line);
                }
            }
            else
            {
                Console.WriteLine("Script file not found.");
            }
        }
    }
}
