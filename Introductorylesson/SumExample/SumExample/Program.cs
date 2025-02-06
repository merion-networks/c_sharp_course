
while (true)
{
    Console.Write("Введите первое число: ");

    if (int.TryParse(Console.ReadLine(), out int firstNumber))
    {
        Console.Write("Введите второе число: ");
        if (int.TryParse(Console.ReadLine(), out int secondNumber))
        {
            var sum = firstNumber + secondNumber;
            Console.WriteLine($"Сумма чисел: {sum}");
            break;
        }
        else
        {
            Console.WriteLine("Некорректный ввод второго числа.");
        }
    }
    else
    {
        Console.WriteLine("Некорректный ввод первого числа.");
    }
}