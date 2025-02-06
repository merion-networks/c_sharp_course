
Console.Write("Введите число N: ");
if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
{
    PrintNumbers(n);
}
else
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число.");
}

void PrintNumbers(int n)
{
    Console.WriteLine("Числа от 1 до N:");
    for (int i = 1; i <= n; i++)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine();
}