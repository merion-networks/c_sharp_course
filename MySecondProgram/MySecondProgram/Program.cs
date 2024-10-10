using System.ComponentModel;

Console.WriteLine("Добро пожаловать в консольный калькулятор на C#!");
List<string> history = new List<string>();

bool exit = false;

while (!exit)
{
    ShowMenu();

    var choice = GetUserChoice();
    exit = ProcessChoice(choice);
}

bool ProcessChoice(int choice)
{
    double firstNumber = 0, secondNumber = 0, result = 0;

    switch (choice)
    {
        case 1:
            ActionChoice(firstNumber, secondNumber, result, "+");
            break;
        case 2:
            ActionChoice(firstNumber, secondNumber, result, "-");
            break;
        case 3:
            ActionChoice(firstNumber, secondNumber, result, "*");
            break;
        case 4:
            ActionChoice(firstNumber, secondNumber, result, "/");
            break;
        case 5:
            ActionChoice(firstNumber, secondNumber, result, "^");
            break;
        case 6:
            GetOneNumbers(out firstNumber);
            result = SquareRoot(firstNumber);
            Console.WriteLine($"Результат sqrt({firstNumber}) = {result}");
            SaveHistory($"sqrt({firstNumber}) = {result}");
            break;
        case 7:
            ShowHistory();
            break;
        case 0:
            return true;
        default:
            Console.WriteLine("Выбор некоректный. Введите число в соответсвии с пунктами меню!");
            break;


    }
    return false;
}

void ShowHistory()
{
    Console.WriteLine("\n История операций:");

    if (history.Count == 0)
    {
        Console.WriteLine("Историй пуста!");
    }
    else
    {
        foreach (var record in history)
        {
            Console.WriteLine(record);
        }
    }
}

void SaveHistory(string operation)
{
    history.Add(operation);
}

void ActionChoice(double firstNumber, double secondNumber, double result, string operation)
{
    GetTwoNumbers(out firstNumber, out secondNumber);

    switch (operation)
    {
        case "+":
            result = Add(firstNumber, secondNumber);
            break;
        case "-":
            result = Subtract(firstNumber, secondNumber);
            break;
        case "*":
            result = Multiply(firstNumber, secondNumber);
            break;
        case "/":
            result = Divade(firstNumber, secondNumber);
            break;
        case "^":
            result = Power(firstNumber, secondNumber);
            break;
        default:
            Console.WriteLine("Оператор не передан");
            return;
    }

    Console.WriteLine($"Результат {firstNumber} {operation} {secondNumber} = {result}");
    SaveHistory($"{firstNumber} {operation} {secondNumber} = {result}");
}

double Add(double firstNumber, double secondNumber)
{
    return firstNumber + secondNumber;
}

double Subtract(double firstNumber, double secondNumber)
{
    return firstNumber - secondNumber;
}

double Multiply(double firstNumber, double secondNumber)
{
    return firstNumber * secondNumber;
}

double Divade(double firstNumber, double secondNumber)
{
    if (secondNumber == 0)
        throw new DivideByZeroException("Делить на ноль невозможно!");

    return firstNumber / secondNumber;
}

double Power(double firstNumber, double secondNumber)
{
    return Math.Pow(firstNumber, secondNumber);
}
double SquareRoot(double firstNumber)
{
    if (firstNumber < 0)
        throw new ArgumentException("Невозможно вычеслить корень квадратный из отрицательного числа");

    return Math.Sqrt(firstNumber);
}

void GetTwoNumbers(out double firstNumber, out double secondNumber)
{
    Console.Write("Введите 1 число:");
    firstNumber = GetValidNumber();
    Console.Write("Введите 2 число:");
    secondNumber = GetValidNumber();
}


void GetOneNumbers(out double firstNumber)
{
    Console.Write("Введите число:");
    firstNumber = GetValidNumber();
}

double GetValidNumber()
{
    while (true)
    {
        try
        {
            string input = Console.ReadLine();
            double number = double.Parse(input.Replace(',', '.'));
            return number;
        }
        catch (FormatException e)
        {
            Console.WriteLine("Некорректный ввод. Попробуйте еще раз!");
        }
    }
}

int GetUserChoice()
{
    Console.Write("Ваш выбор:");
    if (int.TryParse(Console.ReadLine(), out int choice))
        return choice;
    return 0;
}

void ShowMenu()
{
    Console.WriteLine("\n Пожалуйста, выберите операцию:");
    Console.WriteLine("1. Сложение (+)");
    Console.WriteLine("2. Вычетание (-)");
    Console.WriteLine("3. Умножение (*)");
    Console.WriteLine("4. Деление (/)");
    Console.WriteLine("5. Возведение в степень (^)");
    Console.WriteLine("6. Вычисление квадратного корня (sqrt)");
    Console.WriteLine("7. Посмотреть все операции");
    Console.WriteLine("0. Выход!");
}