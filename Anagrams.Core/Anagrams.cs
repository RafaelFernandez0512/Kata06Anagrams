using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Anagrams.Core
{
    public static class Anagrams
    {
        public static Dictionary<string,string> FindAnagrams(string path,string paramaters=null)
        {
            ValidateFindAnagrams(path);
            var file = File.ReadAllLines(path);
            if (paramaters==null)
            {
                return file.ToDictionary(e => e);
            }
            var words = paramaters?.Split(",");
            var anagrams = new Dictionary<string, string>();
            if (!file.Any(e => words.Contains(e)))
                return anagrams;
          
                foreach (var word in file.GroupBy(e => string.Concat(e.OrderBy(x => x))).Where(e=>words.Contains(e.Key)||words.Any(e=>words.Equals(e))))
                {
                    if (word.Count()>1)
                    {
                        anagrams.Add(word.First(),string.Join(" - ",word));
                    }
                }
         
            return  anagrams;
        }

        private static void ValidateFindAnagrams(string input)
        {
            if(input==null)
                throw new NullReferenceException();
            if (!File.Exists(input))
                throw new FileNotFoundException();
        }
    }
}