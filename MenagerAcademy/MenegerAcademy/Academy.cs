using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace MenagerAcademy
{

    public record Student(string Name, int Age);

    public record Course(string Name, int Duration, List<string> Topics)
    {
        public List<Student> Students { get; init; } = new();
    }

    public class Academy
    {
        public string Name { get; }

        public List<Course> Courses { get; set; } = new();

        public Academy(string name) => Name = name;

        private void InfoCouse(Course course)
        {
            Console.WriteLine($"\nКурс: {course.Name} (Продолжительность  - {course.Duration} месяцев)");
            Console.WriteLine("Темы:");
            course.Topics.ForEach(topic => Console.WriteLine($"- {topic}"));
            Console.WriteLine("Студенты:");
            course.Students.ForEach(student => Console.WriteLine($"- {student.Name} (Возраст: {student.Age})"));
        }

        private Course? SearchCourse()
        {
            Console.WriteLine("Введите название курса:");
            var courseName = Console.ReadLine();

            var course = Courses.Find(c => c.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase));

            if (course == null)
            {
                Console.WriteLine($"Курс с названием {courseName} не найден в академии!");
            }

            return course;
        }


        public void ShowAllCourses()
        {
            foreach (var course in Courses)
            {
                InfoCouse(course);
            }
        }

        public void LoadCoursesFromJson(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    Courses = JsonSerializer.Deserialize<List<Course>>(fs, option) ?? new List<Course>();
                    if (Courses.Count > 0)
                        Console.WriteLine("Все курсы добавлены успешно!");
                    else
                        Console.WriteLine("Ни один курс не добавлен!");
                }
            }
            catch (Exception ex) { Console.WriteLine($"Во время загрузки курсов произошла ошибка!\nОшибка:  {ex.Message}"); }
        }


        public void AddStudentToCourse()
        {
            var course = SearchCourse();
            if (course == null)
            {
                return;
            }

            Console.WriteLine("Введите имя студента:");
            var studentName = Console.ReadLine();

            Console.WriteLine("Введите возраст студента:");
            if (!int.TryParse(Console.ReadLine(), out int studentAge))
            {
                Console.WriteLine("Формат возраста студента не верен!");
                return;
            }

            var student = new Student(studentName!, studentAge);

            course.Students.Add(student);

            Console.WriteLine($"Студент {studentName} успешно добавлен на курс - {course.Name}!");
        }

        public void FindCourse()
        {
            var course = SearchCourse();
            if (course == null)
            {
                return;
            }

            Console.WriteLine("Курс найден:");
            InfoCouse(course);
        }

        public void AddNewCourse()
        {
            Console.WriteLine("Введите название новго курса:");
            var courseName = Console.ReadLine();

            Console.WriteLine("Введите продолжительность курса:");
            if (!int.TryParse(Console.ReadLine(), out int courseDuration))
            {
                Console.WriteLine("Формат не верен!");
                return;
            }

            Console.WriteLine($"введите темы для курса - {courseName} (разделяйте темы курса запятыми)");
            var topicsInput = Console.ReadLine();
            var topics = topicsInput?.Split(',').Select(x => x.Trim()).ToList() ?? new List<string>();

            var newCourse = new Course(courseName!, courseDuration, topics);
            Courses.Add(newCourse);

            Console.WriteLine($"Курс {courseName} успешно добавлен в академию");
        }

        public void ShowStatistics()
        {
            Console.WriteLine($"Статистика академии {Name}:");
            Console.WriteLine($"Общее количество курсов в академии - {Courses.Count}");
            Console.WriteLine($"Общее количество студентов в академии - {Courses.Sum(c => c.Students.Count)}");
            Console.WriteLine($"Средлняя продолжительность курсов - {Courses.Average(c => c.Duration)}");
            Console.WriteLine($"Самый полпулярный курс - {Courses.OrderByDescending(c=>c.Students.Count).First().Name}");
        }
    }
}
