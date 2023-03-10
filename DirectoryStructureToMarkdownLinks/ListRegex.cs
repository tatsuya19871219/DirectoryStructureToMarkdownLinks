using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace DirectoryStructureToMarkdownLinks
{
    internal class ListRegex
    {
        readonly List<Regex> _regexes = new();

        public ListRegex(StringCollection collection)
        {
            foreach (string item in collection)
            {
                try
                {
                    _regexes.Add(new Regex(item));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool Contains(string key)
        {
            //bool reslut = false;

            foreach (Regex regex in _regexes)
            {
                if (regex.Match(key).Success) return true;
            }

            return false;
        }

    }
}
