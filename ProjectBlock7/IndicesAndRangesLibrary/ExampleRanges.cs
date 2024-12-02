using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndicesAndRangesLibrary
{
    /// <summary>
    /// Оператор ".."
    /// </summary>
    public class ExampleRanges
    {
        public void ArreyRangeExample()
        {
            Console.WriteLine("Задание 3:");
            string[] names = { "Анна", "Борис", "Виктория", "Григорий", "Денис", "Елена" };

            string[] firstThree = names[..3];
            string[] lastTwo = names[^2..];
            string[] exceptFirstTwo = names[2..];
            ShowName(firstThree, "Первые три имени:");
            ShowName(lastTwo, "Последние два имени:");
            ShowName(exceptFirstTwo, "Все имена, кроме первых двух:");          
        }

        private void ShowName(string[] names, string massege)
        {
            Console.WriteLine(massege);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
        public void ReadLineExample()
        {
            Console.WriteLine("Задание 2:");
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            string firstFive = input.Length >= 5 ? input[..5] : input;
            string lastThree = input.Length >= 3 ? input[^3..] : input;
            string middle = input.Length > 2 ? input[1..^1] : input;

            Console.WriteLine($"Первые пять символов: {firstFive}");
            Console.WriteLine($"Последние три символа: {lastThree}");
            Console.WriteLine($"Все кроме первого и последнего: {middle}");

        }

        public void PractickMetod()
        {
            Console.WriteLine("Задание 1.1:");

            int[] data = { 5, 10, 15, 20, 25, 30, 35 };

            int[] range = data[2..5];
            ShowRange(range, nameof(range));
        }

        public void ExampleStringRanges()
        {
            string message = "Привет, Академия!";

            string hello = message[..6];
            string academy = message[8..^1];

            Console.WriteLine(message);
            Console.WriteLine(hello);
            Console.WriteLine(academy);
        }
        public void ExampleMetodRanges()
        {
            int[] indices = { 1, 2, 3, 4, 5 };

            int[] rangeOne = indices[1..3];
            int[] rangeSecond = indices[..2];
            int[] rangeThird = indices[2..];
            int[] rangeFourth = indices[^3..^1];


            ShowRange(rangeOne, nameof(rangeOne));
            ShowRange(rangeSecond, nameof(rangeSecond));
            ShowRange(rangeThird, nameof(rangeThird));
            ShowRange(rangeFourth, nameof(rangeFourth));
        }

        private void ShowRange(int[] range, string name)
        {
            for (int i = 0; i < range.Length; i++)
            {
                Console.WriteLine($"{name}[{i}] = {range[i]}");

            }
        }
    }
}
