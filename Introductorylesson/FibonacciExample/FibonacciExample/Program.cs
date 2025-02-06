
Console.WriteLine("Введите количество чисел Фибоначчи для вывода:");

if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
{
    PrintFibonacci(count);
}
else
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число.");
}

void PrintFibonacci(int count)
{
    int a = 0;
    int b = 1;

    Console.WriteLine("Числа Фибоначчи: ");

    for (int i = 0; i < count; i++) // i = i + 1;
    {
        Console.Write(a + " ");
        int temp = a;
        a = b;
        b = temp + b;

    }
    Console.WriteLine();
}