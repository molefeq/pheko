
namespace Pheko.Common.DataTransformObjects
{
    public class PatientVitalSignDto
    {
        public int? PatientVitalSignId { get; set; }
        public int PatientConsultationId { get; set; }
        public VitalSignDto VitalSign { get; set; }
        public string VitalSignValue { get; set; }
    }
}
