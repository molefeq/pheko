using System;

namespace Pheko.Common.DataTransformObjects
{
    public class PatientConsultationSickNoteDto
    {
        public int? PatientConsultationSickNoteId { get; set; }
        public int PatientConsultationId { get; set; }
        public int PatientId { get; set; }
        public string SicknessReason { get; set; }
        public string Diagnoses { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
