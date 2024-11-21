using System.Linq.Expressions;
using api.Models;

namespace api.Expressions
{
    public static class GenderFilter
    {
        public static Expression<Func<UserProfile, bool>> MatchesGenderPreferences(UserProfile currentUserProfile)
        {
            if (currentUserProfile.UserProfileGenderPreferences == null)
            {
                throw new Exception("The user profile is incomplete. Please complete your profile.");
            }

            var currentUserGenders = currentUserProfile.UserProfileGenders.Select(g => g.GenderId).ToList();
            var currentUserPreferences = currentUserProfile.UserProfileGenderPreferences;

            return profile => profile != null &&
                profile.UserProfileGenders.Any(ug => currentUserPreferences.Contains(ug.GenderId)) &&
                profile.UserProfileGenderPreferences.Any(up => currentUserGenders.Contains(up));
        }
    }

}