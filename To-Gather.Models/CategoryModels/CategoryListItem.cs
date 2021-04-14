using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.ActivityModels;

namespace To_Gather.Models.CategoryModels
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // public List<ActivityDisplayItem> CategoryActivities { get; set; }
        // public ActivityDisplayItem CategoryActivity { get; set; }
    }
}
