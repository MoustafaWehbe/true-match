using api.Models;

namespace api.Helpers
{
    public class RoomQueryObject
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public RoomStatus? Status { get; set; }
    }
}