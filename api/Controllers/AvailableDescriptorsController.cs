using Microsoft.AspNetCore.Mvc;
using api.DTOs;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using api.Helpers;
using api.Mappers;

namespace api.Controllers
{
    [Route("api/available-descriptors")]
    [ApiController]
    public class AvailableDescriptorsController : ControllerBase
    {
        private readonly IAvailableDescriptorRepository _availableDescriptorRepository;

        public AvailableDescriptorsController(IAvailableDescriptorRepository availableDescriptorRepository)
        {
            _availableDescriptorRepository = availableDescriptorRepository;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<AvailableDescriptorDto>>), 200)]
        public async Task<ActionResult<IEnumerable<AvailableDescriptorDto>>> GetAvailableDescriptors()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var questions = await _availableDescriptorRepository.GetAllAsync();
            return Ok(ResponseHelper.CreateSuccessResponse(questions.Select(q => q.ToAvailableDescriptorDto())));
        }
    }
}
