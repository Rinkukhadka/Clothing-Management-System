using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public class ProductRepository :IproductRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
            products.Add(new Product() { Id=1, Name = "Jeans", Price=24.99, _Color=Color.Clothing, Description= " Womens Jeans .", ImageName="jeans.jpg"});
            products.Add(new Product() { Id = 2, Name = "Womens Heels ", Price = 45, _Color = Color.Shoes, Description = "Tan Heels, Womens Size 6M.", ImageName = "Shoes1.jpg" });
            products.Add(new Product() { Id = 3, Name = "Shadow Palette ", Price = 25, _Color = Color.Beauty, Description = "Nars eye shadow palette", ImageName = "Beauty4.jpg" });
            products.Add(new Product() { Id = 4, Name = " Black dress", Price = 55, _Color = Color.Clothing, Description = "Black mid dress.", ImageName = "Dress3.jpg" });
            products.Add(new Product() { Id = 5, Name = "Clinique Moisturizer", Price = 45, _Color = Color.Beauty, Description = "Clinique Moisturizer.", ImageName = "Beauty1.jpg" });
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(int? id)
        {
           var product_to_delete= products.Find(x=> x.Id == id);
            if(product_to_delete != null)
            {
                products.Remove(product_to_delete);
            }
        }

       

        public Product GetProduct(int? id)
        {
            if(id == null)
            {
                return null;
            }
            else
            {
                return products.Find(x => x.Id == id);
            }
        }

        public List<Product> GetProducts()
        {
            return products;
        }
        public int GetMaxId()
        {
            int max_id = products.Max(x => x.Id);
            return max_id + 1;
        }
        public void UpdateProduct(Product product)
        {
            var product_to_update = products.Find(x=> x.Id == product.Id);
            if( product_to_update != null)
            {
                product_to_update.Id = product.Id;
                product_to_update.Name = product.Name;
                product_to_update.Description = product.Description;
                product_to_update._Color =product._Color;
                product_to_update.Price = product.Price;
                product_to_update.ImageName = product.ImageName;
            }
        }
    }
}
