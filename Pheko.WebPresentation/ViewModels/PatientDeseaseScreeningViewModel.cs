using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientDeseaseScreeningViewModel
    {
        public int? PatientDeseaseScreeningId { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Desease Screening")]
        public int DeseaseScreening_Id { get; set; }

        [Required]
        [Display(Name = "Desease Screening")]
        public string DeseaseScreening_Name { get; set; }

        public string DeseaseScreeningValue { get; set; }

        [Display(Name = "Screened in")]
        public int? YearOfScreening { get; set; }

        public bool SelectedInd { get; set; }
    }
}
