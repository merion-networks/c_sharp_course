using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.Models.Entities;

namespace SystemProjectManager.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Создает базу данных, если ее нет
            context.Database.EnsureCreated();

            // Проверяет, есть ли данные в таблице Users
            if (context.Roles.Any())
            {
                // База данных уже инициализирована
                return;
            }

            var roles = new Role[]
                        {
                            new Role { Name = "User" },
                            new Role { Name = "Develop" },
                            new Role { Name = "Tester" },
                            new Role { Name = "Owner" },
                            new Role { Name = "Administrator" },
                        };

            // Добавляет данные в контекст
            context.Roles.AddRange(roles);


            // Сохраняет изменения в базе данных
            context.SaveChanges();

        }
    }

}


