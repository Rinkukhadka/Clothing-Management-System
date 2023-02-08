using ProductManagementSystem.Models;
namespace ProductManagementSystem.Services
{
    public interface IproductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int? id);
        void AddProduct(Product product);
        void DeleteProduct(int? id);
        void UpdateProduct(Product product);
        int GetMaxId();
    }
}
