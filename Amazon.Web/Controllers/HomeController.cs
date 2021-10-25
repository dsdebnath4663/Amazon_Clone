using Amazon.Service;
using Amazon.Web.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModels homeViewModels = new HomeViewModels();

            homeViewModels.Featuredcategories = CategoryServices.Instance.GetFeaturedCategories();

            return View(homeViewModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}