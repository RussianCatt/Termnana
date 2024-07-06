using System.Collections.Generic;

namespace Termnana.Utilities
{
    public static class Localizer
    {
        private static Dictionary<string, Dictionary<string, string>> Localizations = new Dictionary<string, Dictionary<string, string>>
        {
            ["en"] = new Dictionary<string, string>
            {
                ["Error_NoPermission"] = "You do not have permission to execute '{0}'.",
                ["Error_CommandRequiresArguments"] = "Command '{0}' requires arguments.",
                ["Error_CommandNotFound"] = "Command '{0}' not found.",
                ["Info_NanasLoaded"] = "Nanas loaded successfully."
            }
        };

        public static string GetLocalizedString(string key, params object[] args)
        {
            string languageCode = "en"; // Default language
            if (Localizations.ContainsKey(languageCode) && Localizations[languageCode].ContainsKey(key))
            {
                return string.Format(Localizations[languageCode][key], args);
            }
            return $"[Missing localization: {key}]";
        }
    }
}
