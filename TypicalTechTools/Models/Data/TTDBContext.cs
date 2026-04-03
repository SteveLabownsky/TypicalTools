using Microsoft.EntityFrameworkCore;

namespace TypicalTechTools.Models.Data
{
    public class TTDBContext : DbContext
    {
        public TTDBContext(DbContextOptions<TTDBContext> options) : base (options) 
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product { ProductCode = 12345, ProductName = "Generic Headphones", ProductPrice = 84.99M, ProductDescription = "bluetooth headphones with fair battery life and a 1 month warranty"},
                new Product { ProductCode = 12346, ProductName = "Expensive Headphones", ProductPrice = 149.99M, ProductDescription = "bluetooth headphones with good battery life and a 6 month warranty"},
                new Product { ProductCode = 12347, ProductName = "Name Brand Headphones", ProductPrice = 199.99M, ProductDescription = "bluetooth headphones with good battery life and a 12 month warranty"},
                new Product { ProductCode = 12348, ProductName = "Generic Wireless Mouse", ProductPrice = 39.99M, ProductDescription = "simple bluetooth pointing device"},
                new Product { ProductCode = 12349, ProductName = "Logitach Mouse and Keyboard", ProductPrice = 73.99M, ProductDescription = "mouse and keyboard wired combination"},
                new Product { ProductCode = 12350, ProductName = "Logitach Wireless Mouse", ProductPrice = 149.99M, ProductDescription = "quality wireless mouse"}
                );

            builder.Entity<Review>().HasData(
                new Review { ReviewId = 1, ReviewText = "This is a great product. Highly Recommended.", ProductCode = 12345},
                new Review { ReviewId = 2, ReviewText = "Not worth the excessive price. Stick with a cheaper generic one.", ProductCode = 12350},
                new Review { ReviewId = 3, ReviewText = "A great budget buy. As good as some of the expensive alternatives.", ProductCode = 12345},
                new Review { ReviewId = 4, ReviewText = "Total garbage. Never buying this brand again!", ProductCode = 12347 }
                );

            base.OnModelCreating(builder);

        }
    }
}
