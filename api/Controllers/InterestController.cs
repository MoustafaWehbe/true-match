using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteresetController : ControllerBase
    {
        private readonly IInterestRepository _interestRepo;
        public InteresetController(IInterestRepository interestRepo)
        {
            _interestRepo = interestRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var interests = await _interestRepo.GetAllAsync();

            var interestDto = interests.Select(s => s.ToInterestDto());

            return Ok(ResponseHelper.CreateSuccessResponse(interestDto));
        }
    }
}