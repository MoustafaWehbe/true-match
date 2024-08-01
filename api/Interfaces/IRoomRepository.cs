using api.Dtos;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync(RoomQueryObject query);
        Task<Room> CreateAsync(Room room);
        Task<Room?> GetByIdAsync(int id);
        Task<Room> UpdateAsync(int id, UpdateRoomDto stockDto, Room existingRoom);
        Task<int> GetTotalRoomsAsync(RoomQueryObject query);
        int GetTotalPages(int pageSize, int totalRooms);
    }
}