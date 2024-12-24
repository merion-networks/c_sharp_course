using Microsoft.AspNetCore.Http;

namespace SystemProjectManeger.Services.Interfaces
{
    public interface IStorageService
    {
        Task DeleteFileAsync(string fileUrl);
        Task<string> UploadFileAsync(IFormFile file);
    }
}
