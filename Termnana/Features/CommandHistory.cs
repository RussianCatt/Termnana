using System.Collections.Generic;

namespace Termnana.Features
{
    public static class CommandHistory
    {
        private static List<string> History = new List<string>();
        private static int Index = -1;

        public static void AddToHistory(string command)
        {
            History.Add(command);
            Index = History.Count;
        }

        public static string GetPreviousCommand()
        {
            if (Index > 0)
            {
                Index--;
                return History[Index];
            }
            return null;
        }

        public static string GetNextCommand()
        {
            if (Index < History.Count - 1)
            {
                Index++;
                return History[Index];
            }
            return null;
        }
    }
}
