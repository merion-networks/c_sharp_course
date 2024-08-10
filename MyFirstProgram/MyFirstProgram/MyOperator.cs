namespace MyFirstProgram
{
    /// <summary>
    /// Тема: Операторы
    /// </summary>
    public class MyOperator
    {
        public MyOperator()
        {
            // Демонстрация арифметических операторов
            int result = 10 + 5 * 2;
            Console.WriteLine($"10 + 5 * 2 = {result}");

            int res = (10 + 5) * 2;
            Console.WriteLine($"(10 + 5) * 2 = {res}");

            // Демонстрация операторов сравнения
            bool isEqual = (5 == 5);
            Console.WriteLine($"5 == 5 is {isEqual}");

            // Демонстрация логических операторов
            bool complex = (true && false) || (5 > 3);
            Console.WriteLine($"(true && false) || (5 > 3) is {complex}");

            // Демонстрация операторов присваивания
            int age = 10;
            Console.WriteLine($"Initial age: {age}");

            age += 10;
            Console.WriteLine($"Age after += 10: {age}");

            // Демонстрация тернарного оператора
            string status = (age >= 18) ? "Совершеннолетний" : "Несовершеннолетний";
            Console.WriteLine($"Status: {status}");

            // Демонстрация побитовых операторов
            int a = 5;  // 0101 в двоичной системе
            int b = 3;  // 0011 в двоичной системе

            // Побитовое И (AND)
            int andResult = a & b;  // 0001 в двоичной системе
            Console.WriteLine($"{a} & {b} = {andResult}");

            // Побитовое ИЛИ (OR)
            int orResult = a | b;   // 0111 в двоичной системе
            Console.WriteLine($"{a} | {b} = {orResult}");

            // Побитовое исключающее ИЛИ (XOR)
            int xorResult = a ^ b;  // 0110 в двоичной системе
            Console.WriteLine($"{a} ^ {b} = {xorResult}");

            // Побитовое НЕ (NOT)
            int notResult = ~a;     // 1111...1010 в двоичной системе
            Console.WriteLine($"~{a} = {notResult}");

            // Сдвиг влево
            int leftShift = a << 1; // 1010 в двоичной системе
            Console.WriteLine($"{a} << 1 = {leftShift}");

            // Сдвиг вправо
            int rightShift = a >> 1; // 0010 в двоичной системе
            Console.WriteLine($"{a} >> 1 = {rightShift}");
        }
    }
}