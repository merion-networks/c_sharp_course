Console.Write("Введите год: ");
if(int.TryParse(Console.ReadLine(), out int year) && year > 0)
{
    if (DateTime.IsLeapYear(year))
    {
        Console.WriteLine($"{year} год является високосным.");
    }
    else
    {
        Console.WriteLine($"{year} год не является високосным.");
    }
}
else
{
    Console.WriteLine("Некорректный ввод года.");
}
