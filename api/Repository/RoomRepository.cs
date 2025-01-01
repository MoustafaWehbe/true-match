using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using api.Data;
using api.Dtos;
using api.Expressions;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDBContext _context;

        public RoomRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Room> CreateAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<List<Room>> GetAllAsync(
            AllRoomQueryObject query,
            UserProfile userProfile,
            List<string> blockedUsersIds,
            List<Guid> hiddenRoomIds
        )
        {
            if (userProfile.UserProfileGenderPreferences == null)
            {
                throw new Exception("User does not have a profile yet or it is not complete");
            }

            var preferencesFilter = PreferencesFilter.MatchesPreferencesFilter(userProfile);
            var userPreferencesFilter = preferencesFilter.Compose<User, UserProfile>(user =>
                user.UserProfile!
            );
            var roomPreferencesFilter = userPreferencesFilter.Compose<Room, User>(room =>
                room.User!
            );

            var filteredQuery = _context
                .Rooms.Where(r =>
                    r.UserId != userProfile.UserId
                    && !blockedUsersIds.Contains(r.UserId)
                    && !hiddenRoomIds.Contains(r.Id)
                )
                .Where(roomPreferencesFilter)
                .FindNotDeleted()
                .FindAllRoomByStatus(query.Status, userProfile.UserId!)
                .IncludeRoomDetails();

            filteredQuery = query.SortBy switch
            {
                RoomsSortBy.RecentlyCreated => filteredQuery.OrderByDescending(r => r.CreatedAt),
                RoomsSortBy.NumberOfParticipants => filteredQuery.OrderByDescending(r =>
                    r.RoomParticipants.Count
                ),
                RoomsSortBy.ScheduleDate => filteredQuery.OrderBy(r => r.ScheduledAt),
                _ => filteredQuery.OrderByDescending(r => r.CreatedAt),
            };

            filteredQuery = filteredQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize);

            return await filteredQuery.ToListAsync();
        }

        public async Task<List<Room>> GetMyRoomsAsync(MyRoomQueryObject query, string userId)
        {
            var currentUserProfile = await _context
                .UserProfiles.Include(up => up.UserProfileGenders)
                .Where(up => up.UserId == userId)
                .FirstAsync();

            if (
                currentUserProfile == null
                || currentUserProfile.UserProfileGenderPreferences == null
            )
            {
                throw new Exception("User does not have a profile yet or it is not complete");
            }

            return await _context
                .Rooms.IncludeRoomDetails()
                .Where(r => r.UserId == userId)
                .FindMyRoomByStatus(query.Status)
                .FindNotDeleted()
                .OrderByDescending(r => r.CreatedAt)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(Guid id)
        {
            return await _context
                .Rooms.Include(ls => ls.User)
                .Include(ls => ls.RoomParticipants)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public int GetTotalPages(int pageSize, int totalRooms)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException("Page size must be greater than zero.");
            }

            return (int)Math.Ceiling(totalRooms / (double)pageSize);
        }

        public async Task<int> GetTotalRoomsAsync(
            AllRoomQueryObject query,
            UserProfile userProfile,
            List<string> blockedUsersIds,
            List<Guid> hiddenRoomIds
        )
        {
            if (userProfile.UserProfileGenderPreferences == null)
            {
                throw new Exception("User does not have a profile yet or it is not complete");
            }

            var preferencesFilter = PreferencesFilter.MatchesPreferencesFilter(userProfile);
            var userPreferencesFilter = preferencesFilter.Compose<User, UserProfile>(user =>
                user.UserProfile!
            );
            var roomPreferencesFilter = userPreferencesFilter.Compose<Room, User>(room =>
                room.User!
            );

            var filteredQuery = _context
                .Rooms.Where(r =>
                    r.UserId != userProfile.UserId
                    && !blockedUsersIds.Contains(r.UserId)
                    && !hiddenRoomIds.Contains(r.Id)
                )
                .Where(roomPreferencesFilter)
                .FindNotDeleted()
                .FindAllRoomByStatus(query.Status, userProfile.UserId!);

            var rooms = filteredQuery.AsEnumerable();

            return await Task.FromResult(rooms.Count());
        }

        public async Task<int> GetTotalMyRoomsAsync(MyRoomQueryObject query, string userId)
        {
            var filteredQuery = _context
                .Rooms.Where(r => r.UserId == userId)
                .FindMyRoomByStatus(query.Status)
                .FindNotDeleted();

            var count = filteredQuery.Count();

            return await Task.FromResult(count);
        }

        public async Task<Room> UpdateAsync(Room existingRoom, UpdateRoomDto? roomDto)
        {
            if (roomDto != null)
            {
                existingRoom.Title = roomDto.Title ?? existingRoom.Title;
                existingRoom.Description = roomDto.Description ?? existingRoom.Description;
                existingRoom.ScheduledAt = roomDto.ScheduledAt ?? existingRoom.ScheduledAt;
                existingRoom.FinishedAt = roomDto.FinishedAt ?? existingRoom.FinishedAt;
                existingRoom.UpdatedAt = DateTime.UtcNow;
                existingRoom.Offers = roomDto.Offers ?? existingRoom.Offers;
                existingRoom.RoomStateJson =
                    roomDto.RoomState != null
                        ? JsonDocument.Parse(JsonSerializer.Serialize(roomDto.RoomState))
                        : existingRoom.RoomStateJson;
                existingRoom.QuestionsCategories =
                    roomDto.QuestionsCategories ?? existingRoom.QuestionsCategories;
            }

            _context.Rooms.Update(existingRoom);
            await _context.SaveChangesAsync();
            return existingRoom;
        }

        public async Task<HideRoomDto> HideRoom(HideRoomDto hideRoomDto, User user)
        {
            // Check if the room is already hidden
            var existingHiddenRoom = await _context.HiddenRooms.FirstOrDefaultAsync(hr =>
                hr.UserId == user.Id && hr.RoomId == hideRoomDto.RoomId
            );

            if (existingHiddenRoom != null)
            {
                throw new InvalidDataException("Room is already hidden.");
            }

            // Hide the room
            var hiddenRoom = new HiddenRoom { UserId = user.Id, RoomId = hideRoomDto.RoomId };

            _context.HiddenRooms.Add(hiddenRoom);
            await _context.SaveChangesAsync();

            return hideRoomDto;
        }

        public async Task<List<HiddenRoom>> RoomsIHid(string userId)
        {
            return await _context.HiddenRooms.Where(hr => hr.UserId == userId).ToListAsync();
        }

        public async Task<List<Room>> GetRoomsHistoryAsync(string userId)
        {
            return await _context
                .Rooms.IncludeRoomDetails()
                .Where(RoomExpressions.IsExpired)
                .Where(room =>
                    room.RoomParticipants.Any(participant =>
                        participant.UserId == userId && participant.RoomParticipantEvents.Any()
                    )
                )
                .OrderByDescending(r => r.ScheduledAt)
                .ToListAsync();
        }

        public async Task<int> GetTotalRoomsHistorysAsync(string userId)
        {
            var filteredQuery = _context
                .Rooms.Where(RoomExpressions.IsExpired)
                .Where(room =>
                    room.RoomParticipants.Any(participant =>
                        participant.UserId == userId && participant.RoomParticipantEvents.Any()
                    )
                );

            var count = filteredQuery.Count();

            return await Task.FromResult(count);
        }

        public async Task<Room> MarkRoomAsFinished(Room existingRoom)
        {
            existingRoom.FinishedAt = DateTime.UtcNow;
            _context.Rooms.Update(existingRoom);

            await _context.SaveChangesAsync();
            return existingRoom;
        }
    }
}
