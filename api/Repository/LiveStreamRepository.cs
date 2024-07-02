using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class LiveStreamRepository : ILiveStreamRepository
    {
        private readonly ApplicationDBContext _context;
        public LiveStreamRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<LiveStream> CreateAsync(LiveStream liveStream)
        {
            _context.LiveStreams.Add(liveStream);
            await _context.SaveChangesAsync();
            return liveStream;
        }

        public async Task<List<LiveStream>> GetAllAsync()
        {
            return await _context.LiveStreams.ToListAsync();
        }

        public async Task<LiveStream?> GetByIdAsync(int id)
        {
            return await _context.LiveStreams.Include(a => a.User).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}