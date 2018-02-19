using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name="Username")]
        [Required(ErrorMessage="Username is required.")]
        public string UserName { get; set; }
        
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
