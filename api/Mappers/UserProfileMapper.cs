using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class UserProfileMapper
    {
        public static UserProfileDto ToUserProfileDto(this UserProfile userProfileModel)
        {
            return new UserProfileDto
            {
                Bio = userProfileModel.Bio,
                AgeFilterMax = userProfileModel.AgeFilterMax,
                AgeFilterMin = userProfileModel.AgeFilterMin,
                DistanceFilter = userProfileModel.DistanceFilter,
                pos = userProfileModel.pos,
                Location = userProfileModel.Location,
                Job = userProfileModel.Job,
                School = userProfileModel.School,
                BirthDate = userProfileModel.BirthDate,
                SelectedDescriptors = userProfileModel.SelectedDescriptors,
                UserProfileGenders = userProfileModel.UserProfileGenders
                    .Select(ul => ul.ToUserProfileGenderDto()).ToList(),
            };
        }

        public static UserProfile ToUserProfileFromCreate(this CreateOrUpdateUserProfileDto userProfileDto, string userId)
        {
            return new UserProfile
            {
                Bio = userProfileDto.Bio,
                AgeFilterMax = userProfileDto.AgeFilterMax,
                AgeFilterMin = userProfileDto.AgeFilterMin,
                DistanceFilter = userProfileDto.DistanceFilter,
                pos = userProfileDto.pos,
                Location = userProfileDto.Location,
                Job = userProfileDto.Job,
                School = userProfileDto.School,
                BirthDate = userProfileDto.BirthDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = userId,
                SelectedDescriptors = userProfileDto.SelectedDescriptors,
            };
        }

        public static UserProfile ToUserProfileFromUpdate(this CreateOrUpdateUserProfileDto userProfileDto, UserProfile exisitingUserProfile, string userId)
        {
            return new UserProfile
            {
                Id = exisitingUserProfile.Id,
                Bio = userProfileDto.Bio ?? exisitingUserProfile.Bio,
                AgeFilterMax = userProfileDto.AgeFilterMax ?? exisitingUserProfile.AgeFilterMax,
                AgeFilterMin = userProfileDto.AgeFilterMin ?? exisitingUserProfile.AgeFilterMin,
                DistanceFilter = userProfileDto.DistanceFilter ?? exisitingUserProfile.DistanceFilter,
                pos = userProfileDto.pos ?? exisitingUserProfile.pos,
                Location = userProfileDto.Location ?? exisitingUserProfile.Location,
                Job = userProfileDto.Job ?? exisitingUserProfile.Job,
                School = userProfileDto.School ?? exisitingUserProfile.School,
                BirthDate = userProfileDto.BirthDate ?? exisitingUserProfile.BirthDate,
                UpdatedAt = DateTime.UtcNow,
                UserId = userId,
                SelectedDescriptors = userProfileDto.SelectedDescriptors ?? exisitingUserProfile.SelectedDescriptors,
            };
        }
    }
}