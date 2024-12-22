using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectBlock9
{
    public class AdvancedTechniques
    {
        public void RegularExample()
        {
            string pattern = @"<.*>";
            string input = "<div><p>Текст</p></div>";

            Match match = Regex.Match(input, pattern);
            Console.WriteLine(match.Value);

        }

        public void RegularLazyExample()
        {
            string pattern = @"<.*?>";
            string input = "<div><p>Текст</p></div>";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)            {
                
                Console.WriteLine($"{match.Value}");
            }
        }

        public void RegularPositiveViewingExample() {
            string pattern = @"\w+(?=:)";
            string input = "ключ: значение";

            Match match = Regex.Match(input, pattern);
            Console.WriteLine(match.Value);
        }

        public void RegularNegativeViewingExample()
        {
            string pattern = @"\b(?!un)\w+\b";
            string input = "known unknown unique unusual";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {

                Console.WriteLine($"{match.Value}");
            }
        }


        public void RegularPositiveViewingBackExample()
        {
            string pattern = @"(?<=\$)\d+";
            string input = "Цена: $100";


            Match match = Regex.Match(input, pattern);
            Console.WriteLine(match.Value);
        }

        public void RegularNegativeViewingBackExample()
        {
            // Установим инвариантную культуру
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            string pattern = @"(?<![\d.])\d+(?![\d.])";
            string input = "Версия 1.2.3 номер 4 и значение 10.5";

            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.None);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Найдено число: {match.Value}");
            }
        }
    }
}
