namespace InterfaceLibrary
{
    public interface ILogger
    {
        void Log(string message);

        void  Error(string message)
        {
            Console.WriteLine(message);
        }

        void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}
