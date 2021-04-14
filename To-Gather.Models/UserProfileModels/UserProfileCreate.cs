using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.UserModels
{
    public class UserProfileCreate
    {
        [Required]
        [Display(Name ="UserName")]
        [MaxLength(20, ErrorMessage ="UserName must be under 20 characters")]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        public string Email { get; set; }

        public List<int> ActivityIds { get; set; }
       /* [Display(Name = "User Created")]
        public DateTimeOffset CreatedUser { get; set; }*/
    }
}
