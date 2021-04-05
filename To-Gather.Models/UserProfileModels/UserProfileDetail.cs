using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<int> ActivityIds { get; set; }

        // public List<UserActivity> UserActivities { get; set; }
        
        // public List<UserEvent> UserEvents { get; set; }
    }
}
