using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.DTOs.Task;

namespace SystemProjectManeger.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(CreateTaskDto dto);
        Task UpdateTaskAsync(int id, UpdateTaskDto dto);
        Task DeleteTaskAsync(int id);
    }
}