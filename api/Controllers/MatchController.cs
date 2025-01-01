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
    [Route("api/match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMatchRepository _matchRepo;
        private readonly IRoomRepository _roomRepo;

        public MatchController(
            UserManager<User> userManager,
            IMatchRepository matchRepo,
            IRoomRepository roomRepo
        )
        {
            _userManager = userManager;
            _matchRepo = matchRepo;
            _roomRepo = roomRepo;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<MatchDto>), 200)]
        public async Task<ActionResult<Match>> Create([FromBody] CreateMatchDto createMatchDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user1 = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user1 == null)
            {
                return NotFound("User was not found!");
            }

            var match = createMatchDto.ToMatchFromCreate(user1.Id);

            var createdMatch = await _matchRepo.CreateAsync(match);

            if (createMatchDto.RoomId.HasValue)
            {
                var room = await _roomRepo.GetByIdAsync(createMatchDto.RoomId.Value);

                if (room == null)
                {
                    return NotFound("Room was not found.");
                }

                await _roomRepo.MarkRoomAsFinished(room);
            }

            return CreatedAtAction(nameof(GetById), new { id = match.Id }, match.ToMatchDto());
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<MatchDto>), 200)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var match = await _matchRepo.GetByIdAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(ResponseHelper.CreateSuccessResponse(match.ToMatchDto()));
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<MatchDto>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found!");
            }
            var matches = await _matchRepo.GetMatchesForUserAsync(user.Id);
            var matchesDto = matches.Select(m => m.ToMatchDto()).ToList();
            return Ok(ResponseHelper.CreateSuccessResponse(matchesDto));
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userManager.FindByEmailAsync(User.GetEmail());
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var match = await _matchRepo.GetByIdAsync(id);
            if (match == null)
            {
                return NotFound("Match not found.");
            }

            if (match.User1Id != user.Id && match.User2Id != user.Id)
            {
                return Unauthorized("Action not allowed.");
            }

            await _matchRepo.DeleteAsync(match);

            return Ok(
                ResponseHelper.CreateSuccessResponse(
                    new { message = "Match deleted successfully." }
                )
            );
        }
    }
}
