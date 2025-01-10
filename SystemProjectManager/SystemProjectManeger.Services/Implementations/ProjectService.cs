using SystemProjectManager.DTOs.Project;
using SystemProjectManager.DTOs.User;
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

            // Проверка прав доступа
            if (role != "Administrator" &&
                project.UserProjects.FirstOrDefault(u => u.RoleInProject == "Owner")?.UserId != ownerId)
                throw new Exception("Нет прав для изменения этого проекта");

            await UpdateAsync(project, updateProjectDto);

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

            if (role != "Administrator" &&
                project.UserProjects.FirstOrDefault(u => u.RoleInProject == "Owner")?.UserId != ownerId)
            {
                throw new Exception("Нет прав для удаления этого проекта");
            }

            // Проверка наличия связанных задач
            if (project.Tasks != null && project.Tasks.Any())
            {
                throw new Exception("Внимание! При удалении проекта будут удалены все связанные задачи. " +
                    $"Количество задач, которые будут удалены: {project.Tasks.Count}");
            }

            await projectRepository.DeleteAsync(project);
        }

        public async Task<List<UserDto>> GetProjectMembersAsync(int projectId)
        {
            var project = await projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Проект не найден");
            }

            var members = project.UserProjects.Select(up => new UserDto
            {
                Id = up.UserId,
                FirstName = up.User.FirstName,
                LastName = up.User.LastName,
                Email = up.User.Email,
                Roles = new List<string>() { up.RoleInProject }
            }).ToList();

            return members;
        }

        public async Task RemoveProjectMemberAsync(int projectId, int memberId, int managerId, string? role)
        {
            var project = await projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Проект не найден");
            }

            // Проверка прав доступа
            if (role != "Administrator" &&
                project.UserProjects.FirstOrDefault(u => u.RoleInProject == "Owner")?.UserId != managerId)
            {
                throw new Exception("Нет прав для управления участниками проекта");
            }

            var memberToRemove = project.UserProjects.FirstOrDefault(up => up.UserId == memberId);
            if (memberToRemove == null)
            {
                throw new Exception("Участник не найден в проекте");
            }

            // Нельзя удалить владельца проекта
            if (memberToRemove.RoleInProject == "Owner")
            {
                throw new Exception("Невозможно удалить владельца проекта");
            }

            project.UserProjects.Remove(memberToRemove);
            await projectRepository.UpdateAsync(project);
        }

        public async Task UpdateProjectMemberRoleAsync(int projectId, int memberId, UpdateProjectMemberRoleDto roleDto, int managerId, string? role)
        {
            var project = await projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Проект не найден");
            }

            // Проверка прав доступа
            if (role != "Administrator" &&
                project.UserProjects.FirstOrDefault(u => u.RoleInProject == "Owner")?.UserId != managerId)
            {
                throw new Exception("Нет прав для управления ролями участников");
            }

            var member = project.UserProjects.FirstOrDefault(up => up.UserId == memberId);
            if (member == null)
            {
                throw new Exception("Участник не найден в проекте");
            }

            // Нельзя изменить роль владельца
            if (member.RoleInProject == "Owner")
            {
                throw new Exception("Невозможно изменить роль владельца проекта");
            }

            member.RoleInProject = roleDto.NewProjectRole;
            await projectRepository.UpdateAsync(project);
        }

        public async Task AddProjectMemberAsync(int projectId, AddProjectMemberDto memberDto, int managerId, string? role)
        {
            var project = await projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Проект не найден");
            }

            // Проверка прав доступа
            if (role != "Administrator" &&
                project.UserProjects.FirstOrDefault(u => u.RoleInProject == "Owner")?.UserId != managerId)
            {
                throw new Exception("Нет прав для добавления участников");
            }

            // Проверка, не является ли пользователь уже участником проекта
            if (project.UserProjects.Any(up => up.UserId == memberDto.UserId))
            {
                throw new Exception("Пользователь уже является участником проекта");
            }

            var newMember = new UserProject
            {
                UserId = memberDto.UserId,
                ProjectId = projectId,
                RoleInProject = memberDto.RoleInProject
            };

            project.UserProjects.Add(newMember);
            await projectRepository.UpdateAsync(project);
        }
    }
}
