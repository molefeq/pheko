using Pheko.Common.DataTransformObjects;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientMedicalMonitoringViewModelMapper
    {
        public PatientMedicalMonitoringViewModelMapper() { }

        public PatientMedicalMonitoringDto MapToPatientMedicalMonitoringDto(PatientMedicalMonitoringViewModel patientMedicalMonitoringViewModel)
        {
            if (patientMedicalMonitoringViewModel == null)
            {
                return null;
            }

            PatientMedicalMonitoringDto patientMedicalMonitoringDto = new PatientMedicalMonitoringDto();

            patientMedicalMonitoringDto.PatientMedicalMonitoringId = patientMedicalMonitoringViewModel.PatientMedicalMonitoringId;
            patientMedicalMonitoringDto.PatientConsultationId = patientMedicalMonitoringViewModel.PatientConsultationId;
            patientMedicalMonitoringDto.MedicalMonitoring = new MedicalMonitoringDto()
            {
                MedicalMonitoringId = patientMedicalMonitoringViewModel.MedicalMonitoring_Id,
                Name = patientMedicalMonitoringViewModel.MedicalMonitoring_Name
            };
            patientMedicalMonitoringDto.Value = patientMedicalMonitoringViewModel.MedicalMonitoringValue;

            return patientMedicalMonitoringDto;
        }

        public PatientMedicalMonitoringViewModel MapToPatientMedicalMonitoringViewModel(PatientMedicalMonitoringDto patientMedicalMonitoringDto)
        {
            if (patientMedicalMonitoringDto == null)
            {
                return null;
            }

            PatientMedicalMonitoringViewModel patientMedicalMonitoringViewModel = new PatientMedicalMonitoringViewModel();

            patientMedicalMonitoringViewModel.PatientMedicalMonitoringId = patientMedicalMonitoringDto.PatientMedicalMonitoringId;
            patientMedicalMonitoringViewModel.PatientConsultationId = patientMedicalMonitoringDto.PatientConsultationId;
            patientMedicalMonitoringViewModel.MedicalMonitoring_Id = patientMedicalMonitoringDto.MedicalMonitoring.MedicalMonitoringId.Value;
            patientMedicalMonitoringViewModel.MedicalMonitoring_Name = patientMedicalMonitoringDto.MedicalMonitoring.Name;
            patientMedicalMonitoringViewModel.MedicalMonitoringValue = patientMedicalMonitoringDto.Value;

            return patientMedicalMonitoringViewModel;
        }
    }
}
