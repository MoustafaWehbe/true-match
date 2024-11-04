using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDBContext _context;

        public MessageRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Message> SaveMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<IEnumerable<Message>> GetMessagesByConversationAsync(string senderId, string receiverId)
        {
            return await _context.Messages
                .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == senderId))
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task UpdateMessageStatusAsync(int messageId, MessageStatus status)
        {
            var message = await _context.Messages.FindAsync(messageId);
            if (message != null)
            {
                message.Status = status;
                await _context.SaveChangesAsync();
            }
        }
    }
}
