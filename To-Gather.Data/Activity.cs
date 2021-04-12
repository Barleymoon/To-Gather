using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Data
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        public Guid OwnerId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(150, ErrorMessage ="Please keep description under 150 characters.")]
        public string Description { get; set; }
        
        [Required]
        public string Equipment { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<UsersActivity> UsersActivities { get; set; } = new List<UsersActivity>();
    }
}
