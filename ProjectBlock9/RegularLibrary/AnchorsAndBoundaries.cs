using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectBlock9
{
    public class AnchorsAndBoundaries
    {
        public void RegularBeginningOfLine()
        {
            string pattern = "^Привет";
            string input = "Привет мир\nПривет всем\nЗдравствуйте";
            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Multiline);
            foreach (Match match in matches) {

                Console.WriteLine($"Строка начинается с 'Привет': {match.Value}");
            }

        }

        public void RegularEndOfLine()
        {
            string pattern = @"мир$";
            string input = "Привет мир\nПривет всем\nЗдравствуйте";
            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Multiline);
            foreach (Match match in matches)
            {

                Console.WriteLine($"Строка заканчивается на 'мир': {match.Value}");
            }

        }

        public void RegularBorders()
        {
            string pattern = @"\bкод\b";
            string input = "коды код кодирование код.";
            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Multiline);
            foreach (Match match in matches)
            {

                Console.WriteLine($"Найдено слово 'код': {match.Value} на позиции {match.Index}");

            }

        }

        public void RegularNotBorders()
        {
            string pattern = @"\Bкод\B";
            string input = "коды код подкодирование код. кодек подкод кодирование";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {

                Console.WriteLine($"Найдено слово 'код' внутри: {match.Value} на позиции {match.Index}");

            }

        }
    }
}
