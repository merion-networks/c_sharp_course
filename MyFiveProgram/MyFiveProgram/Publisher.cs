namespace MyFiveProgram
{
    public class Publisher
    {

        public event Action<string> EventActionOccurred;

        public void RaiseActionEvent(string message)
        {
            Console.WriteLine($"LogMessage - Издатель (RaiseActionEvent): Генерация события с сообщением '{message}'");

            EventActionOccurred?.Invoke(message);
        }


        public event EventHandler<EventArguments> EventOccurred;

        public void RaiseEvent(string message)
        {
            Console.WriteLine($"LogMessage - Издатель (RaiseEvent): Генерация события с сообщением '{message}'");

            EventOccurred?.Invoke(this, new EventArguments(message));
        }
    }
}
