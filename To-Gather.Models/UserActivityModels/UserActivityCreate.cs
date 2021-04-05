using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.UserActivityModels
{
    public class UserActivityCreate
    {
        public string Title { get; set; }
        public List<int> ActivityIds { get; set; }
    }
}
