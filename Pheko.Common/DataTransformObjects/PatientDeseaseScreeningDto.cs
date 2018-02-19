
namespace Pheko.Common.DataTransformObjects
{
    public class PatientDeseaseScreeningDto
    {
        public int? PatientDeseaseScreeningId { get; set; }
        public int PatientId { get; set; }
        public DeseaseScreeningDto DeseaseScreening { get; set; }
        public int? YearOfScreening { get; set; }
        public string Value { get; set; }
        public bool SelectedInd { get; set; }
    }
}
