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
    public class UsersActivityService
    {
        // private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly Guid _userId;

        public UsersActivityService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUsersActivity(UsersActivityCreate model)
        {
            var entity =
                new UsersActivity()
                {
                    ActivityId = model.ActivityId,
                    ProfileId = model.ProfileId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.UsersActivities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UsersActivityListItem> GetUsersActivities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UsersActivities
                        .Select(
                        ua =>
                            new UsersActivityListItem
                            {
                                UsersActivityId = ua.UsersActivityId,
                                ActivityId = ua.ActivityId,
                                Activity = new ActivityListItem
                                {
                                    Description = ua.Activity.Description,
                                    Title = ua.Activity.Title,
                                    ActivityId = ua.Activity.ActivityId
                                },
                                ProfileId = ua.ProfileId,
                                Profile = new Models.UserProfileModels.UserProfileListItem
                                {
                                    FirstName = ua.UserProfile.FirstName,
                                    LastName = ua.UserProfile.LastName,
                                    ProfileId = ua.UserProfile.ProfileId
                                }
                            });
                return query.ToArray();
            }
        }
    }
}
