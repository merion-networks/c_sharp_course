using AbstractionLibrary.Strategy;
using AbstractionLibrary.Template;
using EncapsulationLibrary;
using InheritanceLibrary;
using OverridingLibrary;
using PolymorphismLibrary;
using PolymorphismLibrary.Service;
using PracticLibrary;
using PracticLibrary.Interface;
using PracticLibrary.Model;

//BankAccount bankAccount = new BankAccount();
//Person person  = new Person("Василий", 30);

//Console.WriteLine($"Баланс до изменений - {bankAccount.Balance}");

//person.HaveBirthday();
//Console.WriteLine($"У {person.Name} прошло день рождение, теперь ему");
//Console.WriteLine($"Введите баланс");
//var amount = Console.ReadLine();

//bankAccount.Deposit(decimal.Parse(amount));


//Console.WriteLine($"Введите сумму вычета");
//var amountDeduction = Console.ReadLine();

//bankAccount.Whithdraw(decimal.Parse(amountDeduction));

//Console.WriteLine($"Баланс после изменений - {bankAccount.Balance}");




//Dog dog = new Dog();
//dog.Name = "Бобик";
//dog.Bark();
//dog.Eat();


//Cat cat = new Cat();
//cat.Name = "Муська";
//cat.Eat();
//cat.Meow();

//Animal animal = new Animal();
//animal.Name = "Любое животное";
//animal.Eat();


//Triangle triangle = new Triangle();
//Square square = new Square();

//triangle.Height = 20;
//triangle.Base = 15;
//Console.WriteLine($"Площадь треугольника - {triangle.GetArea()}"); 


//square.Side = 10;
//Console.WriteLine($"Площадь квадрата - {square.GetArea()}");


//List<Employee> Employees = new List<Employee>();

//Employees.Add(new SalariedEmployee() { Name = "Иван", AnnyalSalary = 500000 });
//Employees.Add(new HourlyEmployee() { Name = "Федя", HourlyRate = 1200, HoursWorked = 30 });
//Employees.Add(new HourlyEmployee() { Name = "Юля", HourlyRate = 1500, HoursWorked = 30 });
//Employees.Add(new HourlyEmployee() { Name = "Маша", HourlyRate = 1800, HoursWorked = 30 });
//Employees.Add(new SalariedEmployee() { Name = "Петр", AnnyalSalary = 800000 });


//ProcessPayroll(Employees);

//void ProcessPayroll(List<Employee> employees)
//{
//    foreach (var employee in employees)
//    {
//        decimal pay = employee.CalculatePay();
//        Console.WriteLine($"Сотрудник {employee.Name} получит зарплату {pay}");
//    }
//}




//Order order = new Order();
//order.TotalAmount = 2000;

//OrderService orderService = new OrderService();
//orderService.ProcessOrder(order, new CreditCardPayment());
//orderService.ProcessOrder(order, new PayPalPayment());

//CsvDataProcessor csvDataProcessor = new CsvDataProcessor();
//csvDataProcessor.Process(null);



//CompressionContext  compressionContext  = new CompressionContext(new ZipCompressionStrategy());
//compressionContext.CreateArchive("testZip.txt"); //Сжатие в ZIP


//compressionContext.SetStrategy(new RarCompressionStrategy());
////compressionContext.CreateArchive("testRar.txt"); //Сжатие в RAR

//List<Transport> transports = new List<Transport>()
//{
//    new Car {Make = "BMW", ModelName = "3 series"},
//    new Airplane {Make = "Boeing", ModelName = "747"},
//    new FlyingCar {Make = "FutureTech", ModelName = "SkyRunner"}
//};

//foreach (var transport in transports)
//{
//    transport.Start();

//    if (transport is IDriveble driveble)
//    {
//        driveble.Drive();
//    }

//    if (transport is IFlyable flyable)
//    {
//        flyable.Fly();
//    }

//    if (transport is IServiceable serviceable) {

//        serviceable.Service();
//    }

//    Console.WriteLine("------------");
//}

//DerivedClass derivedClass = new DerivedClass();
//derivedClass.Display();

//BaseClass baseClass = new BaseClass();
//baseClass.Display();


//Complex complexFirst = new Complex(1,2);
//Complex complexSecond = new Complex(3,4);

//var result = complexFirst +  complexSecond;
//Console.WriteLine(result);


//Fahrenheit fahrenheit = new Fahrenheit(100);
//Celsius celsius = (Celsius)fahrenheit; // Необходимо явное преобразование
//Console.WriteLine(celsius.Degrees.ToString());

//Fahrenheit fahrenheit1 = celsius;
//Console.WriteLine(fahrenheit1.Degrees.ToString());

//Meter meter = new Meter(1500);
//Kilometer kilometer = meter;  // не требуется явное преобразование
//Console.WriteLine(kilometer.Value.ToString());


//BaseClass baseClassFirst = new BaseClass(10);
//BaseClass baseClassSecond = new BaseClass(40);

//BaseClass baseClassThird = baseClassFirst + baseClassSecond;
//Console.WriteLine(baseClassThird.Value);

//DerivedClass derivedClassFirst = new DerivedClass(10);
//DerivedClass derivedClass = new DerivedClass(40);
//DerivedClass derivedClass1 = derivedClassFirst + derivedClass;

//Console.WriteLine(derivedClass1.Value);


var calculete = new GenericCalculation<Number>();

Number n1 = new Number(5);
Number n2 = new Number(10);

Number number = n1 + n2;

Number result = calculete.Add(n1, n2);

Console.WriteLine(number.Value);


var calcDynamic  = new GenericDynamicCalculation<Number>();
Number number1 = calcDynamic.Add(n1, n2); 