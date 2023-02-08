using Microsoft.EntityFrameworkCore;

namespace ProductManagementSystem.Models
{

    //class representing DB
    public class ProductContext:DbContext
    {
        //CONSTRUCTOR

        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }
        //using code first approach
        public DbSet<Product> Products { get; set; } 
        public DbSet<Product_Color> Colors { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Color>().HasData(

                new Product_Color { Product_Color_Id = 1, Product_Color_Name="Clothing"},
                new Product_Color { Product_Color_Id = 2, Product_Color_Name = "Shoes" },
                new Product_Color { Product_Color_Id = 3, Product_Color_Name = "Beauty" }

                );
            modelBuilder.Entity<Product>().HasData(

                new Product { Id = 1, Product_Color_Id=1, _Color=Color.Clothing, Name="Jeans", Price=10.45, ImageName="jeans.jpg",Description= " Womens Jeans." },
                new Product { Id = 2, Product_Color_Id = 2, _Color = Color.Beauty, Name = "Shadow Palette", Price = 15, ImageName = "Beauty4.jpg", Description = "Nars eye shadow palette" },
                new Product { Id = 3, Product_Color_Id = 3, _Color = Color.Shoes, Name = "Shoes", Price = 44.99, ImageName = "Shoes1.jpg", Description = "an Heels, Womens Size 6M." }
                );
        }
    }
}
