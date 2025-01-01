using api.Models;

namespace api.Dtos
{
    public class CreateMatchDto
    {
        public required string User2Id { get; set; }
        public Guid? RoomId { get; set; }
        public MatchOrigin Origin { get; set; }
    }
}
