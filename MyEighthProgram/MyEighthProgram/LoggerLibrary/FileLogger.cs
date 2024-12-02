using LoggerLibrary.Inteface;
using System.Text;

namespace LoggerLibrary
{
    public class FileLogger : ILogger
    {
        private readonly string logFilePath;
        private readonly long maxSizeFile;
        private static readonly Lock lockObj = new Lock();

        public void Error(string message, Exception? exception = null)
        {
            var fullMessage = message;
            if (exception != null) {
                fullMessage += Environment.NewLine + exception.ToString();
            }

            WriteLog("ERROR", fullMessage);
        }

        public void Info(string message)
        {
            WriteLog("INFO", message);
        }

        public void Worning(string message)
        {
            WriteLog("WARNING", message);
        }

        private void WriteLog(string level, string message)
        {
            var logEntry = FormatLogEntry(level, message);

            lock (lockObj)
            {
                RotateLogFileIfNeeded();
                File.AppendAllText(logFilePath, logEntry, Encoding.UTF8);
            }
        }

        private void RotateLogFileIfNeeded()
        {
            try
            {
                if (!File.Exists(logFilePath)) { return; }

                var fileInfo = new FileInfo(logFilePath);
                if (fileInfo.Length > maxSizeFile)
                {
                    var directory = Path.GetDirectoryName(logFilePath);
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(logFilePath);
                    var extension = Path.GetExtension(logFilePath);

                    var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssmm");
                    var newFileName = $"{fileNameWithoutExtension}_{timeStamp}{extension}";
                    var newFilePath = Path.Combine(directory, newFileName);

                    File.Move(logFilePath, newFilePath, true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string FormatLogEntry(string level, string message)
        {
            var datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var logEntry = $"{datatime} [{level}] {message};{Environment.NewLine}";
            return logEntry;
        }

        public FileLogger(string logFilePath, long maxFileSize = 10 * 1024 * 1024)
        {
            if (string.IsNullOrEmpty(logFilePath))
            {
                throw new ArgumentNullException("Путь к файлу лога не может быть пустым.", nameof(logFilePath));
            }

            if (maxFileSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxFileSize), "Максимальный размер файла должен быть положительным числом.");
            }

            this.logFilePath = logFilePath;
            this.maxSizeFile = maxFileSize;


            var directory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
