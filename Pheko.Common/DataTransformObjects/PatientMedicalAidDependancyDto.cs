using Pheko.Common.Enums;

using System;

namespace Pheko.Common.DataTransformObjects
{
    public class PatientMedicalAidDependancyDto
    {
        public int? PatientMedicalAidDependanciesId { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string FirstFullName { get; set; }
        public string LastName { get; set; }
        public string MedicalAidCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Relationship { get; set; }
        public bool PrincipalInd { get; set; }
        public CrudOperations CrudOperation { get; set; }
    }
}
