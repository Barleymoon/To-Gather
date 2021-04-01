using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.ActivityModels;

namespace To_Gather.Services
{
    public class ActivityService
    {
        private readonly Guid _userId;

        public ActivityService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateActivity(ActivityCreate model)
        {
            var entity =
                new Activity()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    Equipment = model.Equipment,
                    CategoryId = model.CatgoryId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Activities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ActivityListItem> GetAllActivities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Activities
                        .Where(a => a.OwnerId == _userId)
                        .Select(
                            a =>
                                new ActivityListItem
                                {
                                    ActivityId = a.ActivityId,
                                    Title = a.Title,
                                    Description = a.Description,
                                    Equipment = a.Equipment,
                                    CategoryId = a.CategoryId
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
