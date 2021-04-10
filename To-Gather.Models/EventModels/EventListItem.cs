using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.EventModels
{
    public class EventListItem
    {
        public int EventId { get; set; }
        
        [Required]
        [MaxLength(15, ErrorMessage = "Event Title must be under 15 characters.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Event Description can not be over 200 characters.")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        // [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Event")]
        public DateTimeOffset EventTime { get; set; }

        [Required]
        [Display(Name = "Must be over 21 to attend")]
        public bool IsOfAge { get; set; }

        /*public int ActivityId { get; set; }
        public int LocationId { get; set; }*/
    }
}
