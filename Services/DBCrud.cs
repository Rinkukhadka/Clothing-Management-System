

using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public class DBCrud : IproductRepository
    {
        private ProductContext _ProductContext;
        public DBCrud(ProductContext productContext)
        {
            _ProductContext = productContext;
        }

        public void AddProduct(Product product)
        {
            if(product._Color.ToString()=="White")
            { product.Product_Color_Id = 1; }
            if (product._Color.ToString() == "Pink")
            { product.Product_Color_Id = 2; }
            if (product._Color.ToString() == "Light_green")
            { product.Product_Color_Id = 3; }


            _ProductContext.Products.Add(product);
            _ProductContext.SaveChanges();

        }

        public void DeleteProduct(int? id)
        {
           var product = _ProductContext.Products.Find(id);
            if(product != null)
            {
                _ProductContext.Products.Remove(product);
                _ProductContext.SaveChanges();
            }
        }

        public int GetMaxId()
        {
            return _ProductContext.Products.Max(x => x.Id) + 1;
        }

        public Product GetProduct(int? id)
        {
            return _ProductContext.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(_ProductContext.Products);
        }

        public void UpdateProduct(Product product)
        {
           var prod = _ProductContext.Products.Find(product.Id);
            if(prod != null)
            {
                prod.Id = product.Id;
                prod.Price = product.Price;
                prod.Name = product.Name;
                prod.Description = product.Description;
                prod.ImageName = product.ImageName;
                prod._Color = product._Color;

                if (product._Color.ToString() == "White")
                { prod.Product_Color_Id = 1; }
                if (product._Color.ToString() == "Pink")
                { prod.Product_Color_Id = 2; }
                if (product._Color.ToString() == "Light_green")
                { prod.Product_Color_Id = 3; }

                _ProductContext.SaveChanges();
            }
        }
    }
}
