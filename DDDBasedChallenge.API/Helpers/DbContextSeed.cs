using DDDBasedChallenge.Domain.Entities;
using DDDBasedChallenge.Persistence;

namespace DDDBasedChallenge.API.Helpers
{
    public static class DbContextSeed
    {
        public static void SeedData(DDDBasedChallengeContext context)
        {
            var categories = new List<Category>
            {
                Category.Create("Category 1"),
                Category.Create("Category 2"),
            };

            var products = new List<Product>
            {
                Product.Create("Product 1", 3, 1, new DateTime(2021, 02, 03)),
                Product.Create("Product 2", 1, 1, new DateTime(2021, 02, 03)),
                Product.Create("Product 3", 5, 1, new DateTime(2021, 02, 03)),
                Product.Create("Product 4", 6, 1, new DateTime(2021, 02, 03)),
                Product.Create("Product 5", 8, 1, new DateTime(2021, 02, 03)),
                Product.Create("Product 6", 8, 2, new DateTime(2021, 02, 03)),
                Product.Create("Product 7", 8, 2, new DateTime(2021, 02, 03)),
                Product.Create("Product 8", 8, 2, new DateTime(2021, 02, 03)),
                Product.Create("Product 9", 8, 2, new DateTime(2021, 02, 03)),
                Product.Create("Product 10", 8, 2, DateTime.Now)

            };

            context.Categories.AddRange(categories);
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
