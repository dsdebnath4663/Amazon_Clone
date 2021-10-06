using Amazon.Web.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Web.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult checkout()
        {
            CheckoutViewModels model = new CheckoutViewModels();

           var CartProductsCookie = Request.Cookies["CartProducts"];// request browser for take cookies

            if (CartProductsCookie != null)
            {
                
                var ProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();

                model.CartProducts = ProductService.Instance.GetProductList(ProductIDs);
                model.CartProductIDs = ProductIDs;
            }
             
            return View(model);
        }
    }
}