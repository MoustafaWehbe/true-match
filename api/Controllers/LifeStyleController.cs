using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeStyleController : ControllerBase
    {
        private readonly ILifeStyleRepository _lifeStyleRepo;
        public LifeStyleController(ILifeStyleRepository lifeStyleRepo)
        {
            _lifeStyleRepo = lifeStyleRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lifeStyles = await _lifeStyleRepo.GetAllAsync();

            var lifeStyleDto = lifeStyles.Select(s => s.ToLifeStyleDto());

            return Ok(ResponseHelper.CreateSuccessResponse(lifeStyleDto));
        }
    }
}