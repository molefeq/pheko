using Pheko.Common.DataTransformObjects;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientClinicalExaminationViewModelMapper
    {
        public PatientClinicalExaminationViewModelMapper() { }

        public PatientClinicalExaminationDto MapToPatientClinicalExaminationDto(PatientClinicalExaminationViewModel patientClinicalExaminationViewModel)
        {
            if (patientClinicalExaminationViewModel == null)
            {
                return null;
            }

            PatientClinicalExaminationDto patientClinicalExaminationDto = new PatientClinicalExaminationDto();

            patientClinicalExaminationDto.PatientClinicalExaminationId = patientClinicalExaminationViewModel.PatientClinicalExaminationId;
            patientClinicalExaminationDto.PatientConsultationId = patientClinicalExaminationViewModel.PatientConsultationId;
            patientClinicalExaminationDto.ClinicalExamination = new ClinicalExaminationDto()
            {
                ClinicalExaminationId = patientClinicalExaminationViewModel.ClinicalExamination_Id,
                Name = patientClinicalExaminationViewModel.ClinicalExamination_Name
            };
            patientClinicalExaminationDto.Value = patientClinicalExaminationViewModel.ClinicalExaminationValue;

            return patientClinicalExaminationDto;
        }

        public PatientClinicalExaminationViewModel MapToPatientClinicalExaminationViewModel(PatientClinicalExaminationDto patientClinicalExaminationDto)
        {
            if (patientClinicalExaminationDto == null)
            {
                return null;
            }

            PatientClinicalExaminationViewModel patientClinicalExaminationViewModel = new PatientClinicalExaminationViewModel();

            patientClinicalExaminationViewModel.PatientClinicalExaminationId = patientClinicalExaminationDto.PatientClinicalExaminationId;
            patientClinicalExaminationViewModel.PatientConsultationId = patientClinicalExaminationDto.PatientConsultationId;
            patientClinicalExaminationViewModel.ClinicalExamination_Id = patientClinicalExaminationDto.ClinicalExamination.ClinicalExaminationId.Value;
            patientClinicalExaminationViewModel.ClinicalExamination_Name = patientClinicalExaminationDto.ClinicalExamination.Name;
            patientClinicalExaminationViewModel.ClinicalExaminationValue = patientClinicalExaminationDto.Value;

            return patientClinicalExaminationViewModel;
        }
    }
}
