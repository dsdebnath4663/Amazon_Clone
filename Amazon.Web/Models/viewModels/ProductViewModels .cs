using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazon.Web.Models.viewModels
{
    public class ProductViewModels
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }

    }
}