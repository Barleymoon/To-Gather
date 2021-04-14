using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Gather.Models.CategoryModels
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(3, ErrorMessage ="Title must be more than 3 characters.")]
        public string Title { get; set; }
        [MaxLength(150, ErrorMessage ="Description can not be more than 150 characters.")]
        public string Description { get; set; }
    }
}
