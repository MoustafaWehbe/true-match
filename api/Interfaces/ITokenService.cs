using api.Models;

namespace api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}