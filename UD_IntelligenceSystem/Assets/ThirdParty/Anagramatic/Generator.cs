using System.Collections.Generic;
using System.Linq;

namespace Anagramatic
{
    public static class Generator
    {
        public static Dictionary<string, List<string>> Generate(string[] data)
        {
            var anagrams = new Dictionary<string, List<string>>();

            foreach (string line in data)
            {
                string cleanLine = line.Trim();
                string sortedLine = Sorting.SortString(cleanLine).ToLower();
                if (!anagrams.ContainsKey(sortedLine))
                {
                    anagrams[sortedLine] = new List<string>();
                }
                anagrams[sortedLine].Add(cleanLine);
            }

            var filteredAnagrams = anagrams
                .Where(kv => kv.Value.Count > 1)
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            var sortedAnagrams = filteredAnagrams
                .OrderByDescending(kv => kv.Value.Count)
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            return sortedAnagrams;
        }
    }
}