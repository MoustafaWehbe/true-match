using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task<Room> CreateAsync(Room room);
        Task<Room?> GetByIdAsync(int id);
        Task<Room> UpdateAsync(int id, UpdateRoomDto stockDto, Room existingRoom);
    }
}