using DependencyInjection.DI.Interface;
using DependencyInjection.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DI.Service
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> tasks = new List<TaskItem>();
        public readonly ILogger logger;

        public TaskService(ILogger logger)
        {
            this.logger = logger;
        }

        public void AddTask(string description)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Description = description,
                CreatedAt = DateTime.Now
            };
            tasks.Add(task);
            logger.LogInformation($"Задача добавлена: {description}");
        }

        public List<TaskItem> GetTasks()
        {
            logger.LogInformation($"{nameof(GetTasks)} - \"Получение списка задач.");
            return tasks;
        }
    }
}
