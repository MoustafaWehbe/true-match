using api.Models;

namespace api.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }

        public required string SenderId { get; set; }
        public User? Sender { get; set; }

        public required string ReceiverId { get; set; }
        public User? Receiver { get; set; }

        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public MessageStatus Status { get; set; } = MessageStatus.Sent;
    }
}