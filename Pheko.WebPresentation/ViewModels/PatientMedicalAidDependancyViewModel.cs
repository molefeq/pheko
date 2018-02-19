using Pheko.WebPresentation.Utility;

using System;
using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
   public class PatientMedicalAidDependancyViewModel
    {
        public int? PatientMedicalAidDependanciesId { get; set; }

        [Display(Name = "Patient")]
        [Required]
        public int PatientId { get; set; }

        [Display(Name = "Title")]
        [StringLength(10, ErrorMessage = "Title cannot be more than 10 characters.")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Firstnames")]
        [StringLength(100, ErrorMessage = "Firstnames cannot be more than 100 characters.")]
        [Required]
        public string FirstFullName { get; set; }

        [Display(Name = "Lastname")]
        [StringLength(50, ErrorMessage = "Lastname cannot be more than 50 characters.")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Medical Aid Code")]
        [StringLength(20, ErrorMessage = "Medical Aid Code cannot be more than 20 characters.")]
        [Required]
        public string MedicalAidCode { get; set; }

        [Display(Name = "Date Of Birth")]
        public string BirthDate { get; set; }

        [Display(Name = "Relationship")]
        [StringLength(50, ErrorMessage = "Relationship cannot be more than 50 characters.")]
        [Required]
        public string Relationship { get; set; }

        [Display(Name = "Principal Member?")]
        [Required]
        public bool PrincipalInd { get; set; }

        public ModelCrudOperations CrudOperation { get; set; }
    }
}
