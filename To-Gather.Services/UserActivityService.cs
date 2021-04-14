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

            UserActivity userActivity = new UserActivity()
            {
                OwnerId = _userId,
                Title = model.Title,
                ActivityIds = model.ActivityIds,
                UsersActivities = allActivities.Where(a => model.ActivityIds.Contains(a.ActivityId)).ToList(),
                ProfileId = userprofile.ProfileId
            };

            _db.UserActivities.Add(userActivity);
            return _db.SaveChanges() > 0;
        }

        public List<UserActivityListItem> GetAllUserActivities()
        {
            List<UserActivityListItem> allActivities = _db.UserActivities.Select(a => new UserActivityListItem
            {
                UserActivityId = a.UserActivityId,
                Title = a.Title,
                Activities = a.UsersActivities.Select(ua => new ActivityDisplay
                {
                    ActivityId = ua.ActivityId,
                    Title = ua.Title
                }).ToList()
            }).ToList();
            return allActivities;
        }

        public UserActivityDetail GetUserActivityById(int id)
        {
            UserActivity activityToGet = _db.UserActivities.Single(ua => ua.UserActivityId == id);
            UserActivityDetail activityDetail = new UserActivityDetail
            {
                UserActivityId = activityToGet.UserActivityId,
                Title = activityToGet.Title,
                // ActivityIds = activityToGet.ActivityIds,
                Activities = activityToGet.UsersActivities.Select(a => new ActivityDisplay
                {
                    ActivityId = a.ActivityId,
                    Title = a.Title
                }).ToList()
            };
            return activityDetail;
        }

        public bool UpdateUserActivity(UserActivityEdit model)
        {
            UserActivity editActivity = _db.UserActivities.Single(ua => ua.UserActivityId == model.UserActivityId);
            editActivity.Title = model.Title;
            editActivity.ActivityIds = model.ActivityIds;
            editActivity.UsersActivities = _db.Activities.Where(ua => model.ActivityIds.Contains(ua.ActivityId)).ToList();

            List<Activity> activityRemove = _db.Activities.Where(ua => !model.ActivityIds.Contains(ua.ActivityId)).ToList();
            foreach (Activity activity in activityRemove)
            {
                editActivity.UsersActivities.Remove(activity);
            }

            return _db.SaveChanges() == 1;
        }

        public bool DeleteUserActivity(int id)
        {
            UserActivity deleteActivity = _db.UserActivities.Single(ua => ua.UserActivityId == id);
            _db.UserActivities.Remove(deleteActivity);
            return _db.SaveChanges() > 0;
        }
    }
}
