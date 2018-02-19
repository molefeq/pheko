using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientClinicalExaminationViewModel
    {
        public int? PatientClinicalExaminationId { get; set; }

        [Required]
        [Display(Name = "Consultation")]
        public int PatientConsultationId { get; set; }

        [Required]
        [Display(Name = "Clinical Examination")]
        public int ClinicalExamination_Id { get; set; }

        [Required]
        [Display(Name = "Clinical Examination")]
        public string ClinicalExamination_Name { get; set; }

        public string ClinicalExaminationValue { get; set; }
    }
}
