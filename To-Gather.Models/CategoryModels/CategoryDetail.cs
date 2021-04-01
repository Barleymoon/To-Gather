using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;

namespace To_Gather.Models.CategoryModels
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Activity> CategoryActivities { get; set; }
    }
}
