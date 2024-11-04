
using api.Models;

namespace api.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> SaveMessageAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesByConversationAsync(string senderId, string receiverId);
        Task UpdateMessageStatusAsync(int messageId, MessageStatus status);
    }
}
