using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.DTOs;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using api.Helpers;
using Microsoft.OpenApi.Any;

namespace api.Controllers
{
    [Route("api/system-question")]
    [ApiController]
    public class SystemQuestionsController : ControllerBase
    {
        private readonly ISystemQuestionRepository _systemQuestionRepository;

        public SystemQuestionsController(ISystemQuestionRepository systemQuestionRepository)
        {
            _systemQuestionRepository = systemQuestionRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SystemQuestion>>> GetSystemQuestions()
        {
            var questions = await _systemQuestionRepository.GetAllAsync();
            return Ok(ResponseHelper.CreateSuccessResponse(questions));
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
