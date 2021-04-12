using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Models.ActivityModels;
using To_Gather.Models.UserProfileModels;

namespace To_Gather.Models.UsersActivityModels
{
    public class UsersActivityListItem
    {
        public int UsersActivityId { get; set; }

        public int ActivityId { get; set; }
        public ActivityListItem Activity { get; set; }

        public int ProfileId { get; set; }
        public UserProfileListItem Profile { get; set; }
    }
}
