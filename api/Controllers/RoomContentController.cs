using api.Dtos;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/room-content")]
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
        [ProducesResponseType(typeof(ApiResponse<List<RoomContentDto>>), 200)]
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