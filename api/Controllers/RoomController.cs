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
        private readonly IUserProfileRepository _userProfileRepo;
        private readonly IUserRepository _userRepo;
        private readonly ISystemQuestionRepository _systemQuestionRepository;

        public RoomController(
            IRoomRepository roomRepo,
            UserManager<User> userManager,
            IUserProfileRepository userProfileRepo,
            IUserRepository userRepo,
            ISystemQuestionRepository systemQuestionRepository
        )
        {
            _roomRepo = roomRepo;
            _userManager = userManager;
            _userProfileRepo = userProfileRepo;
            _userRepo = userRepo;
            _systemQuestionRepository = systemQuestionRepository;
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

            var userProfile = await _userProfileRepo.GetByUserId(user.Id);
            if (userProfile == null)
            {
                return BadRequest("User profile missing.");
            }

            var blockedUsersIds = (await _userRepo.UsersIbBlocked(user.Id))
                .Select(b => b.BlockedUserId)
                .ToList();
            var hiddenRooms = (await _roomRepo.RoomsIHid(user.Id)).Select(hr => hr.RoomId).ToList();

            var rooms = await _roomRepo.GetAllAsync(
                query,
                userProfile,
                blockedUsersIds,
                hiddenRooms
            );

            var totalRooms = await _roomRepo.GetTotalRoomsAsync(
                query,
                userProfile,
                blockedUsersIds,
                hiddenRooms
            );
            var totalPages = _roomRepo.GetTotalPages(query.PageSize, totalRooms);

            var roomDtos = rooms.Select(s => s.ToRoomDto(user.Id)).ToList();
            var response = ResponseHelper.CreatePagedResponse(
                totalRooms,
                totalPages,
                query.PageNumber,
                query.PageSize,
                roomDtos
            );

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
            var response = ResponseHelper.CreatePagedResponse(
                totalRooms,
                totalPages,
                query.PageNumber,
                query.PageSize,
                roomDtos
            );

            return Ok(response);
        }

        [HttpGet("history")]
        [Authorize]
        [ProducesResponseType(typeof(PagedResponse<RoomDto>), 200)]
        public async Task<IActionResult> GetRoomsHistory([FromQuery] RoomsHistoryQueryObject query)
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

            var rooms = await _roomRepo.GetRoomsHistoryAsync(user.Id);

            var totalRooms = await _roomRepo.GetTotalRoomsHistorysAsync(user.Id);
            var totalPages = _roomRepo.GetTotalPages(query.PageSize, totalRooms);

            var roomDtos = rooms.Select(s => s.ToRoomDto(user.Id)).ToList();
            var response = ResponseHelper.CreatePagedResponse(
                totalRooms,
                totalPages,
                query.PageNumber,
                query.PageSize,
                roomDtos
            );

            return Ok(response);
        }

        [HttpPost("start-room/{id:guid}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<RoomDto>), 200)]
        public async Task<IActionResult> StartRoom([FromRoute] Guid id)
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

            if (!room.canStart)
            {
                return BadRequest("Cannot start room");
            }
            else if (room.StartedAt != null)
            {
                return BadRequest("Room already started!");
            }
            room.StartedAt = DateTime.UtcNow;
            room.UpdatedAt = DateTime.UtcNow;
            await _roomRepo.UpdateAsync(room);

            return Ok(ResponseHelper.CreateSuccessResponse(room.ToRoomDto()));
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<SimpleApiResponse>), 200)]
        public async Task<IActionResult> DeleteRoom(Guid id)
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

            return Ok(
                ResponseHelper.CreateSuccessResponse(new { message = "Room deleted successfully." })
            );
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

            var randomQuestions = await _systemQuestionRepository.GenerateRandomQuestions(
                roomDto.QuestionsCategories
            );

            var room = roomDto.ToRoomFromCreate(
                user.Id,
                new RoomState
                {
                    RoundQuestions = randomQuestions.Select(q => q.ToSystemQuestionDto()).ToList(),
                }
            );

            var createdRoom = await _roomRepo.CreateAsync(room);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdRoom.Id },
                ResponseHelper.CreateSuccessResponse(room.ToRoomDto())
            );
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<RoomDto>), 200)]
        [Authorize]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateRoomDto updateRoomDto
        )
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

            if (
                updateRoomDto.QuestionsCategories != null
                && updateRoomDto.QuestionsCategories.SequenceEqual(existingRoom.QuestionsCategories)
            )
            {
                var randomQuestions = await _systemQuestionRepository.GenerateRandomQuestions(
                    updateRoomDto.QuestionsCategories
                );

                if (updateRoomDto.RoomState != null)
                {
                    updateRoomDto.RoomState.RoundQuestions = randomQuestions
                        .Select(q => q.ToSystemQuestionDto())
                        .ToList();
                }
                else
                {
                    updateRoomDto.RoomState = new RoomState
                    {
                        RoundQuestions = randomQuestions
                            .Select(q => q.ToSystemQuestionDto())
                            .ToList(),
                    };
                }
            }

            var room = await _roomRepo.UpdateAsync(existingRoom, updateRoomDto);

            return Ok(ResponseHelper.CreateSuccessResponse(room.ToRoomDto()));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<RoomDto>), 200)]
        [Authorize]
        public async Task<ActionResult<Room>> GetById(Guid id)
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

            await _roomRepo.HideRoom(hideRoomDto, user);
            ;

            return Ok(
                ResponseHelper.CreateSuccessResponse(new { message = "Room has been hidden." })
            );
        }
    }
}
