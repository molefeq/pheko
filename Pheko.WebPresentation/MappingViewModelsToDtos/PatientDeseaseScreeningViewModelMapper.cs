using Pheko.Common.DataTransformObjects;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientDeseaseScreeningViewModelMapper
    {
        public PatientDeseaseScreeningViewModelMapper() { }

        public PatientDeseaseScreeningDto MapToPatientDeseaseScreeningDto(PatientDeseaseScreeningViewModel patientDeseaseScreeningViewModel)
        {
            if (patientDeseaseScreeningViewModel == null)
            {
                return null;
            }

            PatientDeseaseScreeningDto patientDeseaseScreeningDto = new PatientDeseaseScreeningDto();

            patientDeseaseScreeningDto.PatientDeseaseScreeningId = patientDeseaseScreeningViewModel.PatientDeseaseScreeningId;
            patientDeseaseScreeningDto.PatientId = patientDeseaseScreeningViewModel.PatientId;
            patientDeseaseScreeningDto.DeseaseScreening = new DeseaseScreeningDto()
            {
                DeseaseScreeningId = patientDeseaseScreeningViewModel.DeseaseScreening_Id,
                Name = patientDeseaseScreeningViewModel.DeseaseScreening_Name
            };
            patientDeseaseScreeningDto.Value = patientDeseaseScreeningViewModel.DeseaseScreeningValue;
            patientDeseaseScreeningDto.YearOfScreening = patientDeseaseScreeningViewModel.YearOfScreening;
            patientDeseaseScreeningDto.SelectedInd = patientDeseaseScreeningViewModel.SelectedInd;

            return patientDeseaseScreeningDto;
        }

        public PatientDeseaseScreeningViewModel MapToPatientDeseaseScreeningViewModel(PatientDeseaseScreeningDto patientDeseaseScreeningDto)
        {
            if (patientDeseaseScreeningDto == null)
            {
                return null;
            }

            PatientDeseaseScreeningViewModel patientDeseaseScreeningViewModel = new PatientDeseaseScreeningViewModel();

            patientDeseaseScreeningViewModel.PatientDeseaseScreeningId = patientDeseaseScreeningDto.PatientDeseaseScreeningId;
            patientDeseaseScreeningViewModel.PatientId = patientDeseaseScreeningDto.PatientId;
            patientDeseaseScreeningViewModel.DeseaseScreening_Id = patientDeseaseScreeningDto.DeseaseScreening.DeseaseScreeningId.Value;
            patientDeseaseScreeningViewModel.DeseaseScreening_Name = patientDeseaseScreeningDto.DeseaseScreening.Name;
            patientDeseaseScreeningViewModel.DeseaseScreeningValue = patientDeseaseScreeningDto.Value;
            patientDeseaseScreeningViewModel.YearOfScreening = patientDeseaseScreeningDto.YearOfScreening;
            patientDeseaseScreeningViewModel.SelectedInd = patientDeseaseScreeningDto.SelectedInd;

            return patientDeseaseScreeningViewModel;
        }
    }
}
