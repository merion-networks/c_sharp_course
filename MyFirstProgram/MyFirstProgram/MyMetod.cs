using System;

namespace MyFirstProgram
{
    // Расширение для подсчета слов в строке
    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            return str.Split(new char[] { ' ', ',', '.', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    /// <summary>
    /// Тема: Методы
    /// </summary>
    public class MyMetod
    {
        // Сложение целых чисел
        public int Sum(int a, int b)
        {
            return a + b;
        }

        // Сложение чисел с плавающей точкой
        public double Sum(double a, double b)
        {
            return a + b;
        }

        // Метод без возвращаемого значения
        public void TempSum(int a, int b)
        {
            var result = a + b;
        }

        // Метод с опциональным параметром
        public void PrintInfo(string name, int age = 30)
        {
            Console.WriteLine($"Имя: {name}, возраст - {age}");
        }

        // Рекурсивный метод для вычисления факториала
        public int Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }

        public MyMetod()
        {
            // Демонстрация работы методов
            int result = Sum(1, 2);
            double result2 = Sum(2.5, 3.7);

            PrintInfo("Test");
            PrintInfo("Test", 45);
            PrintInfo(age: 50, name: "Test");

            var resFactorial = Factorial(13);
            Console.WriteLine(resFactorial);

            // Демонстрация метода расширения
            string test = "привет, это тестовая строка демонстрации метода расширения.";
            Console.WriteLine(test);
            Console.WriteLine(test.WordCount());
        }
    }
}