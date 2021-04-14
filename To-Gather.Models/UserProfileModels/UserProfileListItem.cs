using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.UserProfileModels
{
    public class UserProfileListItem
    {
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name ="Created User")]
        public DateTimeOffset CreatedUser { get; set; }
    }
}
