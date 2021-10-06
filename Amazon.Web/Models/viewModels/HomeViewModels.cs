using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazon.Web.Models.viewModels
{
    public class HomeViewModels
    {
        public List<Category> Featuredcategories { get; set; }
        public List<Product> Featuredproducts { get; set; }


    }
}