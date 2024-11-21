using api.Data;
using api.Dtos;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signinManager;
        private readonly ApplicationDBContext _context;

        public AccountController(
            UserManager<User> userManager,
            ITokenService tokenService,
            SignInManager<User> signInManager,
            ApplicationDBContext context
        )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
            _context = context;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse<User>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 500)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x =>
                x.Email == loginDto.Email.ToLower()
            );

            if (user == null)
            {
                return Unauthorized("Invalid email!");
            }

            var result = await _signinManager.CheckPasswordSignInAsync(
                user,
                loginDto.Password,
                false
            );

            if (!result.Succeeded)
                return Unauthorized("Username not found and/or password incorrect");

            return Ok(
                ResponseHelper.CreateSuccessResponse(
                    new NewUserDto { Email = user.Email!, Token = _tokenService.CreateToken(user) }
                )
            );
        }

        [HttpPost("logout")]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return Ok(
                ResponseHelper.CreateSuccessResponse(new { message = "Successfully logged out." })
            );
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiResponse<User>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 500)]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new User
                {
                    Email = registerDto.Email,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    UserName = registerDto.Email,
                };

                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            ResponseHelper.CreateSuccessResponse(
                                new NewUserDto
                                {
                                    Email = user.Email!,
                                    Token = _tokenService.CreateToken(user),
                                }
                            )
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> DeleteAccount()
        {
            var email = User.GetEmail();
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return NotFound("User was not found!");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(up =>
                    up.UserId == user.Id
                );

                if (userProfile != null)
                {
                    _context.UserProfiles.Remove(userProfile);
                    await _context.SaveChangesAsync();
                }

                var result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, new { error = "Failed to delete user account." });
                }

                await transaction.CommitAsync();

                return Ok(
                    ResponseHelper.CreateSuccessResponse(
                        new
                        {
                            message = "Account deleted dsmfgjsdhfgsdhfg jhsdgf jdhsgfjhsg fjhdsgfjhdsgfj gsfjhsgdfjh hghjfgfjhsdgf jsgfjhsbfjdhs fhsdfnbsdvfn svnfbvdsnfvn sdvfnbsdvfnsdvfnbsdvf bdsvfnsbd vfnvsdnvf successfully.",
                        }
                    )
                );
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
