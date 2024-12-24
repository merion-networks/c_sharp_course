using System.ComponentModel.DataAnnotations;
using SystemProjectManager.Models.Enums;

namespace SystemProjectManager.Models.Entities
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ProjectStatus Status { get; set; }

        // Навигационные свойства
        public ICollection<UserProject> UserProjects { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
