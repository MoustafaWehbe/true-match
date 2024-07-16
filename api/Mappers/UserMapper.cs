using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                LiveStreams = userModel.LiveStreams,
                Media = userModel.Media,
                UserProfile = userModel.UserProfile,
            };
        }
    }
}