using System.Linq.Expressions;
using api.Models;

namespace api.Expressions
{
    public static class GenderFilter
    {
        public static Expression<Func<UserProfile, bool>> MatchesPreferencesFilter(UserProfile currentUserProfile)
        {
            if (currentUserProfile.UserProfileGenderPreferences == null)
            {
                throw new Exception("The user profile is incomplete. Please complete your profile.");
            }

            var currentUserGenders = currentUserProfile.UserProfileGenders.Select(g => g.GenderId).ToList();
            var currentUserPreferences = currentUserProfile.UserProfileGenderPreferences;

            return userProfile => userProfile != null &&
                (!currentUserProfile.AgeFilterMin.HasValue ||
                userProfile.BirthDate.HasValue &&
                (DateTime.UtcNow.Year - userProfile.BirthDate.Value.Year) >= currentUserProfile.AgeFilterMin.Value) &&
                (!currentUserProfile.AgeFilterMax.HasValue ||
                userProfile.BirthDate.HasValue &&
                (DateTime.UtcNow.Year - userProfile.BirthDate.Value.Year) <= currentUserProfile.AgeFilterMax.Value) &&
                userProfile.UserProfileGenders.Any(ug => currentUserPreferences.Contains(ug.GenderId)) &&
                userProfile.UserProfileGenderPreferences != null &&
                userProfile.UserProfileGenderPreferences.Any(up => currentUserGenders.Contains(up)) &&
                userProfile.pos != null &&
                currentUserProfile.pos != null &&
                (!currentUserProfile.DistanceFilter.HasValue ||
                userProfile.pos.Distance(currentUserProfile.pos) <= currentUserProfile.DistanceFilter.Value * 1000);
        }
    }

}