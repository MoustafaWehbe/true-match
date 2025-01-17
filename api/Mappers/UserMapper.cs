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
                Id = userModel.Id,
                Media = userModel.Media.Select(m => m.ToMediaDto()).ToList(),
                UserProfile = userModel.UserProfile?.ToUserProfileDto(),
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };
        }

        public static UserSimplifiedDto ToUserSimplifiedDto(this User userModel)
        {
            return new UserSimplifiedDto
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };
        }
    }
}
