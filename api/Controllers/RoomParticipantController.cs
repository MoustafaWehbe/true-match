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

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<RoomParticipantDto>), 200)]
        public async Task<IActionResult> joinRoom([FromBody] CreateRoomParticipantDto createRoomParticipantDto)
        {
            var user = await _userManager.FindByEmailAsync(User.GetEmail());

            var room = await _roomRepo.GetByIdAsync(createRoomParticipantDto.RoomId);

            if (room == null)
            {
                return BadRequest("Room does not exist");
            }

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            var roomParticipant = await _roomParticipantRepo.joinRoomAsync(user, createRoomParticipantDto);

            if (roomParticipant == null)
            {
                return StatusCode(500, "Could not join");
            }
            else
            {
                return Ok(ResponseHelper.CreateSuccessResponse(roomParticipant.ToRoomParticipantDto()));
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<RoomParticipantDto>), 200)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoomParticipantDto updateDto)
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

            var existingRoomParticipants = await _roomParticipantRepo.GetRoomParticipantsAsync(user);
            var existingRoomParticipant = existingRoomParticipants.Where(rp => rp.RoomId == id).FirstOrDefault();
            if (existingRoomParticipant == null)
            {
                return NotFound();
            }

            await _roomParticipantRepo.UpdateRoomParticipantAsync(existingRoomParticipant, updateDto);

            return Ok(ResponseHelper.CreateSuccessResponse(existingRoomParticipant.ToRoomParticipantDto()));
        }

    }
}