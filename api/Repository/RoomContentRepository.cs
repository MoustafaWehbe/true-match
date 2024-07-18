using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RoomContentRepository : IRoomContentRepository
    {
        private readonly ApplicationDBContext _context;
        public RoomContentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<RoomContent>> GetAllAsync()
        {
            return await _context.RoomContent.ToListAsync();
        }

    }
}