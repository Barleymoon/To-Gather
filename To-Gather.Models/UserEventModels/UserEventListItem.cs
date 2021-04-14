using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Models.EventModels;
using To_Gather.Models.UserProfileModels;

namespace To_Gather.Models.UserEventModels
{
    public class UserEventListItem
    {
        public int UserEventId { get; set; }

        public int EventId { get; set; }
        public EventListItem Event { get; set; }

        public int ProfileId { get; set; }
        public UserProfileListItem Profile { get; set; }
    }
}
