using Pheko.Common.DataTransformObjects;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientChronicDeseaseViewModelMapper
    {
        public PatientChronicDeseaseViewModelMapper() { }

        public PatientChronicDeseaseDto MapToPatientChronicDeseaseDto(PatientChronicDeseaseViewModel patientChronicDeseaseViewModel)
        {
            if (patientChronicDeseaseViewModel == null)
            {
                return null;
            }

            PatientChronicDeseaseDto patientChronicDeseaseDto = new PatientChronicDeseaseDto();

            patientChronicDeseaseDto.PatientChronicDeseaseId = patientChronicDeseaseViewModel.PatientChronicDeseaseId;
            patientChronicDeseaseDto.PatientId = patientChronicDeseaseViewModel.PatientId;
            patientChronicDeseaseDto.ChronicDesease = new ChronicDeseaseDto()
            {
                ChronicDeseaseId = patientChronicDeseaseViewModel.ChronicDesease_Id,
                Name = patientChronicDeseaseViewModel.ChronicDesease_Name
            };
            patientChronicDeseaseDto.Value = patientChronicDeseaseViewModel.ChronicDeseaseValue;
            patientChronicDeseaseDto.YearOfDiagnoses = patientChronicDeseaseViewModel.YearOfDiagnoses;
            patientChronicDeseaseDto.SelectedInd = patientChronicDeseaseViewModel.SelectedInd;

            return patientChronicDeseaseDto;
        }

        public PatientChronicDeseaseViewModel MapToPatientChronicDeseaseViewModel(PatientChronicDeseaseDto patientChronicDeseaseDto)
        {
            if (patientChronicDeseaseDto == null)
            {
                return null;
            }

            PatientChronicDeseaseViewModel patientChronicDeseaseViewModel = new PatientChronicDeseaseViewModel();

            patientChronicDeseaseViewModel.PatientChronicDeseaseId = patientChronicDeseaseDto.PatientChronicDeseaseId;
            patientChronicDeseaseViewModel.PatientId = patientChronicDeseaseDto.PatientId;
            patientChronicDeseaseViewModel.ChronicDesease_Id = patientChronicDeseaseDto.ChronicDesease.ChronicDeseaseId.Value;
            patientChronicDeseaseViewModel.ChronicDesease_Name = patientChronicDeseaseDto.ChronicDesease.Name;
            patientChronicDeseaseViewModel.ChronicDeseaseValue = patientChronicDeseaseDto.Value;
            patientChronicDeseaseViewModel.YearOfDiagnoses = patientChronicDeseaseDto.YearOfDiagnoses;
            patientChronicDeseaseViewModel.SelectedInd = patientChronicDeseaseDto.SelectedInd;

            return patientChronicDeseaseViewModel;
        }
    }
}
