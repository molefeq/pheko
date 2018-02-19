
namespace Pheko.Common.DataTransformObjects
{
    public class PatientChronicDeseaseDto
    {
        public int? PatientChronicDeseaseId { get; set; }
        public int PatientId { get; set; }
        public int? YearOfDiagnoses { get; set; }
        public string Value { get; set; }
        public bool SelectedInd { get; set; }

        public virtual ChronicDeseaseDto ChronicDesease { get; set; }
    }
}
