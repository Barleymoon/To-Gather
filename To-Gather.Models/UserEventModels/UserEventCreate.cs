﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.UserEventModels
{
    public class UserEventCreate
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public int ProfileId { get; set; }
    }
}
