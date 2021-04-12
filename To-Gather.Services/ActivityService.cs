using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.ActivityModels;
using To_Gather.Models.UsersActivityModels;

namespace To_Gather.Services
{
    public class ActivityService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly Guid _userId;

        public ActivityService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateActivity(ActivityCreate model)
        {
            UserProfile userProfile = _db.UserProfiles.Single(up => up.OwnerId == _userId);

            Activity activity = new Activity()
            {
                OwnerId = _userId,
                Title = model.Title,
                Description = model.Description,
                Equipment = model.Equipment,
                CategoryId = model.CategoryId
            };
            _db.Activities.Add(activity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<ActivityListItem> GetAllActivities()
        {
            List<ActivityListItem> activities = _db.Activities.Select(a => new ActivityListItem
            {
                ActivityId = a.ActivityId,
                Title = a.Title,
                Description = a.Description,
                Equipment = a.Equipment,
                CategoryId = a.CategoryId
            }).ToList();
            return activities;
        }

        public ActivityDetail GetActivityById(int id)
        {
            Activity getActivity = _db.Activities.Single(a => a.ActivityId == id);
            ActivityDetail detail = new ActivityDetail()
            {
                ActivityId = getActivity.ActivityId,
                Title = getActivity.Title,
                Description = getActivity.Description,
                Equipment = getActivity.Equipment,
                CategoryId = getActivity.CategoryId
            };
            return detail;
        }

        public bool UpdateActivity(ActivityEdit model)
        {
            Activity editActivity = _db.Activities.Single(a => a.ActivityId == model.ActivityId);
            editActivity.ActivityId = model.ActivityId;
            editActivity.Title = model.Title;
            editActivity.Description = model.Description;
            editActivity.Equipment = model.Equipment;
            editActivity.CategoryId = model.CategoryId;

            return _db.SaveChanges() > 0;
        }


        public bool DeleteActivity(int id)
        {
            Activity deleteActivity = _db.Activities.Single(a => a.ActivityId == id);
            _db.Activities.Remove(deleteActivity);
            return _db.SaveChanges() == 1;
        }

        public bool JoinActivityToUsersActivity(UsersActivityCreate model)
        {
            UserProfile userProfile = _db.UserProfiles.Single(up => up.OwnerId == _userId);

            UsersActivity usersActivity = new UsersActivity()
            {
                ActivityId = model.ActivityId,
                ProfileId = model.ProfileId
            };
            _db.UsersActivities.Add(usersActivity);
            return _db.SaveChanges() == 1;
        }
    }
}
