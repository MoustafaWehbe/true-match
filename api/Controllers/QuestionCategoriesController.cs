using api.Dtos;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/question-category")]
    [ApiController]
    public class QuestionCategoriesController : ControllerBase
    {
        private readonly IQuestionCategoryRepository _questionCategoryRepository;

        public QuestionCategoriesController(IQuestionCategoryRepository questionCategoryRepository)
        {
            _questionCategoryRepository = questionCategoryRepository;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<QuestionCategoryDto>>), 200)]
        public async Task<ActionResult<IEnumerable<QuestionCategory>>> GetQuestionCategories()
        {
            var categories = await _questionCategoryRepository.GetAllAsync();
            return Ok(ResponseHelper.CreateSuccessResponse(categories));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<QuestionCategory>> GetQuestionCategory(int id)
        {
            var category = await _questionCategoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(ResponseHelper.CreateSuccessResponse(category));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<QuestionCategory>> CreateQuestionCategory(
            QuestionCategoryDto categoryDto
        )
        {
            var category = new QuestionCategory { Name = categoryDto.Name };

            await _questionCategoryRepository.CreateAsync(category);

            return CreatedAtAction(nameof(GetQuestionCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateQuestionCategory(
            int id,
            QuestionCategoryDto categoryDto
        )
        {
            var category = await _questionCategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.Name = categoryDto.Name;
            category.UpdatedAt = DateTime.UtcNow;

            await _questionCategoryRepository.UpdateAsync(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteQuestionCategory(int id)
        {
            var category = await _questionCategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _questionCategoryRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
