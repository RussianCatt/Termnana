using Termnana.Configuration;
using System.Collections.Generic;
using System.Text.Json;

namespace Termnana.Features
{
    public static class CommandAliases
    {
        private static Dictionary<string, string> Aliases = new Dictionary<string, string>();

        public static void LoadAliases()
        {
            var aliasesJson = ConfigurationManager.GetSetting("CommandAliases");
            if (!string.IsNullOrEmpty(aliasesJson))
            {
                Aliases = JsonSerializer.Deserialize<Dictionary<string, string>>(aliasesJson);
            }
            else
            {
                Aliases = new Dictionary<string, string>();
            }
        }

        public static void SaveAliases()
        {
            var aliasesJson = JsonSerializer.Serialize(Aliases);
            ConfigurationManager.SetSetting("CommandAliases", aliasesJson);
        }

        public static void AddAlias(string alias, string command)
        {
            Aliases[alias] = command;
            SaveAliases();
        }

        public static void RemoveAlias(string alias)
        {
            if (Aliases.ContainsKey(alias))
            {
                Aliases.Remove(alias);
                SaveAliases();
            }
        }

        public static string ResolveAlias(string alias)
        {
            return Aliases.ContainsKey(alias) ? Aliases[alias] : alias;
        }
    }
}
