using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class CreatePatientViewModel
    {
        [Required]
        [Display(Name="Firstname")]
        [StringLength(50, ErrorMessage="Firstname cannot be more than 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        [StringLength(50, ErrorMessage = "Lastname cannot be more than 50 characters.")]
        public string LastName { get; set; }
    }
}
