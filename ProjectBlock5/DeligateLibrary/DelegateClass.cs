namespace DeligateLibrary
{
    public class DelegateClass
    {

        public delegate int MathOperation(int a, int b);

        public delegate void Notify(string message);

        public delegate int SumOperation(int a, int b);

        public delegate Task<int> SumOperationAsync(int a, int b);

        public delegate Object ObjectCreator();

        public delegate void ObjectProcessor<in T>(T obj);



        public void ProcessString(string str)
        {
            Console.WriteLine($"Строка {str}");
        }
        public string CreateString()
        {
            return "Привет академия!";
        }

        public int ExampleMathOperation(int a, int b)
        {
            return a + b;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine($"Сообщение: {message}");
        }

        public void LogMessage(string message)
        {
            Console.WriteLine($"Лог: {message}");
        }

        public void ExampleAction()
        {
            Action<string> action = message => Console.WriteLine(message);
            action("Сообщение через action");
        }

        public void ExampleFunc()
        {
            Func<int, int, int> func = (a, b) => a + b;
            int result = func(1, 2);
            Console.WriteLine("Результат через func " + result);
        }

        public void ExamplePredicate()
        {
            Predicate<int> predicate = number => number > 0;
            bool check = predicate(10);
            Console.WriteLine($"Число положительное {check}");
        }


        public void ExampleNotify()
        {

            Notify notify = ShowMessage;
            notify += LogMessage;

            notify("Сообщение для нескольких методов - Привет академия!");


            notify -= ShowMessage;

            notify += delegate (string message)
            {
                Console.WriteLine($"Анонимное сообщение: {message}");
            };

            notify("Сообщение для нескольких методов - Привет академия!");

            notify += message => Console.WriteLine(message);

            notify("Новое Сообщение для нескольких методов - Привет академия!");

            Console.WriteLine("Обобщенные делегаты:");
        }

        public void ExampleFakeAsync()
        {

            SumOperation sumOperation = (a, b) =>
            {
                Thread.Sleep(2000);
                return a + b;
            };

            //Старая реализация которая не работает на платформе Net
            //IAsyncResult asyncResult = sumOperation.BeginInvoke(5,3, null, null);
            //int result = sumOperation.EndInvoke(asyncResult);

            Task<int> task = Task.Run(() => sumOperation(1, 2));

            int result = task.Result;

            Console.WriteLine($"Результат асинхронного вызова {result}");

        }

        public async Task ExampleDelegateAsync()
        {
            SumOperationAsync sumOperationAsync = async (a, b) =>
            {
                await Task.Delay(3000);
                return a + b;
            };

            int result = await sumOperationAsync(1, 2);

            Console.WriteLine($"Результат асинхронного вызова {result}");
        }

        public DelegateClass()
        {
            MathOperation mathOperation = ExampleMathOperation;
            Console.WriteLine(mathOperation(1, 2));
            ExampleNotify();
            ExampleAction();
            ExampleFunc();
            ExamplePredicate();
            ExampleFakeAsync();


            ObjectCreator objectCreator = CreateString;
            Object obj = objectCreator();
            Console.WriteLine(obj);

            ObjectProcessor<string> objectProcessor = ProcessString;
            objectProcessor("Привет, академия! ");
        }
    }
}
