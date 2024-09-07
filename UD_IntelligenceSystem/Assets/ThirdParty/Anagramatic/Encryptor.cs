using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Anagramatic
{
    public static class Encryptor
    {
        public static string ResolveString(string data, Dictionary<string, List<string>> anagramMap, float resolution = 0.0f)
        {
            string[] words = Regex.Split(data, @"(\W+)");
            List<string> encryptedWords = new List<string>();
            foreach (string word in words)
            {
                string strippedWord = new string(word.Where(char.IsLetterOrDigit).ToArray());
                string punctuation = new string(word.Where(c => !char.IsLetterOrDigit(c)).ToArray());

                string sortedWord = Sorting.SortString(strippedWord).ToLower();


                string addWord = word;
                if (anagramMap.ContainsKey(sortedWord))
                {
                    addWord = ResolveAnagram(strippedWord, anagramMap[sortedWord], resolution);
                }
                encryptedWords.Add(addWord + punctuation);
            }

            return string.Join("", encryptedWords);
        }

        public static string ResolveAnagram(string input, List<string> anagrams, float resolution = 0.0f)
        {
            Random random = new Random();

            if (random.NextDouble() <= resolution)
            {
                return input;
            }

            int randomIndex = random.Next(anagrams.Count);
            return anagrams[randomIndex];
        }
    }
}