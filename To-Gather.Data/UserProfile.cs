using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Data
{
    public class UserProfile
    {
        [Key]
        public int ProfileId { get; set; }
        
        [Required]
        public Guid OwnerId { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        public string Email { get; set; }

        [Display(Name ="User Created")]
        public DateTimeOffset CreatedUser { get; set; }

        public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();
        // public List<UserEvent> UserEvents { get; set; }
    }
}
