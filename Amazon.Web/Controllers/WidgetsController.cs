using Amazon.Entities;
using Amazon.Web.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Web.Controllers
{
    public class WidgetsController : Controller
    {
        // GET: Widgets
        public ActionResult ProductsWidgets(bool isLatestProducts)
        {
            ProductsWidgetViewModel model = new ProductsWidgetViewModel();

            if (isLatestProducts)
            {
                model.Products = ProductService.Instance.GetLatestProducts(4);
            }
            else
            {
                model.Products = ProductService.Instance.GetProducts(1,8);
            }

            return PartialView (model);
        }
    }
}