using api.Dtos;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<List<SystemQuestionDto>>), 200)]
        public async Task<ActionResult<IEnumerable<SystemQuestionDto>>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questions = await _systemQuestionRepository.GetAllAsync();
            return Ok(
                ResponseHelper.CreateSuccessResponse(questions.Select(q => q.ToSystemQuestionDto()))
            );
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
