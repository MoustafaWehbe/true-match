using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class UserProfileGenderMapper
    {
        public static UserProfileGender ToUserProfileGenderFromCreate(this UserProfileGenderDto userProfileGenderModel, int userProfileId)
        {
            return new UserProfileGender
            {
                UserProfileId = userProfileId,
                GenderId = userProfileGenderModel.GenderId,
                isMain = userProfileGenderModel.isMain
            };
        }

        public static UserProfileGenderDto ToUserProfileGenderDto(this UserProfileGender userProfileGenderModel)
        {
            return new UserProfileGenderDto
            {
                GenderId = userProfileGenderModel.GenderId,
                isMain = userProfileGenderModel.isMain,
            };
        }
    }
}