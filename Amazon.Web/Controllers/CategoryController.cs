
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
        public object CategoriesServices { get; private set; }

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            CategorySearchViewModels model = new CategorySearchViewModels();
            model.categoryList = CategoryServices.Instance.GetCategories();
            return PartialView(model);
        }
        [HttpPost] 
        public ActionResult Create(CategoryViewModels models)

        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category();
                newCategory.Name = models.Name;
                newCategory.Description = models.Description;
                newCategory.ImageUrl = models.ImageUrl;
                newCategory.isfeatured = models.isfeatured;

                CategoryServices.Instance.SaveCategory(newCategory);
                return RedirectToAction("CategoryTable");
            }
            else
            {
                return HttpStatusCodeResult(500);
            }

        }

        private ActionResult HttpStatusCodeResult(int v)
        {
            throw new NotImplementedException();
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
            int totalItems = CategoryServices.Instance.GetCategoriesCount(pageNo, Search);


            if (model.categoryList != null)
            {

                model.pager = new Pager(totalItems, pageNo,4);
            
               return PartialView("CategoryTable", model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        #endregion

      
    }

}