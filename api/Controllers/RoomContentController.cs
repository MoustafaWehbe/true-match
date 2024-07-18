using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomContentController : ControllerBase
    {
        private readonly IRoomContentRepository _roomContentRepo;
        public RoomContentController(IRoomContentRepository roomContentRepo)
        {
            _roomContentRepo = roomContentRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var roomContent = await _roomContentRepo.GetAllAsync();

            var roomContentDto = roomContent.Select(s => s.ToRoomContentDto());

            return Ok(ResponseHelper.CreateSuccessResponse(roomContentDto));
        }
    }
}