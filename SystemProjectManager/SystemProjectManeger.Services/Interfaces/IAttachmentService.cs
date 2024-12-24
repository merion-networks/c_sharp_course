using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.DTOs.Attachment;

namespace SystemProjectManeger.Services.Interfaces
{
    public interface IAttachmentService
    {
        Task<AttachmentDto> GetByIdAsync(int id);
        Task<IEnumerable<AttachmentDto>> GetByTaskIdAsync(int taskId);
        Task<AttachmentDto> UploadAsync(IFormFile file, int taskId);
        Task DeleteAsync(int id);
    }
}
