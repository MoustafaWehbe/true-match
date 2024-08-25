using api.Data;
using api.Dtos;
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

        public async Task<RoomParticipant?> joinRoomAsync(User user, CreateRoomParticipantDto createRoomParticipantDto)
        {
            var roomParticipants = await GetRoomParticipantsAsync(user);

            if (roomParticipants.Any(rp => rp.RoomId == createRoomParticipantDto.RoomId))
            {
                var alreadyParticipatedRoom = roomParticipants.Where(rp => rp.RoomId == createRoomParticipantDto.RoomId).FirstOrDefault();
                if (alreadyParticipatedRoom != null)
                {
                    alreadyParticipatedRoom.IsInterested = true;
                    alreadyParticipatedRoom.Attended = true;
                    alreadyParticipatedRoom.AttendedFromTime = DateTime.UtcNow;
                    alreadyParticipatedRoom.SocketId = createRoomParticipantDto.SocketId;
                    await _context.SaveChangesAsync();
                }
                return alreadyParticipatedRoom;
            }
            else
            {
                var newRoomParticipant = new RoomParticipant
                {
                    RoomId = createRoomParticipantDto.RoomId,
                    UserId = user.Id,
                    IsInterested = true,
                    Attended = true,
                    AttendedFromTime = DateTime.UtcNow,
                    SocketId = createRoomParticipantDto.SocketId

                };
                await _context.RoomParticipants.AddAsync(newRoomParticipant);
                await _context.SaveChangesAsync();
                return newRoomParticipant;
            }
        }

        public async Task<RoomParticipant?> UpdateRoomParticipantAsync(RoomParticipant existingRoomParticipant, UpdateRoomParticipantDto updateDto)
        {
            existingRoomParticipant.IsInterested = updateDto.IsInterested;
            existingRoomParticipant.AttendedFromTime = updateDto.AttendedFromTime;
            existingRoomParticipant.AttendedToTime = updateDto.AttendedToTime;

            await _context.SaveChangesAsync();

            return existingRoomParticipant;
        }

        public async Task LeaveRoomAsync(int roomId, string userId)
        {
            var participant = await _context.RoomParticipants
                .Where(rp => rp.RoomId == roomId && rp.UserId == userId && rp.AttendedToTime == null)
                .OrderByDescending(rp => rp.AttendedFromTime)
                .FirstOrDefaultAsync();

            if (participant != null)
            {
                participant.AttendedToTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}