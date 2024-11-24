using System.Text.Json;
using api.Dtos;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace api.Controllers
{
    [Route("api/system-question")]
    [ApiController]
    public class SystemQuestionsController : ControllerBase
    {
        private readonly ISystemQuestionRepository _systemQuestionRepository;
        private readonly IRoomRepository _roomRepo;
        private readonly UserManager<User> _userManager;

        public SystemQuestionsController(
            ISystemQuestionRepository systemQuestionRepository,
            IRoomRepository roomRepo,
            UserManager<User> userManager
        )
        {
            _systemQuestionRepository = systemQuestionRepository;
            _roomRepo = roomRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<SystemQuestionDto>>), 200)]
        public async Task<ActionResult<IEnumerable<SystemQuestionDto>>> GetAll(
            [FromQuery] List<Guid> categories,
            [FromQuery] Guid roomId
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (categories != null && categories.Count > 0)
            {
                IQueryable<SystemQuestion> query = _systemQuestionRepository.GetAll();
                query = query.Where(q => categories.Contains(q.CategoryId));
                var questions = await query.ToListAsync();

                var randomQuestions = questions.OrderBy(q => Guid.NewGuid()).Take(3).ToList();

                var room = await _roomRepo.GetByIdAsync(roomId);

                if (room == null)
                {
                    return NotFound("Room was not found.");
                }

                var user = await _userManager.FindByEmailAsync(User.GetEmail());

                if (user == null)
                {
                    return NotFound("User was not found!");
                }

                if (user.Id != room.UserId || room.IsArchived(user.Id))
                {
                    return BadRequest("Room/User validation failed.");
                }

                var existingRoomState = room.RoomState;
                if (existingRoomState != null)
                {
                    existingRoomState.RoundQuestions = randomQuestions
                        .Select(q => q.ToSystemQuestionDto())
                        .ToList();
                }
                else
                {
                    existingRoomState = new RoomState
                    {
                        RoundQuestions = randomQuestions
                            .Select(q => q.ToSystemQuestionDto())
                            .ToList(),
                    };
                }
                room.RoomStateJson = JsonDocument.Parse(
                    JsonSerializer.Serialize(existingRoomState)
                );

                await _roomRepo.UpdateAsync(room);

                return Ok(
                    ResponseHelper.CreateSuccessResponse(
                        randomQuestions.Select(q => q.ToSystemQuestionDto())
                    )
                );
            }
            else
            {
                var questions = await _systemQuestionRepository.GetAllAsync();
                return Ok(
                    ResponseHelper.CreateSuccessResponse(
                        questions.Select(q => q.ToSystemQuestionDto())
                    )
                );
            }
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<SystemQuestion>> GetSystemQuestion(Guid id)
        {
            var question = await _systemQuestionRepository.GetByIdAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(ResponseHelper.CreateSuccessResponse(question));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<SystemQuestion>> CreateSystemQuestion(
            CreateSystemQuestionDto systemQuestionDto
        )
        {
            var systemQuestion = new SystemQuestion
            {
                Name = systemQuestionDto.Name,
                CategoryId = systemQuestionDto.CategoryId,
            };

            await _systemQuestionRepository.CreateAsync(systemQuestion);

            return CreatedAtAction(
                nameof(GetSystemQuestion),
                new { id = systemQuestion.Id },
                systemQuestion
            );
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateSystemQuestion(
            Guid id,
            UpdateSystemQuestionDto systemQuestionDto
        )
        {
            var systemQuestion = await _systemQuestionRepository.GetByIdAsync(id);
            if (systemQuestion == null)
            {
                return NotFound();
            }

            systemQuestion.Name = systemQuestionDto.Name;
            systemQuestion.CategoryId = systemQuestionDto.CategoryId;
            systemQuestion.UpdatedAt = DateTime.UtcNow;

            await _systemQuestionRepository.UpdateAsync(systemQuestion);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSystemQuestion(Guid id)
        {
            var question = await _systemQuestionRepository.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            try
            {
                await _systemQuestionRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                var errorResponse = ResponseHelper.CreateErrorResponse<AnyType>(ex.Message);
                return StatusCode(500, errorResponse);
            }

            return NoContent();
        }
    }
}
