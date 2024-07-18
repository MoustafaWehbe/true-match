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
                Rooms = userModel.Rooms,
                Media = userModel.Media,
                UserProfile = userModel.UserProfile,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };
        }

        public static UserSimplifiedDto ToUserSimplifiedDto(this User userModel)
        {
            return new UserSimplifiedDto
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };
        }
    }
}