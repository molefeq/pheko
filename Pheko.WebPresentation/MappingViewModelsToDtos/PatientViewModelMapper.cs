using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;
using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientViewModelMapper
    {
        public PatientViewModelMapper() { }

        public PatientDto MapSearchPatientViewModelToPatientDto(SearchPatientViewModel searchPatientViewModel)
        {
            if (searchPatientViewModel == null)
            {
                return null;
            }

            PatientDto patientDto = new PatientDto();

            patientDto.PatientId = searchPatientViewModel.PatientId;
            patientDto.FirstName = searchPatientViewModel.FirstName;
            patientDto.LastName = searchPatientViewModel.LastName;
            patientDto.BirthDate = Converter.StringToDate(searchPatientViewModel.BirthDate);
            patientDto.IDNumber = searchPatientViewModel.IdNumber;

            return patientDto;
        }

        public PatientDto MapCreatePatientViewModelToPatientDto(CreatePatientViewModel createPatientViewModel)
        {
            if (createPatientViewModel == null)
            {
                return null;
            }

            PatientDto patientDto = new PatientDto();

            patientDto.FirstName = createPatientViewModel.FirstName;
            patientDto.LastName = createPatientViewModel.LastName;

            return patientDto;
        }

        public PatientDto MapToPatientDto(PatientViewModel patientViewModel)
        {
            if (patientViewModel == null)
            {
                return null;
            }

            PatientDto patientDto = new PatientDto();

            PatientAddressViewModelMapper patientAddressViewModelMapper = new PatientAddressViewModelMapper();
            CrudOperationsMapper crudOperationsMapper = new CrudOperationsMapper();

            patientDto.PatientId = patientViewModel.PatientId;
            patientDto.Title = patientViewModel.Title;
            patientDto.FirstName = patientViewModel.FirstName;
            patientDto.MiddleName = patientViewModel.MiddleName;
            patientDto.LastName = patientViewModel.LastName;
            patientDto.Gender = patientViewModel.Gender;
            patientDto.EthnicGroup = patientViewModel.EthnicGroup;
            patientDto.BirthDate = Converter.StringToDate(patientViewModel.BirthDate);
            patientDto.IDNumber = patientViewModel.IDNumber;
            patientDto.MobileNumber = patientViewModel.MobileNumber;
            patientDto.HomeTelephoneCode = patientViewModel.HomeTelephoneCode;
            patientDto.HomeTelephoneNumber = patientViewModel.HomeTelephoneNumber;
            patientDto.WorkTelephoneCode = patientViewModel.WorkTelephoneCode;
            patientDto.WorkTelephoneNumber = patientViewModel.WorkTelephoneNumber;
            patientDto.EmailAddress = patientViewModel.EmailAddress;
            patientDto.MaritalStatus = patientViewModel.MaritalStatus;
            patientDto.MarriageType = patientViewModel.MarriageType;
            patientDto.PrefferedContactType = patientViewModel.PrefferedContactType;
            patientDto.MedicalAidName = patientViewModel.MedicalAidName;
            patientDto.MedicalAidScheme = patientViewModel.MedicalAidScheme;
            patientDto.MedicalAidNumber = patientViewModel.MedicalAidNumber;
            patientDto.PrincipalMemberInd = patientViewModel.PrincipalMemberInd;
            patientDto.PrefferedContactMethod = patientViewModel.PrefferedContactMethod;
            patientDto.SourceOfDiscovery = patientViewModel.SourceOfDiscovery;
            patientDto.MedicalAidInd = patientViewModel.MedicalAidInd;
            patientDto.IDType = patientViewModel.IDType;
            patientDto.CrudOperation = crudOperationsMapper.MapToCrudOperations(patientViewModel.CrudOperation);

            if (patientViewModel.PhysicalAddress != null)
            {
                patientDto.PhysicalAddress = patientAddressViewModelMapper.MapToPatientAddressDto(patientViewModel.PhysicalAddress);
            }

            if (patientViewModel.PostalAddress != null)
            {
                patientDto.PostalAddress = patientAddressViewModelMapper.MapToPatientAddressDto(patientViewModel.PostalAddress);
            }

            return patientDto;
        }

        public PatientViewModel MapToPatientViewModel(PatientDto patientDto)
        {
            if (patientDto == null)
            {
                return null;
            }

            PatientViewModel patientViewModel = new PatientViewModel();

            PatientAddressViewModelMapper patientAddressViewModelMapper = new PatientAddressViewModelMapper();
            CrudOperationsMapper crudOperationsMapper = new CrudOperationsMapper();

            patientViewModel.PatientId = patientDto.PatientId;
            patientViewModel.Title = patientDto.Title;
            patientViewModel.FirstName = patientDto.FirstName;
            patientViewModel.MiddleName = patientDto.MiddleName;
            patientViewModel.LastName = patientDto.LastName;
            patientViewModel.Gender = patientDto.Gender;
            patientViewModel.EthnicGroup = patientDto.EthnicGroup;
            patientViewModel.BirthDate = Converter.DateToString(patientDto.BirthDate);
            patientViewModel.IDNumber = patientDto.IDNumber;
            patientViewModel.MobileNumber = patientDto.MobileNumber;
            patientViewModel.HomeTelephoneCode = patientDto.HomeTelephoneCode;
            patientViewModel.HomeTelephoneNumber = patientDto.HomeTelephoneNumber;
            patientViewModel.WorkTelephoneCode = patientDto.WorkTelephoneCode;
            patientViewModel.WorkTelephoneNumber = patientDto.WorkTelephoneNumber;
            patientViewModel.EmailAddress = patientDto.EmailAddress;
            patientViewModel.MaritalStatus = patientDto.MaritalStatus;
            patientViewModel.MarriageType = patientDto.MarriageType;
            patientViewModel.PrefferedContactType = patientDto.PrefferedContactType;
            patientViewModel.MedicalAidName = patientDto.MedicalAidName;
            patientViewModel.MedicalAidScheme = patientDto.MedicalAidScheme;
            patientViewModel.MedicalAidNumber = patientDto.MedicalAidNumber;
            patientViewModel.PrincipalMemberInd = patientDto.PrincipalMemberInd == null ? false : patientDto.PrincipalMemberInd.Value;
            patientViewModel.PrefferedContactMethod = patientDto.PrefferedContactMethod;
            patientViewModel.SourceOfDiscovery = patientDto.SourceOfDiscovery;
            patientViewModel.MedicalAidInd = patientDto.MedicalAidInd == null ? false : patientDto.MedicalAidInd.Value;
            patientViewModel.IDType = patientDto.IDType;
            patientViewModel.CrudOperation = crudOperationsMapper.MapToModelCrudOperations(patientDto.CrudOperation);

            if (patientDto.PhysicalAddress != null)
            {
                patientViewModel.PhysicalAddress = patientAddressViewModelMapper.MapToPatientAddressViewModel(patientDto.PhysicalAddress);
            }

            if (patientDto.PostalAddress != null)
            {
                patientViewModel.PostalAddress = patientAddressViewModelMapper.MapToPatientAddressViewModel(patientDto.PostalAddress);
            }

            return patientViewModel;
        }
    }
}
