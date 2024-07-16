using api.Data;
using api.Dtos;
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
            return await _context.LiveStreams
                .Include(ls => ls.User)
                .Include(ls => ls.LiveStreamParticipants)
                .ToListAsync();
        }

        public async Task<LiveStream?> GetByIdAsync(int id)
        {
            return await _context.LiveStreams
                .Include(ls => ls.User)
                .Include(ls => ls.LiveStreamParticipants)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<LiveStream?> UpdateAsync(int id, UpdateLiveStreamDto liveStreamDto)
        {
            var existingLiveStream = await _context.LiveStreams.FirstOrDefaultAsync(x => x.Id == id);

            if (existingLiveStream == null)
            {
                return null;
            }

            existingLiveStream.Title = liveStreamDto.Title;
            existingLiveStream.Description = liveStreamDto.Description;
            existingLiveStream.ScheduledAt = liveStreamDto.ScheduledAt;
            existingLiveStream.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingLiveStream;
        }
    }
}