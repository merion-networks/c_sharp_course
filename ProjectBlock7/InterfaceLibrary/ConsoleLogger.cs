namespace InterfaceLibrary
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(string message)
        {
            Console.WriteLine($"{nameof(ConsoleLogger)} | {message}");
        }
    }
}
