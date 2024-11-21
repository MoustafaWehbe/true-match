using api.Dtos;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/genders")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;

        public GenderController(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<GenderDto>>), 200)]
        public async Task<ActionResult<IEnumerable<GenderDto>>> GetAvailableDescriptors()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var questions = await _genderRepository.GetAllAsync();
            return Ok(ResponseHelper.CreateSuccessResponse(questions.Select(q => q.ToGenderDto())));
        }
    }
}
