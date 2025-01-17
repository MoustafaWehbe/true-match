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
    [Route("api/user-profile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepo;
        private readonly UserManager<User> _userManager;

        public UserProfileController(
            IUserProfileRepository userProfileRepo,
            UserManager<User> userManager
        )
        {
            _userProfileRepo = userProfileRepo;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<UserProfileDto>), 200)]
        public async Task<ActionResult<UserProfileDto>> CreateOrUpdateUserProfile(
            [FromBody] CreateOrUpdateUserProfileDto userProfileDto
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userProfileDto == null)
            {
                return BadRequest("Invalid live stream data.");
            }

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            var createdUserProfile = await _userProfileRepo.CreateOrUpdateAsync(
                userProfileDto,
                user.Id
            );

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdUserProfile.Id },
                ResponseHelper.CreateSuccessResponse(createdUserProfile.ToUserProfileDto())
            );
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<UserProfileDto>), 200)]
        public async Task<ActionResult<UserProfile>> GetById(Guid id)
        {
            var userProfile = await _userProfileRepo.GetByIdAsync(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(ResponseHelper.CreateSuccessResponse(userProfile.ToUserProfileDto()));
        }
    }
}
