using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RoomParticipantsRepository : IRoomParticipantsRepository
    {
        private readonly ApplicationDBContext _context;
        public RoomParticipantsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<RoomParticipant>> GetAllAsync()
        {
            return await _context.RoomParticipants.ToListAsync();
        }

    }
}