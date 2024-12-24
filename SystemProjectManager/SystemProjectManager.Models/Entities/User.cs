using System.ComponentModel.DataAnnotations;


namespace SystemProjectManager.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string AvatarUrl { get; set; }

        // Навигационные свойства
        public ICollection<TaskAssignment> TaskAssignments { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserProject> UserProjects { get; set; }
    }
}
