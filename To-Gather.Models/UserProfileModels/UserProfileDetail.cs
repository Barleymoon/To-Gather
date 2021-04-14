using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.ActivityModels;
using To_Gather.Models.UserEventModels;
using To_Gather.Models.UsersActivityModels;

namespace To_Gather.Models.UserProfileModels
{
    public class UserProfileDetail
    {
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Created User")]
        public DateTimeOffset CreatedUser { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        // public List<int> ActivityIds { get; set; }

        // public List<ActivityDetail> Activities { get; set; }

        public List<UsersActivityListItem> UserActivities { get; set; }
        public List<UserEventListItem> UserEvents { get; set; }
    }
}
