using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.UserActivityModels;
using To_Gather.Models.UserModels;
using To_Gather.Models.UserProfileModels;

namespace To_Gather.Services
{
    public class UserProfileService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        private readonly Guid _userId;
        public UserProfileService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserProfileCreate model)
        {
            // List<Activity> allActivities = _db.Activities.ToList();

            UserProfile userProfile = new UserProfile()
            {
                OwnerId = _userId,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Email = model.Email,
                // UserActivities = (ICollection<UserActivity>)allActivities.Where(ua => model.ActivityIds.Contains(ua.ActivityId)).ToList()
            };
            _db.UserProfiles.Add(userProfile);
            return _db.SaveChanges() > 0;
        }

        public List<UserProfileListItem> GetProfile()
        {
            List<UserProfileListItem> profile = _db.UserProfiles.
                Select(up => new UserProfileListItem
                {
                    ProfileId = up.ProfileId,
                    UserName = up.UserName,
                    LastName = up.LastName,
                    FirstName = up.FirstName,
                    CreatedUser = up.CreatedUser,
                    UsersActivityDisplay = up.UserActivities.Select(ua => new UserActivityListItem
                    {
                        Title = ua.Title,
                        Activities = ua.UsersActivities.Select(a => new ActivityDisplay
                        {
                            ActivityId = a.ActivityId,
                            Title = a.Title
                        }).ToList()
                    }).ToList(),
                }).ToList();
            return profile;
        }

        public UserProfileDetail GetProfileById(int id)
        {
            UserProfile getProfile = _db.UserProfiles.Single(up => up.ProfileId == id);
            UserProfileDetail profileDetail = new UserProfileDetail()
            {
                ProfileId = getProfile.ProfileId,
                UserName = getProfile.UserName,
                FirstName = getProfile.FirstName,
                LastName = getProfile.LastName,
                Age = getProfile.Age,
                CreatedUser = getProfile.CreatedUser,
                Email = getProfile.Email
            };

            return profileDetail;
        }

        public bool UpdateUserProfile(UserProfileEdit model)
        {
            UserProfile profileToEdit = _db.UserProfiles.Single(up => up.ProfileId == model.ProfileId);
            profileToEdit.ProfileId = model.ProfileId;
            profileToEdit.UserName = model.UserName;
            profileToEdit.FirstName = model.FirstName;
            profileToEdit.LastName = model.LastName;
            profileToEdit.Age = model.Age;

            return _db.SaveChanges() > 0;
        }

        public bool DeleteUser(int id)
        {
            UserProfile deleteProfile = _db.UserProfiles.Single(up => up.ProfileId == id);
            _db.UserProfiles.Remove(deleteProfile);
            return _db.SaveChanges() == 1;
        }
    }
}
