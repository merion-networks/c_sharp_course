namespace AttributeLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public sealed class DeveloperInfoAttribute : Attribute
    {
        public string? DeveloperName { get; }

        public DateTime LastModified { get; }

        public DeveloperInfoAttribute(string? developerName, string lastModified)
        {
            DeveloperName = developerName;
            LastModified = DateTime.Parse(lastModified);
        }
    }
}
