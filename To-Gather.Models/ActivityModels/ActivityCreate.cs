using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.ActivityModels
{
    public class ActivityCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Please keep description under 150 characters.")]
        public string Description { get; set; }

        [Required]
        public string Equipment { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
