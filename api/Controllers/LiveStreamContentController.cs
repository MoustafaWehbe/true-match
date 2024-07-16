using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveStreamContentController : ControllerBase
    {
        private readonly ILiveStreamContentRepository _liveStreamContentRepo;
        public LiveStreamContentController(ILiveStreamContentRepository liveStreamContentRepo)
        {
            _liveStreamContentRepo = liveStreamContentRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var liveStreamContent = await _liveStreamContentRepo.GetAllAsync();

            var liveStreamContentDto = liveStreamContent.Select(s => s.ToLiveStreamContentDto());

            return Ok(ResponseHelper.CreateSuccessResponse(liveStreamContentDto));
        }
    }
}