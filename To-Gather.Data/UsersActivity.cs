using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Data
{
    public class UsersActivity
    {
        [Key]
        public int UsersActivityId { get; set; }
        public Guid OwnerId { get; set; }


        [ForeignKey(nameof(Activity))]
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }


        [ForeignKey(nameof(UserProfile))]
        public int ProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
