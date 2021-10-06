
using Amazon.Entities;
using Amazon.Service;
using Amazon.Web.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Web.Controllers
{
    public class CategoryController : Controller
    {


        [HttpGet]
        public ActionResult Index()
        {
             return View();
        }

        #region Creation

        [HttpGet]
        public ActionResult Create()
        {
             return PartialView();

        }
        [HttpPost]
        public ActionResult Create(CategoryViewModels models)

        {
            /*CategoryServices.Instance.SaveCategory(Category);*/
            var newCategory = new Category();

            newCategory.Name = models.Name;
            newCategory.Description = models.Description;
            newCategory.ImageUrl = models.ImageUrl;

            newCategory.isfeatured = models.isfeatured;

            CategoryServices.Instance.SaveCategory (newCategory);
            return RedirectToAction("CategoryTable");

        }
/*        [HttpGet]
        public ActionResult Delete(int ID)

        {
            var category = CategoryServices.Instance.GetCategory(ID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete1(int ID)

        {
            var category = CategoryServices.Instance.GetCategory(ID);
            return View(category);
        }*/
        [HttpPost]
        public ActionResult Delete(Category category)

        {
            CategoryServices.Instance.Deletecategory(category.ID);

            return RedirectToAction("CategoryTable");
        }

        #endregion

        #region Updation

        [HttpGet]
        public ActionResult Edit(int ID)
        {
             var category = CategoryServices.Instance.GetCategory(ID);

              return PartialView(category);
        }


        [HttpPost]
        public ActionResult Edit(Category category)
        {


            CategorySearchViewModels model = new CategorySearchViewModels();

            model.categoryList = CategoryServices.Instance.GetCategories();
            CategoryServices.Instance.UpdateCategory(category);
            return RedirectToAction("CategoryTable");
        }




        public ActionResult CategoryTable(String Search, int? pageNo)
        {
            CategorySearchViewModels model = new CategorySearchViewModels();

            model.categoryList = CategoryServices.Instance.GetCategories();

            if (string.IsNullOrEmpty(Search) == false)
            {
                model.searchKeyword = Search;
                model.categoryList = model.categoryList
                                         .Where(p => p.Name != null &&
                                                   (p.Name).ToLowerInvariant().Contains(Search.ToLowerInvariant()))
                                         .ToList();
            }


            return PartialView(model);
        }
        #endregion

    }

}