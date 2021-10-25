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

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Category>().Property(p => p.ImageUrl).IsRequired().HasMaxLength(500);

        }

        public DbSet<Category> Categories { get; set; } // individullay create database table
        public DbSet<Product> Products { get; set; } // individullay create database table
        public DbSet<Config> Configurations { get; set; }
        
        public DbSet<Users> Users { get; set; }                                              // 
                                                                                            // 
    }
}
