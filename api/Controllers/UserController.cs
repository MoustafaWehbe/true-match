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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly UserManager<User> _userManager;

        public UserController(IUserRepository userRepo, UserManager<User> userManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] UserQueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = await _userManager.FindByEmailAsync(User.GetEmail());

            if (currentUser == null)
            {
                return NotFound("User not found.");
            }

            var users = await _userRepo.GetAllAsync(query, currentUser);
            var totalUsers = await _userRepo.GetTotalUsersAsync(currentUser);
            var totalPages = _userRepo.GetTotalPages(query.PageSize, totalUsers);

            var userDto = users.Select(u => u.ToUserDto()).ToList();

            var response = ResponseHelper.CreatePagedResponse(
                totalUsers,
                totalPages,
                query.PageNumber,
                query.PageSize,
                userDto
            );

            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(ResponseHelper.CreateSuccessResponse(user.ToUserDto()));
        }

        [HttpGet("/me")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<UserDto>), 200)]
        public async Task<IActionResult> Me()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound();
            }
            var me = await _userRepo.GetByIdAsync(user.Id);

            if (me == null)
            {
                return NotFound();
            }
            return Ok(ResponseHelper.CreateSuccessResponse(me.ToUserDto()));
        }

        [HttpPost("block-user")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> BlockUser([FromBody] BlockUserDto blockUserDto)
        {
            var currentUser = await _userManager.FindByEmailAsync(User.GetEmail());

            if (currentUser == null)
            {
                return NotFound("User not found.");
            }

            var blockedUser = await _userManager.FindByIdAsync(blockUserDto.BlockedUserId);

            if (blockedUser == null)
            {
                return NotFound("User to block not found.");
            }

            var block = new BlockedUser
            {
                BlockerUserId = currentUser.Id,
                BlockedUserId = blockUserDto.BlockedUserId,
            };
            await _userRepo.BlockUser(block);

            return Ok(
                ResponseHelper.CreateSuccessResponse(new { message = "User blocked successfully." })
            );
        }

        [HttpPost("unblock-user")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> UnblockUser([FromBody] BlockUserDto unblockUserDto)
        {
            var currentUser = await _userManager.FindByEmailAsync(User.GetEmail());

            if (currentUser == null)
            {
                return NotFound("User not found.");
            }

            await _userRepo.UnBlockUser(currentUser, unblockUserDto);
            return Ok(
                ResponseHelper.CreateSuccessResponse(new { message = "User blocked successfully." })
            );
        }
    }
}
