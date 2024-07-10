using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] UserQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _userRepo.GetAllAsync(query);
            var totalUsers = await _userRepo.GetTotalUsersAsync();
            var totalPages = await _userRepo.GetTotalPagesAsync(query.PageSize);

            var userDto = users.Select(u => u.ToUserDto()).ToList();

            var response = new
            {
                TotalUsers = totalUsers,
                TotalPages = totalPages,
                CurrentPage = query.PageNumber,
                query.PageSize,
                Users = userDto
            };

            return Ok(response);
        }
    }
}