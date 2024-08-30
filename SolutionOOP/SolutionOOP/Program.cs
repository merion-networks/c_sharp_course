using SolutionOOP;
/**
 * PascalCase - предназначен для наименования классов и методов
 * Каждое слово пишется с заглавной буквы и без разделителей
 * Хорошо: public class Car, public int CalculeteAge
 * Плохо: public class car, public int calculeteAge
 * 
 * camalCase - предназначен для наименования локальных переменных и полей класса
 * Первое слово начинается с маленькой буквы, а каждое последующее слово пишется с заглавной буквы и без разделителей 
 * Хорошо: public static int totalCar; int currentYear = 2024
 * Плохо: public static int TotalCar; int CurrentYear = 2024
 * 
 * Использование осмысленных имен
 * Имена должны отражать что делает метод или хранит переменная (поле , свойство)
 * Хорошо: GetCustomerDetails(), totalAmound
 * Плохо: GetStuff(), a
 * 
 * Нужно избегать сокращений, если они не общеприняты
 * Нужно использовать слова полностью , кроме общепринятых абривеатур
 * Хорошо: HttpRequest, UserIdentification (UserId/UserID)
 * Плохо: UsrID, HttpReq
 * 
 * Примеры хороших и плохих имен
 * Хорошие
 * CustomerRepository - класс для работы с данными клиентов
 * CalculateTotalPtice() - метод расчет общей цены
 * isActive - логическое поле указываеющее на активность 
 * numberOfItems - переменная для храниения количества элементов
 * 
 * Плохие
 * Data - слишком общее имя
 * DoStuff - не информативное имя метода 
 * flag - неясное назначение переменной
 * f - неинформативное имя переменной
 * 
 * Избегайте венгерской нотации Плохо string strName, int iSize Хорошо string name , int size
 * 
 * Длинна имен
 * Имена должны быть достаточны длинными чтобы быть понятнымы , но не черезмерно длинными
 * Хорошо GetCustumerBuName()
 * Плохо GetCustName()
**/


var honda = new Car() { Make = "Honda", Model="Civic", Year = 2021, Speed = 40};
var bmw = new Car() { Make = "BMW", Model="320i", Year = 1999, Speed = 50};

Car ferrary = Car.CreateSportCar();

honda.Accelerate();
bmw.Accelerate();

Console.WriteLine("Сколько лет авто?");
Console.WriteLine($"Honda - {honda.CalculeteAge(DateTime.Now.Year)}");
Console.WriteLine($"BMW - {bmw.CalculeteAge(DateTime.Now.Year)}");


honda.Speed = 70;
bmw.Speed = 40;
Console.WriteLine(honda.Speed);
Console.WriteLine(bmw.Speed);
    
honda.Accelerate();
bmw.Accelerate();

bmw.Speed = 301;
Console.WriteLine(bmw.Speed);






