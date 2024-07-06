using Termnana.Configuration;
using System;

namespace Termnana.Features
{
    public static class Themes
    {
        public static void ApplyTheme()
        {
            if (ConfigurationManager.GetSetting("Theme") is string themeName)
            {
                switch (themeName.ToLower())
                {
                    case "dark":
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "light":
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    default:
                        Console.ResetColor();
                        break;
                }
                Console.Clear();
            }
        }

        public static void SetTheme(string themeName)
        {
            ConfigurationManager.SetSetting("Theme", themeName);
            ApplyTheme();
        }
    }
}
