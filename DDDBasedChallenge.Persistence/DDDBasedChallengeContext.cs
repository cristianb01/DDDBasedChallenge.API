using DDDBasedChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Persistence
{
    public class DDDBasedChallengeContext : DbContext
    {
        public DDDBasedChallengeContext(DbContextOptions<DDDBasedChallengeContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DDDBasedChallengeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //var products = new List<Product>
            //{
            //    Product.Create("Product 1", 3, 1, DateTime.Now).Data,
            //    Product.Create("Product 2", 1, 1, DateTime.Now).Data,
            //    Product.Create("Product 3", 5, 1, DateTime.Now).Data,
            //    Product.Create("Product 4", 6, 1, DateTime.Now).Data,
            //    Product.Create("Product 5", 8, 1, DateTime.Now).Data
            //};

            //var categories = new List<Category>
            //{
            //    Category.Create("Category 1").Data,
            //    Category.Create("Category 2").Data,
            //    Category.Create("Category 3").Data,
            //    Category.Create("Category 4").Data,
            //    Category.Create("Category 5").Data,
            //    Category.Create("Category 6").Data,
            //};

            //modelBuilder.Entity<Category>(entity =>
            //{
            //    entity.HasData(categories);
            //});

            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.HasData(products);
            //});
        }
    }
}
