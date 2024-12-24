using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProjectManager.Models.Entities
{
    public class TaskAttachment
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileUrl { get; set; }
        public DateTime UploadedAt { get; set; }

        // Навигационные свойства
        public int TaskId { get; set; }
        public ProjectTask Task { get; set; }
    }
}
