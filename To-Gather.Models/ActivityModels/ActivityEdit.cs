using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.ActivityModels
{
    public class ActivityEdit
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Equipment { get; set; }
        public int CategoryId { get; set; }
    }
}
