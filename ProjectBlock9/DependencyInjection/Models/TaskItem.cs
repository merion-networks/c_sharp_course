
namespace DependencyInjection.Models
{
    public class TaskItem
    {
        public Guid Id { get; internal set; }
        public string Description { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
    }
}