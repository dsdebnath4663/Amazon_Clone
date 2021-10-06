using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amazon.Web.Models.viewModels
{
    public class CheckoutViewModels
    {
        public List<Product> CartProducts { get; set; }
        public List<int> CartProductIDs { get; set; }


    }
}