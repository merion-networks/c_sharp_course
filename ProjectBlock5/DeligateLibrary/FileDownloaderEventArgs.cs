namespace DeligateLibrary
{
    public class FileDownloaderEventArgs : EventArgs
    {
        public string Message { get; set; }

        public string FileName { get; set; }

        public FileDownloaderEventArgs(string message, string fileName)
        {
            Message = message; FileName = fileName;
        }
    }
}
