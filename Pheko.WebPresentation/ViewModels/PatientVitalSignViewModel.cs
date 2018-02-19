using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientVitalSignViewModel
    {
        public int? PatientVitalSignId { get; set; }

        [Required]
        [Display(Name = "Consultation")]
        public int PatientConsultationId { get; set; }

        [Required]
        [Display(Name = "Vital Sign")]
        public int VitalSign_Id { get; set; }

        [Required]
        [Display(Name = "Vital Sign")]
        public string VitalSign_Name{ get; set; }

        public string VitalSignValue { get; set; }
    }
}
