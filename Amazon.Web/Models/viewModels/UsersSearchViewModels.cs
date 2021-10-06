using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazon.Web.Models.viewModels
{
    public class UsersSearchViewModels
    {
        public int pageNumber { get; set; }
        public string searchKeyword { get; set; }
        public List<Users> usersList { get; set; }

    }
}