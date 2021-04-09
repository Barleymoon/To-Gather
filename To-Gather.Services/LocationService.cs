using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.LocationModels;

namespace To_Gather.Services
{
    public class LocationService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            UserProfile userProfile = _db.UserProfiles.Single(up => up.OwnerId == _userId);
            Location location = new Location()
            {
                OwnerId = _userId,
                Title = model.Title,
                Description = model.Description,
                StreetAddress = model.StreetAddress,
                // TimeZone = model.TimeZone,
                Terrain = model.Terrain,
                Weather = model.Weather
            };

            _db.Locations.Add(location);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            IEnumerable<LocationListItem> location = _db.Locations.Select(l => new LocationListItem
            {
                LocationId = l.LocationId,
                Title = l.Title,
                StreetAddress = l.StreetAddress,
                Description = l.Description
            });
            return location;
        }

        public LocationDetail GetLocationById(int id)
        {
            Location location = _db.Locations.Single(l => l.LocationId == id);
            LocationDetail locationDetail = new LocationDetail()
            {
                LocationId = location.LocationId,
                Title = location.Title,
                StreetAddress = location.StreetAddress,
                Description = location.Description,
                Terrain = location.Terrain,
                Weather = location.Weather
            };
            return locationDetail;
        }

        public bool UpdateLocation(LocationEdit model)
        {
            Location editLocation = _db.Locations.Single(l => l.LocationId == model.LocationId);
            editLocation.LocationId = model.LocationId;
            editLocation.StreetAddress = model.StreetAddress;
            editLocation.Title = model.Title;
            editLocation.Description = model.Description;
            editLocation.Terrain = model.Terrain;
            editLocation.Weather = model.Weather;

            return _db.SaveChanges() > 0;
        }

        /*public bool DeleteLocation(int id)
        {
            Location deleteLocation = _db.Locations.Single(l => l.LocationId == id);
            _db.Locations.Remove(deleteLocation);
            return _db.SaveChanges() == 1;
        }*/
    }
}
