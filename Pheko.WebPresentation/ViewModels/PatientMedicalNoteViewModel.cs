using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientMedicalNoteViewModel
    {
        public int? PatientMedicalNoteId { get; set; }

        [Required]
        [Display(Name = "Consultation")]
        public int PatientConsultationId { get; set; }

        [Required]
        [Display(Name = "Medical Note")]
        public int MedicalNote_Id { get; set; }

        [Required]
        [Display(Name = "Medical Note")]
        public string MedicalNote_Name { get; set; }

        public string MedicalNoteValue { get; set; }
    }
}
