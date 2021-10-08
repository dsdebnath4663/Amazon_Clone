using Amazon.Database;
using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.
    Entity;
namespace Amazon.Service
{
    public class CategoryServices
    {

        #region Singleton 
        public static CategoryServices Instance
        {

            get
            {
                if (instance == null) instance = new CategoryServices();

                return instance;
            }
        }
        private static CategoryServices instance { get; set; }

        private CategoryServices()

        {
        }
        #endregion
        public Category GetCategory(int ID)
        {
            using (var context = new AmazonContext())
            {
                return context.Categories.Find(ID);
            }
        }
        public List<Category> GetCategories()
        {
            using (var context = new AmazonContext())
            {
                return context.Categories.ToList();
            }
        }
        public List<Category> GetCategoriesByPageNoAndSearchKeyWord(int? pageNo, string Search)
        {
            using (var context = new AmazonContext())
            {
                int page = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                int pageSize = int.Parse(ConfigurationService.Instance.GetConfig("ListingPageSize").Value);


               if (!string.IsNullOrEmpty(Search))
                {
                    return context
                        .Categories.Where(category => category.Name != null && category.Name.ToLower()
                                   .Contains(Search.ToLower()))
                                   .OrderBy(x => x.ID)
                                   .Skip((page - 1) * pageSize)
                                   .Include(x => x.Products)
                                   .Take(pageSize)
                                   .ToList();

                }
                else
                {
                    return context.Categories.OrderBy(x => x.ID)
                                 .Skip((page - 1) * pageSize)
                               //  .Include(x => x.Products)
                                 .Take(pageSize)
                                 .ToList();
               }


              


            }
        }
        public List<Category> GetFeaturedCategories()
        {
            using (var context = new AmazonContext())
            {
                return context.Categories.Where(x => x.isfeatured).ToList();
            }
        }


        /// <summary>
        /// saving new category into database
        /// </summary>
        /// <param name="category"> input receive from end user using view</param>
        public void SaveCategory(Category category)

        {
            using (var context = new AmazonContext())

            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public void Updatecategory(Category category)
        {   //  using(var context= new AmazonContext()) 
            using (var context = new AmazonContext())

            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }
        public void Deletecategory(int ID)
        {   //  using(var context= new AmazonContext()) 
            using (var context = new AmazonContext())

            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;

                var category = context.Categories.Find(ID);


                context.Categories.Remove(category);

                context.SaveChanges();
            }

        }
        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"> category data from end user</param>
        public void UpdateCategory(Category category) // update category
        {
            using (var context = new AmazonContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }


}
