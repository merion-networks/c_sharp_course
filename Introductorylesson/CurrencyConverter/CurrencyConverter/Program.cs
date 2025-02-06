using System.Globalization;

Console.Write("Введите сумму в исходной валюте: ");

if(decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount) && amount >= 0)
{
    Console.Write("Введите курс обмена: ");
    if (decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal rate) && rate > 0)
    {
        decimal convertedAmount = amount * rate;
        Console.WriteLine($"Сумма после конвертации: {convertedAmount:F2}");
    }
    else
    {
        Console.WriteLine("Некорректный ввод курса.");
    }
}
else
{
    Console.WriteLine("Некорректный ввод курса.");
}
