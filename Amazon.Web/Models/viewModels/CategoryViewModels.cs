using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amazon.Web.Models.viewModels
{
    public class CategoryViewModels
    {
        [Required]
        [MinLength(5), MaxLength(60)]
        public string Name { get; set; }

        [ MaxLength(500)]
        public string Description { get; set; }
       
        public string ImageUrl { get; set; }

        public bool isfeatured { get; set; }

    }
}