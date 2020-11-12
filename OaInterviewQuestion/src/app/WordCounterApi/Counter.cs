using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

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

        public IOrderedEnumerable<WordMetric> CountUniqueWords(string filename)
        {
            var text = File.ReadAllText(filename);
            string[] words = text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
           
            return words.GroupBy(x => x).Select(y => new WordMetric { Word = y.Key, Count = y.Count() }).OrderBy(z => z.Count);
        }

    }

}
