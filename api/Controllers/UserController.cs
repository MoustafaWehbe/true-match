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
                return BadRequest(ModelState);

            var users = await _userRepo.GetAllAsync(query);
            var totalUsers = await _userRepo.GetTotalUsersAsync();
            var totalPages = _userRepo.GetTotalPages(query.PageSize, totalUsers);

            var userDto = users.Select(u => u.ToUserDto()).ToList();

            var response = ResponseHelper.CreatePagedResponse(totalUsers, totalPages, query.PageNumber, query.PageSize, userDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(ResponseHelper.CreateSuccessResponse(user.ToUserDto()));
        }

        [HttpGet("/me")]
        [Authorize]
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
    }
}