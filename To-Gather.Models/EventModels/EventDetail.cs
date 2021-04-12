using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.EventModels
{
    public class EventDetail
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name ="Date of Event")]
        public DateTimeOffset EventTime { get; set; }

        [Display(Name = "Must be over 21 to attend")]
        public bool IsOfAge { get; set; }

        public int ActivityId { get; set; }
        public int LocationId { get; set; }
    }
}
