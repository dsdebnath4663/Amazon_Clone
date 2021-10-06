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
    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductTable(String Search, int? pageNo)
        {
            ProductSearchViewModels model = new ProductSearchViewModels();

            model.pageNumber = pageNo.HasValue ? pageNo.Value>0 ? pageNo.Value : 1 : 1;
            model.productList = ProductService.Instance.GetProductsByPageNo(model.pageNumber);

            if (string.IsNullOrEmpty(Search) == false)
            {
                model.searchKeyword = Search;
                model.productList = model.productList
                                         .Where(p => p.Name != null &&
                                                   (p.Name).ToLowerInvariant().Contains(Search.ToLowerInvariant()))
                                         .ToList();
            }


            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            var Categories = CategoryServices.Instance.GetCategories();

            return PartialView(Categories);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModels models)

        {

            var newProduct = new Product();

            newProduct.Name = models.Name;
            newProduct.Price = models.Price;
            newProduct.Description = models.Description;
            newProduct.Category = CategoryServices.Instance.GetCategory(models.CategoryID);

            ProductService.Instance.SaveProduct(newProduct);

            return RedirectToAction("ProductTable");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {


            ProductEditViewModels productEditViewModels = new ProductEditViewModels();
            productEditViewModels.products = ProductService.Instance.GetProduct(ID);
            productEditViewModels.categories = CategoryServices.Instance.GetCategories();


            return PartialView(productEditViewModels);
        }
        [HttpPost]
        public ActionResult Edit(Product product)

        {
            ProductService.Instance.UpdateProduct(product);

            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(Product product)

        {
            ProductService.Instance.DeleteProduct(product.ID);

            return RedirectToAction("ProductTable");
        }

    }


}