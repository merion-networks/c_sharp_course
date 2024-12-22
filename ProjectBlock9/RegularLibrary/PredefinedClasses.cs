using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectBlock9
{
    public  class PredefinedClasses
    {
        public void RegularAnyNumber() {
            string pattern = @"\d+";
            string input = "Номера: 123, 456 и 7890";

            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Найдена число: {match.Value} на позиции {match.Index}");
            }
        }

        public void RegularNotNumber()
        {
            string pattern = @"\D+";
            string input = "Номера: 123, 456 и 7890";

            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Найдено не число: {match.Value} на позиции {match.Index}");
            }
        }

        public void RegularAlphanumericCharacter()
        {
            string pattern = @"\w+";
            string input = "Пример_текста 123 !@#";

            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Найдено слово:  {match.Value} на позиции {match.Index}");
            }
        }

        public void RegularNotAlphanumericCharacter()
        {
            string pattern = @"\W+";
            string input = "Пример_текста 123 !@#";

            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Найдено:  {match.Value} на позиции {match.Index}");
            }
        }

        public void RegularAnySpaceCharacter()
        {
            string pattern = @"\s+";
            string input = "Пример_текста 1  _ 23   !@#";

            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.None);

            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Найден пробел:  {match.Value} на позиции {match.Index}");
            }
        }
        public void RegularNotSpaceCharacter()
        {
            string pattern = @"\S+";
            string input = "Пример_текста 1  _ 23   !@#";

            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.None);

            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Найден пробел:  {match.Value} на позиции {match.Index}");
            }
        }
    }
}
