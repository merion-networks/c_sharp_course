using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SystemProjectManager.DTOs.Project;
using SystemProjectManeger.Services.Interfaces;

namespace SystemProjectManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        // Создание проекта
        [Authorize(Roles = "Owner, Administrator")]
        [HttpPost("createproject")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto createProjectDto)
        {
            var managerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var project = await projectService.CreateProjectAsync(createProjectDto, managerId);
            return Ok(project);
        }

        [Authorize]
        // Получение списка проектов
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await projectService.GetProjectsAsync();
            return Ok(projects);
        }

        [Authorize(Roles = "Owner, Administrator")]
        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, [FromBody] UpdateProjectDto updateProjectDto)
        {
            var ownerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = User.FindFirstValue(ClaimTypes.Role);
            await projectService.UpdateProjectAsync(projectId, updateProjectDto, ownerId, role);
            return Ok();
        }


        [Authorize(Roles = "Owner, Administrator")]
        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var ownerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = User.FindFirstValue(ClaimTypes.Role);
            await projectService.DeleteProjectAsync(projectId, ownerId, role);
            return NoContent();
        }

        [Authorize(Roles = "Owner, Administrator")]
        [HttpPost("{projectId}/members")]
        public async Task<IActionResult> AddProjectMember(int projectId, [FromBody] AddProjectMemberDto memberDto)
        {
            var managerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = User.FindFirstValue(ClaimTypes.Role);
            await projectService.AddProjectMemberAsync(projectId, memberDto, managerId, role);
            return Ok();
        }

        // Обновление роли участника в проекте
        [Authorize(Roles = "Owner, Administrator")]
        [HttpPut("{projectId}/members/{memberId}")]
        public async Task<IActionResult> UpdateProjectMemberRole(
            int projectId,
            int memberId,
            [FromBody] UpdateProjectMemberRoleDto roleDto)
        {
            var managerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = User.FindFirstValue(ClaimTypes.Role);
            await projectService.UpdateProjectMemberRoleAsync(projectId, memberId, roleDto, managerId, role);
            return Ok();
        }

        // Удаление участника из проекта
        [Authorize(Roles = "Owner, Administrator")]
        [HttpDelete("{projectId}/members/{memberId}")]
        public async Task<IActionResult> RemoveProjectMember(int projectId, int memberId)
        {
            var managerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = User.FindFirstValue(ClaimTypes.Role);
            await projectService.RemoveProjectMemberAsync(projectId, memberId, managerId, role);
            return NoContent();
        }

        // Получение списка участников проекта
        [Authorize]
        [HttpGet("{projectId}/members")]
        public async Task<IActionResult> GetProjectMembers(int projectId)
        {
            var members = await projectService.GetProjectMembersAsync(projectId);
            return Ok(members);
        }
    }
}
