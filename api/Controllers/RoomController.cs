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
    [Route("api/room")]
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
        [ProducesResponseType(typeof(PagedResponse<RoomDto>), 200)]
        public async Task<IActionResult> GetAll([FromQuery] AllRoomQueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            var rooms = await _roomRepo.GetAllAsync(query, user.Id);

            var totalRooms = await _roomRepo.GetTotalRoomsAsync(query, user.Id);
            var totalPages = _roomRepo.GetTotalPages(query.PageSize, totalRooms);

            var roomDtos = rooms.Select(s => s.ToRoomDto(user.Id)).ToList();
            var response = ResponseHelper.CreatePagedResponse(totalRooms, totalPages, query.PageNumber, query.PageSize, roomDtos);

            return Ok(response);
        }

        [HttpGet("my-rooms")]
        [Authorize]
        [ProducesResponseType(typeof(PagedResponse<RoomDto>), 200)]
        public async Task<IActionResult> GetMyRooms([FromQuery] MyRoomQueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            var rooms = await _roomRepo.GetMyRoomsAsync(query, user.Id);

            var totalRooms = await _roomRepo.GetTotalMyRoomsAsync(query, user.Id);
            var totalPages = _roomRepo.GetTotalPages(query.PageSize, totalRooms);

            var roomDtos = rooms.Select(s => s.ToRoomDto(user.Id)).ToList();
            var response = ResponseHelper.CreatePagedResponse(totalRooms, totalPages, query.PageNumber, query.PageSize, roomDtos);

            return Ok(response);
        }

        [HttpPost("start-room/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<RoomDto>), 200)]
        public async Task<IActionResult> StartRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            var room = await _roomRepo.GetByIdAsync(id);

            if (room == null)
            {
                return NotFound("Room was not found.");
            }

            if (room.UserId != user.Id)
            {
                return Unauthorized("Action not allowed.");
            }

            // after one hour passed, you can't start the room anymore,
            // otherwise you can start the room if it is after the scheduled datetime
            if (
                room.ScheduledAt > DateTime.UtcNow ||
                DateTime.UtcNow.AddHours(-RoomConstants.AfterStartTheRoomIsValidFor) > room.ScheduledAt)
            {
                return BadRequest("Cannot start room");
            }
            // first time starting it
            else if (room.StartedAt == null)
            {
                room.StartedAt = DateTime.UtcNow;
                room.UpdatedAt = DateTime.UtcNow;
                await _roomRepo.UpdateAsync(room);
            }
            // starting the room again while it is still valid
            else
            {
                room.UpdatedAt = DateTime.UtcNow;
                await _roomRepo.UpdateAsync(room);
            }

            return Ok(ResponseHelper.CreateSuccessResponse(room.ToRoomDto()));
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> SoftDeleteRoom(int id)
        {
            var user = await _userManager.FindByEmailAsync(User.GetEmail());
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var room = await _roomRepo.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound("Room not found.");
            }

            if (room.UserId != user.Id)
            {
                return Unauthorized("Action not allowed.");
            }

            room.IsDeleted = true;
            room.UpdatedAt = DateTime.UtcNow;

            await _roomRepo.UpdateAsync(room);

            return Ok(ResponseHelper.CreateSuccessResponse(new { message = "Room deleted successfully." }));
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<RoomDto>), 200)]
        public async Task<ActionResult<RoomDto>> CreateRoom([FromBody] CreateRoomDto roomDto)
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

            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, ResponseHelper.CreateSuccessResponse(room.ToRoomDto()));
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<RoomDto>), 200)]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoomDto updateRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRoom = await _roomRepo.GetByIdAsync(id);
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User was not found.");
            }

            if (existingRoom == null)
            {
                return NotFound();
            }

            if (user.Id != existingRoom.UserId)
            {
                return Unauthorized("Action not allowed");
            }

            existingRoom.Title = updateRoomDto.Title;
            existingRoom.Description = updateRoomDto.Description;
            existingRoom.ScheduledAt = updateRoomDto.ScheduledAt;
            existingRoom.FinishedAt = updateRoomDto.FinishedAt;
            existingRoom.UpdatedAt = DateTime.UtcNow;
            existingRoom.Offers = updateRoomDto.Offers;
            existingRoom.QuestionsCategories = updateRoomDto.QuestionsCategories;


            var room = await _roomRepo.UpdateAsync(existingRoom);

            return Ok(ResponseHelper.CreateSuccessResponse(room.ToRoomDto()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<RoomDto>), 200)]
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

        [HttpPost("hide-room")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> HideRoom([FromBody] HideRoomDto hideRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var room = await _roomRepo.GetByIdAsync(hideRoomDto.RoomId);
            if (room == null)
            {
                return NotFound("Room not found.");
            }

            await _roomRepo.HideRoom(hideRoomDto, user); ;

            return Ok(ResponseHelper.CreateSuccessResponse(new { message = "Room has been hidden." }));
        }
    }
}