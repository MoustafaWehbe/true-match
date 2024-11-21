using api.Models;

namespace api.Helpers
{
    public class AllRoomQueryObject
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public AllRoomStatus? Status { get; set; }
    }

    public class MyRoomQueryObject
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public MyRoomStatus? Status { get; set; }
    }
}
