using System;

namespace MyFirstProgram
{
    /// <summary>
    /// Тема: Типы данных
    /// </summary>
    public class MyType
    {
        public MyType()
        {
            // Целочисленный тип
            int age = 32;

            // Типы с плавающей точкой
            double price = 19.99;
            float singlePrecision = 19.99f;

            // Строковый тип
            string name = "Борис";

            // Символьный тип
            char firstLetter = 'Б';

            // Логический тип
            bool isAdult = true;

            // Константа
            const double PI = 3.14159;

            // Приведение типов (явное)
            int priceInt = (int)price;

            Console.WriteLine($"Цена (double): {price}");
            Console.WriteLine($"Цена (int): {priceInt}");

            // Nullable типы
            int? nullableInt = null;
            string? nullableString = null;
            float? nullableFloat = null;
            double? nullableDouble = null;

            // Использование var (неявная типизация)
            var myMessage = "Автоматически определится string";
            var myVarInt = 0; // Автоматически определится int

            // Вывод информации о типах
            Console.WriteLine($"Тип myMessage: {myMessage.GetType()}");
            Console.WriteLine($"Тип myVarInt: {myVarInt.GetType()}");
        }
    }
}