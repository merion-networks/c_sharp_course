namespace SystemProjectManager.Models.Entities
{
    public class TaskAssignment
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TaskId { get; set; }
        public ProjectTask Task { get; set; }
    }
}
