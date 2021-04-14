using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.UsersActivityModels
{
    public class UsersActivityCreate
    {
        [Required]
        public int ActivityId { get; set; }

        [Required]
        public int ProfileId { get; set; }
    }
}
