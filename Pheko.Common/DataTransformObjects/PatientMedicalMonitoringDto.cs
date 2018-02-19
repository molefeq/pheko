
namespace Pheko.Common.DataTransformObjects
{
    public class PatientMedicalMonitoringDto
    {
        public int? PatientMedicalMonitoringId { get; set; }
        public int PatientConsultationId { get; set; }
        public MedicalMonitoringDto MedicalMonitoring { get; set; }
        public string Value { get; set; }
    }
}
