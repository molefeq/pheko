using Pheko.Common.Enums;

using System;

namespace Pheko.Common.DataTransformObjects
{
    public class PatientDto
    {
        public int? PatientId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EthnicGroup { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IDNumber { get; set; }
        public string MobileNumber { get; set; }
        public string HomeTelephoneCode { get; set; }
        public string HomeTelephoneNumber { get; set; }
        public string WorkTelephoneCode { get; set; }
        public string WorkTelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MaritalStatus { get; set; }
        public string MarriageType { get; set; }
        public string PrefferedContactType { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidScheme { get; set; }
        public string MedicalAidNumber { get; set; }
        public bool? PrincipalMemberInd { get; set; }
        public string PrefferedContactMethod { get; set; }
        public string SourceOfDiscovery { get; set; }
        public bool? MedicalAidInd { get; set; }
        public string IDType { get; set; }
        public CrudOperations CrudOperation { get; set; }

        public PatientAddressDto PhysicalAddress { get; set; }
        public PatientAddressDto PostalAddress { get; set; }
    }
}
