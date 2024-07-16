using api.Dtos;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
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

            return Ok(ResponseHelper.CreateSuccessResponse(liveStreamDto));
        }

        [HttpPost]
        [Authorize]
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

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            var liveStream = liveStreamDto.ToLiveStreamFromCreate(user.Id);

            var createdLiveStream = await _liveStreamRepo.CreateAsync(liveStream);

            return CreatedAtAction(nameof(GetLiveStreamById), new { id = createdLiveStream.Id }, liveStream.ToLiveStreamDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLiveStreamDto updateStreamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liveStream = await _liveStreamRepo.UpdateAsync(id, updateStreamDto);
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            if (liveStream == null)
            {
                return NotFound();
            }

            if (user.Id != liveStream.UserId)
            {
                return Unauthorized("Action not allowed");
            }

            return Ok(ResponseHelper.CreateSuccessResponse(liveStream.ToLiveStreamDto()));
        }

        [HttpGet("{id}")]
        [Authorize]
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

            return Ok(ResponseHelper.CreateSuccessResponse(liveStream.ToLiveStreamDto()));
        }

    }
}