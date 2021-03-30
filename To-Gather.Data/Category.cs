using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Description cannot be over 100 characters")]
        public string Description { get; set; }
    }
}
