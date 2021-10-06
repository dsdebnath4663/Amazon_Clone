using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Database
{


    public class AmazonContext : DbContext, IDisposable
    {
        public AmazonContext() : base("AmazonConnection") // tell dbcontext file which connection is use
        {

        }
        public DbSet<Category> Categories { get; set; } // individullay create database table
        public DbSet<Product> Products { get; set; } // individullay create database table
        public DbSet<Config> Configurations { get; set; }
        
        public DbSet<Users> Users { get; set; }                                              // 
                                                                                            // 
    }
}
