using ProjectBlock8.ExampleException;
using ReadAndWriteFileLibrary;
using ReadAndWriteFileLibrary.Model;

/*
    System.Exception: Это базовый класс для всех исключений в C#. Он предоставляет общие свойства и методы для обработки исключений.
    System.ArgumentException: Исключение, которое возникает, когда один из аргументов, переданных методу, является недопустимым.
    System.ArgumentNullException: Исключение, которое возникает, когда аргумент, переданный методу, имеет значение null, а метод не допускает значения null.
    System.ArgumentOutOfRangeException: Исключение, которое возникает, когда значение аргумента находится за пределами допустимого диапазона.
    System.InvalidOperationException: Исключение, которое возникает, когда метод вызывается в неподходящее время или когда объект находится в несоответствующем состоянии.
    System.NotImplementedException: Исключение, которое возникает, когда вызывается метод или свойство, которые еще не реализованы.
    System.NullReferenceException: Исключение, которое возникает, когда происходит попытка доступа к объекту или члену объекта, который имеет значение null
    System.IndexOutOfRangeException: Исключение, которое возникает, когда происходит попытка доступа к элементу массива или коллекции с использованием индекса, который находится за пределами допустимого диапазона.
    System.FormatException: Исключение, которое возникает, когда формат аргумента недопустим или не соответствует ожидаемому формату.
    System.OverflowException: Исключение, которое возникает, когда арифметическая операция приводит к переполнению
    System.DivideByZeroException: Исключение, которое возникает, когда происходит попытка деления на ноль.
    System.IO.FileNotFoundException: Исключение, которое возникает, когда запрашиваемый файл не найден
    System.IO.DirectoryNotFoundException: Исключение, которое возникает, когда запрашиваемый каталог не найден. 
    System.IO.IOException: Исключение, которое возникает, когда происходит ошибка ввода-вывода при работе с файлами или потоками.
    System.UnauthorizedAccessException: Исключение, которое возникает, когда у текущего пользователя нет необходимых прав доступа для выполнения операции.
 
 */

//ExampleDivadeByZero exampleDivadeByZero = new ExampleDivadeByZero();
//exampleDivadeByZero.ExampleMetod();

//ExampleFileException exampleFileException = new ExampleFileException();
//exampleFileException.ExampleMetod();

//ExampleDataBase exampleDataBase = new ExampleDataBase();
//exampleDataBase.ExampleMetod();


//ExampleFormateException exampleFormateException = new ExampleFormateException();
//exampleFormateException.ExampleMetod();

//ExampleApi exampleApi = new ExampleApi();
//exampleApi.MetodApi();


WriteFileExample writeToExample = new WriteFileExample();   
//writeToExample.ExampleMetrod();

ReadFileExample readFileExample = new ReadFileExample();
//readFileExample.ExampleMetrod();


Settings settings = new Settings
{
    ThemeName = "Dark",
    ThemePath = "C:\\Themes\\Dark.xaml",
    FontSize = 14,
    ShowNotification = true,
    ShowIcon = true,
    Language = "Русский",
    LastBackupDate = DateTime.Now
};

writeToExample.SaveSettings(settings);

var loadedSettings = readFileExample.LoadSettings();

// Используем загруженные настройки
Console.WriteLine($"ThemeName: {loadedSettings.ThemeName}");
Console.WriteLine($"ThemePath: {loadedSettings.ThemePath}");
Console.WriteLine($"Font Size: {loadedSettings.FontSize}");
Console.WriteLine($"Show Notifications: {loadedSettings.ShowNotification}");
Console.WriteLine($"Show Icon: {loadedSettings.ShowIcon}");
Console.WriteLine($"Language: {loadedSettings.Language}");
Console.WriteLine($"Last Backup Date: {loadedSettings.LastBackupDate}");


List<Customer> customers = new List<Customer>
{
    new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" },
    new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com" },
    new Customer { Id = 3, Name = "Alice Johnson", Email = "alice@example.com" }
};


writeToExample.ExportDataToCsv(customers);


string binaryPath = Path.Combine("Files", "binary.bin");
byte[] data = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
writeToExample.WriteBinaryFile(binaryPath, data);

var binaryData = readFileExample.ReadBinaryFile(binaryPath);

writeToExample.CompressFile(Path.Combine("Files", "customers.csv"), Path.Combine("Files", "customersCompress.zip"));


readFileExample.DecompressFile(Path.Combine("Files", "customersCompress.zip"), Path.Combine("Files", "customers_new.csv"));
Console.ReadKey();
