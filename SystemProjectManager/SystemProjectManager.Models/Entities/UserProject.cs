namespace SystemProjectManager.Models.Entities
{
    public class UserProject
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string RoleInProject { get; set; }
    }
}