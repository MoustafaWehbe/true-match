using api.Dtos;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync(
            AllRoomQueryObject query,
            UserProfile userProfile,
            List<string> blockedUsersIds,
            List<Guid> hiddenRoomsIds
        );
        Task<List<Room>> GetMyRoomsAsync(MyRoomQueryObject query, string userId);
        Task<Room> CreateAsync(Room room);
        Task<Room?> GetByIdAsync(Guid id);
        Task<Room> UpdateAsync(Room room, UpdateRoomDto? roomDto = null);
        Task<int> GetTotalRoomsAsync(
            AllRoomQueryObject query,
            UserProfile userProfile,
            List<string> blockedUsersIds,
            List<Guid> hiddenRoomsIds
        );
        Task<int> GetTotalMyRoomsAsync(MyRoomQueryObject query, string userId);
        int GetTotalPages(int pageSize, int totalRooms);
        Task<HideRoomDto> HideRoom(HideRoomDto hideRoomDto, User user);
        Task<List<HiddenRoom>> RoomsIHid(string userId);
    }
}
