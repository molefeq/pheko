using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientChronicDeseaseViewModel
    {
        public int? PatientChronicDeseaseId { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Chronic Desease")]
        public int ChronicDesease_Id { get; set; }

        [Required]
        [Display(Name = "Chronic Desease")]
        public string ChronicDesease_Name { get; set; }

        public string ChronicDeseaseValue { get; set; }
        
        [Display(Name = "Diagnosed In")]
        public int? YearOfDiagnoses { get; set; }

        public bool SelectedInd { get; set; }
    }
}
