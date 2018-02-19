using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientMedicalMonitoringViewModel
    {
        public int? PatientMedicalMonitoringId { get; set; }

        [Required]
        [Display(Name = "Consultation")]
        public int PatientConsultationId { get; set; }

        [Required]
        [Display(Name = "Medical Monitoring")]
        public int MedicalMonitoring_Id { get; set; }

        [Required]
        [Display(Name = "Medical Monitoring")]
        public string MedicalMonitoring_Name { get; set; }

        public string MedicalMonitoringValue { get; set; }
    }
}
