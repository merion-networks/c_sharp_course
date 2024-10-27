namespace GenericDelegateLibrary
{
    public class ActionClass
    {
        void Example()
        {
            Action<string> actionPrint = PrintMessage;

            actionPrint("Print");
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        void ExampleTask()
        {
            Action action = () => Console.WriteLine("Task work!");

            Task task = new Task(action);
            task.Start();
        }

        void ExampleGUI()
        {
            /*
             * Button submitButton = new Button();
             * submitButton.Click += OnSubmit;
             * void OnSubmit(object sender, EventArgs e)
             * {
             *     MessageBox.Show("Форма отправлена!");
             * }
            */
        }

       void ExampleCallBack()
        {
            PerfomOperation(() => Console.WriteLine("Опереция завершена"));
        }

        protected void PerfomOperation(Action onComplite) { 
            Thread.Sleep(1000);

            onComplite();
        }


        public  void ExampleParallel()
        {
            List<int> numbers = Enumerable.Range(0, 10).ToList();

            Parallel.ForEach(numbers, number =>
                {
                    Console.WriteLine($"Обработано число - {number}, на потоке {Thread.CurrentThread.ManagedThreadId}");
                });
        }
    }
}
