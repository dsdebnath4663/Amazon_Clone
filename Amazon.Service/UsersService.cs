using Amazon.Database;
using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazon.Web.Controllers
{
    public class UsersService
    {
        #region Singleton 
        public static UsersService Instance
        {

            get
            {
                if (instance == null) instance = new UsersService();

                return instance;
            }
        }
        private static UsersService instance { get; set; }

        private UsersService()
        {
        }
        #endregion

        public Users GetUsers(int ID)
        {
            using (var context = new AmazonContext())
            {
                return context.Users.Find(ID);
            }
        }

        public List<Users> getAllUsersList()
        {
            using (var context = new AmazonContext())
            {
                return context.Users
                             .OrderBy(x => x.Name)
                             .ToList();
            }
        }


        public void SaveUsers(Users users)
        {
            using (var context = new AmazonContext())
            {
                context.Users.Add(users);
                context.SaveChanges();
            }
        }
        public void UpdateUser(Users users)
        {
            using (var context = new AmazonContext())
            {
                context.Entry(users).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteUsers(int ID)
        {
            using (var context = new AmazonContext())

            {

                var userData = context.Users.Find(ID);

                context.Users.Remove(userData);

                context.SaveChanges();
            }

        }


    }
}