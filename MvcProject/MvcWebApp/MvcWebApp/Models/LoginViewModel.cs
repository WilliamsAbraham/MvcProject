using System.ComponentModel.DataAnnotations;

namespace MvcWebApp.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Password), Required]
        public string Password { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
