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

        public UserProfileController(IUserProfileRepository userProfileRepo, UserManager<User> userManager)
        {
            _userProfileRepo = userProfileRepo;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UserProfile>> CreateUserProfile([FromBody] CreateUserProfileDto userProfileDto)
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

            var userProfile = userProfileDto.ToUserProfileFromCreate(user.Id);

            foreach (var interestDto in userProfileDto.UserProfileInterests)
            {
                userProfile.UserProfileInterests.Add(new UserProfileInterest
                {
                    InterestId = interestDto.InterestId,
                    UserProfile = userProfile
                });
            }

            foreach (var lifestyleDto in userProfileDto.UserProfileLifeStyles)
            {
                userProfile.UserProfileLifeStyles.Add(new UserProfileLifeStyle
                {
                    LifeStyleId = lifestyleDto.LifeStyleId,
                    UserProfile = userProfile
                });
            }

            var createdUserProfile = await _userProfileRepo.CreateAsync(userProfile);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = createdUserProfile.Id }, createdUserProfile.ToUserProfileDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> GetUserProfileById(int id)
        {
            var userProfile = await _userProfileRepo.GetByIdAsync(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(ResponseHelper.CreateSuccessResponse(userProfile));
        }
    }
}