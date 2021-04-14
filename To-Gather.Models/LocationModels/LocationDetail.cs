using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.LocationModels
{
    public class LocationDetail
    {
        public int LocationId { get; set; }

        [Display(Name = "Location Title")]
        public string Title { get; set; }
        [Display(Name = "Address")]

        public string StreetAddress { get; set; }

        [MaxLength(100, ErrorMessage = "Description must be under 100 characters.")]
        public string Description { get; set; }

        [Display(Name = "Weather")]
        public string Weather { get; set; }
        public string Terrain { get; set; }
    }
}
