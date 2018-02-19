using System;
using System.ComponentModel.DataAnnotations;

namespace Pheko.WebPresentation.ViewModels
{
    public class PatientConsultationSickNoteViewModel
    {
        public int? PatientConsultationSickNoteId { get; set; }

        public int PatientConsultationId { get; set; }

        public int PatientId { get; set; }

        [Display(Name = "Reason")]
        public string SicknessReason { get; set; }

        [Display(Name = "Diagnoses")]
        public string Diagnoses { get; set; }

        [Display(Name = "From")]
        public string StartDate { get; set; }

        [Display(Name = "To")]
        public string EndDate { get; set; }
    }
}
