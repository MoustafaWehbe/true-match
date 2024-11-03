using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        // POST: api/messages
        [HttpPost]
        public async Task<IActionResult> SaveMessage([FromBody] Message message)
        {
            message.CreatedAt = DateTime.UtcNow;
            message.Status = "sent";  // Default status on creation

            var savedMessage = await _messageRepository.SaveMessageAsync(message);
            return Ok(savedMessage);
        }

        // GET: api/messages/conversation/{senderId}/{receiverId}
        [HttpGet("conversation/{senderId}/{receiverId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages(string senderId, string receiverId)
        {
            var messages = await _messageRepository.GetMessagesByConversationAsync(senderId, receiverId);
            return Ok(messages);
        }

        // PUT: api/messages/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateMessageStatus(int id, [FromBody] string status)
        {
            await _messageRepository.UpdateMessageStatusAsync(id, status);
            return NoContent();
        }
    }
}
