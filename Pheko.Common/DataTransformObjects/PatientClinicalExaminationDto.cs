
namespace Pheko.Common.DataTransformObjects
{
    public class PatientClinicalExaminationDto
    {
        public int? PatientClinicalExaminationId { get; set; }
        public int PatientConsultationId { get; set; }
        public virtual ClinicalExaminationDto ClinicalExamination { get; set; }
        public string Value { get; set; }
    }
}
