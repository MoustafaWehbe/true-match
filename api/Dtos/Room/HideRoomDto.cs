using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class HideRoomDto
    {
        [Required]
        public Guid RoomId { get; set; }
    }
}
