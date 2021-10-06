using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazon.Web.Models.viewModels
{
    public class ProductEditViewModels
    {
        public List<Category> categories { get; set; }
        public Product products { get; set; }


    }
}