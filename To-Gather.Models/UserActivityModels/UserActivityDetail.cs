﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.UserActivityModels
{
    public class UserActivityDetail
    {
        public int UserActivityId { get; set; }
        public string Title { get; set; }
        public IEnumerable<ActivityDisplay> Activities { get; set; }
        public List<int> ActivityIds { get; set; }
    }
}