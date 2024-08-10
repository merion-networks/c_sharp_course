using System;
using MyFirstProgram;

// Вариант точки входа после появления top-level statements (C# 9.0 и выше)
Console.WriteLine("Hello, World!");

//MyException: Демонстрация использования класса MyException
var myException = new MyException();

// MyType: Демонстрирует различные типы данных в C#
var myType = new MyType();

// MyOperator: Показывает использование различных операторов
var myOperation = new MyOperator();

// MyConditionalConstruction: Иллюстрирует условные конструкции (if, switch и т.д.)
var myConditionalConstruction = new MyConditionalConstruction();

// MyCycle: Демонстрирует работу с циклами (for, while, do-while)
var myCycle = new MyCycle();

// MyMethod: Показывает определение и вызов методов
var myMethod = new MyMetod();

// MyClass: Пример создания класса с конструктором и свойствами
 var myClass = new MyClass("Test", 40);

// Вариант точки входа до появления top-level statements (до C# 9.0)
/*
namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Это однострочный комментарий

            /*
            Это многострочный комментарий
            Для большого количества строк!
            *//*

            Console.WriteLine("Hello, World!");

            // Здесь можно добавить код для демонстрации других классов
            // var myException = new MyException();
        }
    }
}
*/