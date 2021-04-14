using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Data
{
    public class UserEvent
    {
        public int UserEventId { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        
        [ForeignKey(nameof(UserProfile))]
        public int ProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
