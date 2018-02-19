using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientPastMedicalHistoryViewModel
    {
        public int? PatientPastMedicalHistoryId { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }
        
        public string PastMedicalHistoryValue { get; set; }

        [Required]
        [Display(Name = "Past Medical History")]
        public int PastMedicalHistory_Id { get; set; }

        [Required]
        [Display(Name = "Past Medical History")]
        public string PastMedicalHistory_Name { get; set; }
    }
}
