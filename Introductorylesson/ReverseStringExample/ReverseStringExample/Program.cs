Console.WriteLine("Введите строку: ");
var input = Console.ReadLine();

string reverse = ReverseString(input);

Console.WriteLine($"Обращенная строка - {reverse}");

string ReverseString(string? input)
{
    if (input == null)
    {
        throw new ArgumentNullException("input");
    }
    char[] charArray = input.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
}