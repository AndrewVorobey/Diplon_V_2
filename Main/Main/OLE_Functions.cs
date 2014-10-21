using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Main
{
    public partial class OLE
    {
        static int FindInt(string s, int i)
        {
            int[] matches = Regex.Matches(s, "\\d+")
                .Cast<Match>()
                .Select(x => int.Parse(x.Value))
                .ToArray();
            foreach (int match in matches) ;
            if (matches.Length > i)
                return matches[i];
            else return -1;
        }
        static string FindName(string s)
        {
            Regex regex = new Regex(@"\s([А-Я][а-я]*)\s([А-Я])\.\s?([А-Я])\.?");
            return regex.Match(s).Value;

        }
    }
}
