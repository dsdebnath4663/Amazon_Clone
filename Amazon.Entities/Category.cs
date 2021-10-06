using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Entities
{
    public class Category :BaseEntity
    {
       /* public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }*/

        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
        public bool isfeatured { get; set; }
    }
}
