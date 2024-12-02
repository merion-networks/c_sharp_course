// See https://aka.ms/new-console-template for more information


using CustomExtensionsLibrary.Attributes;
using CustomExtensionsLibrary.Consol;
using CustomExtensionsLibrary.Extensions;

string numberString = "123";

try
{
    int number = numberString.ToInt();
    Console.WriteLine($"Строка \"{numberString}\" преобразована в число {number}.");
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
}


int num = 5;
Console.WriteLine($"\nЧисло {num} является простым: {num.IsPrime()}");
Console.WriteLine($"Факториал числа {num}: {num.Factorial()}");

// Работа с расширяющими методами для DateTime
DateTime date = DateTime.Now;
Console.WriteLine($"\nТекущая дата и время: {date}");
Console.WriteLine($"Unix Timestamp: {date.ToToUnixTimestamp()}");
Console.WriteLine($"Является выходным днем: {date.IsWeekend()}");

Type type = typeof(DemoAttribute);

if (Attribute.GetCustomAttribute(type, typeof(AuthorAttribute)) is AuthorAttribute authorAttribute)
{
    Console.WriteLine("\nИнформация об авторе:");
    Console.WriteLine($"Имя: {authorAttribute.Name}");
    Console.WriteLine($"Email: {authorAttribute.Email}");
}

if (Attribute.GetCustomAttribute(type, typeof(VersionAttribute)) is VersionAttribute versionAttribute)
{
    Console.WriteLine("\nИнформация о версии:");
    Console.WriteLine($"Версия: {versionAttribute.NumberVersion}");
    Console.WriteLine($"Изменения: {versionAttribute.Changes}");
}

if (Attribute.GetCustomAttribute(type, typeof(DocumentationAttribute)) is DocumentationAttribute documentationAttribute)
{
    Console.WriteLine("\nИнформация о документации:");
    Console.WriteLine($"Описание: {documentationAttribute.Description}");
    Console.WriteLine($"Ссылка на Confluence: {documentationAttribute.ConfluenceLink}");
}


// Работа с расширяющими методами для коллекций
List<int> numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };

IEnumerable<int> uniqueNumbers = numbers.GetUnique();
Console.WriteLine($"\nУникальные числа: {uniqueNumbers.ToSeparatorString()}");
