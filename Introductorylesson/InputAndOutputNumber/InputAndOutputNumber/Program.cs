while (true)
{
    Console.Write("Введите число: ");

    var input = Console.ReadLine();

    if (int.TryParse(input, out int number))
    {
        Console.WriteLine($"Вы ввели целое число - {number}");
        break;
    }
    else if (double.TryParse(input, out double doubleNumber))
    {
        Console.WriteLine($"Вы ввели число с плавающей точкой - {doubleNumber}");
        break;
    }
    else
    {
        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
    }
}
