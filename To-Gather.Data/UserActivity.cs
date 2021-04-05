using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Data
{
    public class UserActivity
    {
        public int UserActivityId { get; set; }
        public string Title { get; set; }
        public Guid OwnerId { get; set; }


        [ForeignKey(nameof(Activity))]
        public List<int> ActivityIds { get; set; }
        public virtual List<Activity> UsersActivities { get; set; }


        [ForeignKey(nameof(UserProfile))]
        public int ProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
