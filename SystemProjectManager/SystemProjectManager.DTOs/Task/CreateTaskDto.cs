using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.DTOs.Attachment;
using SystemProjectManager.Models.Enums;

namespace SystemProjectManager.DTOs.Task
{
    public class CreateTaskDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public List<int> AssignedUserIds { get; set; }
        public List<AttachmentDto> Attachments { get; set; }
    }
}
