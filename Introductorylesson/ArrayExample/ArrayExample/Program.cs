int[] numbers  = new int[5];

for (int i = 0; i < numbers.Length; i++)
{
    Console.Write($"Введите элемент массива {i + 1}: ");
    while(!int.TryParse(Console.ReadLine(), out numbers[i]))
    {
        Console.Write("Некорректный ввод. Пожалуйста, введите целое число: ");
    }
}

Console.WriteLine("Вы ввели следующие числа:");
Console.WriteLine(string.Join(", ", numbers));

var sum = 0;
foreach (int num in numbers)
{
    sum += num;
}

Console.WriteLine($"Сумма элементов массива: {sum}");
