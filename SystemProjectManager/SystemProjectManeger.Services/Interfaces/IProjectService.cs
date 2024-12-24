using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.DTOs.Project;

namespace SystemProjectManeger.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateProjectAsync(CreateProjectDto createProjectDto, int ownerId);
        Task<IEnumerable<ProjectDto>> GetProjectsAsync();
        Task<ProjectDto> GetProjectByIdAsync(int projectId);
        Task UpdateProjectAsync(int projectId, UpdateProjectDto updateProjectDto, int ownerId, string role);
        Task DeleteProjectAsync(int projectId, int ownerId, string role);
        // Добавьте методы для управления командой проекта
    }
}
