using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.Models.Entities;

namespace SystemProjectManeger.Repositories.Interfaces
{
    public interface IAttachmentRepository
    {
        Task<TaskAttachment> GetByIdAsync(int id);
        Task<IEnumerable<TaskAttachment>> GetByTaskIdAsync(int taskId);
        Task<TaskAttachment> CreateAsync(TaskAttachment attachment);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
