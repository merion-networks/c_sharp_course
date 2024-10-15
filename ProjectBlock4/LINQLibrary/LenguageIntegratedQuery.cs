using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LINQLibrary
{
    public class LenguageIntegratedQuery
    {
        List<int> collection = new List<int>() { 0, 1, 2, 3, 4, 4 , 3, 4, 5 };


        List<Student> students = new List<Student>()
        {
            new Student{ Name = "Алексей", Age = 20, Grade = 85 },
            new Student{ Name = "Мария", Age = 21, Grade = 92 },
            new Student{ Name = "Макс", Age = 21, Grade = 92 },
            new Student{ Name = "Иван", Age = 19, Grade = 88 }
        };


        public void ExampleLINQtoXML()
        {
            XDocument xDocument = new XDocument();

            XElement xStudents = new XElement("Students");
            foreach (var student in students)
            {
                var xStudent = new XElement("Student");

                xStudent.Add(
                    new XAttribute("Id", student.Id),
                    new XAttribute("Name", student.Name),
                    new XAttribute("Age", student.Age),
                    new XAttribute("Grade", student.Grade));

                xStudents.Add(xStudent);
            }
            xDocument.Add(xStudents);


            xDocument.Save("student.xml");

            Console.WriteLine("Документ сохранен!");


            XDocument xDocumentLoad = XDocument.Load("student.xml");

            var studentNames = from xstudent in xDocumentLoad.Descendants("Student")
                               select xstudent.Attribute("Name").Value;

            foreach (var name in studentNames)
            {
                Console.WriteLine(name);
            }
        }


        public void ExanpleLINQtoSQL()
        {
            using (var context = new ScoolContext())
            {
                var students = context.Students?.Where(s => s.Grade > 80);

                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Name}: {student.Grade}");
                }
            }
        }


        public void ExampleAdvenced()
        {
            /*
             * - `Distinct()` — удаляет дубликаты.
             * - `Union()` — объединение последовательностей.
             * - `Intersect()` — пересечение последовательностей.
             * - `Except()` — разность последовательностей.
             */
            var distinctNumbers = collection?.Distinct().ToList();

            Console.WriteLine("Уникальные числа:");
            distinctNumbers.ForEach(num => Console.WriteLine(num));


        }


        public void ExampleinqExtension()
        {
            var words = new List<string> { "apple", "banana", "apricot", "cherry" };


            var wordsWithAp = words.WhereContains("ap");

            var conteins = words.Contains("ap"); //Вернет true или false

            wordsWithAp.ToList().ForEach(w=> Console.WriteLine(w));

            

            var indexWords = words?.Select((word, index) => $"{index} - {word}");

           indexWords?.ToList().ForEach(w => Console.WriteLine(w));
        }

        public void ExampleAgregate()
        {
            var count = collection.Count;
            var sum = collection.Sum();
            var average = collection.Average();
            var min = collection.Min();
            var max = collection.Max();
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Count: {count}");
            Console.WriteLine($"Avarage: {average}");
            Console.WriteLine($"Sum: {sum}");
        }

        public void ExampleGroupBy()
        {
            var groupStudents = students.GroupBy(x => x.Grade).ToList();

            Console.WriteLine("Сгрупперованные студенты (classic)");
            foreach (var group in groupStudents)
            {
                Console.WriteLine($"Оценка: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($"{student.Name} - {student.Grade}");
                }
            }

            Console.WriteLine("\nСгрупперованные студенты (LINQ ForEach)");
            groupStudents.ForEach(group =>
            {
                Console.WriteLine($"Оценка: {group.Key}");
                group.ToList().ForEach(student => Console.WriteLine($"{student.Name} - {student.Grade}"));
            });
        }

        public void ExampleJoin()
        {
            var newStudents = new List<Student>()
            {
                new Student{ Id = 1, Name = "Алексей", Age = 22},
                new Student{ Id = 2, Name = "Анастасия", Age = 19 }
            };

            var grades = new List<Grade>() {
                new Grade { StudentId = 1, Scope = 90 },
                new Grade { StudentId = 2, Scope = 95 },
            };

            var studentGraids = newStudents.Join(grades,
                                                student => student.Id,
                                                grade => grade.StudentId,
                                                (student, grade) => new { student.Name, grade.Scope });

            foreach (var sg in studentGraids)
            {
                Console.WriteLine($"{sg.Name} - {sg.Scope}");
            }
        }


        public void ExampleGroupJoin()
        {
            var newStudents = new List<Student>()
            {
                new Student{ Id = 1, Name = "Алексей", Age = 22},
                new Student{ Id = 2, Name = "Анастасия", Age = 19 }
            };

            var grades = new List<Grade>() {
                new Grade { StudentId = 1, Scope = 90 },
                new Grade { StudentId = 1, Scope = 96 },
                new Grade { StudentId = 2, Scope = 95 },
                new Grade { StudentId = 2, Scope = 90 },
                new Grade { StudentId = 2, Scope = 87 },
            };

            var studentGraids = newStudents.GroupJoin(grades,
                                      student => student.Id,
                                      grade => grade.StudentId,
                                      (student, gradesGroup) => new { student.Name, Grades = gradesGroup });



            foreach (var sg in studentGraids)
            {
                Console.WriteLine($"{sg.Name}");
                foreach (var grade in sg.Grades)
                    Console.WriteLine($"Оценка - {grade.Scope}");
            }
        }
        public void ExampleOrder()
        {

            var sortedStudets = students.OrderBy(s => s.Grade).ToList();

            Console.WriteLine("Отсортированные студенты (classic)");
            foreach (var student in sortedStudets)
            {
                Console.WriteLine($"{student.Name} - {student.Grade}");
            }

            Console.WriteLine("\nОтсортированные студенты (LINQ ForEach)");
            sortedStudets.ForEach(student => Console.WriteLine($"{student.Name} - {student.Grade}"));
        }

        public void ExampleSelectMany()
        {
            var numberGroup = new List<List<int>>
            {
                new List<int> { 1,2},
                new List<int> { 3,4},
                new List<int> { 5,6},
                new List<int> { 7,8}
            };

            var allNumbers = numberGroup.SelectMany(group => group);

            Console.WriteLine("Все числа (classic)");
            foreach (var item in allNumbers)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("\nВсе числа (LINQ ForEach)");
            allNumbers.ToList().ForEach(num => Console.Write($"{num} "));
        }

        public void ExampleWhere()
        {
            var evenNumber = collection.Where(num => num % 2 == 0);
            Console.WriteLine("Все четные числа (classic)");
            foreach (int num in evenNumber)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine("\nВсе четные числа (LINQ ForEach)");
            evenNumber.ToList().ForEach(num => Console.Write($"{num} "));


        }

        public LenguageIntegratedQuery()
        {
            //Query Syntax
            var result = from item in collection
                         where item != null
                         select item;

            //Metod Syntax

            var resultMetod = collection.Where(item => item != null);
        }


    }
}
