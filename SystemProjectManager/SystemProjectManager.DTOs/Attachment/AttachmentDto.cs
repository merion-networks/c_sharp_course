﻿namespace SystemProjectManager.DTOs.Attachment
{
    public class AttachmentDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public DateTime UploadedAt { get; set; }
        public int TaskId { get; set; }
    }
}