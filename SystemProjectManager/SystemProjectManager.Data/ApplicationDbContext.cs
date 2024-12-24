using Microsoft.EntityFrameworkCore;
using SystemProjectManager.Models.Entities;

namespace SystemProjectManager.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<TaskAttachment> Attachments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Конфигурация для сущности User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.FirstName).IsRequired();
                entity.Property(u => u.LastName).IsRequired();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();

                // Связь с UserRoles (многие ко многим через таблицу-связку)
                entity.HasMany(u => u.UserRoles)
                      .WithOne(ur => ur.User)
                      .HasForeignKey(ur => ur.UserId);

                // Связь с UserProjects (многие ко многим через таблицу-связку)
                entity.HasMany(u => u.UserProjects)
                      .WithOne(up => up.User)
                      .HasForeignKey(up => up.UserId);

                // Связь с TaskAssignments
                entity.HasMany(u => u.TaskAssignments)
                      .WithOne(ta => ta.User)
                      .HasForeignKey(ta => ta.UserId);

            });

            // Конфигурация для сущности Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired();

                // Связь с UserRoles
                entity.HasMany(r => r.UserRoles)
                      .WithOne(ur => ur.Role)
                      .HasForeignKey(ur => ur.RoleId);
            });

            // Конфигурация для сущности UserRole (таблица-связка для User и Role)
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });
            });

            // Конфигурация для сущности Project
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired();

                // Связь с UserProjects
                entity.HasMany(p => p.UserProjects)
                      .WithOne(up => up.Project)
                      .HasForeignKey(up => up.ProjectId);

                // Связь с ProjectTasks
                entity.HasMany(p => p.Tasks)
                      .WithOne(t => t.Project)
                      .HasForeignKey(t => t.ProjectId);
            });

            // Конфигурация для сущности UserProject (таблица-связка для User и Project)
            modelBuilder.Entity<UserProject>(entity =>
            {
                entity.HasKey(up => new { up.UserId, up.ProjectId });
            });

            // Конфигурация для сущности ProjectTask
            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title).IsRequired();
                entity.Property(t => t.Priority).IsRequired();
                entity.Property(t => t.Deadline).IsRequired();
                entity.Property(t => t.Status).IsRequired();

                // Связь с Project
                entity.HasOne(t => t.Project)
                      .WithMany(p => p.Tasks)
                      .HasForeignKey(t => t.ProjectId);

                // Связь с TaskAssignments
                entity.HasMany(t => t.TaskAssignments)
                      .WithOne(ta => ta.Task)
                      .HasForeignKey(ta => ta.TaskId);

                // Связь с Attachments
                entity.HasMany(t => t.Attachments)
                      .WithOne(a => a.Task)
                      .HasForeignKey(a => a.TaskId);

            });

            // Конфигурация для сущности Attachment
            modelBuilder.Entity<TaskAttachment>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.FileName).IsRequired();
                entity.Property(a => a.FileUrl).IsRequired();
                entity.Property(a => a.UploadedAt).IsRequired();

                // Связь с ProjectTask
                entity.HasOne(a => a.Task)
                      .WithMany(t => t.Attachments)
                      .HasForeignKey(a => a.TaskId);
            });

            // Конфигурация для сущности TaskAssignment (таблица-связка для User и ProjectTask
            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.HasKey(ta => new { ta.UserId, ta.TaskId });

                // Связи установлены в конфигурациях User и ProjectTask
            });
        }
    }
}
