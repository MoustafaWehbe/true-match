using System.Linq.Expressions;
using api.Models;

namespace api.Expressions
{
    public static class RoomExpressions
    {
        public static Expression<Func<Room, bool>> IsExpired =>
            r =>
                r.StartedAt.HasValue
                && r.StartedAt.Value.AddMinutes(RoomConstants.TotalRoundsDuration + 1)
                    <= DateTime.UtcNow;

        public static Expression<Func<Room, bool>> IsInProgress =>
            r =>
                r.StartedAt.HasValue
                && !r.FinishedAt.HasValue
                // logic for !IsExpired
                && r.StartedAt.Value.AddMinutes(RoomConstants.TotalRoundsDuration + 1)
                    > DateTime.UtcNow;

        public static Expression<Func<Room, bool>> IsArchived =>
            r =>
                (r.FinishedAt.HasValue && r.FinishedAt < DateTime.UtcNow)
                ||
                // login for IsExpired
                (
                    r.StartedAt.HasValue
                    && r.StartedAt.Value.AddMinutes(RoomConstants.TotalRoundsDuration + 1)
                        <= DateTime.UtcNow
                );
    }
}
