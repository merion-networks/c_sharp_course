namespace AbstractionLibrary.Logger
{
    public class Logger : ITextLogger, IEmailLogger
    {
        void ITextLogger.Log(string message)
        {
            Console.WriteLine($"ITextLogger - {message}");
        }
        
        void IEmailLogger.Log(string message)
        {
            Console.WriteLine($"IEmailLogger - {message}");
        } 
    }
}
