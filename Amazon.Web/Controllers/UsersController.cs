using Amazon.Entities;
using Amazon.Web.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Web.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserTable(String Search, int? pageNo)
        {
            UsersSearchViewModels model = new UsersSearchViewModels();

            model.pageNumber = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.usersList = UsersService.Instance.getAllUsersList();

            if (string.IsNullOrEmpty(Search) == false)
            {
                model.searchKeyword = Search;
                model.usersList = model.usersList
                                         .Where(p => p.Name != null &&
                                                   (p.Name).ToLowerInvariant().Contains(Search.ToLowerInvariant()))
                                         .ToList();
            }


            return PartialView(model);
        }


        [HttpGet]
        public ActionResult CreateUser()
        {
            return PartialView("");
        }


        [HttpPost]
        public ActionResult CreateUser(Users users)
        {
            UsersService.Instance.SaveUsers(users);

            return RedirectToAction("UserTable");
        }

        [HttpGet]
        public ActionResult EditUsers(int id)
        {
            Users user = new Users();

            user = UsersService.Instance.GetUsers(id);

            return PartialView(user);
        }
        [HttpPost]
        public ActionResult EditUsers(Users users)

        {
            UsersService.Instance.UpdateUser(users);

            return RedirectToAction("UserTable");
        }
        
               [HttpPost]
        public ActionResult DeleteUsers(Users users)

        {
            UsersService.Instance.DeleteUsers(users.ID);

            return RedirectToAction("UserTable");
        }


    }
}