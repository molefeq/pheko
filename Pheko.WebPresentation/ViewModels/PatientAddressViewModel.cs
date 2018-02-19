using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientAddressViewModel
    {
        public int? PatientAddressId { get; set; }

        [Display(Name = "Address Line1")]
        [StringLength(50, ErrorMessage = "Address Line1 cannot be more than 50 characters.")]
        public string Line1 { get; set; }

        [Display(Name = "Address Line2")]
        [StringLength(50, ErrorMessage = "Address Line2 cannot be more than 50 characters.")]
        public string Line2 { get; set; }

        [Display(Name = "Suburb")]
        [StringLength(50, ErrorMessage = "Suburb cannot be more than 50 characters.")]
        public string Suburb { get; set; }

        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "City cannot be more than 100 characters.")]
        public string City { get; set; }

        [Display(Name = "Postal Code")]
        [StringLength(10, ErrorMessage = "Postal Code cannot be more than 10 characters.")]
        public string PostalCode { get; set; }

        [Display(Name = "Province")]
        public int? ProvinceId { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }
    }
}
