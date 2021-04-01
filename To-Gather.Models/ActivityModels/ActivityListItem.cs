using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.ActivityModels
{
    public class ActivityListItem
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }

        [Display(Name="Activity Description")]
        public string Description { get; set; }
        public string Equipment { get; set; }
        public int CategoryId { get; set; }
    }
}
