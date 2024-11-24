using api.Dtos;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        private readonly UserManager<User> _userManager;

        public MessageController(
            IMessageRepository messageRepository,
            UserManager<User> userManager
        )
        {
            _messageRepository = messageRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<MessageDto>), 200)]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateMessageDto messageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // TODO: check if the user "senderId" is a match with the receiver "receiverId" so they can exchange messages.
            var message = messageDto.ToMessageFromCreate();
            message.CreatedAt = DateTime.UtcNow;
            message.Status = MessageStatus.Sent;

            var savedMessage = await _messageRepository.SaveMessageAsync(message);

            return Ok(ResponseHelper.CreateSuccessResponse(savedMessage.ToMessageDto()));
        }

        [HttpGet("conversation/{senderId}/{receiverId}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<MessageDto>>), 200)]
        public async Task<ActionResult<IEnumerable<Message>>> GetAll(
            string senderId,
            string receiverId
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            if (user.Id != senderId)
            {
                return Unauthorized("Not authorized.");
            }

            var messages = await _messageRepository.GetMessagesByConversationAsync(
                senderId,
                receiverId
            );

            return Ok(ResponseHelper.CreateSuccessResponse(messages.Select(m => m.ToMessageDto())));
        }

        [HttpPut("{id}/status")]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] MessageStatus status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _messageRepository.UpdateMessageStatusAsync(id, status);
            return NoContent();
        }
    }
}
