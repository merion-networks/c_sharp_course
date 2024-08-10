using System;

namespace MyFirstProgram
{
    /// <summary>
    /// Тема: Цыклы
    /// </summary>
    public class MyCycle
    {
        public MyCycle()
        {
            // Демонстрация различных циклов и операторов управления циклом

            // Цикл for
            Console.WriteLine("Цикл for:");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            // Цикл while
            Console.WriteLine("\nЦикл while:");
            int j = 0;
            while (j < 10)
            {
                Console.WriteLine(j);
                j++;
            }

            // Цикл do-while
            Console.WriteLine("\nЦикл do-while:");
            do
            {
                Console.WriteLine("Это выполнится хотя бы раз");
            } while (false);

            // Цикл foreach
            Console.WriteLine("\nЦикл foreach:");
            string[] fruits = { "Яблоко", "Банан", "Груша" };
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            // Демонстрация операторов break и continue
            Console.WriteLine("\nИспользование break и continue:");
            for (int i = 0; i < 10; i++)
            {
                if (i == 5) continue; // Пропустить итерацию, когда i равно 5
                if (i == 8) break;    // Прервать цикл, когда i равно 8

                Console.WriteLine(i);
            }
        }
    }
}