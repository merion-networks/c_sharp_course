using System.ComponentModel.DataAnnotations;
using SystemProjectManager.Models.Enums;


namespace SystemProjectManager.Models.Entities
{
    public class ProjectTask
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public TaskPriority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public ProjectTaskStatus Status { get; set; }

        // Навигационные свойства
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<TaskAssignment> TaskAssignments { get; set; }
        public ICollection<TaskAttachment> Attachments { get; set; }
    }
}
