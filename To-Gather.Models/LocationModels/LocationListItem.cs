using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.LocationModels
{
    public class LocationListItem
    {
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Location Title")]
        public string Title { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Description must be under 100 characters.")]
        public string Description { get; set; }
    }
}
