using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
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
            UserProfile userProfile = new UserProfile()
            {
                OwnerId = _userId,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Email = model.Email
            };
            _db.UserProfiles.Add(userProfile);
            return _db.SaveChanges() > 0;
        }

        public List<UserProfileListItem> GetProfile()
        {
            List<UserProfileListItem> profile = _db.UserProfiles.Select(up => new UserProfileListItem
            {
                ProfileId = up.ProfileId,
                UserName = up.UserName,
                LastName = up.LastName,
                FirstName = up.FirstName,
                CreatedUser = up.CreatedUser
            }).ToList();
            return profile;
        }
    }
}
