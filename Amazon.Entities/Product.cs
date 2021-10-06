using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Entities
{
    public class Product :BaseEntity
    {
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }

     
    }
}
