using System.Linq
 
int[] numbers = { 99, 9, 3, 4, 3 };

int min = FindMin(numbers);
int max = FindMax(numbers);


Console.WriteLine($"Минимальное число: {min}");
Console.WriteLine($"Максимальное число: {max}");

Console.WriteLine($"Минимальное число: {numbers.Min()}");
Console.WriteLine($"Максимальное число: {numbers.Max()}");

int FindMax(int[] numbers)
{
    int max = numbers[0];
    foreach (var num in numbers)
    {
        if (num > max)
            max = num;
    }
    return max;
}
int FindMin(int[] numbers)
{
    int min = numbers[0];
    foreach (var num in numbers)
    {
        if (num < min)
            min = num;
    }
    return min;
}
