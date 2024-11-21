using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/media")]
    public class MediaController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<User> _userManager;
        private readonly IMediaRepository _mediaRepo;

        public MediaController(
            IWebHostEnvironment env,
            UserManager<User> userManager,
            IMediaRepository mediaRepo
        )
        {
            _env = env;
            _userManager = userManager;
            _mediaRepo = mediaRepo;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found!");
            }

            var webRootPath =
                _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            var uploadsFolderPath = Path.Combine(webRootPath, "uploads");

            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"/uploads/{fileName}"; // URL for accessing the image

            var media = new Media
            {
                Url = fileUrl,
                MediaType = MediaType.Image,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _mediaRepo.CreateAsync(media);

            return Ok(ResponseHelper.CreateSuccessResponse(media));
        }
    }
}
