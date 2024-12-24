using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.DTOs.Attachment;
using SystemProjectManager.DTOs.Task;
using SystemProjectManager.Models.Entities;
using SystemProjectManager.Models.Enums;
using SystemProjectManeger.Repositories.Interfaces;
using SystemProjectManeger.Services.Interfaces;

namespace SystemProjectManeger.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task CreateTaskAsync(CreateTaskDto dto)
        {
            var task = new ProjectTask
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), dto.Priority),
                Deadline = dto.Deadline,
                Status = ProjectTaskStatus.Open, // Устанавливаем статус по умолчанию
                ProjectId = dto.ProjectId,
                TaskAssignments = new List<TaskAssignment>(),
                Attachments = new List<SystemProjectManager.Models.Entities.TaskAttachment>()
            };

            // Добавляем назначенных пользователей
            if (dto.AssignedUserIds != null && dto.AssignedUserIds.Any())
            {
                foreach (var userId in dto.AssignedUserIds)
                {
                    task.TaskAssignments.Add(new TaskAssignment
                    {
                        UserId = userId
                    });
                }
            }
            // Сохраняем задачу в репозитории
            await taskRepository.CreateTaskAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await taskRepository.DeleteTaskAsync(id);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            var tasks = await taskRepository.GetAllTasksAsync();

            var taskDtos = tasks.Select(task => new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                Deadline = task.Deadline,
                Status = task.Status,
                ProjectId = task.ProjectId,
                AssignedUserIds = task.TaskAssignments?.Select(a => a.UserId).ToList()!,
                Attachments = task.Attachments?.Select(att => new AttachmentDto
                {
                    Id = att.Id,
                    FileName = att.FileName,
                    FileUrl = att.FileUrl,
                    UploadedAt = att.UploadedAt
                }).ToList()!
            });

            return taskDtos;
        }

        public async Task<TaskDto> GetTaskByIdAsync(int id)
        {
            var task = await taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Задача с идентификатором {id} не найдена.");
            }

            var taskDto = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                Deadline = task.Deadline,
                Status = task.Status,
                ProjectId = task.ProjectId,
                AssignedUserIds = task.TaskAssignments?.Select(a => a.UserId).ToList()!,
                Attachments = task.Attachments?.Select(att => new AttachmentDto
                {
                    Id = att.Id,
                    FileName = att.FileName,
                    FileUrl = att.FileUrl,
                    UploadedAt = att.UploadedAt
                }).ToList()!
            };

            return taskDto;
        }

        public async Task UpdateTaskAsync(int id, UpdateTaskDto dto)
        {
            var task = await taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Задача с идентификатором {id} не найдена.");
            }

            // Обновляем свойства задачи
            if (!string.IsNullOrEmpty(dto.Title))
            {
                task.Title = dto.Title;
            }

            if (!string.IsNullOrEmpty(dto.Description))
            {
                task.Description = dto.Description;
            }

            if (dto.Priority.HasValue)
            {
                task.Priority = dto.Priority.Value;
            }

            if (dto.Deadline.HasValue)
            {
                task.Deadline = dto.Deadline.Value;
            }

            if (dto.Status.HasValue)
            {
                task.Status = dto.Status.Value;
            }

            // Обновляем назначенных пользователей
            if (dto.AssignedUserIds != null)
            {
                // Очищаем текущие назначения
                task.TaskAssignments.Clear();

                // Добавляем новые назначения
                foreach (var userId in dto.AssignedUserIds)
                {
                    task.TaskAssignments.Add(new TaskAssignment
                    {
                        UserId = userId
                    });
                }
            }
            await taskRepository.UpdateTaskAsync(task);
        }
    }
}
