using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class LiveStreamContentRepository : ILiveStreamContentRepository
    {
        private readonly ApplicationDBContext _context;
        public LiveStreamContentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<LiveStreamContent>> GetAllAsync()
        {
            return await _context.LiveStreamContent.ToListAsync();
        }

    }
}