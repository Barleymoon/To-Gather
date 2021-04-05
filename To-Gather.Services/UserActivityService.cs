using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.UserActivityModels;

namespace To_Gather.Services
{
    public class UserActivityService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly Guid _userId;

        public UserActivityService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUserActivity(UserActivityCreate model)
        {
            UserProfile userprofile = _db.UserProfiles.Single(up => up.OwnerId == _userId);
            List<Activity> allActivities = _db.Activities.ToList();

            UserActivity activity = new UserActivity()
            {
                Title = model.Title,
                ActivityIds = model.ActivityIds,
                UsersActivities = allActivities.Where(a => model.ActivityIds.Contains(a.ActivityId)).ToList(),
                ProfileId = userprofile.ProfileId
            };

            _db.UserActivities.Add(activity);
            return _db.SaveChanges() > 0;
        }

        public List<UserActivityDisplay> GetActivitiesByOwner()
        {
            List<UserActivityDisplay> allActivities = _db.UserActivities.Where(ua => ua.OwnerId == _userId)
                .Select(ua => new UserActivityDisplay
                {
                    UserActivityId = ua.UserActivityId,
                    Title = ua.Title,
                    Activities = ua.UsersActivities.Select(ad => new ActivityDisplay
                    {
                        ActivityId = ad.ActivityId,
                        Title = ad.Title
                    }).ToList()
                }).ToList();
            return allActivities;
        }
    }
}
