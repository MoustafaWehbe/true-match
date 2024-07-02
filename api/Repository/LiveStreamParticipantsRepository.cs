using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class LiveStreamParticipantsRepository : ILiveStreamParticipantsRepository
    {
        private readonly ApplicationDBContext _context;
        public LiveStreamParticipantsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<LiveStreamParticipant>> GetAllAsync()
        {
            return await _context.LiveStreamParticipants.ToListAsync();
        }

    }
}