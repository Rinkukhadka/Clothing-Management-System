using System.ComponentModel.DataAnnotations;
namespace ProductManagementSystem.Models

{
    public class Product_Color
    {
        [Key]
        public int Product_Color_Id { get; set; }
        public string? Product_Color_Name { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
