namespace LoggerLibrary.Inteface
{
    public interface ILogger
    {
        void Info(string message);
        void Worning(string message);
        void Error(string message, Exception? exception = null);
    }
}
