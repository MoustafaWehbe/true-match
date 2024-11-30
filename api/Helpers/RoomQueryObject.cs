using api.Models;

namespace api.Helpers
{
    public abstract class RoomQueryBase
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class AllRoomQueryObject : RoomQueryBase
    {
        public AllRoomStatus? Status { get; set; }
        public RoomsSortBy SortBy { get; set; } = RoomsSortBy.RecentlyCreated;
    }

    public class MyRoomQueryObject : RoomQueryBase
    {
        public MyRoomStatus? Status { get; set; }
    }
}
