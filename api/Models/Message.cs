using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Sender")]
        public required string SenderId { get; set; }
        public User? Sender { get; set; }

        [ForeignKey("Receiver")]
        public required string ReceiverId { get; set; }
        public User? Receiver { get; set; }

        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public MessageStatus Status { get; set; } = MessageStatus.Sent;
    }
}
