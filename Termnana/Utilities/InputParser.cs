using System.Collections.Generic;

namespace Termnana.Utilities
{
    public static class InputParser
    {
        public static List<string> ParseInput(string input)
        {
            var parts = new List<string>();
            var currentPart = string.Empty;
            var inQuotes = false;

            foreach (var c in input)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ' ' && !inQuotes)
                {
                    if (!string.IsNullOrWhiteSpace(currentPart))
                    {
                        parts.Add(currentPart);
                        currentPart = string.Empty;
                    }
                }
                else
                {
                    currentPart += c;
                }
            }

            if (!string.IsNullOrWhiteSpace(currentPart))
            {
                parts.Add(currentPart);
            }

            return parts;
        }
    }
}
