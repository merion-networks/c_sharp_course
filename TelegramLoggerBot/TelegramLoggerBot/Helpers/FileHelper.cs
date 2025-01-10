using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramLoggerBot.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Возвращает путь к самому последнему созданному файлу в указанной директории.
        /// </summary>
        /// <param name="directoryPath">Путь к директории для поиска файлов.</param>
        /// <returns>Полный путь к последнему созданному файлу или null, если файлов нет.</returns>
        public static string GetLatestFile(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"Директория '{directoryPath}' не существует.");
            }

            var directoryInfo = new DirectoryInfo(directoryPath);

            var files = directoryInfo.GetFiles();

            if(files.Length == 0)
            {
                throw new Exception($"В Директория '{directoryPath}' файлов нет.");
            }

            var latestFile = files.OrderByDescending(f => f.CreationTime).FirstOrDefault()?.FullName;
            return latestFile;
        }
    }
}
