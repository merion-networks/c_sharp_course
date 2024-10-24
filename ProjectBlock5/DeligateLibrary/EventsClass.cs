using static DeligateLibrary.DelegateClass;

namespace DeligateLibrary
{
    public class EventsClass
    {
        public event Notify ProcessComplited;

        public event EventHandler<ProcessEventArgs> ProcessEventComplited;

        public virtual void OnProcessComplited(string message)
        {
            ProcessComplited?.Invoke(message);
        }
    }

    public class ProcessEventArgs : EventArgs
    {
        public string Message { get; set; }

        public ProcessEventArgs(string message) { Message = message; }
    }
}
