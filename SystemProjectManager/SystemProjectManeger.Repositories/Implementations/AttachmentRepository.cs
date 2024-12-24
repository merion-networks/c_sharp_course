using Microsoft.EntityFrameworkCore;
using SystemProjectManager.Data;
using SystemProjectManager.Models.Entities;
using SystemProjectManeger.Repositories.Interfaces;

namespace SystemProjectManeger.Repositories.Implementations
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly ApplicationDbContext context;

        public AttachmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<TaskAttachment> GetByIdAsync(int id)
        {
            return await context.Attachments
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<TaskAttachment>> GetByTaskIdAsync(int taskId)
        {
            return await context.Attachments
                .Where(a => a.TaskId == taskId)
                .ToListAsync();
        }

        public async Task<TaskAttachment> CreateAsync(TaskAttachment attachment)
        {
            context.Attachments.Add(attachment);
            await context.SaveChangesAsync();
            return attachment;
        }

        public async Task DeleteAsync(int id)
        {
            var attachment = await GetByIdAsync(id);
            if (attachment != null)
            {
                context.Attachments.Remove(attachment);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await context.Attachments.AnyAsync(a => a.Id == id);
        }
    }
}
