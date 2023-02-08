using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementSystem.Models
{
    public enum Color
    {
        Clothing,
        Shoes,
        Beauty
    }
    public class Product
    {

        //Validators 
        [Display(Name="Product Id")]
        [Required(ErrorMessage = "Field cannot be empty")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //to remove conflict of id created by DB id 
        public int Id { get; set; }

        public int Product_Color_Id { get; set; } // foreign key from product_color table

        [Display(Name="Product Name")]
        [Required(ErrorMessage ="Please fill in the name of product")]
        [MaxLength(80)]
        //[AllLetters(ErrorMessage ="Enter letters only")]
        public string? Name { get; set; }


        [Display (Name="Description of product")]
        [DataType(DataType.MultilineText)]
        [MaxLength(300, ErrorMessage ="Description too long")]
        public string? Description { get; set; }


        [DataType(DataType.Currency)]

        public double? Price { get; set; }
        public string? ImageName { get; set; }

        public Color _Color { get; set; }
    }
}
