using System.ComponentModel.DataAnnotations;

namespace CmsShop.Models.ViewModels.Account
{
    public class LoginUserVM
    {
        [Required]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        public bool  RememberMe { get; set; }
    }
}