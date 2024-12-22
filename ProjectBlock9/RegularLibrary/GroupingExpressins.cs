using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectBlock9
{
    public class GroupingExpressins
    {
        public void RegularExample()
        {
            string pattern = "(ab)+";
            string input = "ab abab ababab bababa";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine($"Найдено совпадение: {match.Value}");
            }
        }

        public void RegularNumberExample()
        {
            string pattern = @"(\w+)@(\w+\.\w+)";
            string input = "email@example.com";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine($"Локальная часть: {match.Groups[1].Value}");
                Console.WriteLine($"Домен: {match.Groups[2].Value}");
            }
        }

        public void RegularNameNumberExample()
        {
            string pattern = @"(?<local>\w+)@(?<domain>\w+\.\w+)";
            string input = "email@example.com";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine($"Локальная часть: {match.Groups["local"].Value}");
                Console.WriteLine($"Домен: {match.Groups["domain"].Value}");
            }
        }
    }
}