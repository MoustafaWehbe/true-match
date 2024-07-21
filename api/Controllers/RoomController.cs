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
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepo;
        private readonly UserManager<User> _userManager;

        public RoomController(IRoomRepository roomRepo, UserManager<User> userManager)
        {
            _roomRepo = roomRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rooms = await _roomRepo.GetAllAsync();

            var roomDto = rooms.Select(s => s.ToRoomDto());

            return Ok(ResponseHelper.CreateSuccessResponse(roomDto));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Room>> CreateRoom([FromBody] CreateRoomDto roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (roomDto == null)
            {
                return BadRequest("Invalid live stream data.");
            }

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            var room = roomDto.ToRoomFromCreate(user.Id);

            var createdRoom = await _roomRepo.CreateAsync(room);

            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, room.ToRoomDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoomDto updateStreamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room = await _roomRepo.UpdateAsync(id, updateStreamDto);
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            if (room == null)
            {
                return NotFound();
            }

            if (user.Id != room.UserId)
            {
                return Unauthorized("Action not allowed");
            }

            return Ok(ResponseHelper.CreateSuccessResponse(room.ToRoomDto()));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var room = await _roomRepo.GetByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(ResponseHelper.CreateSuccessResponse(room.ToRoomDto()));
        }

    }
}