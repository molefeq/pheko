
namespace Pheko.Common.DataTransformObjects
{
    public class PatientMedicalNoteDto
    {
        public int? PatientMedicalNoteId { get; set; }
        public int PatientConsultationId { get; set; }
        public MedicalNoteDto MedicalNote { get; set; }
        public string Value { get; set; }
    }
}
