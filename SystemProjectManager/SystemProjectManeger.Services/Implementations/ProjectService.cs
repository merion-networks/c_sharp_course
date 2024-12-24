using SystemProjectManager.DTOs.Project;
using SystemProjectManager.Models.Entities;
using SystemProjectManager.Models.Enums;
using SystemProjectManeger.Repositories.Interfaces;
using SystemProjectManeger.Services.Interfaces;

namespace SystemProjectManeger.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;
        private readonly IUserRepository userRepository;

        public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            this.projectRepository = projectRepository;
            this.userRepository = userRepository;
        }

        public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto createProjectDto, int ownerId)
        {
            var manager = await userRepository.GetByIdAsync(ownerId);
            if (manager == null)
            {
                throw new Exception("Manager not found");
            }

            var project = new Project
            {
                Name = createProjectDto.Name,
                Description = createProjectDto.Description,
                StartDate = createProjectDto.StartDate,
                EndDate = createProjectDto.EndDate,
                Status = ProjectStatus.Planned,
                UserProjects = new List<UserProject>
                {
                    new UserProject { UserId = ownerId, RoleInProject = "Owner" }
                }
            };

            await projectRepository.AddAsync(project);

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Status = project.Status.ToString(),
                StartDate = project.StartDate,
                EndDate = project.EndDate
                // Добавьте остальные свойства
            };
        }
        public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
        {
            var projects = await projectRepository.GetAllAsync();
            if (projects == null)
            {
                throw new Exception("Проекты не найден");
            }

            var projectsDTO = new List<ProjectDto>();

            foreach (var project in projects)
            {
                projectsDTO.Add(new ProjectDto()
                {
                    Name = project.Name,
                    Description = project.Description,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Status = project.Status.ToString()

                });
            }

            return projectsDTO;
        }
        public async Task<ProjectDto> GetProjectByIdAsync(int projectId)
        {
            var project = await projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Проект не найден");
            }
            return new ProjectDto()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Status = project.Status.ToString()
            };
        }
        public async Task UpdateProjectAsync(int projectId, UpdateProjectDto updateProjectDto, int ownerId, string role)
        {
            var project = await projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Проект не найден");
            }

            if (role == "Administrator")
            {
                await UpdateAsync(project, updateProjectDto);
            }
            else
            {
                if (project.UserProjects.FirstOrDefault(u => u.RoleInProject == "Owner")?.UserId != ownerId)
                    throw new Exception("Нет прав для изменения этого проекта");

                await UpdateAsync(project, updateProjectDto);
            }
        }

        private async Task UpdateAsync(Project project, UpdateProjectDto updateProjectDto)
        {
            // Обновление данных пользователя
            project.Name = updateProjectDto.Name;
            project.Description = updateProjectDto.Description;
            project.StartDate = updateProjectDto.StartDate;
            project.EndDate = updateProjectDto.EndDate;
            project.Status = (ProjectStatus)Enum.Parse(typeof(ProjectStatus), updateProjectDto.Status, true);
            await projectRepository.UpdateAsync(project);
        }

        public async Task DeleteProjectAsync(int projectId, int ownerId, string role)
        {
            var project = await projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Проект не найден");
            }


            if (role == "Administrator")
            {
                await projectRepository.DeleteAsync(project);
            }
            else
            {
                if (project.UserProjects.FirstOrDefault(u => u.RoleInProject == "Owner")?.UserId != ownerId)
                    throw new Exception("Нет прав для удаления этого проекта");

                await projectRepository.DeleteAsync(project);
            }
        }

    }
}
