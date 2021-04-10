using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.EventModels;

namespace To_Gather.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            UserProfile userProfile = _db.UserProfiles.Single(up => up.OwnerId == _userId);

            Event thisEvent = new Event()
            {
                OwnerId = _userId,
                Title = model.Title,
                Description = model.Description,
                EventTime = DateTimeOffset.Now,
                IsOfAge = model.IsOfAge,
                ActivityId = model.ActivityId,
                LocationId = model.LocationId
            };

            _db.Events.Add(thisEvent);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<EventListItem> GetAllEvents()
        {
            List<EventListItem> allEvents = _db.Events.Select(e => new EventListItem
            {
                EventId = e.EventId,
                Title = e.Title,
                Description = e.Description,
                IsOfAge = e.IsOfAge,
                EventTime = e.EventTime
            }).ToList();
            return allEvents;
        }
    }
}
