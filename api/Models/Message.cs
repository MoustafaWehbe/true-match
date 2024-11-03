using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        [ForeignKey("Sender")]
        public required string SenderId { get; set; }
        public required User Sender { get; set; }

        [ForeignKey("Receiver")]
        public required string ReceiverId { get; set; }
        public required User Receiver { get; set; }

        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        public required string Status { get; set; }
    }
}
