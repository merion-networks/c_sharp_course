using Microsoft.EntityFrameworkCore;
using SystemProjectManager.Data;
using SystemProjectManager.Models.Entities;
using SystemProjectManeger.Repositories.Interfaces;

namespace SystemProjectManeger.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext context;

        public TaskRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateTaskAsync(ProjectTask task)
        {
            await context.ProjectTasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await GetTaskByIdAsync(id);
            if (task != null)
            {
                context.ProjectTasks.Remove(task);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Задача с идентификатором {id} не найдена.");
            }
        }

        public async Task<IEnumerable<ProjectTask>> GetAllTasksAsync()
        {
            return await context.ProjectTasks
                .Include(p => p.TaskAssignments)
               .Include(p => p.Attachments)
                    .ToListAsync();
        }

        public async Task<ProjectTask> GetTaskByIdAsync(int id)
        {
            return await context.ProjectTasks.FindAsync(id);
        }

        public async Task UpdateTaskAsync(ProjectTask task)
        {
            context.ProjectTasks.Update(task);
            await context.SaveChangesAsync();
        }
    }
}
