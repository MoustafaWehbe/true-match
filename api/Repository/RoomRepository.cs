using api.Data;
using api.Dtos;
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

        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms
                .Include(ls => ls.User)
                .Include(ls => ls.RoomParticipants)
                .ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms
                .Include(ls => ls.User)
                .Include(ls => ls.RoomParticipants)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Room?> UpdateAsync(int id, UpdateRoomDto roomDto)
        {
            var existingRoom = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRoom == null)
            {
                return null;
            }

            existingRoom.Title = roomDto.Title;
            existingRoom.Description = roomDto.Description;
            existingRoom.ScheduledAt = roomDto.ScheduledAt;
            existingRoom.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return existingRoom;
        }
    }
}