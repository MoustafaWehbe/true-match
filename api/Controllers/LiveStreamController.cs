using api.Dtos.LiveStream;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/liveStreams")]
    [ApiController]
    public class LiveStreamController : ControllerBase
    {
        private readonly ILiveStreamRepository _liveStreamRepo;
        private readonly UserManager<User> _userManager;

        public LiveStreamController(ILiveStreamRepository liveStreamRepo, UserManager<User> userManager)
        {
            _liveStreamRepo = liveStreamRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var liveStreams = await _liveStreamRepo.GetAllAsync();

            var liveStreamDto = liveStreams.Select(s => s.ToLiveStreamDto());

            return Ok(liveStreamDto);
        }

        [HttpPost]
        public async Task<ActionResult<LiveStream>> CreateLiveStream([FromBody] CreateLiveStreamDto liveStreamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (liveStreamDto == null)
            {
                return BadRequest("Invalid live stream data.");
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            var liveStream = liveStreamDto.ToLiveStreamFromCreate(user.Id);

            var createdLiveStream = await _liveStreamRepo.CreateAsync(liveStream);

            return CreatedAtAction(nameof(GetLiveStreamById), new { id = createdLiveStream.Id }, liveStream.ToLiveStreamDto());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LiveStream>> GetLiveStreamById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var liveStream = await _liveStreamRepo.GetByIdAsync(id);

            if (liveStream == null)
            {
                return NotFound();
            }

            return Ok(liveStream.ToLiveStreamDto());
        }

    }
}