using System;

namespace Anagramatic
{
    public static class Sorting
    {
        public delegate string KeyDelegate(string input);

        public static string SortString(string input, KeyDelegate? key = null)
        {
            string processedInput = key != null ? key(input) : input;
            char[] chars = processedInput.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}