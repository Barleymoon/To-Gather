using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Data
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public Guid OwnerId { get; set; }
        
        [Required]
        [Display(Name = "Location Title")]
        public string Title { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="Description must be under 100 characters.")]
        public string Description { get; set; }

        [Display(Name ="Weather")]
        public string Weather { get; set; }

        /*[Required]
        public TimeZone TimeZone { get; set; }*/
        
        [Required]
        public string Terrain { get; set; }
        // public virutal List<Event> Events { get; set; }
    }
}
