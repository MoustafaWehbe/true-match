using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Dtos;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using api.Helpers;
using Microsoft.OpenApi.Any;
using Microsoft.EntityFrameworkCore;
using api.Mappers;
using System.Text.Json;

namespace api.Controllers
{
    [Route("api/system-question")]
    [ApiController]
    public class SystemQuestionsController : ControllerBase
    {
        private readonly ISystemQuestionRepository _systemQuestionRepository;
        private readonly IRoomRepository _roomRepo;

        public SystemQuestionsController(ISystemQuestionRepository systemQuestionRepository, IRoomRepository roomRepo)
        {
            _systemQuestionRepository = systemQuestionRepository;
            _roomRepo = roomRepo;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<SystemQuestionDto>>), 200)]
        public async Task<ActionResult<IEnumerable<SystemQuestionDto>>> GetSystemQuestions([FromQuery] List<int> categories, [FromQuery] int? roomId)
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

                var randomQuestions = questions
                    .OrderBy(q => Guid.NewGuid())
                    .Take(3)
                    .ToList();


                if (roomId.HasValue)
                {

                    var room = await _roomRepo.GetByIdAsync((int)roomId);

                    if (room == null)
                    {
                        return NotFound("Room was not found.");
                    }
                    var existingRoomMetadata = room.RoomMetaData != null ? JsonSerializer.Deserialize<RoomMetaData>(room.RoomMetaData) : null;
                    if (existingRoomMetadata != null)
                    {
                        existingRoomMetadata.SystemQuestions = (List<SystemQuestionDto>?)randomQuestions.Select(q => q.ToSystemQuestionDto());
                    }
                    else
                    {
                        existingRoomMetadata = new RoomMetaData { SystemQuestions = (List<SystemQuestionDto>?)randomQuestions.Select(q => q.ToSystemQuestionDto()) };
                    }
                    room.RoomMetaData = JsonDocument.Parse(JsonSerializer.Serialize(existingRoomMetadata));

                    await _roomRepo.UpdateAsync(room);
                }

                return Ok(ResponseHelper.CreateSuccessResponse(randomQuestions.Select(q => q.ToSystemQuestionDto())));
            }
            else
            {
                var questions = await _systemQuestionRepository.GetAllAsync();
                return Ok(ResponseHelper.CreateSuccessResponse(questions.Select(q => q.ToSystemQuestionDto())));
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<SystemQuestion>> GetSystemQuestion(int id)
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
        public async Task<ActionResult<SystemQuestion>> CreateSystemQuestion(CreateSystemQuestionDto systemQuestionDto)
        {
            var systemQuestion = new SystemQuestion
            {
                Name = systemQuestionDto.Name,
                CategoryId = systemQuestionDto.CategoryId
            };

            await _systemQuestionRepository.CreateAsync(systemQuestion);

            return CreatedAtAction(nameof(GetSystemQuestion), new { id = systemQuestion.Id }, systemQuestion);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateSystemQuestion(int id, UpdateSystemQuestionDto systemQuestionDto)
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSystemQuestion(int id)
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
