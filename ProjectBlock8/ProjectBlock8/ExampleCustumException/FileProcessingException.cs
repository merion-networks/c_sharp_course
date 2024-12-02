namespace ProjectBlock8.ExampleCustumException
{
    public class FileProcessingException : Exception
    {
        public string FilePath { get; }

        public FileProcessingException(string filePath, string message) : base(message)
        {
            FilePath = filePath;
        }
    }
}
