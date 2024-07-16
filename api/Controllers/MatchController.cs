using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using api.Extensions;
using Microsoft.AspNetCore.Identity;
using api.Mappers;
using api.Repository;
using api.Interfaces;
using api.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMatchRepository _matchRepo;

        public MatchController(ApplicationDBContext context, UserManager<User> userManager, MatchRepository matchRepo)
        {
            _context = context;
            _userManager = userManager;
            _matchRepo = matchRepo;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Match>> CreateMatch([FromBody] CreateMatchDto createMatchDto)
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

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, match.ToMatchDto());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            var match = await _matchRepo.GetByIdAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }


        [HttpGet("myMatches")]
        [Authorize]
        public async Task<IActionResult> GetMyMatches()
        {
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found!");
            }
            var matches = await _matchRepo.GetMatchesForUserAsync(user.Id);

            var matchesDto = matches.Select(m => m.ToMatchDto()).ToList();

            return Ok(matchesDto);
        }
    }
}
