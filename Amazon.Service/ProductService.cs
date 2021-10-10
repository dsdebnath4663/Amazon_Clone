using Amazon.Database;
using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Amazon.Web.Controllers
{
    public class ProductService
    {
        #region Singleton 
        public static ProductService Instance
        {

            get
            {
                if (instance == null) instance = new ProductService();

                return instance;
            }
        }
        private static ProductService instance { get; set; }

        private ProductService()

        {
        }
        #endregion
        public Product GetProduct(int ID)
        {
            using (var context = new AmazonContext())
            {
                return context.Products.Find(ID);
                //                return context.Products.Where(x=>x.ID == ID).Include(x=> x.Category).FirstOrDefault(ID);

            }
        }

        public List<Product> GetProductList(List<int> ids)
        {
            using (var context = new AmazonContext())
            {
                return context.Products.Where(x => ids.Contains(x.ID)).ToList();
            }
        }
        public List<Product> GetProductsByPageNo(int pageNo)

        {
            int pageSize = 10;
            using (var context = new AmazonContext())
            {
                return context.Products
                             .OrderBy(x => x.Name)
                             //.Include(x => x.Category)
                             .ToList();//.Include(x => x.Category)

                /* return context.Products
                               .OrderBy(x => x.Name)
                               .Skip((pageNo - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();//.Include(x => x.Category)*/
            }

        }

        public List<Product> GetProducts()
        {
            var context = new AmazonContext();

            return context.Products.ToList();

        }
        public void SaveProduct(Product product)
        {
            using (var context = new AmazonContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new AmazonContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteProduct(int ID)
        {
            using (var context = new AmazonContext())

            {

                var product = context.Products.Find(ID);

                context.Products.Remove(product);

                context.SaveChanges();
            }

        }

    }

}