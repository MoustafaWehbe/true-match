using api.Models;

namespace api.Dtos
{
    public class CreateMessageDto
    {
        public required string SenderId { get; set; }
        public required string ReceiverId { get; set; }
        public required string Content { get; set; }
    }
}