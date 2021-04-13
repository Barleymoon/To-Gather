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
                EventTime = DateTime.Now,
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

        public EventDetail GetEventById(int id)
        {
            Event getEvent = _db.Events.Single(e => e.EventId == id);
            EventDetail detailEvent = new EventDetail
            {
                EventId = getEvent.EventId,
                Title = getEvent.Title,
                Description = getEvent.Description,
                EventTime = getEvent.EventTime,
                IsOfAge = getEvent.IsOfAge,
                ActivityId = getEvent.ActivityId,
                LocationId = getEvent.LocationId
            };
            return detailEvent;
        }

        public bool UpdateEvent(EventEdit model)
        {
            Event editEvent = _db.Events.Single(e => e.EventId == model.EventId);
            editEvent.Title = model.Title;
            editEvent.Description = model.Description;
            editEvent.EventTime = model.EventTime;
            editEvent.IsOfAge = model.IsOfAge;
            editEvent.ActivityId = model.ActivityId;
            editEvent.LocationId = model.LocationId;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteEvent(int id)
        {
            Event deleteEvent = _db.Events.Single(e => e.EventId == id);
            _db.Events.Remove(deleteEvent);
            return _db.SaveChanges() > 0;
        }

        public bool JoinUserEvent(UserEventCreate model)
        {
            UserProfile userProfile = _db.UserProfiles.Single(up => up.OwnerId == _userId);

            UserEvent userEvent = new UserEvent()
            {
                EventId = model.EventId,
                ProfileId = model.ProfileId
            };

            _db.UserEvents.Add(userEvent);
            return _db.SaveChanges() == 1;
        }
    }
}
