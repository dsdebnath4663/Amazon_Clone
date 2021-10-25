using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Amazon.Web.Models.viewModels.BaseListingViewModel;

namespace Amazon.Web.Models.viewModels
{
    public class CategorySearchViewModels
    {

      
        public string searchKeyword { get; set; }
        public List<Category> categoryList { get; set; }
        public Pager pager  { get; set; }
      //  public object Categories { get; internal set; }

        public int pageNumber { get; set; }


    }
}