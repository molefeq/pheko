using Pheko.WebPresentation.Utility;

using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientConsultationViewModel
    {
        public int? PatientConsultationId { get; set; }

        [Required]
        [Display(Name = "Doctor")]
        public int? DoctorId { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int? PatientId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string ConsultationStatus { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        public ModelCrudOperations CrudOperation { get; set; }
    }
}
