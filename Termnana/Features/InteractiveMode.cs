using System;

namespace Termnana.Features
{
    public interface IInteractiveNana
    {
        void StartInteractiveMode(string[] args);
        void ProcessInput(string input);
        bool IsActive { get; }
    }

    public static class InteractiveMode
    {
        public static void ExecuteInteractiveNana(IInteractiveNana nana, string[] args)
        {
            nana.StartInteractiveMode(args);
            while (nana.IsActive)
            {
                string input = Console.ReadLine();
                nana.ProcessInput(input);
            }
        }
    }
}
