using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazon.Web.Models.viewModels
{
    public class CategorySearchViewModels
    {

      
        public string searchKeyword { get; set; }
        public List<Category> categoryList { get; set; }


    }
}