using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectBlock9
{
    public class CharacterClasses
    {
        public void RegularSquareBrackets()
        {
            string pattern = "[aeiou]";
            string input = "Hello World";

            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Гласная буква: {match.Value} на позиции {match.Index}");
            }

        }

        public void RegularCircumflex()
        {
            string pattern = "[^aeiou]";
            string input = "Hello World";

            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Согласная буква и пробел: {match.Value} на позиции {match.Index}");
            }

        }
    }
}
