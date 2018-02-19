
namespace Pheko.Common.DataTransformObjects
{
    public class PatientPastMedicalHistoryDto
    {
        public int? PatientPastMedicalHistoryId { get; set; }
        public int PatientId { get; set; }
        public string Value { get; set; }

        public PastMedicalHistoryDto PastMedicalHistory { get; set; }
    }
}
