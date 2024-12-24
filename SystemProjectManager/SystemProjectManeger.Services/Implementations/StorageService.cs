using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SystemProjectManeger.Services.Interfaces;

namespace SystemProjectManeger.Services.Implementations
{
    public class StorageService : IStorageService
    {
        private readonly string uploadDirectory;
        private readonly IConfiguration configuration;
        public StorageService(IConfiguration configuration)
        {
            this.configuration = configuration;
            uploadDirectory = configuration["Storage:UploadDirectory"] ?? "uploads";

            // Создаем директорию, если она не существует
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

        }
        public async Task DeleteFileAsync(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl))
                return;

            try
            {
                // Получаем локальный путь из URL
                var fileName = Path.GetFileName(fileUrl);
                var filePath = Path.Combine(uploadDirectory, fileName);

                if (File.Exists(filePath))
                {
                    await Task.Run(() => File.Delete(filePath));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting file: {ex.Message}");
            }
        }

        public async  Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            try
            {
                // Генерируем уникальное имя файла
                var fileName = $"{Guid.NewGuid()}{file.FileName}";
                var filePath = Path.Combine(uploadDirectory, fileName);

                // Сохраняем файл
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Возвращаем URL файла
                return $"/uploads/{fileName}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error uploading file: {ex.Message}");
            }
        }
    }
}
