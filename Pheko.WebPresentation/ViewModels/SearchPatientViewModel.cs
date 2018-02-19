using System;
using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class SearchPatientViewModel
    {
        [Display(Name = "Patient Id")]
        public int? PatientId { get; set; }

        [Display(Name = "Firstname")]
        [StringLength(50, ErrorMessage = "Firstname cannot be more than 50 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [StringLength(50, ErrorMessage = "Lastname cannot be more than 50 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public string BirthDate { get; set; }

        [Display(Name = "ID Number")]
        [StringLength(20, ErrorMessage = "ID Number cannot be more than 20 characters.")]
        public string IdNumber { get; set; }
    }
}
