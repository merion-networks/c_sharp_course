using MenagerAcademy;

class Program
{
    static void Main(string[] args)
    {
        var academy = new Academy("Marion Academy");

        academy.LoadCoursesFromJson("courses.json");

        Console.WriteLine($"Добро пожаловать в {academy.Name}");

        while (true)
        {

            Console.WriteLine("\nВведите действие:");
            Console.WriteLine("1. Показать все курсы");
            Console.WriteLine("2. Добавить новый курс");
            Console.WriteLine("3. Найти курс по названию");
            Console.WriteLine("4. Добавить студента на курс");
            Console.WriteLine("5. Вывести статистику академии");
            Console.WriteLine("6. Выход");


            var choice = Console.ReadLine(); 

            switch (choice)
            {
                case "1":
                    academy.ShowAllCourses();
                    break;
                case "2":
                    academy.AddNewCourse();
                    break;
                case "3":
                    academy.FindCourse();
                    break;
                case "4":
                    academy.AddStudentToCourse();
                    break;
                case "5":
                    academy.ShowStatistics();
                    break;
                case "6":
                    Console.WriteLine("Спасибо за использование системы. До свидания!");
                    return;
                default:
                    Console.WriteLine("Не верный выбор. Введите число которое есть в меню действий.");
                    break;
            }

        }
    }
}

