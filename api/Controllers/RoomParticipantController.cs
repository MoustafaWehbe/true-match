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

        [HttpPost("deregister/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> deregisterRoom([FromRoute] int id)
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


        [HttpPost("register/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<RoomParticipantDto>), 200)]
        public async Task<IActionResult> registerRoom([FromRoute] int id)
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

        [HttpPost("join/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> joinRoom(int roomId)
        {
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            var room = await _roomRepo.GetByIdAsync(roomId);

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
                var alreadyParticipatedRoom = roomParticipants.Where(rp => rp.RoomId == roomId).FirstOrDefault();

                if (alreadyParticipatedRoom == null)
                {
                    return BadRequest("Can't join");
                }

                var newRoomParticipantEvent = new RoomParticipantEvent
                {
                    RoomParticipantId = alreadyParticipatedRoom.Id,
                    Left = false,
                    AttendedFromTime = DateTime.UtcNow,
                    AttendedToTime = null,
                    CreatedAt = DateTime.UtcNow
                };
                await _roomParticipantRepo.CreateRoomParticipantEventAsync(newRoomParticipantEvent);
            }
            return Ok(ResponseHelper.CreateSuccessResponse(new { message = "User joined." }));
        }

        [HttpPut]
        [Route("leave/{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> LeaveRoom([FromRoute] int roomId)
        {

            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            var room = await _roomRepo.GetByIdAsync(roomId);

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
                var alreadyParticipatedRoom = roomParticipants.Where(rp => rp.RoomId == roomId).FirstOrDefault();

                if (alreadyParticipatedRoom == null)
                {
                    return BadRequest("Can't join");
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