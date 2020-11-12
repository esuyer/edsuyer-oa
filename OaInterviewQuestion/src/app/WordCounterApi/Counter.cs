using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounterApi
{
    public class Counter
    {
        public int CountWords(string filename)
        {
            return File.ReadLines(filename)
                .Select(line => Regex.Matches(line, @"\b\w+\b").Count)
                .Sum();

        }
    }
}
