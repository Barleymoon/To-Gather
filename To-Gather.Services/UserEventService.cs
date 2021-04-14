using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.EventModels;
using To_Gather.Models.UserEventModels;

namespace To_Gather.Services
{
    public class UserEventService
    {
        public Guid _userId;

        public UserEventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUserEvent(UserEventCreate model)
        {
            var entity =
                new UserEvent()
                {
                    EventId = model.EventId,
                    ProfileId = model.ProfileId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserEvents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserEventListItem> GetAllUsersEvent()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserEvents
                        .Select(
                        ue =>
                            new UserEventListItem
                            {
                                UserEventId = ue.UserEventId,
                                EventId = ue.EventId,
                                Event = new EventListItem
                                {
                                    Title = ue.Event.Title,
                                    Description = ue.Event.Description,
                                    EventTime = ue.Event.EventTime,
                                    IsOfAge = ue.Event.IsOfAge
                                },
                                ProfileId = ue.ProfileId,
                                Profile = new Models.UserProfileModels.UserProfileListItem
                                {
                                    FirstName = ue.UserProfile.FirstName,
                                    LastName = ue.UserProfile.LastName,
                                    ProfileId = ue.UserProfile.ProfileId
                                }
                            });
                return query.ToArray();
            }
        }
    }
}
