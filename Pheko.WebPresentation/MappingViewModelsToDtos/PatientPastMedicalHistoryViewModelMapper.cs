using Pheko.Common.DataTransformObjects;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientPastMedicalHistoryViewModelMapper
    {
        public PatientPastMedicalHistoryViewModelMapper() { }

        public PatientPastMedicalHistoryDto MapToPatientPastMedicalHistoryDto(PatientPastMedicalHistoryViewModel patientPastMedicalHistoryViewModel)
        {
            if (patientPastMedicalHistoryViewModel == null)
            {
                return null;
            }

            PatientPastMedicalHistoryDto patientPastMedicalHistoryDto = new PatientPastMedicalHistoryDto();

            patientPastMedicalHistoryDto.PatientPastMedicalHistoryId = patientPastMedicalHistoryViewModel.PatientPastMedicalHistoryId;
            patientPastMedicalHistoryDto.PatientId = patientPastMedicalHistoryViewModel.PatientId;
            patientPastMedicalHistoryDto.PastMedicalHistory = new PastMedicalHistoryDto()
            {
                PastMedicalHistoryId = patientPastMedicalHistoryViewModel.PastMedicalHistory_Id,
                Name = patientPastMedicalHistoryViewModel.PastMedicalHistory_Name
            };
            patientPastMedicalHistoryDto.Value = patientPastMedicalHistoryViewModel.PastMedicalHistoryValue;

            return patientPastMedicalHistoryDto;
        }

        public PatientPastMedicalHistoryViewModel MapToPatientPastMedicalHistoryViewModel(PatientPastMedicalHistoryDto patientPastMedicalHistoryDto)
        {
            if (patientPastMedicalHistoryDto == null)
            {
                return null;
            }

            PatientPastMedicalHistoryViewModel patientPastMedicalHistoryViewModel = new PatientPastMedicalHistoryViewModel();

            patientPastMedicalHistoryViewModel.PatientPastMedicalHistoryId = patientPastMedicalHistoryDto.PatientPastMedicalHistoryId;
            patientPastMedicalHistoryViewModel.PatientId = patientPastMedicalHistoryDto.PatientId;
            patientPastMedicalHistoryViewModel.PastMedicalHistory_Id = patientPastMedicalHistoryDto.PastMedicalHistory.PastMedicalHistoryId.Value;
            patientPastMedicalHistoryViewModel.PastMedicalHistory_Name = patientPastMedicalHistoryDto.PastMedicalHistory.Name;
            patientPastMedicalHistoryViewModel.PastMedicalHistoryValue = patientPastMedicalHistoryDto.Value;

            return patientPastMedicalHistoryViewModel;
        }
    }
}
