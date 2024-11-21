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

        public async Task<List<RoomParticipant>> GetRoomParticipantsAsync(User user)
        {
            return await _context.RoomParticipants.Where(rp => rp.UserId == user.Id).ToListAsync();
        }

        public async Task<RoomParticipantEvent?> CreateRoomParticipantEventAsync(
            RoomParticipantEvent roomParticipantEvent
        )
        {
            await _context.RoomParticipantEvents.AddAsync(roomParticipantEvent);
            await _context.SaveChangesAsync();
            return roomParticipantEvent;
        }

        public async Task<RoomParticipant?> CreateAsync(RoomParticipant roomParticipant)
        {
            await _context.RoomParticipants.AddAsync(roomParticipant);
            await _context.SaveChangesAsync();
            return roomParticipant;
        }

        public async Task DeleteAsync(Guid roomId, string userId)
        {
            var roomParticipant = await _context
                .RoomParticipants.Where(rp => rp.RoomId == roomId && rp.UserId == userId)
                .FirstOrDefaultAsync();

            if (roomParticipant != null)
            {
                _context.RoomParticipants.Remove(roomParticipant);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("roomParticipant not found.");
            }
        }
    }
}
