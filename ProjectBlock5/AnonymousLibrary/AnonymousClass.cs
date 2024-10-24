namespace AnonymousLibrary
{
    public class AnonymousClass
    {
        delegate int Operation(int x, int y);

        public event EventHandler EventHandler;

        void ExampleMetod()
        {
            Operation operation = delegate (int x, int y) { return x + y; };
            int result = operation(1, 2);
            Console.WriteLine(result);
        }

        void ExampleEvent()
        {
            EventHandler += delegate (object sender, EventArgs eventArgs)
            {
                Console.WriteLine("Событие произошло!");
            };

            EventHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}
