using api.Dtos;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Bogus.DataSets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/room-participant")]
    [ApiController]
    public class RoomParticipantController : ControllerBase
    {
        private readonly IRoomRepository _roomRepo;
        private readonly IRoomParticipantsRepository _roomParticipantRepo;
        private readonly UserManager<User> _userManager;

        public RoomParticipantController(IRoomParticipantsRepository roomParticipantRepo, UserManager<User> userManager, IRoomRepository roomRepo)
        {
            _roomParticipantRepo = roomParticipantRepo;
            _roomRepo = roomRepo;
            _userManager = userManager;
        }

        [HttpPost("deregister/{id:guid}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> deregisterRoom([FromRoute] Guid id)
        {
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            var room = await _roomRepo.GetByIdAsync(id);

            if (room == null)
            {
                return BadRequest("Room does not exist");
            }

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            if (room.FinishedAt != null)
            {
                return BadRequest("Can't deregister from rooms finished in the past.");
            }

            await _roomParticipantRepo.DeleteAsync(id, user.Id);

            return Ok(ResponseHelper.CreateSuccessResponse(new { message = "Successfully deregistered." }));
        }


        [HttpPost("register/{id:guid}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<RoomParticipantDto>), 200)]
        public async Task<IActionResult> registerRoom([FromRoute] Guid id)
        {
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            var room = await _roomRepo.GetByIdAsync(id);

            if (room == null)
            {
                return BadRequest("Room does not exist");
            }

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            if (DateTime.UtcNow >= room.ScheduledAt)
            {
                return BadRequest("Could not register. The room already started");
            }

            var roomParticipants = await _roomParticipantRepo.GetRoomParticipantsAsync(user);

            if (roomParticipants.Any(rp => rp.RoomId == room.Id))
            {
                return BadRequest("Already registered");
            }

            var newRoomParticipant = new RoomParticipant
            {
                RoomId = id,
                UserId = user.Id
            };

            await _roomParticipantRepo.CreateAsync(newRoomParticipant);

            return Ok(ResponseHelper.CreateSuccessResponse(newRoomParticipant.ToRoomParticipantDto()));
        }

        [HttpPost("join/{id:guid}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> joinRoom(Guid id, [FromBody] JoinRoomDto joinRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            var room = await _roomRepo.GetByIdAsync(id);

            if (room == null)
            {
                return BadRequest("Room does not exist");
            }

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            if (room.StartedAt == null)
            {
                return BadRequest("Room has not started yet");
            }

            if (room.isExpired)
            {
                return BadRequest("Can't join. Room has expired");
            }

            var roomParticipants = await _roomParticipantRepo.GetRoomParticipantsAsync(user);

            if (room.UserId == user.Id)
            {
                var newRoomParticipantEvent = new RoomParticipantEvent
                {
                    Left = false,
                    AttendedFromTime = DateTime.UtcNow,
                    AttendedToTime = null,
                    CreatedAt = DateTime.UtcNow,
                    SocketId = joinRoomDto.SocketId
                };
                await _roomParticipantRepo.CreateRoomParticipantEventAsync(newRoomParticipantEvent);
            }
            else if (roomParticipants.Any(rp => rp.RoomId == room.Id))
            {
                var alreadyParticipatedRoom = roomParticipants.Where(rp => rp.RoomId == id).FirstOrDefault();

                if (alreadyParticipatedRoom == null)
                {
                    return BadRequest("Can't join. Not registered to this room.");
                }

                var newRoomParticipantEvent = new RoomParticipantEvent
                {
                    RoomParticipantId = alreadyParticipatedRoom.Id,
                    Left = false,
                    AttendedFromTime = DateTime.UtcNow,
                    AttendedToTime = null,
                    CreatedAt = DateTime.UtcNow,
                    SocketId = joinRoomDto.SocketId
                };
                await _roomParticipantRepo.CreateRoomParticipantEventAsync(newRoomParticipantEvent);
            }
            return Ok(ResponseHelper.CreateSuccessResponse(new { message = "User joined." }));
        }

        [HttpPost]
        [Route("leave/{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> LeaveRoom([FromRoute] Guid id)
        {

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            var room = await _roomRepo.GetByIdAsync(id);

            if (room == null)
            {
                return BadRequest("Room does not exist");
            }

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            if (user.Id != room.UserId && room.StartedAt == null)
            {
                return BadRequest("Room has not started yet");
            }

            var roomParticipants = await _roomParticipantRepo.GetRoomParticipantsAsync(user);

            if (roomParticipants.Any(rp => rp.RoomId == room.Id))
            {
                var alreadyParticipatedRoom = roomParticipants.Where(rp => rp.RoomId == id).FirstOrDefault();

                if (alreadyParticipatedRoom == null)
                {
                    return BadRequest("Can't leave. You are not even registered!");
                }

                var newRoomParticipantEvent = new RoomParticipantEvent
                {
                    RoomParticipantId = alreadyParticipatedRoom.Id,
                    Left = true,
                    AttendedToTime = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };
                await _roomParticipantRepo.CreateRoomParticipantEventAsync(newRoomParticipantEvent);
            }
            return Ok(ResponseHelper.CreateSuccessResponse(new { message = "User Left." }));
        }
    }
}