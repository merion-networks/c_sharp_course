using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectBlock9
{
    public class BaseConstruction
    {


        void RegularPoint()
        {
            string pattern = "a.c";
            string input = "abc arc a\nc a-c";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Найдено совпадение: '{match.Value}' на позиции {match.Index}");
            }
        }

        void RegularStar()
        {
            string pattern = "ab*c";
            string input = "ac abc abbc abbbc";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Найдено совпадение: '{match.Value}' на позиции {match.Index}");
            }
        }


        void RegularPlus()
        {
            string pattern = "ab+c";
            string input = "ac abc abbc abbbc";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Найдено совпадение: '{match.Value}' на позиции {match.Index}");
            }
        }
        void RegularQuestion()
        {
            string pattern = "ab?c";
            string input = "ac abc abbc abbbc";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Найдено совпадение: '{match.Value}' на позиции {match.Index}");
            }
        }

        void RegularRepetitions()
        {
            string pattern = "ab{2}c";
            string input = "ac abc abbc abbbc abbc";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Найдено совпадение: '{match.Value}' на позиции {match.Index}");
            }
        }

        void RegularRepetitionsDiapazone()
        {
            string pattern = "ab{2,4}c";
            string input = "ac abc abbc abbbc abbc abbbbbc abbbbc";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Найдено совпадение: '{match.Value}' на позиции {match.Index}");
            }
        }


    }
}
