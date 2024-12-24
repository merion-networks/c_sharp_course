using Microsoft.AspNetCore.Http;
using SystemProjectManager.DTOs.Attachment;
using SystemProjectManager.Models.Entities;
using SystemProjectManeger.Repositories.Interfaces;
using SystemProjectManeger.Services.Interfaces;

namespace SystemProjectManeger.Services.Implementations
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IStorageService storageService; // Сервис для работы с хранилищем файлов

        public AttachmentService(IAttachmentRepository attachmentRepository, IStorageService storageService)
        {
            this.attachmentRepository = attachmentRepository;
            this.storageService = storageService;
        }

        public async Task<AttachmentDto> GetByIdAsync(int id)
        {
            var attachment = await attachmentRepository.GetByIdAsync(id);
            return attachment != null ? MapToDto(attachment) : null!;
        }

        public async Task<IEnumerable<AttachmentDto>> GetByTaskIdAsync(int taskId)
        {
            var attachments = await attachmentRepository.GetByTaskIdAsync(taskId);
            return attachments.Select(MapToDto);
        }

        public async Task<AttachmentDto> UploadAsync(IFormFile file, int taskId)
        {
            // Загрузка файла в хранилище
            string fileUrl = await storageService.UploadFileAsync(file);

            var attachment = new TaskAttachment
            {
                FileName = file.FileName,
                FileUrl = fileUrl,
                UploadedAt = DateTime.UtcNow,
                TaskId = taskId
            };

            var createdAttachment = await attachmentRepository.CreateAsync(attachment);
            return MapToDto(createdAttachment);
        }

        public async Task DeleteAsync(int id)
        {
            var attachment = await attachmentRepository.GetByIdAsync(id);
            if (attachment != null)
            {
                await storageService.DeleteFileAsync(attachment.FileUrl);
                await attachmentRepository.DeleteAsync(id);
            }
        }

        private AttachmentDto MapToDto(TaskAttachment attachment)
        {
            return new AttachmentDto
            {
                Id = attachment.Id,
                FileName = attachment.FileName,
                FileUrl = attachment.FileUrl,
                UploadedAt = attachment.UploadedAt,
                TaskId = attachment.TaskId
            };
        }
    }
}
