using Microsoft.EntityFrameworkCore;

namespace LINQLibrary
{
    internal class ScoolContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=students.db");
        }

        public ScoolContext()
        {
            Database.EnsureCreated();// Создаем БД при первом обращении
        }

    }
}