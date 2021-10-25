using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Entities
{
    public class BaseEntity

    {
        public int ID { get; set; }
       
        [Required]
        [MinLength(5),MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

    }
}   
