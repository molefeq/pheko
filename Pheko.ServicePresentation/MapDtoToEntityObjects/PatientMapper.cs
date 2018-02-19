using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientMapper
    {
        public PatientMapper() { }

        public PatientDto MapToPatientDto(Patient patient)
        {
            if (patient == null)
            {
                return null;
            }

            PatientDto patientDto = new PatientDto();

            PatientAddressMapper patientAddressMapper = new PatientAddressMapper();

            patientDto.PatientId = patient.PatientId;
            patientDto.Title = patient.Title;
            patientDto.FirstName = patient.FirstName;
            patientDto.MiddleName = patient.MiddleName;
            patientDto.LastName = patient.LastName;
            patientDto.Gender = patient.Gender;
            patientDto.EthnicGroup = patient.EthnicGroup;
            patientDto.BirthDate = patient.BirthDate;
            patientDto.IDNumber = patient.IDNumber;
            patientDto.MobileNumber = patient.MobileNumber;
            patientDto.HomeTelephoneCode = patient.HomeTelephoneCode;
            patientDto.HomeTelephoneNumber = patient.HomeTelephoneNumber;
            patientDto.WorkTelephoneCode = patient.WorkTelephoneCode;
            patientDto.WorkTelephoneNumber = patient.WorkTelephoneNumber;
            patientDto.EmailAddress = patient.EmailAddress;
            patientDto.MaritalStatus = patient.MaritalStatus;
            patientDto.MarriageType = patient.MarriageType;
            patientDto.PrefferedContactType = patient.PrefferedContactType;
            patientDto.MedicalAidName = patient.MedicalAidName;
            patientDto.MedicalAidScheme = patient.MedicalAidScheme;
            patientDto.MedicalAidNumber = patient.MedicalAidNumber;
            patientDto.PrincipalMemberInd = patient.PrincipalMemberInd;
            patientDto.PrefferedContactMethod = patient.PrefferedContactMethod;
            patientDto.SourceOfDiscovery = patient.SourceOfDiscovery;
            patientDto.MedicalAidInd = patient.MedicalAidInd;
            patientDto.IDType = patient.IDType;

            if (patient.PostalAddress != null)
            {
                patientDto.PostalAddress = patientAddressMapper.MapToPatientAddressDto(patient.PostalAddress);
            }

            if (patient.PhysicalAddress != null)
            {
                patientDto.PhysicalAddress = patientAddressMapper.MapToPatientAddressDto(patient.PhysicalAddress);
            }

            return patientDto;
        }

        public void MapToPatient(Patient patient, PatientDto patientDto)
        {
            if (patientDto == null)
            {
                return;
            }

            patient = patient ?? new Patient();

            PatientAddressMapper patientAddressMapper = new PatientAddressMapper();

            patient.Title = patientDto.Title;
            patient.FirstName = patientDto.FirstName;
            patient.MiddleName = patientDto.MiddleName;
            patient.LastName = patientDto.LastName;
            patient.Gender = patientDto.Gender;
            patient.EthnicGroup = patientDto.EthnicGroup;
            patient.BirthDate = patientDto.BirthDate;
            patient.IDNumber = patientDto.IDNumber;
            patient.MobileNumber = patientDto.MobileNumber;
            patient.HomeTelephoneCode = patientDto.HomeTelephoneCode;
            patient.HomeTelephoneNumber = patientDto.HomeTelephoneNumber;
            patient.WorkTelephoneCode = patientDto.WorkTelephoneCode;
            patient.WorkTelephoneNumber = patientDto.WorkTelephoneNumber;
            patient.EmailAddress = patientDto.EmailAddress;
            patient.MaritalStatus = patientDto.MaritalStatus;
            patient.MarriageType = patientDto.MarriageType;
            patient.PrefferedContactType = patientDto.PrefferedContactType;
            patient.MedicalAidName = patientDto.MedicalAidName;
            patient.MedicalAidScheme = patientDto.MedicalAidScheme;
            patient.MedicalAidNumber = patientDto.MedicalAidNumber;
            patient.PrincipalMemberInd = patientDto.PrincipalMemberInd;
            patient.PrefferedContactMethod = patientDto.PrefferedContactMethod;
            patient.SourceOfDiscovery = patientDto.SourceOfDiscovery;
            patient.MedicalAidInd = patientDto.MedicalAidInd;
            patient.IDType = patientDto.IDType;

            if (patientDto.PostalAddress != null)
            {
                patient.PostalAddress = patient.PostalAddress ?? new PatientAddress();
                patientAddressMapper.MapToPatientAddress(patient.PostalAddress, patientDto.PostalAddress);
            }

            if (patientDto.PhysicalAddress != null)
            {
                patient.PhysicalAddress = patient.PhysicalAddress ?? new PatientAddress();
                patientAddressMapper.MapToPatientAddress(patient.PhysicalAddress, patientDto.PhysicalAddress);
            }


        }

    }
}
