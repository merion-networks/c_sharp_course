Console.Write("Введите исходную строку: ");
string input = Console.ReadLine();

Console.Write("Введите символ для замены: ");
char oldChar = Console.ReadKey().KeyChar;

Console.WriteLine();

Console.Write("Введите новый символ: ");
char newChar = Console.ReadKey().KeyChar;
Console.WriteLine();

var result = input.Replace(oldChar, newChar);
Console.WriteLine($"Результат замены: {result}");

