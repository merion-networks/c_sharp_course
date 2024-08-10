using System;

namespace MyFirstProgram
{
    // Базовый класс для животных
    public class Animal
    {
        public void Eat()
        {
            // Метод для приема пищи (пустая реализация)
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Животные издают звуки");
        }
    }

    // Класс собаки, наследуется от Animal
    public class Dog : Animal
    {
        public void Bark()
        {
            // Метод для лая (пустая реализация)
        }

        public override void MakeSound()
        {
            Console.WriteLine("Собаки издают звук: Гав");
        }
    }

    // Класс кошки, наследуется от Animal
    public class Cat : Animal
    {
        public void Meow()
        {
            // Метод для мяуканья (пустая реализация)
        }

        public override void MakeSound()
        {
            Console.WriteLine("Кошки издают звук: Мяу");
        }
    }

    /// <summary>
    /// Тема: Классы и объекты
    /// </summary>
    public class MyClass
    {
        // Приватные поля
        private string _name;
        private int _age;
        private string _description;

        // Свойства
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public int Age { get; set; }

        // Статический метод для суммирования
        public static int Sum(int a, int b)
        {
            return a + b;
        }

        // Конструктор
        public MyClass(string name, int age)
        {
            _age = age;
            _name = name;

            // Демонстрация работы с классом Животные
            Animal animal = new Animal();
            animal.Eat();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();

            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            // Демонстрация полиморфизма
            animal.MakeSound();
            cat.MakeSound();
            dog.MakeSound();
        }
    }
}