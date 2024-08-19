using api.Data;
using api.Dtos;
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

        public async Task<List<Room>> GetAllAsync(RoomQueryObject query)
        {
            return await _context.Rooms
                .Include(ls => ls.User)
                .Include(ls => ls.RoomParticipants)
                .Where(r => query.Status == null ? true : r.Status == query.Status)
                .OrderByDescending(r => r.CreatedAt)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms
                .Include(ls => ls.User)
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

        public async Task<int> GetTotalRoomsAsync(RoomQueryObject query)
        {
            return await _context.Rooms.Where(r => query.Status == null ? true : r.Status == query.Status).CountAsync();
        }

        public async Task<Room> UpdateAsync(int id, UpdateRoomDto roomDto, Room existingRoom)
        {
            existingRoom.Title = roomDto.Title;
            existingRoom.Description = roomDto.Description;
            existingRoom.ScheduledAt = roomDto.ScheduledAt;
            existingRoom.FinishedAt = roomDto.FinishedAt;
            existingRoom.Status = roomDto.Status;
            existingRoom.UpdatedAt = DateTime.UtcNow;
            existingRoom.Offers = roomDto.Offers;
            existingRoom.QuestionsCategories = roomDto.QuestionsCategories;

            await _context.SaveChangesAsync();

            return existingRoom;
        }
    }
}