using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemProjectManager.DTOs.Attachment;
using SystemProjectManeger.Services.Interfaces;

namespace SystemProjectManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentController : Controller
    {
        private readonly IAttachmentService attachmentService;

        public AttachmentController(IAttachmentService attachmentService)
        {
            this.attachmentService = attachmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttachmentDto>> GetById(int id)
        {
            var attachment = await attachmentService.GetByIdAsync(id);
            if (attachment == null)
                return NotFound();

            return Ok(attachment);
        }

        [HttpGet("task/{taskId}")]
        public async Task<ActionResult<IEnumerable<AttachmentDto>>> GetByTaskId(int taskId)
        {
            var attachments = await attachmentService.GetByTaskIdAsync(taskId);
            return Ok(attachments);
        }

        [HttpPost("{taskId}")]
        public async Task<ActionResult<AttachmentDto>> Upload(IFormFile file, int taskId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var attachment = await attachmentService.UploadAsync(file, taskId);
            return CreatedAtAction(nameof(GetById), new { id = attachment.Id }, attachment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await attachmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
