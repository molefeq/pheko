using Pheko.Common.DataTransformObjects;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientVitalSignViewModelMapper
    {
        public PatientVitalSignViewModelMapper() { }

        public PatientVitalSignDto MapToPatientVitalSignDto(PatientVitalSignViewModel patientVitalSignViewModel)
        {
            if (patientVitalSignViewModel == null)
            {
                return null;
            }

            PatientVitalSignDto patientVitalSignDto = new PatientVitalSignDto();

            patientVitalSignDto.PatientVitalSignId = patientVitalSignViewModel.PatientVitalSignId;
            patientVitalSignDto.PatientConsultationId = patientVitalSignViewModel.PatientConsultationId;
            patientVitalSignDto.VitalSign = new VitalSignDto()
            {
                VitalSignId = patientVitalSignViewModel.VitalSign_Id,
                Name = patientVitalSignViewModel.VitalSign_Name
            };
            patientVitalSignDto.VitalSignValue = patientVitalSignViewModel.VitalSignValue;

            return patientVitalSignDto;
        }

        public PatientVitalSignViewModel MapToPatientVitalSignViewModel(PatientVitalSignDto patientVitalSignDto)
        {
            if (patientVitalSignDto == null)
            {
                return null;
            }

            PatientVitalSignViewModel patientVitalSignViewModel = new PatientVitalSignViewModel();

            patientVitalSignViewModel.PatientVitalSignId = patientVitalSignDto.PatientVitalSignId;
            patientVitalSignViewModel.PatientConsultationId = patientVitalSignDto.PatientConsultationId;
            patientVitalSignViewModel.VitalSign_Id = patientVitalSignDto.VitalSign.VitalSignId.Value;
            patientVitalSignViewModel.VitalSign_Name = patientVitalSignDto.VitalSign.Name;
            patientVitalSignViewModel.VitalSignValue = patientVitalSignDto.VitalSignValue;

            return patientVitalSignViewModel;
        }
    }
}
