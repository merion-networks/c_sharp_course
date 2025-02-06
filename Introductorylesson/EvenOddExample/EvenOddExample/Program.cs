Console.WriteLine("Введите число: ");

if (int.TryParse(Console.ReadLine(), out int number))
{
    if (int.IsEvenInteger(number))
    {
        Console.WriteLine("Четное число!");
    }

    if (number % 2 == 0)
    {
        Console.WriteLine("Четное число!");
    }
    else
    {
        Console.WriteLine("Не четное число!");
    }
}
else
{
    Console.WriteLine("Не корректный ввод");
}
