using Microsoft.EntityFrameworkCore;
using SystemProjectManager.Data;
using SystemProjectManager.Models.Entities;
using SystemProjectManeger.Repositories.Interfaces;

namespace SystemProjectManeger.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext context;

        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Project project)
        {
            await context.Projects.AddAsync(project);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await context.Projects
                .Include(p => p.UserProjects)
                .ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await context.Projects
                .Include(p => p.UserProjects)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Project project)
        {
            context.Projects.Update(project);
            await context.SaveChangesAsync();
        }

        // Добавьте остальные методы
    }
}
