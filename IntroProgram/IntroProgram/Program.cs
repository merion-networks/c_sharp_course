Console.WriteLine("Hello, Academy! Добро пожаловать в обучающую программу по C#");


Console.WriteLine("Введите ваше имя:");
var name = Console.ReadLine();

Console.WriteLine("Введите ваше возраст:");
var age = int.Parse(Console.ReadLine());

Console.WriteLine("Введите ваше любимое число:");
var favoriteNumber = int.Parse(Console.ReadLine());

int currentYear = DateTime.Now.Year;
int birthYear = currentYear - age;

Console.WriteLine($"Привет! {name} , вы родились в {birthYear} году!");

if (age >= 18)
{
    Console.WriteLine("Вы совершеннолетний");
}
else
{
    Console.WriteLine("Вы еще не достигли совершеннолетия");
}

Console.WriteLine($"Числа от 1 до {favoriteNumber}");

for (int i = 1; i <= favoriteNumber; i++)
{
    Console.Write($"|{i}| ");
}


int sum = CalculateSum(favoriteNumber);

Console.WriteLine($"\nСумма чисел от 1 до {favoriteNumber} = {sum}");

int CalculateSum(int favoriteNumber)
{
    int sum = 0;
    for (int i = 1; i <= favoriteNumber; i++)
    {
        sum += i;
    }

    return sum;
}
