using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazon.Web.Models.viewModels
{
    public class ProductSearchViewModels
    {

        public int pageNumber { get; set; }
        public string searchKeyword { get; set; }
        public List<Product> productList { get; set; }


    }
}