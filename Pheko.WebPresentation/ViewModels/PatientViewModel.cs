using Pheko.WebPresentation.Utility;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientViewModel
    {
        public int? PatientId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        [StringLength(50, ErrorMessage = "Firstname cannot be more than 50 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Middlename")]
        [StringLength(50, ErrorMessage = "Middlename cannot be more than 50 characters.")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        [StringLength(50, ErrorMessage = "Lastname cannot be more than 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [StringLength(10, ErrorMessage = "Gender cannot be more than 10 characters.")]
        public string Gender { get; set; }
        
        [Required]
        [Display(Name = "Ethnic Group")]
        [StringLength(10, ErrorMessage = "Ethnic Group cannot be more than 10 characters.")]
        public string EthnicGroup { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public string BirthDate { get; set; }

        [Display(Name = "Id Number")]
        [StringLength(20, ErrorMessage = "Id Number cannot be more than 20 characters.")]
        public string IDNumber { get; set; }

        [Display(Name = "Id Type")]
        [StringLength(20, ErrorMessage = "Id Type cannot be more than 20 characters.")]
        public string IDType { get; set; }

        [Display(Name = "Mobile Number")]
        [StringLength(20, ErrorMessage = "Mobile Number cannot be more than 20 characters.")]
        public string MobileNumber { get; set; }

        [Display(Name = "Code")]
        [StringLength(10, ErrorMessage = "Code cannot be more than 10 characters.")]
        public string HomeTelephoneCode { get; set; }

        [Display(Name = "Home Telephone")]
        [StringLength(20, ErrorMessage = "Home Telephone cannot be more than 20 characters.")]
        public string HomeTelephoneNumber { get; set; }

        [Display(Name = "Code")]
        [StringLength(10, ErrorMessage = "Code cannot be more than 10 characters.")]
        public string WorkTelephoneCode { get; set; }

        [Display(Name = "Work Telephone")]
        [StringLength(20, ErrorMessage = "Work Telephone cannot be more than 20 characters.")]
        public string WorkTelephoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Email Address cannot be more than 100 characters.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Marital Status")]
        [StringLength(10, ErrorMessage = "Marital Status cannot be more than 10 characters.")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Marriage Type")]
        [StringLength(50, ErrorMessage = "Marriage Type cannot be more than 50 characters.")]
        public string MarriageType { get; set; }

        [Display(Name = "Preffered Contact Type")]
        [StringLength(20, ErrorMessage = "Preffered Contact Type cannot be more than 20 characters.")]
        public string PrefferedContactType { get; set; }

        [Display(Name = "Medical Aid Name")]
        [StringLength(100, ErrorMessage = "Medical Aid Name cannot be more than 100 characters.")]
        public string MedicalAidName { get; set; }

        [Display(Name = "Medical Aid Scheme")]
        [StringLength(100, ErrorMessage = "Medical Aid Scheme cannot be more than 100 characters.")]
        public string MedicalAidScheme { get; set; }

        [Display(Name = "Medical Aid Number")]
        [StringLength(100, ErrorMessage = "Medical Aid Number cannot be more than 100 characters.")]
        public string MedicalAidNumber { get; set; }

        [Display(Name = "Principal Member ?")]
        public bool PrincipalMemberInd { get; set; }

        [Display(Name = "Preffered Contact Method")]
        [StringLength(50, ErrorMessage = "Preffered Contact Method cannot be more than 50 characters.")]
        public string PrefferedContactMethod { get; set; }

        [Display(Name = "Source Of Discovery")]
        [StringLength(100, ErrorMessage = "Source Of Discovery cannot be more than 100 characters.")]
        public string SourceOfDiscovery { get; set; }

        [Display(Name = "Medical Aid ?")]
        public bool MedicalAidInd { get; set; }

        public ModelCrudOperations CrudOperation { get; set; }

        [Display(Name = "Physical Address")]
        public PatientAddressViewModel PhysicalAddress { get; set; }

        [Display(Name = "Postal Address")]
        public PatientAddressViewModel PostalAddress { get; set; }
        
        public PatientViewModel()
        {
            PhysicalAddress = new PatientAddressViewModel();
            PostalAddress = new PatientAddressViewModel();
        }
    }
}
