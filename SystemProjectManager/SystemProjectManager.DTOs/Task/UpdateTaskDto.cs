using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.Models.Enums;

namespace SystemProjectManager.DTOs.Task
{
    public class UpdateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority? Priority { get; set; }
        public DateTime? Deadline { get; set; }
        public ProjectTaskStatus? Status { get; set; }
        public List<int> AssignedUserIds { get; set; }
    }
}
