namespace AttributeLibrary
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LogExecutioAttribute : Attribute
    {
        public string Name { get;}
        public string Message { get;}

        public LogExecutioAttribute(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}
