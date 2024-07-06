using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using Termnana.Logging;

namespace Termnana.Nanas
{
    public static class NanaManager
    {
        public static List<INana> Nanas { get; private set; } = new List<INana>();

        public static void LoadNanas()
        {
            var nanaDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Nanas");

            if (!Directory.Exists(nanaDirectory))
            {
                Directory.CreateDirectory(nanaDirectory);
            }

            var nanaFiles = Directory.GetFiles(nanaDirectory, "*.dll");

            var assemblies = nanaFiles.Select(Assembly.LoadFrom).ToList();

            var configuration = new ContainerConfiguration().WithAssemblies(assemblies);

            try
            {
                using (var container = configuration.CreateContainer())
                {
                    Nanas = container.GetExports<INana>().ToList();
                    Logger.LogInfo("Nanas loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error loading Nanas: {ex.Message}");
                throw;
            }
        }

        public static void ListNanas()
        {
            if (Nanas.Count == 0)
            {
                Console.WriteLine("No Nanas available.");
                return;
            }

            Console.WriteLine("Available Nanas:");
            foreach (var nana in Nanas)
            {
                Console.WriteLine($" - {nana.CommandName} by {nana.Author}, Version: {nana.Version}");
                Console.WriteLine($"   Description: {nana.Description}");
                Console.WriteLine($"   Dependencies: {string.Join(", ", nana.Dependencies)}");
            }
        }
    }
}
