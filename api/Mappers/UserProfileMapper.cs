using api.Dtos.UserProfile;
using api.Models;

namespace api.Mappers
{
    public static class UserProfileMapper
    {
        public static UserProfileDto ToUserProfileDto(this UserProfile userProfileModel)
        {
            return new UserProfileDto
            {
                Id = userProfileModel.Id,
                Bio = userProfileModel.Bio,
                Height = userProfileModel.Height,
                RelationshipGoal = userProfileModel.RelationshipGoal,
                Education = userProfileModel.Education,
                Zodiac = userProfileModel.Zodiac,
                LoveStyle = userProfileModel.LoveStyle,
                UserProfileInterests = userProfileModel.UserProfileInterests.Select(ui => new UserProfileInterestDto
                {
                    InterestId = ui.InterestId
                }).ToList(),
                UserProfileLifeStyles = userProfileModel.UserProfileLifeStyles.Select(ul => new UserProfileLifeStyleDto
                {
                    LifeStyleId = ul.LifeStyleId
                }).ToList(),
                CreatedAt = userProfileModel.CreatedAt,
                UpdatedAt = userProfileModel.UpdatedAt,
            };
        }

        public static UserProfile ToUserProfileFromCreate(this CreateUserProfileDto userProfileDto, string userId)
        {
            return new UserProfile
            {
                Bio = userProfileDto.Bio,
                Height = userProfileDto.Height,
                RelationshipGoal = userProfileDto.RelationshipGoal,
                Education = userProfileDto.Education,
                Zodiac = userProfileDto.Zodiac,
                LoveStyle = userProfileDto.LoveStyle,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = userId
            };
        }
    }
}