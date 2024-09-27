namespace OverridingLibrary.Logger
{
    public class Logger
    {
        public void Log(string message) { /*...*/ }
        public void Log(string message, Exception exception) { /*...*/ }
        public void Log(string message, string format, params object[] args) { /*...*/ }
    }
}
