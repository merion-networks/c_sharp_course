/*
 - Для float нужно добавлять суфикс 'f' или 'F'
 - Для decimal нужно добавлять суфикс 'm' или 'M'
 - Для ulong нужно добавлять суфикс 'ul' или 'UL'
 - Для long нужно добавлять суфикс 'l' или 'L'
 - Для uint нужно добавлять суфикс 'u' или 'U' 
 */


//Неявная типизация

using CycleLibrary;
using IfElseLibrary;
using OperationLibrary.Logic;
using OperationLibrary.Operation;
using ProgramType.ReferenceType;
using ProgramType.SpecialType;
using ProgramType.ValuesType;
using VariablesLibrary;


var age = 10;
var name = "name";

const int maxInt = int.MaxValue;
const int minInt = int.MinValue;
const double pi = 3.14159;

///Преобразование типов
int x = 10;
long lx = x; //Тут не явное преобразование типов из int в long

double d = 21.567;
int y = (int)d; // Явное преобразование типов из double в int


//Числовые разделители 

int billion = 1_000_000_000;
double avagadro = 6.022_140_73e23;

//var enumType = new EnumType();
//var structType = new StructType();
//var tuples = new Tuples();
//var nullableType = new NullableType();

//var variable = new Variable();
//var pecord = new Record();


//Патерны сопоставления 

//object massege = "Hello, academy!";

//if (massege is string { Length: > 5 } str)
//{
//    Console.WriteLine($"Строка длинной больше 5 - {str}");
//}

//ArithmeticOperation arithmeticOperation = new ArithmeticOperation();
//TernaryOperator ternaryOperator = new TernaryOperator();
//ArrayType arrayType = new ArrayType();
//ConstructionIfElse tempIfElse = new ConstructionIfElse();
//ConstractionSwitch constractionSwitch = new ConstractionSwitch();
//constractionSwitch.MappingToTipes();
//constractionSwitch.Exapmle();
//constractionSwitch.ExampleWhen();

//ForCycle forCycle = new ForCycle();
//ForeachCycle foreachCycle = new ForeachCycle();
//WhileCycle whileCycle = new WhileCycle();
//DoWhileCycle doWhileCycle = new DoWhileCycle();

GameClass gameClass = new GameClass();
gameClass.Start();



