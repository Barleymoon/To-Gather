using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.LocationModels
{
    public class LocationEdit
    {
        public int LocationId { get; set; }
        public string StreetAddress { get; set; }

        [Display(Name = "Location Title")]
        public string Title { get; set; }

        [MaxLength(100, ErrorMessage = "Description must be under 100 characters.")]
        public string Description { get; set; }

        [Display(Name = "Weather")]
        public string Weather { get; set; }
        public string Terrain { get; set; }
    }
}
