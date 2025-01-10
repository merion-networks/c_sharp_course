using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.Data;
using SystemProjectManager.Models.Entities;
using SystemProjectManeger.Repositories.Interfaces;

namespace SystemProjectManeger.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            DbInitializer.Initialize(context); //TODO
        }
        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users
                .Include(p => p.UserProjects)
                .Include(p => p.TaskAssignments)
                .Include(u => u.UserRoles)
                .ToListAsync();
        }

        public async Task<Role> GetAllRoleAsync(string roleName)
        {
            return await context.Roles
                .Include(u => u.UserRoles).FirstOrDefaultAsync(r => r.Name == roleName);
                
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users
                            .Include(u => u.UserRoles)
                            .ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
