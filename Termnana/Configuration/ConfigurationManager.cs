using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Termnana.Configuration
{
    public static class ConfigurationManager
    {
        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

        private static Dictionary<string, string> settings = new Dictionary<string, string>();

        static ConfigurationManager()
        {
            LoadConfiguration();
        }

        public static void LoadConfiguration()
        {
            if (File.Exists(ConfigFilePath))
            {
                var json = File.ReadAllText(ConfigFilePath);
                settings = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
            }
        }

        public static void SaveConfiguration()
        {
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigFilePath, json);
        }

        public static string GetSetting(string key)
        {
            return settings.ContainsKey(key) ? settings[key] : string.Empty;
        }

        public static void SetSetting(string key, string value)
        {
            settings[key] = value;
            SaveConfiguration();
        }
    }
}
