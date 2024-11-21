using System.Text.Json;
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
                Id = userProfileModel.Id,
                Bio = userProfileModel.Bio,
                AgeFilterMax = userProfileModel.AgeFilterMax,
                AgeFilterMin = userProfileModel.AgeFilterMin,
                DistanceFilter = userProfileModel.DistanceFilter,
                Hidden = userProfileModel.Hidden,
                pos = userProfileModel.pos,
                Location = userProfileModel.Location != null ? JsonSerializer.Deserialize<UserLocation>(userProfileModel.Location) : null,
                Job = userProfileModel.Job,
                School = userProfileModel.School,
                BirthDate = userProfileModel.BirthDate,
                SelectedDescriptors = userProfileModel.SelectedDescriptors != null ? JsonSerializer.Deserialize<List<SelectedDescriptor>>(userProfileModel.SelectedDescriptors) : null,
                UserProfileGenders = userProfileModel.UserProfileGenders
                    .Select(ul => ul.ToUserProfileGenderDto()).ToList(),
                UserProfileGenderPreferences = userProfileModel.UserProfileGenderPreferences
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
                Hidden = userProfileDto.Hidden ?? false,
                pos = userProfileDto.pos,
                Location = JsonDocument.Parse(JsonSerializer.Serialize(userProfileDto.Location)),
                Job = userProfileDto.Job,
                School = userProfileDto.School,
                BirthDate = userProfileDto.BirthDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = userId,
                SelectedDescriptors = JsonDocument.Parse(JsonSerializer.Serialize(userProfileDto.SelectedDescriptors)),
                UserProfileGenderPreferences = userProfileDto.UserProfileGenderPreferences ?? new List<Guid>()
            };
        }

        public static void ToUserProfileFromUpdate(this CreateOrUpdateUserProfileDto userProfileDto, UserProfile existingUserProfile, string userId)
        {
            existingUserProfile.Bio = userProfileDto.Bio ?? existingUserProfile.Bio;
            existingUserProfile.AgeFilterMax = userProfileDto.AgeFilterMax ?? existingUserProfile.AgeFilterMax;
            existingUserProfile.AgeFilterMin = userProfileDto.AgeFilterMin ?? existingUserProfile.AgeFilterMin;
            existingUserProfile.DistanceFilter = userProfileDto.DistanceFilter ?? existingUserProfile.DistanceFilter;
            existingUserProfile.Hidden = userProfileDto.Hidden.HasValue ? userProfileDto.Hidden.Value : existingUserProfile.Hidden;
            existingUserProfile.pos = userProfileDto.pos ?? existingUserProfile.pos;
            existingUserProfile.Job = userProfileDto.Job ?? existingUserProfile.Job;
            existingUserProfile.School = userProfileDto.School ?? existingUserProfile.School;
            existingUserProfile.BirthDate = userProfileDto.BirthDate ?? existingUserProfile.BirthDate;
            existingUserProfile.UpdatedAt = DateTime.UtcNow;
            existingUserProfile.Location = userProfileDto.Location != null
                ? JsonDocument.Parse(JsonSerializer.Serialize(userProfileDto.Location))
                : existingUserProfile.Location;
            existingUserProfile.SelectedDescriptors = userProfileDto.SelectedDescriptors != null
                ? JsonDocument.Parse(JsonSerializer.Serialize(userProfileDto.SelectedDescriptors))
                : existingUserProfile.SelectedDescriptors;
            existingUserProfile.UserProfileGenders = userProfileDto.UserProfileGenders != null ?
                    userProfileDto.UserProfileGenders.Select(upg => upg.ToUserProfileGenderFromCreate(existingUserProfile.Id)).ToList() :
                    existingUserProfile.UserProfileGenders;
            existingUserProfile.UserProfileGenderPreferences = userProfileDto.UserProfileGenderPreferences ?? existingUserProfile.UserProfileGenderPreferences;
        }
    }
}