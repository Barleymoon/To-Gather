using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.CategoryModels
{
    public class ActivityDisplayItem
    {
        // public int ActivityId { get; set; }

        [Display(Name ="Activity Title")]
        public string Title { get; set; }

        /*[Display(Name = "Activity Description")]
        public string Description { get; set; }*/
        // public string Equipment { get; set; }
    }
}
