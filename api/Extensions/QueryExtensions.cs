using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<Room> FindAllRoomByStatus(this IQueryable<Room> query, AllRoomStatus? roomStatus, string userId)
        {
            switch (roomStatus)
            {
                case AllRoomStatus.InProgress:
                    return query.Where(r => r.IsInProgress(userId));
                case AllRoomStatus.Coming:
                    return query.Where(r => r.StartedAt == null);
                case AllRoomStatus.InterestedIn:
                    return query.Where(r => r.StartedAt == null && r.RoomParticipants.Any(rp => rp.UserId == userId));
                default:
                    return query;
            }
        }

        public static IQueryable<Room> FindMyRoomByStatus(this IQueryable<Room> query, MyRoomStatus? roomStatus, string userId)
        {
            switch (roomStatus)
            {
                case MyRoomStatus.Coming:
                    return query.Where(r => r.StartedAt == null);
                case MyRoomStatus.Archived:
                    return query.AsEnumerable().Where(r => r.IsArchived(userId)).AsQueryable();
                default:
                    return query;
            }
        }

        public static IQueryable<Room> FindNotDeleted(this IQueryable<Room> query)
        {
            return query.Where(r => !r.IsDeleted);
        }

        public static IQueryable<Room> IncludeRoomDetails(this IQueryable<Room> query)
        {
            return query.Include(ls => ls.User)
                .Include(ls => ls.RoomParticipants);
        }
    }
}
