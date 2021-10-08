
using Amazon.Entities;
using Amazon.Service;
using Amazon.Web.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Amazon.Web.Models.viewModels.BaseListingViewModel;
using System.Data.Entity;



namespace Amazon.Web.Controllers
{
    public class CategoryController : Controller
    {


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();

        }
        [HttpPost]
        public ActionResult Create(CategoryViewModels models)

        {
            var newCategory = new Category();

            newCategory.Name = models.Name;
            newCategory.Description = models.Description;
            newCategory.ImageUrl = models.ImageUrl;
            newCategory.isfeatured = models.isfeatured;

            CategoryServices.Instance.SaveCategory(newCategory);
            return RedirectToAction("CategoryTable");

        }

        [HttpPost]
        public ActionResult Delete(Category category)

        {
            CategoryServices.Instance.Deletecategory(category.ID);

            return RedirectToAction("CategoryTable");
        }


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




        public ActionResult CategoryTable(string Search, int? pageNo)
        {
            CategorySearchViewModels model = new CategorySearchViewModels();

            model.searchKeyword = Search;
            model.categoryList = CategoryServices.Instance.GetCategoriesByPageNoAndSearchKeyWord(pageNo, Search);
            int totalItems = model.categoryList.Count;


            if (model.categoryList != null)
            {

                model.pager = new Pager(totalItems, pageNo);

               return PartialView("CategoryTable", model);
              //  return PartialView(model);


            }
            else
            {
                return HttpNotFound();
            }
        }
        #endregion

    }

}