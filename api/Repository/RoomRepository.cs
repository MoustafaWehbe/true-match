using api.Data;
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

        public async Task<List<Room>> GetAllAsync(AllRoomQueryObject query, string userId)
        {
            return await _context.Rooms
                .IncludeRoomDetails()
                .FindAllRoomByStatus(query.Status, userId)
                .FindNotDeleted()
                .OrderByDescending(r => r.CreatedAt)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }

        public async Task<List<Room>> GetMyRoomsAsync(MyRoomQueryObject query, string userId)
        {
            return await _context.Rooms
                .IncludeRoomDetails()
                .Where(r => r.UserId == userId)
                .FindMyRoomByStatus(query.Status, userId)
                .FindNotDeleted()
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

        public async Task<int> GetTotalRoomsAsync(AllRoomQueryObject query, string userId)
        {
            return await _context.Rooms
                .FindNotDeleted()
                .FindAllRoomByStatus(query.Status, userId)
                .CountAsync();
        }

        public async Task<int> GetTotalMyRoomsAsync(MyRoomQueryObject query, string userId)
        {
            return await _context.Rooms
                .FindMyRoomByStatus(query.Status, userId)
                .Where(r => r.UserId == userId)
                .FindNotDeleted()
                .CountAsync();
        }

        public async Task<Room> UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return room;
        }
    }
}