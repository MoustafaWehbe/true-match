using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class HideRoomDto
    {
        [Required]
        public int RoomId { get; set; }
    }
}