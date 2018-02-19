using Pheko.Common.DataTransformObjects;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientMedicalNoteViewModelMapper
    {
        public PatientMedicalNoteViewModelMapper() { }

        public PatientMedicalNoteDto MapToPatientMedicalNoteDto(PatientMedicalNoteViewModel patientMedicalNoteViewModel)
        {
            if (patientMedicalNoteViewModel == null)
            {
                return null;
            }

            PatientMedicalNoteDto patientMedicalNoteDto = new PatientMedicalNoteDto();

            patientMedicalNoteDto.PatientMedicalNoteId = patientMedicalNoteViewModel.PatientMedicalNoteId;
            patientMedicalNoteDto.PatientConsultationId = patientMedicalNoteViewModel.PatientConsultationId;
            patientMedicalNoteDto.MedicalNote = new MedicalNoteDto()
            {
                MedicalNoteId = patientMedicalNoteViewModel.MedicalNote_Id,
                Name = patientMedicalNoteViewModel.MedicalNote_Name
            };
            patientMedicalNoteDto.Value = patientMedicalNoteViewModel.MedicalNoteValue;

            return patientMedicalNoteDto;
        }

        public PatientMedicalNoteViewModel MapToPatientMedicalNoteViewModel(PatientMedicalNoteDto patientMedicalNoteDto)
        {
            if (patientMedicalNoteDto == null)
            {
                return null;
            }

            PatientMedicalNoteViewModel patientMedicalNoteViewModel = new PatientMedicalNoteViewModel();

            patientMedicalNoteViewModel.PatientMedicalNoteId = patientMedicalNoteDto.PatientMedicalNoteId;
            patientMedicalNoteViewModel.PatientConsultationId = patientMedicalNoteDto.PatientConsultationId;
            patientMedicalNoteViewModel.MedicalNote_Id = patientMedicalNoteDto.MedicalNote.MedicalNoteId.Value;
            patientMedicalNoteViewModel.MedicalNote_Name = patientMedicalNoteDto.MedicalNote.Name;
            patientMedicalNoteViewModel.MedicalNoteValue = patientMedicalNoteDto.Value;

            return patientMedicalNoteViewModel;
        }
    }
}
