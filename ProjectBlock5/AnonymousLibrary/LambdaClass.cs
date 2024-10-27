using System.Linq.Expressions;

namespace AnonymousLibrary
{
    public class LambdaClass
    {
        void Example()
        {
            //С параметром
            Action<string> greet = name => Console.WriteLine("Привет, " + name);
            greet("Анна!");

            //Без параметра
            Action sayHello = () => Console.WriteLine("Привет!");
            sayHello();

            //Многострочное лямбда-выродение
            Func<int, int, int> calculate = (x, y) =>
            {
                int result = x * y + y;
                Console.WriteLine("Результат операции - " + result);
                return result;
            };

            int multiplicatin = calculate(5, 4);

        }

        public void ExampleTypeInference()
        {
            Func<int, int> square = x => x * x;
            int result = square(5); //Результата 25
        }

        public void ExampleClosures()
        {
            int multiplier = 3;
            Func<int, int> myltiply = x => x * multiplier;
            int result = myltiply(5);// вывод результата - 15 
        }

        public void ExamplePractic()
        {
            List<Func<int>> funcs = new List<Func<int>>();

            // Не правильно будет вывод : 5 5 5 5 5
            //for (int i = 0; i < 5; i++)
            //{
            //    funcs.Add(() => i);
            //}

            //Правильно, будет вывод : 0 1 2 3 4 

            for (int i = 0; i < 5; i++)
            {
                int local = i;
                funcs.Add(() => local);
            }

            foreach (var func in funcs)
            {
                Console.WriteLine(func());
            }
        }

        public void ExampleExpressionTrees()
        {
            Expression<Func<int, int>> expression = x => x + 1;

            ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "x");
            BinaryExpression body = Expression.Add(parameterExpression, Expression.Constant(1));

            Expression<Func<int, int>> lambda = Expression.Lambda<Func<int, int>>(body, parameterExpression);

            int result = lambda.Compile()(5);

            Console.WriteLine(result);
        }

        public async Task ExampleLambdaAsync()
        {
            try
            {
                Func<int, Task<int>> asyncFunc = async x =>
                    {
                        await Task.Delay(1000);
                        return x * x;
                    };

                var result = await asyncFunc(5);
                Console.WriteLine($"{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public void ExampleLINQ()
        {
            var numbers = Enumerable.Range(0, 10);
            var evenNumber = numbers.Where(n => n % 2 == 0);

            foreach (var number in evenNumber)
            {
                Console.WriteLine(number); //Вывод 0 2 4 6 8 10
            }

            var notevenNumber = numbers.Where(n => n % 2 > 0);

            foreach (var number in notevenNumber)
            {
                Console.WriteLine(number); //Вывод 1 3 5 7 9
            }
        }

        public void ExampleLINQStudent()
        {
            var students = new List<Student>
            {
                new Student {Name = "Алексей", Grade = 85},
                new Student {Name = "Мария", Grade = 90},
                new Student {Name = "Иван", Grade = 75},
                new Student {Name = "Светлана", Grade = 92},

            };

            var topStudens = students.Where(s => s.Grade > 80).OrderByDescending(s => s.Grade).Select(s => s.Name).ToList();

            foreach (var studentName in topStudens)
            {
                Console.WriteLine(studentName);
            }
        }

        public void ExampleError()
        {
            bool shoulBreak = false;
            for (int i = 0; i < 5; i++)
            {
                if (shoulBreak)
                    break;

                Func<int> func = () =>
                {
                    if (i == 4)
                    {
                        shoulBreak = true;
                        return i;
                    }
                    return i;
                };

                Console.WriteLine(func());
            }

            for (int i = 0; i < 5; i++)
            {
                Func<bool> func = () =>
                {
                    if (i == 4)
                    {
                        return true;
                    }
                    Console.WriteLine(i);
                    return false;
                };

                bool continueLoop = func();
                if (continueLoop)
                    break;
            }

        }

        public void ExampleDefault()
        {
            Func<int, int, int> func = (x, y) => x + y;
            Func<int, int> addFive = x => func(x, 5);

            int result = addFive(10); //Результат 15
        }

        public void ExampleEvent()
        {
            Publicher publicher = new Publicher();
            publicher.OnMessage += (sender, message) => { Console.WriteLine($"Получено сообщение от издателя: {message}"); };

            // publicher.SoSo();
            publicher.DoSamething();
        }


        public void ExamplePracticWork()
        {
            Task.Run(() =>
                {
                    Console.WriteLine("Задача выполняется!");

                })
                .ContinueWith(t => { Console.WriteLine("Задача завершена!"); });


            //services.AddTransient<IRepository>(provider => new Repository());

            //public IComamnd SaveCommond => new RelayCommand(param => Save(), param => CanSave())
        }
    }
}