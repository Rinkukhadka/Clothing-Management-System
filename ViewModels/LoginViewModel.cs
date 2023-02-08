using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage =("Please enter username"))]
        public string? UserName { get; set; }

        [Required(ErrorMessage="Please enter password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
