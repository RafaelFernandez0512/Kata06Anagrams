using System;
using System.IO;
using NUnit.Framework;

using System.Collections.Generic;

namespace KataAnagrams.Test
{
    public class FindAnagramsTest
    {
        private readonly string _path = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.Parent.FullName,"wordlist.txt") ;
        [Test]
        public void FindAnagrams_InputNull_ReturnNullReferenceException()
        {
            Assert.Catch<NullReferenceException>( ()=>Anagrams.Core.Anagrams.FindAnagrams(null));
        }

        [Test]
        public void FindAnagrams_FileInvalid_ReturnFileFoundException()
        {
            var expect = "wordlist";
            Assert.Catch<FileNotFoundException>( ()=>Anagrams.Core.Anagrams.FindAnagrams(expect));
        }

        [Test]
        public void FindAnagrams_FileContentsLines_ReturnsNoDictionaryNotEmpty()
        {
            Assert.IsNotEmpty(Anagrams.Core.Anagrams.FindAnagrams(_path));
        }
        [Test]
        public void FindAnagrams_WordsAreContentInDictionary_ReturnDictionaryWithAnagrams()
        {
            var expect = new Dictionary<string, string>()
            {
                ["AAM"] = "AAM - AMA"
            };
            var parameter = "AAM";
            var result = Anagrams.Core.Anagrams.FindAnagrams(_path, parameter);
            Assert.AreEqual(expect,result);
        }
        [Test]
        public void FindAnagramas_WordsSeparateByCommaAndContentsDictionary_ReturnDictionaryWithAnagrams()
        {
            var expect = new Dictionary<string, string>()
            {
                ["AAM"] = "AAM - AMA",
                ["ACT"] = "ACT - ATC - CAT"
            };
            var parameter = "AAM,ACT";
            var result = Anagrams.Core.Anagrams.FindAnagrams(_path, parameter);
            Assert.AreEqual(expect,result);
            
        }
    }
}