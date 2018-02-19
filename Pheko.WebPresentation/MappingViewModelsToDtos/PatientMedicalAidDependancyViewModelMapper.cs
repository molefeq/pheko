using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;
using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientMedicalAidDependancyViewModelMapper
    {
        public PatientMedicalAidDependancyViewModelMapper() { }

        public PatientMedicalAidDependancyDto MapToPatientMedicalAidDependancyDto(PatientMedicalAidDependancyViewModel patientMedicalAidDependancyViewModel)
        {
            if (patientMedicalAidDependancyViewModel == null)
            {
                return null;
            }

            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto();

            CrudOperationsMapper crudOperationsMapper = new CrudOperationsMapper();

            patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId = patientMedicalAidDependancyViewModel.PatientMedicalAidDependanciesId;
            patientMedicalAidDependancyDto.PatientId = patientMedicalAidDependancyViewModel.PatientId;
            patientMedicalAidDependancyDto.Title = patientMedicalAidDependancyViewModel.Title;
            patientMedicalAidDependancyDto.FirstFullName = patientMedicalAidDependancyViewModel.FirstFullName;
            patientMedicalAidDependancyDto.LastName = patientMedicalAidDependancyViewModel.LastName;
            patientMedicalAidDependancyDto.MedicalAidCode = patientMedicalAidDependancyViewModel.MedicalAidCode;
            patientMedicalAidDependancyDto.BirthDate = Converter.StringToDate(patientMedicalAidDependancyViewModel.BirthDate);
            patientMedicalAidDependancyDto.Relationship = patientMedicalAidDependancyViewModel.Relationship;
            patientMedicalAidDependancyDto.PrincipalInd = patientMedicalAidDependancyViewModel.PrincipalInd;
            patientMedicalAidDependancyDto.CrudOperation = crudOperationsMapper.MapToCrudOperations(patientMedicalAidDependancyViewModel.CrudOperation);

            return patientMedicalAidDependancyDto;
        }

        public PatientMedicalAidDependancyViewModel MapToPatientMedicalAidDependancyViewModel(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            if (patientMedicalAidDependancyDto == null)
            {
                return null;
            }

            PatientMedicalAidDependancyViewModel patientMedicalAidDependancyViewModel = new PatientMedicalAidDependancyViewModel();

            CrudOperationsMapper crudOperationsMapper = new CrudOperationsMapper();

            patientMedicalAidDependancyViewModel.PatientMedicalAidDependanciesId = patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId;
            patientMedicalAidDependancyViewModel.PatientId = patientMedicalAidDependancyDto.PatientId;
            patientMedicalAidDependancyViewModel.Title = patientMedicalAidDependancyDto.Title;
            patientMedicalAidDependancyViewModel.FirstFullName = patientMedicalAidDependancyDto.FirstFullName;
            patientMedicalAidDependancyViewModel.LastName = patientMedicalAidDependancyDto.LastName;
            patientMedicalAidDependancyViewModel.MedicalAidCode = patientMedicalAidDependancyDto.MedicalAidCode;
            patientMedicalAidDependancyViewModel.BirthDate = Converter.DateToString(patientMedicalAidDependancyDto.BirthDate);
            patientMedicalAidDependancyViewModel.Relationship = patientMedicalAidDependancyDto.Relationship;
            patientMedicalAidDependancyViewModel.PrincipalInd = patientMedicalAidDependancyDto.PrincipalInd;
            patientMedicalAidDependancyViewModel.CrudOperation = crudOperationsMapper.MapToModelCrudOperations(patientMedicalAidDependancyDto.CrudOperation);

            return patientMedicalAidDependancyViewModel;
        }
    }
}
