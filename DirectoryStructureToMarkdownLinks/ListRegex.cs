using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DirectoryStructureToMarkdownLinks
{
    internal class ListRegex
    {
        readonly List<Regex> _regexes = new();

        public ListRegex(StringCollection collection) 
        {
            foreach(string item in collection)
            {
                _regexes.Add(new Regex(item));
            }
        }

        public bool Contains(string key)
        {
            //bool reslut = false;

            foreach(Regex regex in _regexes)
            {
                if (regex.Match(key).Success) return true;
            }

            return false;
        }

    }
}
