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

        public async Task<RoomParticipant?> joinRoomAsync(User user, int roomId)
        {
            var roomParticipants = await GetRoomParticipantsAsync(user);

            if (roomParticipants.Any(rp => rp.RoomId == roomId))
            {
                var alreadyParticipatedRoom = roomParticipants.Where(rp => rp.RoomId == roomId).FirstOrDefault();
                if (alreadyParticipatedRoom != null)
                {
                    alreadyParticipatedRoom.IsInterested = true;
                    alreadyParticipatedRoom.Attended = true;
                    alreadyParticipatedRoom.AttendedFromTime = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
                return alreadyParticipatedRoom;
            }
            else
            {
                var newRoomParticipant = new RoomParticipant
                {
                    RoomId = roomId,
                    UserId = user.Id,
                    IsInterested = true,
                    Attended = true,
                    AttendedFromTime = DateTime.UtcNow,

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
    }
}