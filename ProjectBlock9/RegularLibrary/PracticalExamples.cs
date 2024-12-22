using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectBlock9
{
    public class PracticalExamples
    {
        //private static string pattern;
        //Regex Regex = new Regex(pattern, RegexOptions.Compiled);

        //- `IsMatch(string input)`: проверяет, соответствует ли строка заданному шаблону.
        //- `Match(string input)`: ищет первое совпадение.
        //- `Matches(string input)`: ищет все совпадения.
        //- `Replace(string input, string replacement)`: заменяет совпадения на заданную строку.
        //- `Split(string input)`: разделяет строку по заданному шаблону.


        public void ValidateEmail()
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            string[] emails = { "user@example.com", "user.example", "user@.com", "user@domain.co.uk" };


            foreach (string email in emails)
            {

                if (Regex.IsMatch(email, pattern))
                {
                    Console.WriteLine($"Корректный email: {email}");
                }
                else
                {
                    Console.WriteLine($"Некорректный email: {email}");
                }
            }
        }

        public void GetTextForLog()
        {
            string input = @"[2023-10-02 12:00:00] INFO User 'alice' logged in.
                             [2023-10-02 12:05:00] ERROR Unable to connect to database.
                             [2023-10-02 12:10:00] INFO User 'bob' logged out.";

            string pattern = @"\[(?<date>[\d\-\:\s]+)\]\s(?<level>\w+)\s(?<message>.+)";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {

                Console.WriteLine($"Дата: {match.Groups["date"].Value}");
                Console.WriteLine($"Уровень: {match.Groups["level"].Value}");
                Console.WriteLine($"Сообщение: {match.Groups["message"].Value}");
                Console.WriteLine();

            }
        }

        public void GerUrlForText()
        {
            string pattern = @"https?://\S+";
            string input = "Посетите https://www.example.com или http://example.org для дополнительной информации.";

            MatchCollection matches = Regex.Matches(input, pattern);


            foreach (Match match in matches)
            {
                Console.WriteLine($"Найден URL: {match.Value}");
            }

        }


        public void RegularReplece()
        {
            string pattern = @"(\d{3})(\d{3})(\d{4})"; //(XXX) XXX-XXXX
            string replacement = "($1)$2-$3";
            string input = "Контакты: 8005551234, 9006667890.";

            string result = Regex.Replace(input, pattern, replacement);

            Console.WriteLine(result);

        }

        public void RegularRepleceSpace()
        {
            string pattern = @"\s+";
            string replacement = " ";
            string input = "Это   пример   текста   с    лишними  пробелами.";

            string result = Regex.Replace(input, pattern, replacement);

            Console.WriteLine(result);
        }

        public void ExeptionRegular()
        {
            try
            {
                string pattern = "a+";
                string input = new string('a', 1000000) + "b";

                Regex regex = new Regex(pattern, RegexOptions.None, TimeSpan.FromMilliseconds(10));
                regex.Match(input);
            }
            catch (RegexMatchTimeoutException e)
            {
                Console.WriteLine("Регулярное выражение превысило тайм-аут.");
            }

        }


        public void ExamplePatternWhitespace()
        {
            string pattern = @"
          ^                      # Начало строки
          (?<local>[\w\.-]+)     # Локальная часть
          @                      # Символ '@'
          (?<domain>[\w\.-]+)    # Доменная часть
          \.                     # Точка '.'
          (?<tld>\w{2,6})        # Домен верхнего уровня
          $                      # Конец строки
          ";


            Regex regex = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            Match match = regex.Match("user@example.com");

            if (match.Success)
            {
                Console.WriteLine($"Локальная часть: {match.Groups["local"].Value}");
                Console.WriteLine($"Домен: {match.Groups["domain"].Value}");
                Console.WriteLine($"TLD: {match.Groups["tld"].Value}");

            }

        }

    }
}
